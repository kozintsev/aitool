using System;
using System.Collections.Generic;

using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ESKDClassifier
    //Класс:
    //42 - устройства и системы контроля и регулирования парамметрами технолоогического процесса
    //75 - детали-тела вращения
    //74 - детали-не тела вращения
{
    [Serializable]
    public class ESKDClass
    {
        public ESKDClass() 
        {
            this.eskdViews = new ObservableCollection<ESKDClass>();
        }

        public ObservableCollection<ESKDClass> eskdViews { get; set; }

        public string CodESKD
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public bool View = false;

        public string PathPicture
        {
            get;
            set;
        }

    }
    // под класс
    //public class SubClass : Classifier
    //{
    //    public string Name
    //    {
    //        get;
    //        set;
    //    }
    //}
    //Группа


    // Подгруппа

    //Вид
    public class ESKDView
    {
        public string CodESKD
        {
            get;
            set;
        }
    }
}
