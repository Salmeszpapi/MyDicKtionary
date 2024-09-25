using CommunityToolkit.Maui.Views;
using MyDicKtionary.Models;

namespace MyDicKtionary.View;

public partial class QuizSubstate : Popup
{
	public QuizSubstate()
	{
		InitializeComponent();
    }
    private void StartQuiz(object sender, EventArgs e)
    {
        this.CloseAsync(QuizResultEnum.Start);
    }

    private void Close(object sender, EventArgs e)
    {
        this.CloseAsync(QuizResultEnum.Closed);
    }
}