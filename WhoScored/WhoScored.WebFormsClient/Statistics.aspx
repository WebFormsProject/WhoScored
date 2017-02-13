<%@ Page Title="Statistics" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="WhoScored.WebFormsClient.Statistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:GridView runat="server" ID="StatisticsGridView" AutoGenerateColumns="true"></asp:GridView>
    </div>
</asp:Content>
