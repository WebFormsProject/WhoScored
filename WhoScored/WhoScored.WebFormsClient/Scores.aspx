<%@ Page Title="Scores" Language="C#" AutoEventWireup="true" MasterPageFile="~/Public.Master" CodeBehind="Scores.aspx.cs" Inherits="WhoScored.WebFormsClient.Scores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <ul class="collection">
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
        </ul>--%>
</asp:Content>