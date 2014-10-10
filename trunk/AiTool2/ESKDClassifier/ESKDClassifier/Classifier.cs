﻿using System;
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

        //public bool view = false;

        public string PathPicture
        {
            get;
            set;
        }
        [NonSerialized]
        private string fullPathPictures;
        public string FullPathPictures
        {
            get { return fullPathPictures; }
            set { fullPathPictures = value; }
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
