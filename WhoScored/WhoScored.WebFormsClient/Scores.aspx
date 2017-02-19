<%@ Page Title="Scores" Language="C#" AutoEventWireup="true" MasterPageFile="~/Public.Master" CodeBehind="Scores.aspx.cs" Inherits="WhoScored.WebFormsClient.Scores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <ul class="collection">
            <asp:Repeater ID="Parent" runat="server" DataSource="<%# GetLeagues() %>" ItemType="WhoScored.Models.Models.League">
                <ItemTemplate>
                    <li><b><%# Item.Name %></b></li>
                    <ul>
                        <asp:Repeater runat="server" DataSource="<%# GetGamesByLeague(Item) %>" ItemType="WhoScored.Models.Models.Game">
                            <ItemTemplate>
                                <span><%# Item.HomeTeam.Name %></span>
                                <span><%# Item.HomeTeamGoals %></span>
                                -
                            <span><%# Item.AwayTeamGoals %></span>
                                <span><%# Item.AwayTeam.Name %></span>
                                <br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
