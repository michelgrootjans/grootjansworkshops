<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create a new character</h2>
    <% using (Html.BeginForm("Create", "Character")) { %>
        Name: <%= Html.TextBox("name") %>
        <input type="submit" value="Create" />
    <% } %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">
Create a new character
</asp:Content>
