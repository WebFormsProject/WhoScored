<%@ Page Title="Leagues" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Leagues.aspx.cs" Inherits="WhoScored.WebFormsClient.Leagues" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView runat="server"
        ID="ListViewLeagues"
        ItemType="WhoScored.Models.Models.League"
        SelectMethod="ListViewLeagues_GetData">
        <ItemTemplate>
            <div class="col s12 m8 offset-m2 l6 offset-l3">
                <div class="card-panel grey lighten-5 z-depth-1">
                    <div class="row valign-wrapper">
                        <div class="col s2">
                            <img src="<%#: Item.LeaugeLogo %>" alt="" class="circle responsive-img">
                        </div>
                        <div class="col s10">
                            <span class="black-text">
                                <h5>
                                    <asp:HyperLink NavigateUrl='<%# string.Format("~/LeaguesTable?id={0}", Item.Id) %>' runat="server" Text='<%#: Item.Name %>' />
                                    <p><%#: Item.Country.Name %></p>
                                </h5>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
