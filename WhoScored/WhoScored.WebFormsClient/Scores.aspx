<%@ Page Title="Scores" Language="C#" AutoEventWireup="true" MasterPageFile="~/Public.Master" CodeBehind="Scores.aspx.cs" Inherits="WhoScored.WebFormsClient.Scores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <%--<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>--%>
        <h4>Date: <%# string.Format("{0:dd MM yyyy}", DateTime.Now) %></h4>
        <asp:Repeater ID="Parent" runat="server" DataSource="<%# GetLeagues() %>" ItemType="WhoScored.Models.Models.League">
            <ItemTemplate>
                <div class="card-panel center brown lighten-1 custom-panel">
                    <h6>
                        <asp:HyperLink NavigateUrl='<%# string.Format("~/LeaguesTable?id={0}", Item.Id) %>' CssClass="brown-text text-lighten-5" runat="server" Text='<%#: Item.Name %>' />
                    </h6>
                </div>
                <table class="bordered">
                    <asp:Repeater runat="server" DataSource="<%# GetGamesByLeague(Item) %>" ItemType="WhoScored.Models.Models.Game">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("GameDate", "{0:HH:mm}" ) %></td>
                                <td><%# Item.HomeTeam.Name %></td>
                                <td><%# Item.HomeTeamGoals %></td>
                                <td>-</td>
                                <td><%# Item.AwayTeamGoals %></td>
                                <td><%# Item.AwayTeam.Name %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
