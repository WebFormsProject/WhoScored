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
        <h3>
            Squad
        </h3>
        <ul class="collection">
            <asp:Repeater ID="RepeaterPeople" runat="server"
                DataSource="<%# GetCurrentPlayers() %>" ItemType="WhoScored.Models.Models.FootballPlayer">
                <ItemTemplate>
                    <li class="collection-item avatar">
                        <img src="<%#: Item.ImagePath %>" alt="" class="circle">
                        <span class="title"><%#: Item.FirstName %> <%#: Item.LastName %></span>
                        <p><%#: Item.Position %></p>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
