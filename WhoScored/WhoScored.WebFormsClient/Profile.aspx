<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WhoScored.WebFormsClient.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col s8 m8 offset-m2 l6 offset-l3 hoverable">
            <div class="card-panel grey lighten-5 z-depth-1">
                <div class="text-center">
                    <h4><%# this.User.Identity.GetUserName() %></h4>
                    <img src="photos/Avatars/default.png" alt="avatar" class="avatar responsive-img circle" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
