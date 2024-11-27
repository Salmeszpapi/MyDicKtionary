using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizDickTionary.Domain.Dtos;

namespace QuizDickTionary.Domain.Models
{
    public class WordDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public WordDatabase(string dbPath)
        {
            try
            {
                _database = new SQLiteAsyncConnection(dbPath);

                // Check if the WordDto table exists
                var wordTableExists = _database.ExecuteScalarAsync<int>(
                    "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='WordDto'").Result;

                if (wordTableExists == 0)
                {
                    _database.CreateTableAsync<WordDto>().Wait(); // Create table if it doesn't exist
                }

                // Check if the VersionDto table exists
                var versionTableExists = _database.ExecuteScalarAsync<int>(
                    "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='VersionDto'").Result;

                if (versionTableExists == 0)
                {
                    _database.CreateTableAsync<VersionDto>().Wait(); // Create table if it doesn't exist
                }
            }
            catch (Exception ex)
            {
                throw; // Re-throwing to let the exception bubble up
            }
        }

        public async Task<bool> IsEmptyTable()
        {
            return await _database.Table<WordDto>().CountAsync() > 0;
        }

        public async Task<int> HasRecords()
        {
            return await _database.ExecuteScalarAsync<int>("SELECT COUNT(*) from WordDto");
        }

        public async Task<int> GetWordDtoRecordCountAsync()
        {
            return await _database.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM WordDto");
        }

        public async Task<List<string>> GetTableNamesAsync()
        {
            var tableNames = await _database.QueryScalarsAsync<string>(
                "SELECT name FROM sqlite_master WHERE type='table'");
            return tableNames;
        }

        public async Task<List<WordDto>> GetWordsAsync()
        {
            return await _database.Table<WordDto>().ToListAsync();
        }

        public Task<int> SaveWordAsync(WordDto word)
        {
            return _database.InsertAsync(word);
        }

        public Task<int> DeleteWordAsync(Word word)
        {
            return _database.DeleteAsync(word);
        }

        public Task UpdateWord(WordDto word)
        {
            return _database.UpdateAsync(word);
        }

        public void UpdateDictionary(List<Word> words)
        {
            foreach (var item in words)
            {
                _database.UpdateAsync(item);
            }
        }

        public Task<WordDto> GetWordAsync(int id)
        {
            return _database.Table<WordDto>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> DeleteAllWordsAsync()
        {
            return _database.DeleteAllAsync<WordDto>();
        }

        public async Task<List<WordDto>> GetPagedWordsAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1; // Ensure page number is at least 1
            if (pageSize < 1) pageSize = 1;     // Ensure page size is at least 1

            // Calculate the number of items to skip based on the current page
            int skip = (pageNumber - 1) * pageSize;

            return await _database.Table<WordDto>()
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
