<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WhoScored.WebFormsClient.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:ListView runat="server"
            ID="ListViewProfile"
            ItemType="WhoScored.Models.Models.User">
            <ItemTemplate>
                <div class="col s12 m8 offset-m2 l6 offset-l3 hoverable">
                    <div class="card-panel grey lighten-5 z-depth-1">
                        <div class="row valign-wrapper">

                            <div class="col s10">
                                <span class="black-text">Hello,
                                <h5>Test</h5>
                                </span>
                            </div>
                            <div class="col s2">
                                <img src="" alt="User's avatar" class="circle responsive-img">
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
