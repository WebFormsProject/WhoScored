using System;
using System.Web.ModelBinding;
using WebFormsMvp;
using WhoScored.MVP.Models.CustomEventArgs;

namespace WhoScored.MVP.Admin
{
    public interface IManageLeagueView : IView<ManageLeagueViewModel>
    {
        event EventHandler OnGetAllLeagues;

        event EventHandler OnGetAllCountries;

        event EventHandler OnAddLeague;

        event EventHandler<IdEventArgs> OnUpdateLeague;

        event EventHandler<IdEventArgs> OnDeleteLeague;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
