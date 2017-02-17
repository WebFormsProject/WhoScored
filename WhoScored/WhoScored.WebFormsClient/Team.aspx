<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Public.Master" CodeBehind="Team.aspx.cs" Inherits="WhoScored.WebFormsClient.Team" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card-panel">
        <asp:FormView runat="server" ID="TeamFormView" SelectMethod="FormViewTeam_GetData" ItemType="WhoScored.Models.Models.Team">
            <ItemTemplate>
                <div class="center-block center-align">
                    <img src="<%#: Eval("EmblemImagePath")%>" class="img-responsive img-rounded emblem-image center-block" />
                    <h3><%#: Eval("Name")%></h3>
                </div>
            </ItemTemplate>
        </asp:FormView>
        <h3>Squad
        </h3>
        <ul class="collection">
            <asp:Repeater ID="RepeaterPeople" runat="server"
                DataSource="<%# GetCurrentPlayers() %>" ItemType="WhoScored.Models.Models.FootballPlayer">
                <ItemTemplate>
                    <li class="collection-item avatar">
                        <img src="<%#: Item.ImagePath %>" alt="" class="circle">
                        <span class="title"><%#: Item.FirstName %> <%#: Item.LastName %></span>
                        <p><%#: Item.Position %></p>
                        <h4 class="secondary-content"><%#: Item.ShirtNumber %></h4>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div class="card-panel">
        <div class="row">
            <h4 class="col-6">Latest Club News (Fake for now)</h4>
        </div>
        <div class="row">
            <div class="col s12 m4">
                <div class="card">
                    <div class="card-image">
                        <img src="http://wallpapercave.com/wp/ofoImjh.jpg">
                        <span class="card-title">Card Title</span>
                    </div>
                    <div class="card-content">
                        <p>
                            I am a very simple card. I am good at containing small bits of information.
              I am convenient because I require little markup to use effectively.
                        </p>
                    </div>
                    <div class="card-action">
                        <a href="#">This is a link</a>
                    </div>
                </div>
            </div>
            <div class="col s12 m4">
                <div class="card">
                    <div class="card-image">
                        <img src="http://wallpapercave.com/wp/ofoImjh.jpg">
                        <span class="card-title">Card Title</span>
                    </div>
                    <div class="card-content">
                        <p>
                            I am a very simple card. I am good at containing small bits of information.
              I am convenient because I require little markup to use effectively.
                        </p>
                    </div>
                    <div class="card-action">
                        <a href="#">This is a link</a>
                    </div>
                </div>
            </div>
            <div class="col s12 m4">
                <div class="card">
                    <div class="card-image">
                        <img src="http://wallpapercave.com/wp/ofoImjh.jpg">
                        <span class="card-title">Card Title</span>
                    </div>
                    <div class="card-content">
                        <p>
                            I am a very simple card. I am good at containing small bits of information.
              I am convenient because I require little markup to use effectively.
                        </p>
                    </div>
                    <div class="card-action">
                        <a href="#">This is a link</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <a href="News.aspx" class="right btn">More news...</a>
        </div>
    </div>
</asp:Content>