using Ninject.Modules;
using Ninject.Web.Common;
using System.Data.Entity;
using WhoScored.Data;
using WhoScored.WebFormsClient.Presenters;

namespace WhoScored.WebFormsClient.App_Start
{
    public class WhoScoredNinjectModel : NinjectModule
    {
        public override void Load()
        {
            this.Bind<DbContext>().To<WhoScoredContext>().InRequestScope();

            this.Bind<StatisticsPresenter>().ToSelf();

            //this.Bind<IDataProvider>().To<DataProvider>();
        }
    }
}