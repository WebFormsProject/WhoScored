<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WhoScored.WebFormsClient.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main blue-grey lighten-5">
        <div>
            <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                <p class="text-success"><%: SuccessMessage %></p>
            </asp:PlaceHolder>
        </div>
        <div class="container text-center">
            <div class="row">
                <div class="col s5">
                    <h4>Hello,</h4>
                    <h3><%: User.Identity.GetUserName() %> </h3>
                    <asp:Image ID="UserAvatar" AlternateText="avatar" runat="server" CssClass="avatar responsive-img circle" />
                </div>
                <div class="col s6 z-depth-1 hoverable profile-addon grey lighten-4">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <h4>Upload a troll photo</h4>
                                <asp:TextBox ID="TrollPhotoNameTextBox" runat="server" placeholder="Enter a name"></asp:TextBox>
                                <asp:FileUpload ID="TrollPhotoFileUpload" runat="server" AllowMultiple="true" />
                                <asp:Button ID="UploadTrollPhotoButton" runat="server" OnClick="UploadTrollPhotoButton_Click" Text="Upload" CssClass="waves-effect waves-light btn teal lighten-4" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="UploadTrollPhotoButton" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="col s6 z-depth-1 hoverable profile-addon grey lighten-4">
                    <div class="form-group">
                        <h4>Manage your account</h4>
                        <asp:LinkButton PostBackUrl="~/Account/Manage.aspx" runat="server" CssClass="waves-effect waves-light btn teal lighten-4">Manage</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
