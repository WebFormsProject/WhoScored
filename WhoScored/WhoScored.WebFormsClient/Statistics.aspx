<%@ Page Title="Statistics" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="WhoScored.WebFormsClient.Statistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:FormView ID="StatisticsFormView" runat="server" AutoGenerateRows="true" ItemType="WhoScored.Models.Models.Team">
            <ItemTemplate>
                <h2><%# Item.Id %>. <%# Item.Name %> </h2>
<%--                <p>Players: <%# string.Join(", ", Item.FootballPlayers) %></p>
                <p>Titles: <%# string.Join(", ", Item.Titles) %></p>--%>
            </ItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>
