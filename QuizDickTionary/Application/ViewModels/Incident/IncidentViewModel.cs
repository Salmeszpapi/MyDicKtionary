using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizDickTionary.Application.ViewModels.Incident;

namespace QuizDickTionary.Application.ViewModels
{
    public class IncidentViewModel : IIncidentViewModel
    {
        public string Title { get ; set ; }
        public Command CloseDecision { get; set ; }
        public Command ConfirmDecision { get; set; }
        public IncidentViewModel()
        {
            //CloseDecision = new Command()
        }

        public async Task Test()
        {

        }
    }
}
