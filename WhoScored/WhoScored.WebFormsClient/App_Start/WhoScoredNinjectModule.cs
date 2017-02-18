using Ninject.Modules;
using Ninject.Web.Common;
using WhoScored.Data;
using WhoScored.Data.Contracts;
using WhoScored.Services;
using WhoScored.Services.Contracts;
using WhoScored.WebFormsClient.Presenters;

namespace WhoScored.WebFormsClient.App_Start
{
    public class WhoScoredNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWhoScoredContext>().To<WhoScoredContext>().InRequestScope();
            this.Bind(typeof(IWhoScoredRepository<>)).To(typeof(WhoScoredRepository<>));

            this.Bind<StatisticsPresenter>().ToSelf();
            this.Bind<LeaguePresenter>().ToSelf();
            this.Bind<LeagueTablePresenter>().ToSelf();
            this.Bind<TrollPhotosPresenter>().ToSelf();
            this.Bind<TeamPresenter>().ToSelf();
            this.Bind<ScoresPresenter>().ToSelf();
            this.Bind<UserPresenter>().ToSelf();

            this.Bind<IGameService>().To<GameService>();
        }
    }
}