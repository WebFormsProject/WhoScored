<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Public.Master" EnableEventValidation="false"
    CodeBehind="AddNewPlayer.aspx.cs" Inherits="WhoScored.WebFormsClient.AddNewPlayer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row player-container">
        <div class="col s12">
            <h5>Football players</h5>
            <asp:GridView runat="server" SelectMethod="GetFootballPlayers" AutoGenerateColumns="False"
                ItemType="WhoScored.Models.Models.FootballPlayer"
                CellPadding="2" BorderStyle="Solid" BorderColor="#263238" Font-Size="11" DataKeyNames="Id"
                AllowSorting="True" ShowFooter="true"
                UpdateMethod="UpdateFootballPlayer"
                DeleteMethod="DeleteFootballPlayer"
                InsertMethod="InsertFootballPlayer" InsertItemPosition="LastItem" AutoGenerateInsertButton="True">
                <HeaderStyle ForeColor="White" BackColor="#263238"></HeaderStyle>
                <AlternatingRowStyle BackColor="#efebe9"></AlternatingRowStyle>
              
                <Columns>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image runat="server" ImageUrl="<%# Item.ImagePath %>" Width="50" CssClass="circle" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:FileUpload runat="server" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:FileUpload runat="server" />
                        </InsertItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="First name" SortExpression="FirstName">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/Player?id={0}", Item.Id) %>'
                                Text="<%# Item.FirstName %>"></asp:HyperLink>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="FirstNameTextbox" Text='<%#: BindItem.FirstName %>' />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox runat="server" ID="FirstNameTextbox" Text='<%#: BindItem.FirstName %>' />
                        </InsertItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Last name">
                        <ItemTemplate>
                            <asp:Label runat="server" Text="<%# Item.LastName %>"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="LastNameTextbox" Text='<%#: BindItem.LastName %>' />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox runat="server" ID="LastNameTextbox" Text='<%#: BindItem.LastName %>' />

                        </InsertItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Position">
                        <ItemTemplate>
                            <asp:Label runat="server" Text="<%# Item.Position %>"></asp:Label>
                        </ItemTemplate>
                        <InsertItemTemplate>
                            <asp:Label runat="server" Text="<%# Item.Position %>"></asp:Label>

                        </InsertItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Number">
                        <ItemTemplate>
                            <asp:Label runat="server" Text="<%# Item.ShirtNumber %>"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="ShirtNumberTextbox" TextMode="Number" Text='<%#: BindItem.ShirtNumber %>' />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox runat="server" ID="ShirtNumberTextbox" TextMode="Number" Text='<%#: BindItem.ShirtNumber %>' />

                        </InsertItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Height">
                        <ItemTemplate>
                            <asp:Label runat="server" Text="<%# Item.Height %>"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="HeightTextbox" Text='<%#: BindItem.Height %>' />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox runat="server" ID="HeightTextbox" Text='<%#: BindItem.Height %>' />

                        </InsertItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Weight">
                        <ItemTemplate>
                            <asp:Label runat="server" Text="<%# Item.Weight %>"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="WeightTextbox" TextMode="Number" Text='<%#: BindItem.Weight %>' />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox runat="server" ID="WeightTextbox" TextMode="Number" Text='<%#: BindItem.Weight %>' />

                        </InsertItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Country">
                        <ItemTemplate>
                            <asp:Label runat="server" Text="<%# Item.Country.Name %>"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="SelectCountryDropdown" DataTextField="Name" DataValueField="Id"
                                DataSource="<%# GetCountries() %>"
                                AutoPostBack="False" CssClass="player-selector"
                                ItemType="WhoScored.Models.Models.Country"
                                SelectedValue='<%# Bind("CountryId") %>'>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:DropDownList runat="server" ID="SelectCountryDropdown" DataTextField="Name" DataValueField="Id"
                                DataSource="<%# GetCountries() %>"
                                AutoPostBack="False" CssClass="player-selector"
                                ItemType="WhoScored.Models.Models.Country"
                                SelectedValue='<%# Bind("CountryId") %>'>
                            </asp:DropDownList>
                        </InsertItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Team">
                        <ItemTemplate>
                            <asp:Label runat="server" Text="<%# Item.CurrentTeam.Name %>"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="SelectCurrentTeamDropdown" DataSource="<%# GetTeams() %>"
                                ItemType="WhoScored.Models.Models.Team" DataTextField="Name" DataValueField="Id"
                                SelectedValue='<%# Bind("CurrentTeamId") %>'
                                AutoPostBack="False" CssClass="player-selector">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:DropDownList runat="server" ID="SelectCurrentTeamDropdown" DataSource="<%# GetTeams() %>"
                                ItemType="WhoScored.Models.Models.Team" DataTextField="Name" DataValueField="Id"
                                SelectedValue='<%# Bind("CurrentTeamId") %>'
                                AutoPostBack="False" CssClass="player-selector">
                            </asp:DropDownList>
                        </InsertItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Birth date">
                        <ItemTemplate>
                            <asp:Label runat="server" Text="<%# Item.BirthDate %>"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" TextMode="Date" ID="BirthDateTextBox" Text="<%#: BindItem.BirthDate %>" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox runat="server" TextMode="Date" ID="BirthDateTextBox" Text="<%#: BindItem.BirthDate %>" />
                        </InsertItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-xs blue-grey" />
                            <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-xs red" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-xs blue-grey" />
                            <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-xs red" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Insert" CssClass="btn btn-xs blue-grey" />
                            <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-xs red" />
                        </InsertItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="lbInsert" runat="server" CommandName="Insert" Text="Insert"></asp:Button>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>


<%--<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type='text/css'>
        body {
            background-image: url('/photos/background-image.jpg');
            background-size: cover;
            background-position: top center;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="card-panel custom-add-panel">
                <div class="row center">
                    <h5>Add new football player</h5>
                </div>
                <div class="row">
                    <div class="input-field col s6">
                        <asp:Label runat="server" Text="First name" />
                        <asp:TextBox runat="server"></asp:TextBox>
                    </div>
                    <div class="input-field col s6">
                        <asp:Label runat="server" Text="Last name" />
                        <asp:TextBox runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col s6">
                        <asp:Label runat="server" Text="Choose nationality" />
                        <asp:DropDownList runat="server" ID="SelectNationalityDropdown"
                            AutoPostBack="False" SelectMethod="GetCountries" CssClass="player-selector">
                        </asp:DropDownList>
                    </div>
                    <div class="col s6">
                        <asp:Label runat="server" Text="Choose current team" />
                        <asp:DropDownList runat="server" ID="SelectCurrentTeamDropdown"
                            AutoPostBack="False" SelectMethod="GetCountries" CssClass="player-selector">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row">
                    <div class="col s3">
                        <div class="input-field">
                            <asp:Label runat="server" Text="Height" />
                            <asp:TextBox runat="server" ID="HeightTextBox"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="HeightTextBox"
                                                            ErrorMessage="Invalid height" ValidationExpression="[12].[0-9]{2}"/>
                        </div>
                    </div>
                    <div class="col s3">
                        <div class="input-field">
                            <asp:Label runat="server" Text="Weight" />
                            <asp:TextBox runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col s3">
                        <div class="input-field">
                            <asp:Label runat="server" Text="Shirt number" />
                            <asp:TextBox runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">

                    <div class="col s6">
                        <div class="input-field">
                            <asp:Label runat="server" Text="Birth date" />
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col s6">
                        <asp:Label runat="server" Text="Choose player position" />
                        <asp:RadioButtonList ID="PositionRadioButton" runat="server" SelectMethod="GetCountries"></asp:RadioButtonList>
                    </div>
                    <div class="col s6">
                        <asp:Label runat="server" Text="Choose previous teams" />
                        <asp:CheckBoxList ID="CheckBoxPreviousTeams" runat="server" SelectMethod="GetCountries"></asp:CheckBoxList>
                    </div>
                </div>
                <div class="row">
                    <div class="col s6">
                        <asp:Label runat="server" Text="Choose avatar" />
                        <asp:FileUpload runat="server" />
                    </div>
                </div>

                <div class="row center">
                    <div class="col s12">
                        <asp:Button runat="server" Text="Add new player" CssClass="btn btn-large" OnClick="OnClick_AddPlayer" />

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>--%>
