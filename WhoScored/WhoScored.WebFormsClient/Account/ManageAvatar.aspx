<%@ Page Title="Manage Avatar" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="ManageAvatar.aspx.cs" Inherits="WhoScored.WebFormsClient.Account.ManageAvatar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>
    <div class="form-horizontal">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="form-group text-center">
                    <asp:Label AssociatedControlID="AvatarFileUpload" runat="server" CssClass="label label-warning">Upload avatar</asp:Label>
                    <asp:FileUpload ID="AvatarFileUpload" runat="server" AllowMultiple="false" BackColor="Transparent" />
                    <asp:Button ID="UploadAvatarButton" runat="server" OnClick="UploadAvatarButton_Click" Text="Upload" CssClass="btn btn-warning" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="UploadAvatarButton" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
