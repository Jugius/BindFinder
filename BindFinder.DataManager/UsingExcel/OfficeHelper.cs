using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace BindFinder.DataManager.UsingExcel
{
    class OfficeHelper
    {
        internal static bool IsExcelInstalled()
        {
            System.Type officeType = System.Type.GetTypeFromProgID("Excel.Application");
            if (officeType == null)
                return false;
            return true;
        }
        internal static void FormatExportBindsPage(Excel.Worksheet worksheet)
        {
            worksheet.Range["A1"].Value = "Адрес запроса";
            worksheet.Range["B1"].Value = "Latitude";
            worksheet.Range["C1"].Value = "Longitude";
            worksheet.Range["D1"].Value = "Страна";
            worksheet.Range["E1"].Value = "Регион/область";
            worksheet.Range["F1"].Value = "Город";
            worksheet.Range["G1"].Value = "Район";
            worksheet.Range["H1"].Value = "Улица";
            worksheet.Range["I1"].Value = "Дом";
            worksheet.Range["J1"].Value = "Индекс";
            worksheet.Range["K1"].Value = "Описание";
            worksheet.Range["L1"].Value = "Ссылка";
            worksheet.Range["M1"].Value = "Google PlaceID";

            worksheet.Range["A:A"].ColumnWidth = 25;
            worksheet.Range["B:B"].ColumnWidth = worksheet.Range["C:C"].ColumnWidth = worksheet.Range["D:D"].ColumnWidth = 10;
            worksheet.Range["E:E"].ColumnWidth = 17;
            worksheet.Range["F:F"].ColumnWidth = 10;
            worksheet.Range["G:G"].ColumnWidth = 20;
            worksheet.Range["H:H"].ColumnWidth = 30;
            worksheet.Range["I:I"].ColumnWidth = worksheet.Range["J:J"].ColumnWidth = 8;
            worksheet.Range["K:K"].ColumnWidth = 25;
            worksheet.Range["L:L"].ColumnWidth = 10;
            worksheet.Range["M:M"].ColumnWidth = 25;

            string leftSheetChar = "M";

            worksheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, worksheet.Range[$"A1:{leftSheetChar}2"], Type.Missing, Excel.XlYesNoGuess.xlYes, Type.Missing).Name = "ReportTable";
            worksheet.Range[$"A1:{leftSheetChar}2"].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(30, 55, 55));
            worksheet.Range[$"A1:{leftSheetChar}2"].Font.Name = "Calibri";
            worksheet.Range[$"A1:{leftSheetChar}2"].Font.Size = 10;

            worksheet.Range[$"A1:{leftSheetChar}1"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 180, 209));
            worksheet.Range[$"A2:{leftSheetChar}2"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            worksheet.Range[$"A1:{leftSheetChar}2"].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
        }

        internal static void FormatExportBoardsPage(Excel.Worksheet worksheet)
        {
            worksheet.Range["A1"].Value = "Город";
            worksheet.Range["B1"].Value = "Владелец";
            worksheet.Range["C1"].Value = "Улица";
            worksheet.Range["D1"].Value = "Дом";
            worksheet.Range["E1"].Value = "Описание";
            worksheet.Range["F1"].Value = "Носитель";
            worksheet.Range["G1"].Value = "Размер";
            worksheet.Range["H1"].Value = "Напр.";
            worksheet.Range["I1"].Value = "OTS";
            worksheet.Range["J1"].Value = "GRP";
            worksheet.Range["K1"].Value = "№ владельца";
            worksheet.Range["L1"].Value = "№ DOORS";
            worksheet.Range["M1"].Value = "Свет";
            worksheet.Range["N1"].Value = "Фото";
            worksheet.Range["O1"].Value = "Схема";

            worksheet.Range["P1"].Value = "Карта";
            worksheet.Range["Q1"].Value = "Дист.";

            worksheet.Range["R1"].Value = "Адрес точки";
            worksheet.Range["S1"].Value = "Описание точки";           

            string leftSheetChar = "S";

            worksheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, worksheet.Range[$"A1:{leftSheetChar}2"], Type.Missing, Excel.XlYesNoGuess.xlYes, Type.Missing).Name = "ReportTable";
            worksheet.Range[$"A1:{leftSheetChar}2"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            worksheet.Range[$"A1:{leftSheetChar}2"].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(30, 55, 55));
            worksheet.Range[$"A1:{leftSheetChar}2"].Font.Name = "Calibri";
            worksheet.Range[$"A1:{leftSheetChar}2"].Font.Size = 9;

            worksheet.Range[$"A1:{leftSheetChar}1"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(153, 180, 209));
            worksheet.Range[$"A2:{leftSheetChar}2"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            worksheet.Range[$"A1:{leftSheetChar}2"].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            worksheet.Range["A1"].ColumnWidth = 12;
            worksheet.Range["B1"].ColumnWidth = 16;
            worksheet.Range["C1"].ColumnWidth = 20;
            worksheet.Range["D1"].ColumnWidth = 6.5;
            worksheet.Range["E1"].ColumnWidth = 35;
            worksheet.Range["F1"].ColumnWidth = 10;
            worksheet.Range["G1"].ColumnWidth = 8;
            worksheet.Range["H1"].ColumnWidth = 4;
            worksheet.Range["I1"].ColumnWidth = 5;
            worksheet.Range["J1"].ColumnWidth = 5;
            worksheet.Range["K:K"].ColumnWidth = 10;
            worksheet.Range["L:L"].ColumnWidth = 10;
            worksheet.Range["M1"].ColumnWidth = 4;
            worksheet.Range["N1"].ColumnWidth = 6;
            worksheet.Range["O1"].ColumnWidth = 6;
            
            worksheet.Range["P1"].ColumnWidth = 6;
            worksheet.Range["Q1"].ColumnWidth = 6;

            worksheet.Range["R1"].ColumnWidth = 30;
            worksheet.Range["s1"].ColumnWidth = 15;

            worksheet.Range["D2"].NumberFormat = "@";
            worksheet.Range["I2"].NumberFormat = "@";
            worksheet.Range["J2"].NumberFormat = "@";
            //worksheet.Range["K2"].NumberFormat = "@";
            //worksheet.Range["L2"].NumberFormat = "@";
        }
    }
}
