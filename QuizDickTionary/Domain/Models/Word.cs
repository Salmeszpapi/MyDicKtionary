using QuizDickTionary.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDickTionary.Domain.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string Slovak { get; set; }
        public string Hungarian { get; set; }
        public string English { get; set; }
        public int Difficulty { get; set; }
    }
}
