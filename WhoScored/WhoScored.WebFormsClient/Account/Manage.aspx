<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="WhoScored.WebFormsClient.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2><%: Title %></h2>
        <div>
            <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                <p class="text-success"><%: SuccessMessage %></p>
            </asp:PlaceHolder>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-horizontal">
                    <h4>Change your account settings</h4>
                    <hr />
                    <dl class="dl-horizontal">
                        <dt>Password:</dt>
                        <dd>
                            <asp:HyperLink NavigateUrl="/account/managePassword" Text="Change" Visible="false" ID="ChangePassword" runat="server" />
                        </dd>
                    </dl>
                    <dl class="dl-horizontal">
                        <dt>Profile picture:</dt>
                        <dd>
                            <asp:HyperLink NavigateUrl="/account/manageAvatar" Text="Change" Visible="true" ID="ChangeAvatar" runat="server" />
                        </dd>
                    </dl>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
