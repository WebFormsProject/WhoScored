﻿using Ninject.Modules;
using Ninject.Web.Common;
using System.Data.Entity;
using WhoScored.Data;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.WebFormsClient.Presenters;

namespace WhoScored.WebFormsClient.App_Start
{
    public class WhoScoredNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWhoScoredContext>().To<WhoScoredContext>().InRequestScope();
            // this.Bind<DbContext>().To<WhoScoredContext>().InRequestScope();

            this.Bind<StatisticsPresenter>().ToSelf();
            this.Bind<IWhoScoredRepository<Team>>().To<WhoScoredRepository<Team>>();

            this.Bind<LeaguePresenter>().ToSelf();
            this.Bind<LeagueTablePresenter>().ToSelf();
            this.Bind(typeof(IWhoScoredRepository<League>)).To(typeof(WhoScoredRepository<League>));
           // this.Bind<LeagueTablePresenter>().ToSelf();
            this.Bind(typeof(IWhoScoredRepository<LeagueTable>)).To(typeof(WhoScoredRepository<LeagueTable>));

            //  this.Bind<IWhoScoredRepository<League>>().To<WhoScoredRepository<League>>();
        }
    }
}