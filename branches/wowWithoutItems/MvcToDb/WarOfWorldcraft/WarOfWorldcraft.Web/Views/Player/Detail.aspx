<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<ViewPlayerDto>" %>
<%@ Import Namespace="WarOfWorldcraft.Domain.Dto"%>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="server">
	<%= Model.Name %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Model.Name %></h2>
    <% Html.RenderPartial("playerstats", Model); %>

</asp:Content>

