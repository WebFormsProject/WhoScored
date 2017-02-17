<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Public.Master" CodeBehind="LeaguesTable.aspx.cs" Inherits="WhoScored.WebFormsClient.LeaguesTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="LeaguesStatisticsGridView"
        AutoGenerateColumns="false" SelectMethod="GridViewLeagueTable_GetData" ItemType="WhoScored.Models.Models.TeamStatistic">
        <Columns>
            <asp:BoundField HeaderText="#" DataField="Position" />
            <asp:TemplateField HeaderText="Team">
                <ItemTemplate>
                    <asp:HyperLink runat="server" Text='<%# Eval("Team.Name") %>' NavigateUrl='<%# "Team?id=" + Eval("Team.Id") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="P" DataField="PlayedGames" />
            <asp:BoundField HeaderText="W" DataField="WonGames" />
            <asp:BoundField HeaderText="D" DataField="DrawGames" />
            <asp:BoundField HeaderText="L" DataField="LostGames" />
            <asp:BoundField HeaderText="F" DataField="GoalsFor" />
            <asp:BoundField HeaderText="A" DataField="GoalsAgainst" />
            <asp:BoundField HeaderText="GD" DataField="GoalDifference" />
            <asp:BoundField HeaderText="Pts" DataField="Points" />
        </Columns>
    </asp:GridView>
</asp:Content>
