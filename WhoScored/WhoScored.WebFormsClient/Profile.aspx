<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WhoScored.WebFormsClient.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div>
            <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                <p class="text-success"><%: SuccessMessage %></p>
            </asp:PlaceHolder>
        </div>
        <div class="col s8 m8 offset-m2 l6 offset-l3 hoverable">
            <div class="card-panel grey lighten-5 z-depth-1">
                <div class="text-center">
                    <asp:Label ID="UserLabel" runat="server"></asp:Label>
                    <br />
                    <asp:Image ID="UserAvatar" AlternateText="avatar" runat="server" CssClass="avatar responsive-img circle" />
                </div>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="form-group text-center">
                        <asp:Label AssociatedControlID="TrollPhotoFileUpload" runat="server" CssClass="label label-warning">Upload a troll photo</asp:Label>
                        <asp:TextBox ID="TrollPhotoNameTextBox" runat="server" placeholder="Enter a name"></asp:TextBox>
                        <asp:FileUpload ID="TrollPhotoFileUpload" runat="server" AllowMultiple="true" />
                        <asp:Button ID="UploadTrollPhotoButton" runat="server" OnClick="UploadTrollPhotoButton_Click" Text="Upload" CssClass="btn btn-warning" />
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="UploadTrollPhotoButton" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
