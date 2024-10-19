using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDickTionary.Domain.Models
{
    public class Word(int id, string slovak, string hungary, string english, int difficulty)
    {
        public int Id { get; private set; } = id;
        public string Slovak { get; private set; } = slovak;
        public string Hungary { get; private set; } = hungary;
        public string English { get; private set; } = english;
        public int Difficulty { get; private set; } = difficulty;
    }
}
