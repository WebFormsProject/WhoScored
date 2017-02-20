<%@ Page Title="Manage Password" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="ManagePassword.aspx.cs" Inherits="WhoScored.WebFormsClient.Account.ManagePassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section id="passwordForm">
        <asp:PlaceHolder runat="server" ID="changePasswordHolder" Visible="false"></asp:PlaceHolder>
        <div class="container text-center">
            <h2><%: Title %></h2>
            <div class="row">
                <div class="card teal lighten-4">
                    <div class="card-content">
                        <span class="card-title white-text">Choose a new password</span>
                        <div>
                            <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword">Current password</asp:Label>
                            <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                CssClass="text-danger" ErrorMessage="The current password field is required."
                                ValidationGroup="ChangePassword" />
                        </div>
                        <div>
                            <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword">New password</asp:Label>
                            <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                CssClass="text-danger" ErrorMessage="The new password is required."
                                ValidationGroup="ChangePassword" />
                        </div>
                        <div>
                            <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword">Confirm new password</asp:Label>
                            <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                CssClass="text-danger" ErrorMessage="Confirm new password is required."
                                ValidationGroup="ChangePassword" />
                            </div>
                        <div>
                            <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                ValidationGroup="ChangePassword" />
                        </div>
                        <div class="card-action">
                            <asp:Button runat="server" Text="Change Password" ValidationGroup="ChangePassword" OnClick="ChangePassword_Click" CssClass="waves-effect waves-light btn grey darken-1" />
                        </div>
                    </div>
                </div>
            </div>
    </section>
</asp:Content>
