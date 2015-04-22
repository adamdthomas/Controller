using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HalloweenController_v0._0._1.Models{
    
    public enum ResponseList
    {
     [Description("This option will disable all buttons for the amount of time specified in the timeout")]
     lockall,
     [Description("This option will disable the clicked button for the amount of time specified in the timeout")]
     lockbutton,
     [Description("This option will not disable any buttons")]
     locknone,
     [Description("This option will not disable any buttons and will display the web service response")]
     actual,


    }

    public class Button
    {
        [Key]
        public int ButtonID { get; set; }
        public string Label { get; set; }
        public string Style { get; set; }
        public string URI { get; set; }
        public string Response { get; set; }
        public int TimeOut { get; set; }
        public string Users { get; set; }

    }
}