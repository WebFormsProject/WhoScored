﻿using Bytes2you.Validation;
using WebFormsMvp;
using WhoScored.Data.Contracts;
using WhoScored.Models.Models;
using WhoScored.WebFormsClient.Models.CustomEvents;
using WhoScored.WebFormsClient.Views;

namespace WhoScored.WebFormsClient.Presenters
{
    public class LeagueTablePresenter : Presenter<ILeagueTableView>
    {
        private readonly IWhoScoredRepository<LeagueTable> leagueTableRepository;

        public LeagueTablePresenter(ILeagueTableView view, IWhoScoredRepository<LeagueTable> leagueTableRepository) 
            : base(view)
        {
            Guard.WhenArgument(leagueTableRepository, "leagueTableRepository").IsNull().Throw();
            this.leagueTableRepository = leagueTableRepository;

            this.View.OnGetLeagueTableData += this.View_OnGetLeaguesTable;
        }

        private void View_OnGetLeaguesTable(object sender, LeagueTableEventArgs e)
        {
            this.View.Model.LeagueTable = this.leagueTableRepository.GetById(e.Id);
        }
    }
}