using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserAdminLib
{

    /// <summary>
    /// Управление элементарными единицами Базы Данных
    /// т.е. одним объектом (пользователь, право доступа и т.п.)
    /// </summary>
    public abstract class mycDataElement : IComparable<mycDataElement>
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }

       
        /// <summary>
        /// Реализует загрузку записи из базы данных
        /// </summary>
        public virtual void Load()
        {
            Console.WriteLine("Загрузить элемент данных");
        }

        /// <summary>
        /// Реализует удаление элемента(строки) из базы
        /// </summary>
        public virtual void Delete()
        {
            Console.WriteLine("Удалить элемент данных");
        }

        /// <summary>
        /// Реализует обновление полей элемента(строки) в базе(таблице)
        /// </summary>
        public virtual void Update()
        {
            Console.WriteLine("ОБновить элемент данных");
        }

        /// <summary>
        /// Реализует добавление нового элемента(строки) в базе(таблице)
        /// </summary>
        public virtual void Insert()
        {
            Console.WriteLine("Добавить элемент данных");
        }

        //----------------------------------
        // Конструктор
        public mycDataElement()
            :this(0, string.Empty, string.Empty){}

        public mycDataElement(long vID, string vName)
            : this(vID, vName, string.Empty) { }

        public mycDataElement(long vID, string vName, string vComment)
        {
            ID = vID;
            Name = vName;
            Comment = vComment;
        }
        // -----------------------------------
        // Перегрузки
        public override string ToString()
        {
            return string.Format("ID:{0}, Name:{1}", ID, Name);
        }
        public override bool Equals(object obj)
        {
            return obj.ToString()==this.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(mycDataElement de1, mycDataElement de2)
        {
            return de1.Equals(de2);
        }
        public static bool operator !=(mycDataElement de1, mycDataElement de2)
        {
            return !de1.Equals(de2);
        }
        // -----------------------------------
        // Реализации интерфейсов
        int IComparable<mycDataElement>.CompareTo(mycDataElement de)
        {
            if (de != null)
                return ID.CompareTo(de.ID);
            else
                throw new ArgumentNullException("Ошибка: Для сравнения передан null-объект!");
        }
    }

}
