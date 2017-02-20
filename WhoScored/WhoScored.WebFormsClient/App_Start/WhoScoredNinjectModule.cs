using Ninject.Modules;
using Ninject.Web.Common;
using WhoScored.Data;
using WhoScored.Data.Contracts;
using WhoScored.MVP.Presenters;
using WhoScored.MVP.Presenters.Auth;
using WhoScored.Services;
using WhoScored.Services.Contracts;

namespace WhoScored.WebFormsClient
{
    public class WhoScoredNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWhoScoredContext>().To<WhoScoredContext>().InRequestScope();
            this.Bind(typeof(IWhoScoredRepository<>)).To(typeof(WhoScoredRepository<>));

            this.Bind<IUnitOfWork>().To<WhoScoredUnitOfWork>();

            this.Bind<RegisterPresenter>().ToSelf();
            this.Bind<LoginPresenter>().ToSelf();
            this.Bind<ManageAccountPresenter>().ToSelf();
            this.Bind<ManagePasswordPresenter>().ToSelf();
            this.Bind<UserPresenter>().ToSelf();
            this.Bind<UserAvatarPresenter>().ToSelf();
            this.Bind<StatisticsPresenter>().ToSelf();
            this.Bind<LeaguePresenter>().ToSelf();
            this.Bind<LeagueTablePresenter>().ToSelf();
            this.Bind<TrollPhotosPresenter>().ToSelf();
            this.Bind<TeamPresenter>().ToSelf();
            this.Bind<ScoresPresenter>().ToSelf();
            this.Bind<FootballPlayerPresenter>().ToSelf();
            this.Bind<AddFootballPlayerPresenter>().ToSelf();

            this.Bind<IGameService>().To<GameService>();
            this.Bind<IFootballPlayerService>().To<FootballPlayerService>();
            this.Bind<IUserService>().To<UserService>();
            this.Bind<ILeagueTableService>().To<LeagueTableService>();
            this.Bind<ILeagueService>().To<LeagueService>();
            this.Bind<ITeamService>().To<TeamService>();
            this.Bind<ITrollPhotoService>().To<TrollPhotoService>();
            this.Bind<ICountryService>().To<CountryService>();
        }
    }
}