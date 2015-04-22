using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HalloweenController_v0._0._1.DAL
{
    public class MyMethods
    {
        public static bool ShowDisplay;

        public static void WriteToLog(string text)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Temp\ControllerLog.txt", true);
            file.WriteLine(DateTime.Now.ToString() + ": " + text);
            file.Close();
        }

        public static List<string> ResponseTypes()
        {
             List<string> RList = new List<string>();
            RList.Add("lockbutton");
            RList.Add("lockall");
            RList.Add("locknone");
            RList.Add("generic");
            RList.Add("actual");
            return RList;

        }

        public static string ResponseTypes(int ID)
        {
            List<string> RList = new List<string>();
            RList.Add("lockbutton");
            RList.Add("lockall");
            RList.Add("locknone");
            RList.Add("generic");
            RList.Add("actual");
            return RList[ID];

        }
    }
}