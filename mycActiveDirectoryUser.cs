using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace OLAP_roles
{
    sealed public class mycActiveDirectoryUser
    {
        /// <summary>
        /// ФИО пользователя
        /// </summary>
        public string UserNameFull { get { return _nameFull; } }

        public string UserEMail { get { return _nameEmail; } }

        /// <summary>
        /// ФИО (EMail) - одной строкой
        /// </summary>
        public string UserDisplayName { get { return _nameFull + " (" + _nameEmail + ")"; } }

        /// <summary>
        /// логин пользователя без домена
        /// </summary>
        public string UserLoginName
        { // вернуть значение до знака @ в адресе доменной почты
            get
            {
                if (_nameEmail.IndexOf("@") > 0)
                    return _nameEmail.Substring(0, _nameEmail.IndexOf("@"));
                else
                    return _nameEmail;
            }
        }

        /// <summary>
        ///  домен пользователя
        /// </summary>
        public string UserDomainName
        { // вернуть значение до знака @ в адресе доменной почты
            get
            {
                int i1, i2;
                if (_nameEmail.IndexOf("@") > 0)
                {
                    i1 = _nameEmail.IndexOf("@");
                    i2 = _nameEmail.IndexOf(".");
                    return _nameEmail.Substring(i1 + 1, i2-i1-1);
                }
                else
                    return _nameEmail;
            }
        }


        /// <summary>
        /// Полный логин пользователя с доменом
        /// вида DOMAIN\USER
        /// </summary>
        public string UserDomainLogin
        { // получить логин с доменом в виде HOUSE\GLAZOV
            // логины бывают вида a.b.myname@domen.ru
            //ниже есть цикл для поиска точки, после символа @
            get
            {
                string login, domen;
                int i1, i2;
                if (_nameEmail.IndexOf("@") > 0)
                {
                    i1 = _nameEmail.IndexOf("@");
                    // ищем точку после @
                    i2 = 0;
                    while (i2 <= i1)
                    {
                        i2 = _nameEmail.IndexOf(".", i2+1);
                        if (i2 == 0) break;
                    }
                    // login
                    login = _nameEmail.Substring(0, i1);

                    if (i2 > 0)
                        //domen
                        domen = _nameEmail.Substring((i1 + 1), i2 - i1 - 1);
                    else
                        domen = "";
                    
                }
                else
                {
                    login = _nameEmail;
                    domen = string.Empty;
                }
                return string.Concat(domen, "\\", login);
            }
        }

       
        private string _nameFull;
        private string _nameEmail;

        public mycActiveDirectoryUser()
            : this(string.Empty, string.Empty) { }
        public mycActiveDirectoryUser(string email, string name)
        {
            _nameEmail = email;
            _nameFull = name;
        }
    }

    //*******************************************************************************************/

    /// <summary>
    ///  Обработчик для получения списка доменных пользователей
    /// </summary>
    sealed public class mycActiveDirectoryWorker
    {
        /// <summary>
        /// Задает часть имени пользователя для поиска в АД
        /// </summary>
        private string _NameToSeacrh;

        /// <summary>
        /// Список найденных пользователей в АД по указанному шаблону
        /// </summary>
        public List<mycActiveDirectoryUser> UserList;

        public mycActiveDirectoryWorker()            
        {
            _NameToSeacrh = string.Empty;
            UserList = new List<mycActiveDirectoryUser>();
        }
        public mycActiveDirectoryWorker(string name)
        {
            _NameToSeacrh = name;
            UserList = new List<mycActiveDirectoryUser>();
        }

        /// <summary>
        /// Производит поиск в АД списка пользователей, подходящих под указанный шаблон
        /// </summary>
        /// <param name="name"></param>
        public void FindDomainUsers(string name)
        {

            if (!string.IsNullOrEmpty(name)) _NameToSeacrh = name;

            DirectorySearcher searcher = new DirectorySearcher();
            SearchResultCollection results;

            searcher.PropertiesToLoad.Add("cn");  // что это такое???
            //searcher.Filter = "objectClass=Person"; // пользователи и компьютеры
            searcher.Filter = "(&(objectClass=user)(objectCategory=person)(givenName=" + _NameToSeacrh + "*))"; // только пользователи
            //SearchResult result = searcher.FindOne();
//            results = searcher.FindAll();

            /*
             * получения всех элементов из Актив Директори по шаблону uname - человеское имя, первые буквы
             */
            results = searcher.FindAll();            
            UserList.Clear();
            string email;
            string fname;

            foreach (SearchResult result in results)
            {
                
                if (result != null)
                {                   
                    //Получение свойства name
                    PropertyValueCollection prop = result.GetDirectoryEntry().Properties["name"];
                    fname = prop[0].ToString();
                    
                    //Получение свойства userPrincipalName - логин в виде почтового адреса
                    prop = result.GetDirectoryEntry().Properties["userPrincipalName"];
                    email = prop[0].ToString();

                    UserList.Add(new mycActiveDirectoryUser(email, fname));


                    /*
                     *                         
                    // Get the 'DirectoryEntry' that corresponds to 'mySearchResult'.
                    //DirectoryEntry myDirectoryEntry =
                    //result.GetDirectoryEntry();
                    //Console.WriteLine("\nРезультат поиска элемента в АД: {0}\n",
                    //        myDirectoryEntry.Name);

                    //string mySearchResultPath = result.Path;
                    //Console.WriteLine("Полный путь этого элемента : {0}\n", mySearchResultPath);
                    // Get the properties of the 'mySearchResult'.
                    * 
                    ResultPropertyCollection myResultPropColl;
                    myResultPropColl = result.Properties;
                    Console.WriteLine("Список свойств для {0} :", myDirectoryEntry.Name);

                    foreach (string myKey in myResultPropColl.PropertyNames)
                    {
                        string tab = " ";
                        Console.WriteLine(myKey + " = "); // название свойства
                        foreach (Object myCollection in myResultPropColl[myKey])
                        {
                            Console.WriteLine(tab + myCollection); // значение свойства
                        }
                    }
                                               
                    Console.WriteLine("\nПолучение свойства MemberOf");
                    PropertyValueCollection prop = result.GetDirectoryEntry().Properties["MemberOf"];                    
                    for (int i = 0; i < prop.Count; i++)
                    {

                        Console.WriteLine(prop[i].ToString());

                    }

                    Console.WriteLine("\nИмя для проверки:{0};\nСтрока:{1};\nИмя объекта:{2}", 
                        result.GetDirectoryEntry().Username, 
                        result.GetDirectoryEntry().ToString(),
                        result.GetDirectoryEntry().Name);
                    
                    Console.WriteLine("\nПолучить списк свойств одного элемента");
                    foreach (PropertyValueCollection prp in result.GetDirectoryEntry().Properties)
                    {
                        Console.WriteLine(prp.PropertyName);
                    }
                    */


                }
            }
            searcher.Dispose();
            results.Dispose();
        }
    }
}
