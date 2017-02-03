using System;
using WebFormsMvp;

namespace WhoScored.WebFormsClient.Factories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}