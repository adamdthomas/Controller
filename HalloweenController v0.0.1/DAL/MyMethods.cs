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



        public static string StarsPath = "C:\\Logs\\stars.xls";

        public static bool ShowDisplay;

        public static double GetTotalStars(string AccountName)
        {
            Excel StarsSheet = new Excel(StarsPath, AccountName);
            double Totals = StarsSheet.GetCellNumber(1, 2);
            StarsSheet.SaveAndExit();
            return Totals;
        }

        public static double GetTodaysStars(string AccountName)
        {
            Excel StarsSheet = new Excel(StarsPath, AccountName);
            int TR = StarsSheet.GetTodaysRow();
            double TodaysTotals = StarsSheet.GetCellNumber(TR, 5);
            StarsSheet.SaveAndExit();
            return TodaysTotals;
        }

        public static double AddStars(string AccountName, double Amount)
        {
            Excel StarsSheet = new Excel(StarsPath, AccountName);
            int row = StarsSheet.GetTodaysRow();
            double newvalue = StarsSheet.AddToCell(row, 5, Amount);
            StarsSheet.SaveAndExit();
            return newvalue;
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


        public Excel(string FilePath, string SheetName)
        {
            excel = new Application();
            wb = excel.Workbooks.Open(FilePath);

            excel.DisplayAlerts = false;
            excel.Visible = false;

            ws = wb.Sheets[SheetName];
            //ws = wb.ActiveSheet;


            range = ws.get_Range("A1", "A3650");
            // set each cell's format to Text
            range.NumberFormat = "@";

        }

        public void SwitchSheet(string SheetName)
        {
            ws = wb.Sheets[SheetName];
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

        public  double AddToCell(int Row, int Col, double Value)
        {
            double CurrentValue = GetCellNumber(Row, Col);
            double NewValue = CurrentValue + Value;
            SetCellNumber(Row, Col, NewValue);
            return NewValue;
        }

        public int GetTodaysRow()
        {
            DateTime today = DateTime.Today;
            string date = today.ToString("MM/dd/yyyy");
            range = ws.get_Range("A1", "A3650");
            Range foundRange = range.EntireRow.Find(date);
            int row;

            if (foundRange == null)
            {
                int FIR = GetFirstEmptyRow("A");
                SetCellString(FIR, 1, date);
                row = FIR;
            }
            else
            {
                row = foundRange.Row;
            }

            return row;

        }

        public int GetFirstEmptyRow(string ColumnLetter)
        {
            //string currentVal;
            range = ws.get_Range(ColumnLetter + "1", ColumnLetter + "3650");
            var rangeValues = range.Value2;
            int row = 0;
            for (int r = 1; r < 3650; r++)
            {
                var currentVal = rangeValues[r, 1];
                if (currentVal == null)
                {
                    row = r;
                    break;
                }
            }

            //Range foundRange = range.EntireRow.Find("");
            //DateTime today = DateTime.Today;
            //int rowf = foundRange.Row;

            return row;
        }

        public  void SaveAndExit()
        {
            wb.Save();
            wb.Close();
            excel.Quit();

            // Cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            if (range != null)
            {
                Marshal.FinalReleaseComObject(range);
                range = null;
            }

            if (ws != null)
            {
                Marshal.FinalReleaseComObject(ws);
                ws = null;
            }
            if (wb != null)
            {
                Marshal.FinalReleaseComObject(wb);
                wb = null;
            }
            if (excel != null)
            {
                Marshal.FinalReleaseComObject(excel);
                excel = null;
            }

           // Marshal.ReleaseComObject(wb);
        }

    }

}