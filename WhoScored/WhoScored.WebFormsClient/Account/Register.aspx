<%@ Page Title="Register" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WhoScored.WebFormsClient.Account.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type='text/css'>
        body {
            background-image: url('/photos/background-image.jpg');
            background-size: cover;
            background-position: top center;
        }
    </style>
    <div class="container">
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <div class="row">
            <div class="card-panel">

                <div class="row center">
                    <h5>Register</h5>
                </div>
                <div class="row">
                    <div class="input-field col s6">
                        <asp:Label runat="server">Username *</asp:Label>
                        <asp:TextBox runat="server" ID="Username" />
                        <div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                                CssClass="red-text" ErrorMessage="The username field is required." />
                        </div>
                    </div>
                    <div class="input-field col s6">
                        <asp:Label runat="server">E-mail *</asp:Label>
                        <asp:TextBox runat="server" ID="Email" TextMode="Email" />
                        <div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="red-text" ErrorMessage="The e-mail field is required." />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="red-text" ErrorMessage="You must enter a valid e-mail." />
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col s6">
                        <asp:Label runat="server">Password *</asp:Label>
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                        <div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                CssClass="red-text" ErrorMessage="The password field is required." />
                        </div>


                    </div>
                    <div class="col s6">
                        <asp:Label runat="server">Confirm password *</asp:Label>
                        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                        <div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                CssClass="red-text" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                            <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                CssClass="red-text" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                        </div>

                    </div>
                </div>

                <div class="row">
                    <div class="col s6">
                        <asp:Label runat="server">First name *</asp:Label>
                        <asp:TextBox runat="server" ID="FirstName" />
                        <div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                                CssClass="red-text" ErrorMessage="The first name field is required." />
                        </div>


                    </div>
                    <div class="col s6">
                        <asp:Label runat="server">Last name *</asp:Label>
                        <asp:TextBox runat="server" ID="LastName" AssociatedControlID="LastName" />

                        <div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                                CssClass="red-text" ErrorMessage="The last name field is required." />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Profile picture</asp:Label>
                    <asp:FileUpload ID="AvatarFileUpload" runat="server" AllowMultiple="false" />
                </div>

                <div class="row center">
                    <div class="col s12">
                        <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default brown" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
