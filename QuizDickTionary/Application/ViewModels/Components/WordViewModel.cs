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
        public string English { get; set; }
        public string Hungarian { get; set; }
        public bool IsEditing { get; set; } 
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
            English = word.English;
            Hungarian = word.Hungarian;
        }
        private void EditButtonPressed()
        {
            IsEditing = !IsEditing;
            EditButtonText = IsEditing ? "Save" : "Edit";
        }
    }
}
