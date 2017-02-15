<%@ Page Title="TrollPhotos" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="TrollPhotos.aspx.cs" Inherits="WhoScored.WebFormsClient.TrollPhotos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress AssociatedUpdatePanelID="TrollPhotosUpdatePanel" runat="server">
        <ProgressTemplate>
                <asp:Image runat="server" ImageUrl="~/animations/ajax-loader.gif" AlternateText="Loading ..." ToolTip="Loading ..." />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="TrollPhotosUpdatePanel" runat="server">
        <ContentTemplate>
            <div class="text-center">
                <asp:Button ID="ButtonPrevious" Text="<<" runat="server" OnClick="ButtonPrevious_Click" />
                <asp:Image ID="SelectedImage" Width="580" runat="server" />
                <asp:Button ID="ButtonNext" Text=">>" runat="server" OnClick="ButtonNext_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
