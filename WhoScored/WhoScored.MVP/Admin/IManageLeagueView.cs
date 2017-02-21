using System;
using System.Web.ModelBinding;
using WebFormsMvp;

namespace WhoScored.MVP.Admin
{
    public interface IManageLeagueView : IView<ManageLeagueViewModel>
    {
        event EventHandler OnGetAllLeagues;

        event EventHandler OnGetAllCountries;

        event EventHandler OnAddLeague;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
