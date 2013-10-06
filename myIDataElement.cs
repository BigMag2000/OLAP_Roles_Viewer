using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myLib_IDataElement
{
    /// <summary>
    /// Управление элементарными единицами Базы Данных
    /// т.е. одним объектом (пользователь, право доступа и т.п.)
    /// </summary>   
    interface myIDataElement
    {       
        /// <summary>
        /// Реализует загрузку записи из базы данных
        /// </summary>
        void dataLoad();

        /// <summary>
        /// Реализует удаление элемента(строки) из базы данных
        /// </summary>
        void dataDelete();

        /// <summary>
        /// Реализует добавление/обновление полей элемента(строки) в базе данных
        /// </summary>
        void dataSave();

    }

    /// <summary>
    ///  Управление списком загружаемых из базы данных
    ///  (список пользователей. список документов)
    /// </summary>
    interface myIDataList
    {       
        /// <summary>
        ///  Реализует загрузку данных из БД в список
        /// </summary>
        void dataListLoad();

        /// <summary>
        /// Реализует поиск элемента данных в списке 
        /// </summary>
        void Find();
    }
}
