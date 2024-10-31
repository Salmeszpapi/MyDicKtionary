using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDickTionary.Application.ViewModels.Incident
{
    public class IncidentPopup : Popup
    {
        public IncidentPopup()
        {
            var yesButton = new Button { Text = "Yes" };
            var noButton = new Button { Text = "No" };

            yesButton.Clicked += (s, e) => Close(true);
            noButton.Clicked += (s, e) => Close(false);

            Content = new VerticalStackLayout
            {
                Children =
            {
                new Label { Text = "Do you want to proceed?" },
                yesButton,
                noButton
            },
                Spacing = 10,
                Padding = 20
            };
        }
    }
}
