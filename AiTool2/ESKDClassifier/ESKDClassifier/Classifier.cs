using System;
using System.Collections.Generic;

using System.Collections.ObjectModel;

namespace ESKDClassifier
{
    public class Classifier
    {
        public Classifier()
        {
            this.SubClasses = new ObservableCollection<Classifier>();
        }

        public ObservableCollection<Classifier> SubClasses { get; set; }

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

        public string Image
        {
            get;
            set;
        }

        public Classifier Parent
        {
            get;
            set;
        }

    }
}
