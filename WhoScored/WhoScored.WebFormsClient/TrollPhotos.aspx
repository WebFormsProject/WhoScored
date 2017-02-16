<%@ Page Title="TrollPhotos" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="TrollPhotos.aspx.cs" Inherits="WhoScored.WebFormsClient.TrollPhotos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
        <div class="row text-center">
            <%--<div class="col s12 text-center">--%>
                <asp:UpdateProgress AssociatedUpdatePanelID="TrollPhotosUpdatePanel" runat="server">
                    <ProgressTemplate>
                        <asp:Image runat="server" ImageUrl="~/animations/ajax-loader.gif" AlternateText="Loading ..." ToolTip="Loading ..." CssClass="animation-loading"/>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            <%--</div>
            <div class="col s12">--%>
                <asp:UpdatePanel ID="TrollPhotosUpdatePanel" runat="server">
                    <ContentTemplate>
                        <%--<div class="text-center align-middle">--%>
                            <asp:Button ID="ButtonPrevious" Text="<<" runat="server" OnClick="ButtonPrevious_Click" CssClass="btn waves-effect waves-light grey lighten-5" />
                            <asp:Image ID="SelectedImage" Width="640" runat="server" CssClass="responsive-img" />
                            <asp:Button ID="ButtonNext" Text=">>" runat="server" OnClick="ButtonNext_Click" CssClass="btn waves-effect waves-light grey lighten-5" />
                       <%-- </div>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
           <%-- </div>--%>
        </div>
</asp:Content>
