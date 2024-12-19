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
        public WordWithAnswer(WordDto wordDto, string answer)
        {
            //Make this generic for future depending on settings languange
            if (wordDto.English == answer)
            {
                IsCorrect = true;
            }

            IsCorrect = false;
        }
    }
}
