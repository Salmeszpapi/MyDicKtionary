using IronXL;
using MyDicKtionary.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDicKtionary.Util
{
    public static class ExcelAgregator
    {
        public static async Task ProcessExcel()
        {
            await App.Database.DeleteAllWordsAsync();
            WorkBook workBook = null;
            //WorkBook workBook = WorkBook.Load("C:\\Users\\kik\\source\\repos\\MyDicKtionary\\MyDicKtionary\\Util\\EngishWords.xlsx");
            try
            {
                string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                // Combine the directory with the relative path to the Excel file
                string excelPath = Path.Combine(assemblyDirectory, "Util", "EngishWords.xlsx");
                workBook = WorkBook.Load(excelPath);
            }
            catch (Exception ex)
            {
            }
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

        public static async Task ReadExcel()
        {
            var fileUrl = "https://drive.usercontent.google.com/download?id=1BCOY3pZR-bQVduWXDwKvyGk7kQQUXQSz&export=download&authuser=0&confirm=t&uuid=5403b9a9-d52d-4c62-a6c3-dca271c93a34/export?format=xlsx";

            using (HttpClient client = new HttpClient())
            {
                // Download the file
                HttpResponseMessage response = await client.GetAsync(fileUrl);
                if (response.IsSuccessStatusCode)
                {
                    using (Stream stream = await response.Content.ReadAsStreamAsync())
                    {
                        try
                        {
                            IWorkbook workbook = new XSSFWorkbook(stream); // For .xlsx files
                            ISheet sheet = workbook.GetSheetAt(0); // Access the first worksheet

                            int rowCount = sheet.LastRowNum;

                            for (int row = 0; row <= rowCount; row++)
                            {
                                IRow currentRow = sheet.GetRow(row);
                                if (currentRow == null) continue;

                                var englishWord = currentRow.GetCell(0)?.ToString();
                                var hungarianWord = currentRow.GetCell(1)?.ToString();

                                if (!string.IsNullOrWhiteSpace(englishWord) && !string.IsNullOrWhiteSpace(hungarianWord))
                                {
                                    Word word = new Word()
                                    {
                                        English = englishWord,
                                        Hungarian = hungarianWord
                                    };

                                    await App.Database.SaveWordAsync(word);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle exceptions (e.g., logging)
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                }
            }
        }

        public static async Task ReadAndConvertExcelToCSV()
        {
            var fileUrl = "https://drive.usercontent.google.com/download?id=1HH3S4YWUVpFvV2IuQDqKaAGgmnstQfoE&export=download&authuser=0&confirm=t&uuid=8f291b17-ebe7-4725-94f8-633fedb4de41&at=AO7h07dZVweRMQkBrMJM3oJx6zqO:1726904312959";

            using (HttpClient client = new HttpClient())
            {
                // Download the file
                HttpResponseMessage response = await client.GetAsync(fileUrl);
                if (response.IsSuccessStatusCode)
                {
                    using (Stream stream = await response.Content.ReadAsStreamAsync())
                    {
                        try
                        {
                            // Load Excel workbook from the stream using IronXL
                            var workBook = WorkBook.FromStream(stream);
                            var workSheet = workBook.WorkSheets[0]; // Access the first worksheet
                            var englishWords = workSheet.GetColumn(0);
                            var hungaryanWords = workSheet.GetColumn(1);
                        }
                        catch (Exception ex)
                        {
                            // Handle exceptions (e.g., logging)
                        }
                    }
                }
            }
        }

        private static async Task ProcessCSVData(string csvData)
        {
            // Here, you can split the CSV content and process each row as needed
            using (var reader = new StringReader(csvData))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var columns = line.Split(',');

                    if (columns.Length >= 2)
                    {
                        var englishWord = columns[0];
                        var hungarianWord = columns[1];

                        if (!string.IsNullOrWhiteSpace(englishWord) && !string.IsNullOrWhiteSpace(hungarianWord))
                        {
                            Word word = new Word()
                            {
                                English = englishWord,
                                Hungarian = hungarianWord
                            };

                            await App.Database.SaveWordAsync(word); // Save word to database
                        }
                    }
                }
            }
        }
    }
}
