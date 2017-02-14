<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Public.Master" CodeBehind="LeaguesTable.aspx.cs" Inherits="WhoScored.WebFormsClient.LeaguesTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Here</h1>
    
    <asp:GridView runat="server" ID="LeaguesStatisticsGridView" AutoGenerateColumns="true">
    </asp:GridView>
</asp:Content>
