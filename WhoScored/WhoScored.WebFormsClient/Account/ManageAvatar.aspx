<%@ Page Title="Manage Avatar" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="ManageAvatar.aspx.cs" Inherits="WhoScored.WebFormsClient.Account.ManageAvatar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>
    <div class="container text-center">
        <h2><%: Title %></h2>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="card teal lighten-4">
                        <div class="card-content white-text">
                            <span class="card-title">Choose a new profile photo
                                <asp:FileUpload ID="AvatarFileUpload" runat="server" AllowMultiple="false" />
                            </span>
                        </div>
                        <div class="card-action">
                            <asp:Button ID="UploadAvatarButton" runat="server" OnClick="UploadAvatarButton_Click" Text="Upload" CssClass="waves-effect waves-light btn grey darken-1" />
                        </div>
                    </div>
                </div>
                <div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="UploadAvatarButton" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
