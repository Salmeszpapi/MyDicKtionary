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
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Word>().Wait();
        }

        public Task<List<Word>> GetWordsAsync()
        {
            return _database.Table<Word>().ToListAsync();
        }

        public Task<int> SaveWordAsync(Word word)
        {
            return _database.InsertAsync(word);
        }

        public Task<int> DeleteWordAsync(Word word)
        {
            return _database.DeleteAsync(word);
        }

        public Task<int> UpdateWordAsync(Word word)
        {
            return _database.UpdateAsync(word);
        }

        public Task<Word> GetWordAsync(int id)
        {
            return _database.Table<Word>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}