using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace AiToolGui
{
    class NodeTechParam
    {
        public NodeTechParam()
        {
            
        }
        public string VarName{ get; set; }
        public string VarMax { get; set; }
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value;}
        }
    }
}
