﻿using System;
using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.MVP.Views;

namespace WhoScored.MVP.Presenters
{
    public class StatisticsPresenter : Presenter<IStatisticsView>
    {
        private readonly IWhoScoredRepository<Team> teamRepository;

        public StatisticsPresenter(IStatisticsView view, IWhoScoredRepository<Team> teamRepository)
            : base(view)
        {
            Guard.WhenArgument(this.teamRepository, "teamRepository").IsNull().Throw();
            this.teamRepository = teamRepository;

            this.View.GetTeams += this.View_GetTeams;
        }

        private void View_GetTeams(object sender, EventArgs e)
        {
            this.View.Model.Teams = this.teamRepository.GetAll();
        }
    }
}