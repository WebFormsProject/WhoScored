<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.Master" CodeBehind="ManageLeagues.aspx.cs" Inherits="WhoScored.WebFormsClient.Admin.ManageLeagues" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderAdminArea" runat="server">
    <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
        <asp:ListView ID="ListView1" runat="server" ItemType="WhoScored.Models.Models.League"
            SelectMethod="GetAllLeagues" DeleteMethod="DeleteLeague" UpdateMethod="UpdateLeague" InsertMethod="AddLeague"
            InsertItemPosition="LastItem" 
            DataKeyNames="Id">
            <LayoutTemplate>
                <table class="gridview" cellspacing="0" rules="all" border="1" id="MainContent_GridViewCategories" style="border-collapse: collapse;">
                    <tbody>
                        <tr>
                            <th scope="col">
                                <asp:LinkButton Text="League Name" runat="server" ID="LinkButtonSortByCategory" CommandName="Sort" CommandArgument="Name" />
                            </th>
                            <th scope="col">
                                <asp:LinkButton Text="Country" runat="server" ID="LinkButton1" CommandName="Sort" CommandArgument="Name" />
                            </th>
                            <th scope="col">Action</th>
                        </tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        <tr>
                            <td colspan="2">
                                <%--  <asp:DataPager runat="server" ID="DataPagerCategories" PageSize="5">
                                    <Fields>
                                        <asp:NumericPagerField />
                                    </Fields>
                                </asp:DataPager>--%>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#: Item.Name %></td>
                    <td><%#: Item.Country.Name %></td>
                    <td>
                        <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-xs blue-grey" />
                        <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-xs red" />
                    </td>
                </tr>
            </ItemTemplate>
            <EditItemTemplate>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TextBox2" Text="<%#: BindItem.Name %>" />
                        <asp:DropDownList runat="server" ID="SelectCountryDropdown" DataTextField="Name" DataValueField="Id"
                            DataSource="<%# GetCountries() %>"
                            AutoPostBack="False" CssClass="player-selector"
                            ItemType="WhoScored.Models.Models.Country"
                            SelectedValue='<%# Bind("CountryId") %>'>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-xs blue-grey" />
                        <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-xs red" />
                    </td>
                </tr>
            </EditItemTemplate>
            <InsertItemTemplate>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TextBox3" Text="<%#: BindItem.Name %>" />
                        <asp:DropDownList runat="server" ID="SelectCountryDropdown" DataTextField="Name" DataValueField="Id"
                            DataSource="<%# GetCountries() %>"
                            AutoPostBack="False" CssClass="player-selector"
                            ItemType="WhoScored.Models.Models.Country"
                            SelectedValue='<%# Bind("CountryId") %>'>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" CommandName="Insert" Text="Insert" CssClass="btn btn-xs blue-grey" />
                        <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-xs red" />
                    </td>
                </tr>
            </InsertItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
