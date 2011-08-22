using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AiToolGui
{
    public class ProjectChangedEvent : EventArgs
    {
        public int ProjectID { get; set; }
        public string ProjectName {get; set; }
        public string ProjectNum { get; set; }
    }
}
