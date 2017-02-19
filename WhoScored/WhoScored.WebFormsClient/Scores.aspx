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
                            <tr id='<%# Item.Id %>' data-away-team="<%# Item.AwayTeam.Name %>" 
                                data-home-team="<%# Item.HomeTeam.Name %>"
                                data-home-scorers="<%# string.Join(",", Item.GoalScorers.Where(x=>x.CurrentTeam.Name == Item.HomeTeam.Name).Select(x=> x.FirstName +" " + x.LastName)) %>"
                                data-away-scorers="<%# string.Join(",", Item.GoalScorers.Where(x=>x.CurrentTeam.Name == Item.AwayTeam.Name).Select(x=> x.FirstName +" " + x.LastName)) %>">
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

    <div id="pop" class="popbox card-panel brown lighten-5">
        <h5><span id="homeTeam"></span> - <span id="awayTeam"></span></h5>
        <p id="homeScorers"></p>
        <p id="awayScorers"></p>
    </div>
    <script>
        $('tbody tr').hover((e) => {
            $.ajax({
                type: 'POST',
                url: '<%= ResolveUrl("~/Scores.aspx/GetGameDetails") %>',
                contentType: 'application/json',
                data: JSON.stringify({
                    id: e.currentTarget.id,
                    homeTeam: e.currentTarget.dataset.homeTeam,
                    awayTeam: e.currentTarget.dataset.awayTeam,
                    homeScorers: e.currentTarget.dataset.homeScorers,
                    awayScorers: e.currentTarget.dataset.awayScorers
                })
            })
            .done((result) => {
                $('#homeTeam').html(result.d.HomeTeam);
                $('#awayTeam').html(result.d.AwayTeam);
                $('#homeScorers').html("<b>" + result.d.HomeTeam + " scorers:</b> " + result.d.HomeTeamScorers);
                $('#awayScorers').html("<b>" + result.d.AwayTeam + " scorers:</b> " + result.d.AwayTeamScorers);
            });

            $('#pop').show();
            $('#pop').css({
                position: "absolute",
                marginLeft: 0, marginTop: 0,
                top: $(e.currentTarget).position().top + 40, left: $(e.currentTarget).position().left + 80

            });
        });

        $('tbody').mouseleave(() => {
            $('#pop').hide();
        });
    </script>
</asp:Content>
