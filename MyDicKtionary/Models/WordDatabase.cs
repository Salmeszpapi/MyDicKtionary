using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDicKtionary.Models
{
    public class WordDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public WordDatabase(string dbPath)
        {
            try
            {
                _database = new SQLiteAsyncConnection(dbPath);
                _database.CreateTableAsync<Word>().Wait(); // Synchronous wait can block the thread, but it's necessary here
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to initialize database: {ex.Message}");
                throw; // Re-throwing to let the exception bubble up
            }
        }

        public async Task<List<Word>> GetWordsAsync()
        {
            return await _database.Table<Word>().ToListAsync();
        }

        public Task<int> SaveWordAsync(Word word)
        {
            return _database.InsertAsync(word);
        }

        public Task<int> DeleteWordAsync(Word word)
        {
            return _database.DeleteAsync(word);
        }

        public void UpdateDictionary(List<Word> words)
        {
            foreach (var item in words)
            {
                _database.UpdateAsync(item);
            }
        }

        public Task<Word> GetWordAsync(int id)
        {
            return _database.Table<Word>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> DeleteAllWordsAsync()
        {
            return _database.DeleteAllAsync<Word>();
        }
    }
}