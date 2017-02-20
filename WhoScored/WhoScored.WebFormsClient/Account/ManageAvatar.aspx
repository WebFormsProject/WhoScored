<%@ Page Title="Manage Avatar" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="ManageAvatar.aspx.cs" Inherits="WhoScored.WebFormsClient.Account.ManageAvatar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="form-horizontal">
        <section id="avatarForm">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="form-group">
                       <%-- TODO: VISIBILITY!!!--%>
                        <div class="col-md-10">
                            <asp:Image Width="200" Height="200" runat="server" ID="AvatarImage" />
                        </div>
                        <asp:Label AssociatedControlID="AvatarFileUpload" runat="server" CssClass="btn btn-warning">Upload avatar</asp:Label>
                        <asp:FileUpload ID="AvatarFileUpload" runat="server" CssClass="upload-button" AllowMultiple="true" />
                        <asp:Button ID="UploadAvatarButton" runat="server" OnClick="UploadAvatarButton_Click" Text="Upload" CssClass="btn btn-success" />
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="UploadAvatarButton" />
                </Triggers>
            </asp:UpdatePanel>
        </section>
    </div>
</asp:Content>
