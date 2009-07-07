<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<HandleErrorInfo>" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="titleContent" runat="server">
    Oops...
</asp:Content>

<asp:Content ID="errorContent" ContentPlaceHolderID="mainContent" runat="server">
    <h2>
        <%= Model.Exception.Message %>
    </h2>
</asp:Content>
