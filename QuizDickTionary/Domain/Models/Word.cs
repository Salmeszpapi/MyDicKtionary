using QuizDickTionary.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDickTionary.Domain.Models
{
    public class Word : INotifyPropertyChanged
    {
        private bool _isEditing;
        public bool IsEditing
        {
            get => _isEditing;
            set
            {
                _isEditing = value;
            }
        }

        public int Id { get; set; }
        public string Slovak { get; set; }
        public string Hungarian { get; set; }
        public string English { get; set; }
        public int Difficulty { get; set; }

        public Word(WordDto dto)
        {
            Id = dto.Id;
            Slovak = dto.Slovak;
            Hungarian = dto.Hungarian;
            English = dto.English;
            Difficulty = dto.Difficulty;
        }

        public WordDto ToDto() =>
            new WordDto { Id = Id, Slovak = Slovak, Hungarian = Hungarian, English = English, Difficulty = Difficulty };


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
