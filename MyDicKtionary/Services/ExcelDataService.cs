using System;
using System.Reflection;

namespace MyDicKtionary.Services
{
    public class ExcelDataService
    {
        //private static string ImageBasePath = "https://servmidman.gugar.sk/";
        //private static string ftpServerUrl = "ftp://gugar.sk/gugar.sk/sub/servmidman";
        //private static string userName = "hojszi.gugar.sk";
        //private static string password = "myNewDatabasePassword1";
        public ExcelDataService()
        {
        }
        public async Task ReadExcel()
        {

            var fileUrl = "https://docs.google.com/spreadsheets/d/1BCOY3pZR-bQVduWXDwKvyGk7kQQUXQSz/edit?usp=drive_link&ouid=108681645713202296548&rtpof=true&sd=true";
            var localFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "file.xlsx"); // Use a safe directory

            using (HttpClient client = new HttpClient())
            {
                // Download the file
                var response = await client.GetAsync(fileUrl);
                if (response.IsSuccessStatusCode)
                {
                    using (var fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write))
                    {
                        await response.Content.CopyToAsync(fs);
                    }

                    // Process the file locally
                    // ...

                    // Upload the file back (if needed)
                }
            }
        }
    }
}
