using SQLite;
using System.ComponentModel;

namespace MyDicKtionary.Models
{
    public class Word : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _english;
        public string English
        {
            get => _english;
            set
            {
                if (_english != value)
                {
                    _english = value;
                    OnPropertyChanged(nameof(English));
                }
            }
        }

        private string _hungarian;
        public string Hungarian
        {
            get => _hungarian;
            set
            {
                if (_hungarian != value)
                {
                    _hungarian = value;
                    OnPropertyChanged(nameof(Hungarian));
                }
            }
        }

        private int _difficulty;
        public int Difficulty
        {
            get => _difficulty;
            set
            {
                if (_difficulty != value)
                {
                    _difficulty = value;
                    OnPropertyChanged(nameof(Difficulty));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
