namespace QuizDickTionary.Application.ViewModels.Incident
{
    public interface IIncidentViewModel
    {
        public string Title { get; set; }
        public Command CloseDecision { get; set; }
        public Command ConfirmDecision { get; set; }
    }
}