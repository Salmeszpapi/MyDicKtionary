using QuizDickTionary.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDickTionary.Application.Models
{
    public class WordWithAnswer
    {
        public bool IsCorrect { get; }
        public string EnglishWord { get; set; }
        public string HungarianhWord { get; set; }
        public string Answer { get; set; }

        public WordWithAnswer(WordDto wordDto, string answer)
        {
            //Make this generic for future depending on settings
            EnglishWord = wordDto.English;
            HungarianhWord = wordDto.Hungarian;
            Answer = answer;
            if (wordDto.English == answer)
            {
                IsCorrect = true;
            }

            IsCorrect = false;
        }
    }
}
