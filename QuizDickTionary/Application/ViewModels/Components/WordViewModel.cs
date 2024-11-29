using QuizDickTionary.Application.Models;
using QuizDickTionary.Domain.Dtos;
using QuizDickTionary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizDickTionary.Application.ViewModels.Components
{
    public class WordViewModel : BaseViewModel
    {
        public int Id { get; set; }

        private string _hungarian;
        public string Hungarian
        {
            get { return _hungarian; }
            set { InternalSetPropertyValue(ref _hungarian, value); }
        }

        private string _slovak;
        public string Slovak
        {
            get { return _slovak; }
            set { InternalSetPropertyValue(ref _slovak, value);}
        }

        private string _english;
        public string English
        {
            get { return _english; }
            set { InternalSetPropertyValue(ref _english, value); }
        }

        public int Difficulty { get; set; }

        private bool _isEditing;
        public bool IsEditing
        {
            get { return _isEditing; }
            set { InternalSetPropertyValue(ref _isEditing, value); }
        }

        public ICommand EditCommand { get; set; }
        private string _editButtonText;
        public string EditButtonText {
            get {  return _editButtonText; }
            set { InternalSetPropertyValue(ref _editButtonText, value, nameof(EditButtonText)); }
        }

        public WordViewModel(IViewModelFactory viewModelFactory) : base(viewModelFactory)
        {
            EditButtonText = "Edit";
            EditCommand = new Command(EditButtonPressed);
        }

        public void InitializeContent(WordDto word)
        {
            Id = word.Id;
            English = word.English;
            Hungarian = word.Hungarian;
        }
        private async void EditButtonPressed()
        {
            if (_isEditing) 
            {
                await SaveWordToDb();
            }
            EditButtonText = IsEditing ? "Edit" : "Save";
            IsEditing = !IsEditing;
        }

        private async Task SaveWordToDb()
        {
            await App.Database.UpdateWord(new WordDto() { Id = Id, Hungarian = Hungarian, English = English, Difficulty = Difficulty, Slovak = Slovak });
        }
    }
}
