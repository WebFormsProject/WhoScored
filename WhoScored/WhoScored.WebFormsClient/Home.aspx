<%@ Page Title="Home" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WhoScored.WebFormsClient.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <div id="index-banner" class="parallax-container">
            <div class="section no-pad-bot valign-wrapper">
                <div class="container center">
                    <br />
                    <br />
                    <br />
                    <div class="row center" id="home-quote-container">
                        <h3 class="header col s12 light white-text">Football is Freedom, a whole universe!</h3>
                    </div>
                    <div class="row center">
                        <a href="/leagues.apsx" id="download-button" class="btn-large waves-effect waves-light brown lighten-4">Get Started</a>
                    </div>
                </div>
            </div>
            <div class="parallax">
                <img src="photos/background-1.jpg" alt="Unsplashed background img 1" id="background-home-image">
            </div>
        </div>
</asp:Content>
