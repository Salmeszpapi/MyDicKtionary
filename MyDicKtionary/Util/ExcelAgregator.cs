using IronXL;
using MyDicKtionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDicKtionary.Util
{
    public class ExcelAgregator
    {
        public async Task ProcessExcel()
        {
            WorkBook workBook = WorkBook.Load("C:\\Users\\kik\\source\\repos\\MyDicKtionary\\MyDicKtionary\\Util\\EngishWords.xlsx");
            //xlsWorkbook.Metadata.Author = "IronXL";
            //WorkSheet xlsSheet = xlsWorkbook.CreateWorkSheet("new_sheet");
            //xlsSheet["A1"].Value = "Hello World";
            //xlsSheet["A2"].Style.BottomBorder.SetColor("#ff6600");
            //xlsSheet["A2"].Style.BottomBorder.Type = IronXL.Styles.BorderType.Double;
            //xlsWorkbook.SaveAs("NewExcelFile.xls"); //Save the excel file
            WorkSheet workSheet = workBook.WorkSheets[0];

            WorkSheet firstSheet = workBook.DefaultWorkSheet;

            var englishWords = workSheet.GetColumn(0);
            var hungaryanWords = workSheet.GetColumn(1);
            for (int i = 0; i < englishWords.RowCount; i++)
            {
                if (englishWords.Rows[i].IsEmpty || hungaryanWords.Rows[i].IsEmpty)
                { continue; }

                Word word = new Word()
                {
                    English = englishWords.Rows[i].ToString(),
                    Hungarian = hungaryanWords.Rows[i].ToString(),
                };

                await App.Database.SaveWordAsync(word);
            }
        }
    }
}
