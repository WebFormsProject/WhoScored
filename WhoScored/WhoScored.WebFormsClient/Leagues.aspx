<%@ Page Title="Leagues" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Leagues.aspx.cs" Inherits="WhoScored.WebFormsClient.Leagues" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="LeaguesGridView" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="Id"/>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="LeaguesTable?id={0}" DataTextField="Name"/>
        </Columns>
    </asp:GridView>
</asp:Content>
