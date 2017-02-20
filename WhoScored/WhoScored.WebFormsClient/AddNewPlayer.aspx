<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Public.Master" CodeBehind="AddNewPlayer.aspx.cs" Inherits="WhoScored.WebFormsClient.AddNewPlayer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:GridView runat="server" SelectMethod="GetFootballPlayers" AutoGenerateColumns="False"
            ItemType="WhoScored.Models.Models.FootballPlayer">
            <Columns>
                <%--       <asp:BoundField HeaderText="Id" DataField="Id" />
                <asp:BoundField HeaderText="First name" DataField="FirstName" />
                <asp:BoundField HeaderText="Last name" DataField="LastName" />
                <asp:BoundField HeaderText="Image" DataField="ImagePath" />
                <asp:BoundField HeaderText="Position" DataField="Position" />
                <asp:BoundField HeaderText="Shirt Number" DataField="ShirtNumber" />
                <asp:BoundField HeaderText="Birth date" DataField="BirthDate" />
                <asp:BoundField HeaderText="Height" DataField="Height" />
                <asp:BoundField HeaderText="Weight" DataField="Weight" />
                <asp:BoundField HeaderText="Country" DataField="Country.Name" />
                <asp:BoundField HeaderText="Team" DataField="CurrentTeam.Name" />--%>
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label runat="server" Text="<%# Item.FirstName %>"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Item.FirstName %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label runat="server" Text="<%# Item.LastName %>"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Item.LastName %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label runat="server" Text="<%# Item.ImagePath %>"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Item.ImagePath %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label runat="server" Text="<%# Item.Position %>"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Item.Position %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label runat="server" Text="<%# Item.ShirtNumber %>"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" TextMode="Number" Text='<%# Item.ShirtNumber %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                
                  <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label runat="server" Text="<%# Item.Height %>"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Item.Height %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label runat="server" Text="<%# Item.Weight %>"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" TextMode="Number" Text='<%# Item.Weight %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label runat="server" Text="<%# Item.Country.Name %>"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList runat="server" ID="SelectCurrentTeamDropdown"
                            AutoPostBack="False" SelectMethod="GetCountries" CssClass="player-selector">
                        </asp:DropDownList>
                       <%-- <asp:TextBox runat="server" Text='<%# Item.Country.Name %>' />--%>
                    </EditItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label runat="server" Text="<%# Item.CurrentTeam.Name %>"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList runat="server" ID="SelectCurrentTeamDropdown"
                            AutoPostBack="False" SelectMethod="GetCountries" CssClass="player-selector">
                        </asp:DropDownList>
                        <%--<asp:TextBox runat="server" Text='<%# Item.CurrentTeam.Name %>' />--%>
                    </EditItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label runat="server" Text="<%# Item.BirthDate %>"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" TextMode="Date"/>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn" />
                        <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-danger" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Update" CssClass="btn" />
                        <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-danger" />
                    </EditItemTemplate>
                    <%--	<footertemplate>
					<asp:Button id="btnInsert" runat="server" commandname="Insert" text="Insert" />
				</footertemplate>--%>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
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
