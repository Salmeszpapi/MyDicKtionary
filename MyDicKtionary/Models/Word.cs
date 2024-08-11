using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDicKtionary.Models
{
    public class Word
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string English { get; set; }
        public string Hungarian { get; set; }
        public int Difficulty { get; set; } // 1 = Easy, 2 = Medium, 3 = Hard
    }
}
