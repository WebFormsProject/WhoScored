<%@ Page Title="Player" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Player.aspx.cs" Inherits="WhoScored.WebFormsClient.Player" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:FormView runat="server" ID="TeamFormView" SelectMethod="FormViewPlayer_GetData" ItemType="WhoScored.Models.Models.FootballPlayer">
            <ItemTemplate>
                <div class="row">
                    <div class="col s4">
                        <div class="center-block center">
                            <img src="<%# Eval("ImagePath") %>" class="player-image hoverable" />
                        </div>
                        <div class="center-block center-align">
                            <h3><%#: Eval("FirstName")%> <%#: Eval("LastName")%></h3>
                        </div>
                    </div>
                    <div class="col s6 right player-info-panel">
                        <div class="card-panel brown lighten-5 text-center">
                            <h5>Player Information</h5>
                        </div>
                        <div>
                            <table class="bordered">
                                <tr>
                                    <th>Current team</th>
                                    <td><%# Item.CurrentTeam.Name %></td>
                                </tr>
                                <tr>
                                    <th>Country</th>
                                    <td><%# Item.Country.Name %></td>
                                </tr>
                                <tr>
                                    <th>Position</th>
                                    <td><%# Item.Position %></td>
                                </tr>
                                <tr>
                                    <th>Shirt number</th>
                                    <td><%# Item.ShirtNumber %></td>
                                </tr>
                                <tr>
                                    <th>Birth date</th>
                                    <td><%# string.Format("{0:dd/MM/yyyy}", Item.BirthDate) %></td>
                                </tr>
                                <tr>
                                    <th>Height</th>
                                    <td><%# Item.Height %></td>
                                </tr>
                                <tr>
                                    <th>Weight</th>
                                    <td><%# Item.Weight %></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>
