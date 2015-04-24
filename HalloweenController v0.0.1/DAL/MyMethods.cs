using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace HalloweenController_v0._0._1.DAL
{
    public class MyMethods
    {
        public static string StarsPath = "C:\\Logs\\stars.xlsx ";

        public static bool ShowDisplay;

        public static void AddStars(string AccountName, double Amount)
        {
            Excel StarsSheet = new Excel(StarsPath, 0);
            StarsSheet.AddToCell(3, 5, 3);


            //Application excel = new Application();
            //Workbook wb = excel.Workbooks.Open(StarsPath);
            //Worksheet ws = wb.ActiveSheet;
            //var currentCell = ws.Cells[3, 5].value;
            //if (currentCell == null)
            //{
            //    currentCell = 0;
            //}
            //int CC = int.Parse(currentCell.ToString());
            //CC++;
            //ws.Cells[3, 5] = CC.ToString();
            //wb.Save();
            //wb.Close();
            //Marshal.ReleaseComObject(wb);
        }

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


    public class Excel
    {
        public static Application excel;
        public static Workbook wb;
        public static Worksheet ws;
        public static Range range;


        public Excel(string FilePath, int SheetIndex)
        {
            excel = new Application();
            Workbook wb = excel.Workbooks.Open(FilePath);
            Worksheet ws = wb.Sheets[SheetIndex].Activate();
        }

        public  string GetCellString(int Row, int Col)
        {
            var currentCell = ws.Cells[Row, Col].value;
            if (currentCell == null)
            {
                currentCell = "";
            }
            return currentCell.ToString();
        }

        public  double GetCellNumber(int Row, int Col)
        {
            var currentCell = ws.Cells[Row, Col].value;
            if (currentCell == null)
            {
                currentCell = 0;
            }
            double CC = double.Parse(currentCell.ToString());
            return CC;
        }

        public  void SetCellString(int Row, int Col, string Value)
        {
            ws.Cells[Row, Col] = Value.ToString();
        }

        public  void SetCellNumber(int Row, int Col, double Value)
        {
            ws.Cells[Row, Col] = Value;
        }

        public  void AddToCell(int Row, int Col, double Value)
        {
            double CurrentValue = GetCellNumber(Row, Col);
            double NewValue = CurrentValue + Value;
            SetCellNumber(Row, Col, NewValue);
        }

        public  int GetFirstEmptyRow(string ColumnLetter)
        {
            range = ws.get_Range(ColumnLetter + "1", ColumnLetter + "200000");
            Range foundRange = range.EntireRow.Find("");
            int row = foundRange.Row;
            return row;
        }

        public  void SaveAndExit()
        {
            wb.Save();
            wb.Close();
            Marshal.ReleaseComObject(wb);
        }

    }

}