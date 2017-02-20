<%@ Page Title="TrollPhotos" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="TrollPhotos.aspx.cs" Inherits="WhoScored.WebFormsClient.TrollPhotos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="gallery text-center">
        <asp:UpdateProgress AssociatedUpdatePanelID="TrollPhotosUpdatePanel" runat="server">
            <ProgressTemplate>
                <asp:Image runat="server" ImageUrl="~/animations/ajax-loader.gif" AlternateText="Loading ..." ToolTip="Loading ..." CssClass="animation-loading" />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="TrollPhotosUpdatePanel" runat="server">
            <ContentTemplate>
                <asp:Button ID="ButtonPrevious" Text="<< Previous" runat="server" OnClick="ButtonPrevious_Click" CssClass="btn waves-effect waves-light grey lighten-5 btn-next-prev" />
                <div class="selected-image text-center">
                    <asp:Image ID="SelectedImage" runat="server" CssClass="image-responsive" />
                </div>
                <asp:Button ID="ButtonNext" Text="Next >>" runat="server" OnClick="ButtonNext_Click" CssClass="btn waves-effect waves-light grey lighten-5 btn-next-prev" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>