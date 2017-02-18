<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WhoScored.WebFormsClient.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col s8 m8 offset-m2 l6 offset-l3 hoverable">
            <div class="card-panel grey lighten-5 z-depth-1">
                <div class="text-center">
                    <asp:Label ID="UserLabel" runat="server"></asp:Label>
                    <br />
                    <asp:Image ID="UserAvatar" AlternateText="avatar" runat="server" CssClass="avatar responsive-img circle" />
                </div>
            </div>
            <%--<asp:FileUpload ID="TrollPhotoFileUpload" runat="server" OnDataBinding="TrollPhotoFileUpload_DataBinding" />--%>
        </div>
    </div>
</asp:Content>
