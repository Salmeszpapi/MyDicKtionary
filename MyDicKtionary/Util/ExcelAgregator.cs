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
            await App.Database.DeleteAllWordsAsync();

            WorkBook workBook = WorkBook.Load("C:\\Users\\kik\\source\\repos\\MyDicKtionary\\MyDicKtionary\\Util\\EngishWords.xlsx");
            WorkSheet workSheet = workBook.WorkSheets[0];

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
