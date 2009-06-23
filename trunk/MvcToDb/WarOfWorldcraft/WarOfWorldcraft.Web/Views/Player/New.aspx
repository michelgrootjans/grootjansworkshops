<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">
Create a new Player
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create a new player</h2>
    <% using (Html.BeginForm("Create", "Player")) { %>
        Name: <%= Html.TextBox("name") %>
        <input type="submit" value="Create" />
    <% } %>
</asp:Content>