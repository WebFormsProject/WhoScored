using System;
using System.Web.ModelBinding;
using WebFormsMvp;
using WhoScored.MVP.Models;
using WhoScored.MVP.Models.CustomEventArgs;

namespace WhoScored.MVP.Views
{
    public interface IAddFootballPlayerView : IView<AddFootballPlayerViewModel>
    {
        event EventHandler OnGetAllPlayers;

        event EventHandler OnGetAllCoutries;

        event EventHandler OnGetAllTeams;

        event EventHandler<IdEventArgs> OnUpdateFootballPlayer;

        event EventHandler<IdEventArgs> OnDeleteFootballPlayer;

        event EventHandler<IdEventArgs> OnAddFootballPlayer;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
