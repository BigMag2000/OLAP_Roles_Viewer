using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;



namespace OLAP_roles
{
    sealed public class mycOLAPserver
    {
        public string Name { get; set; }        
        public Microsoft.AnalysisServices.Server Server {get; set;}

        public mycOLAPserver(string sOLAPserverName)
        {
            Name = sOLAPserverName;
            Server = new Microsoft.AnalysisServices.Server();
        }

    }

    sealed public class mycOLAPdb //  : IEnumerable<mycOLAPuser>
    {
        public Microsoft.AnalysisServices.Database DBolap { get; set; }
        public string Name { get { return DBolap.Name; } }
        public List<mycOLAProle> listRole;
        public List<mycOLAPuser> listUsers; // общий список юзеров

        public mycOLAPdb()
        {
            DBolap = new Microsoft.AnalysisServices.Database();
            listRole = new List<mycOLAProle>();
            listUsers = new List<mycOLAPuser>();
        }

        //public IEnumerator<mycOLAPuser> GetEnumerator()
        //{
        //    return ((IEnumerator<mycOLAPuser>)listUsers).GetEnumerator();
        //}

        // IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }

    sealed public class mycOLAProle : IComparable
    {
        public Microsoft.AnalysisServices.Role OlapRole { get; set; }
        public string Name {get {return OlapRole.Name;}}
        public string DBname { get; set; }
        public List<mycOLAPuser> listUser;

        public mycOLAProle()
        {
            OlapRole = new Microsoft.AnalysisServices.Role();
            listUser = new List<mycOLAPuser>();
        }

        int IComparable.CompareTo(object obj)
        {
            mycOLAProle tmp = (mycOLAProle)obj;
            if (tmp != null)
                return this.Name.CompareTo(tmp.Name);
            else
                throw new ArgumentException("Ошибка при сравнении ролей в классе mycOLAProle");
        }

        public void AddUser(Microsoft.AnalysisServices.RoleMember usr)
        {
            OlapRole.Members.Add(usr);

            // до Update можно сделать добавление-удаление списка пользователей
            // и потом применить общий Update
            OlapRole.Update();
        }

        public void DeleteUser(mycOLAPuser ouser)
        {
            Microsoft.AnalysisServices.RoleMember usr = new Microsoft.AnalysisServices.RoleMember();
            usr.Name = ouser.Name;
            OlapRole.Members.Remove(usr);
            OlapRole.Update();
        }
    }

    sealed public class mycOLAPuser : IComparable<mycOLAPuser>
    { 
        private Microsoft.AnalysisServices.RoleMember _ASuser { get; set; }
        public string Name {get {return _ASuser.Name;}}
        public string ShortName { get { return _ASuser.Name.Substring(_ASuser.Name.IndexOf('\\')+1); } }
        public string SID { get { return _ASuser.Sid; } }

        public List<mycOLAProle> listRoles { get; set; }

        public mycOLAPuser()
        {
            _ASuser = new Microsoft.AnalysisServices.RoleMember();
            listRoles = new List<mycOLAProle>();
        }
        public mycOLAPuser(Microsoft.AnalysisServices.RoleMember mmbr)
        {
            _ASuser = mmbr;
            listRoles = new List<mycOLAProle>();
        }

        /// <summary>
        /// Мой класс юзера из ОЛАПа основан на мембере ОЛАПа
        /// Путем этого присвоения получаю экземпляр моего класса
        /// </summary>
        /// <param name="mmbr"></param>
        public void SetASuser(Microsoft.AnalysisServices.RoleMember mmbr)
        {
            _ASuser = mmbr;
        }

        int IComparable<mycOLAPuser>.CompareTo(mycOLAPuser usr)
        {
            return this.Name.CompareTo(usr.Name);            
        }
        
    }

    /// <summary>
    /// Класс для работы с ролями в ОЛАП-кубах
    /// осуществляет подключение к серверу и определине ролей
    /// и пользователей
    /// </summary>
    sealed public class mycOLAPCubeWorker
    {
        // Требуется :
        // Загрузить один раз список всех баз на сервере
        // При выборе базы загрузить список всех ролей И
        // список всех пользователей к этим ролям

        public mycOLAPserver ServerOLAP { get; set; }
        public int CountDB {get {return _icountDB;}}
        private int _icountDB;
        public bool StatusConnected;

        public List<mycOLAPdb> listDB; // общий список баз-кубов

        private mycOLAPdb _dbSelected;

        public mycOLAPdb SelectedDB { get{return _dbSelected; } set{_dbSelected = value;} }

        // Конструктор
        public mycOLAPCubeWorker(string sOLAPserverName)
        {
            StatusConnected = false;
            ServerOLAP = new mycOLAPserver(sOLAPserverName);
            listDB = new List<mycOLAPdb>();
        }

        /// <summary>
        /// Подключение к серверу
        /// </summary>
        public void Connect()
        {
            if (string.IsNullOrEmpty(ServerOLAP.Name))
            { throw new ArgumentException("Вы должны указать корректное имя сервера ОЛАП !!!"); }

            if (StatusConnected==false)
            {
                try
                {
                    ServerOLAP.Server.Connect(ServerOLAP.Name);
                }
                catch (Exception e )
                {
                    throw new ArgumentException( string.Format("Ошибка при подключении к серверу {0}\n {1}", ServerOLAP.Name, e.Message));
                }
                
                StatusConnected = true;
                _icountDB = ServerOLAP.Server.Databases.Count;
            }
        }
        public void Disconnect()
        {
            if (StatusConnected)
	        {
		        ServerOLAP.Server.Disconnect();
                StatusConnected = false;
	        }
        }
        /// <summary>
        /// Получить список баз на сервере ОЛАП
        /// </summary>
        public void LoadListDatabase()
        {
            foreach (Microsoft.AnalysisServices.Database asDB in ServerOLAP.Server.Databases)
            {
                mycOLAPdb db = new mycOLAPdb();
                db.DBolap = asDB;
                listDB.Add(db);
            }
        }

        /// <summary>
        /// Поиск и установка текущей базы по ее имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public mycOLAPdb dbSelect(string name)
        {
            _dbSelected = null;
            foreach (mycOLAPdb db in listDB)
            {
                if (db.Name == name)
                {
                    _dbSelected = db;
                    break;
                }
            }
            return _dbSelected;
        }

        /// <summary>
        /// Получить для базы список всех ролей
        /// </summary>
        /// <param name="dbName"></param>
        public void LoadListRoleUserFromDB(string dbName, bool bForceLoad)
        {
            
            // Загрузка ролей и пользователей происходит 1 раз через обращение к базе
            // второй раз используется уже загруженный список
            // bForceLoad - если требуется еще раз перезагрузить списки из базы

            //Проверка наличия, что  база загружена
            _dbSelected = dbSelect(dbName);
            // получить все роли для базы и для каждой роли загрузить всех юзеров
            if (_dbSelected != null && (_dbSelected.listRole.Count==0 || bForceLoad))
            {
                _dbSelected.listRole = new List<mycOLAProle>();
                
                foreach (Microsoft.AnalysisServices.Role dbRole in _dbSelected.DBolap.Roles)
                {
                    mycOLAProle roleSelected = new mycOLAProle();
                    roleSelected.OlapRole = dbRole;
                    roleSelected.DBname = _dbSelected.Name;
                    _dbSelected.listRole.Add(roleSelected);
                    // Загрузить юзеров для этой роли
                    LoadListUserFromRole( _dbSelected, roleSelected, bForceLoad);
                }
            }
        }
        /// <summary>
        /// Для заданной роли получить всех пользователей
        /// Должно выполняться вместе в загрузкой всех ролей для БД
        /// </summary>
        /// <param name="dbRole"></param>
        private void LoadListUserFromRole(mycOLAPdb db,  mycOLAProle dbRole, bool bForceLoad)
        {
           // получить всех юзеров для роли в кубе ОЛАП
            if (dbRole != null && (dbRole.listUser.Count==0 || bForceLoad))
            {
                List<mycOLAPuser> _lstUser = new List<mycOLAPuser>();
                List<mycOLAProle> _lstRole = new List<mycOLAProle>();

                foreach (Microsoft.AnalysisServices.RoleMember mmbr in dbRole.OlapRole.Members)
                { // проходим по списку юзеров в каждой роли
                    

                    // проверка полного списка пользователй
                    // пользователь может быть в разных ролях - ищем повторы
                    // если первый раз - добавить mmbr
                    // если нет то добавить в вписок роли а для db не надо, т.к. есть
                    
                    mycOLAPuser usr = new mycOLAPuser(mmbr);
                    //добавить текущего пользователя в список для этой роли
                    if (dbRole.listUser.Find(u => (u.Name.ToUpper() == mmbr.Name.ToUpper())) == null)
                        dbRole.listUser.Add(usr);

                    ////Собрать полные списки ролей и пользователей
                    //_lstUser.Add(usr);
                    //_lstRole.Add(dbRole);

                    // составить список пользователей для всего куба - каждый юзер входит 1 раз
                    // Найти пользователя этого пользователя в списке по кубу
                    mycOLAPuser usrSearch = db.listUsers.Find(u => (u.Name.ToUpper() == mmbr.Name.ToUpper()));
                    if (usrSearch == null)
                        db.listUsers.Add(usr);
                    else
                        usr = usrSearch;

                    // составить список ролей для пользователя - 1 роли входит 1 раз
                    //if (!usr.listRoles.Contains<mycOLAProle>(dbRole))
                    if (usr.listRoles.Find(x => (x.Name.ToUpper() == dbRole.Name.ToUpper())) == null)
                    {
                        usr.listRoles.Add(dbRole);
                    }
                    
                }
                //db.listUsers = _lstUser.Distinct<mycOLAPuser>().Select(a => a.Name).ToList<mycOLAPuser>();
                // UserList = UserList.Distinct().Select(a => a.Name).ToList();
            }
        }

    }
}
