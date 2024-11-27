using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using QuizDickTionary.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDickTionary.Services
{
    public class ApiDataProvider
    {
        //private static string ImageBasePath = "https://servmidman.gugar.sk/";
        //private static string ftpServerUrl = "ftp://gugar.sk/gugar.sk/sub/servmidman";
        //private static string userName = "hojszi.gugar.sk";
        //private static string password = "myNewDatabasePassword1";

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
                                        WordDto word = new WordDto()
                                        {
                                            Id = row,
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
        }
    }

