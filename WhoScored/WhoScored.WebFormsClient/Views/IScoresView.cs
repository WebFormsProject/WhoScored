using System;
using WebFormsMvp;
using WhoScored.WebFormsClient.Models;

namespace WhoScored.WebFormsClient.Views
{
    public interface IScoresView : IView<ScoresModelView>
    {
        event EventHandler OnGetLatestScores;
    }
}
