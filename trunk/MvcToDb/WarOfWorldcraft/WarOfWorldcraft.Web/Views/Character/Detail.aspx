<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<ViewCharacterDto>" %>
<%@ Import Namespace="WarOfWorldcraft.Domain.Services"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Model.Name %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Model.Name %></h2>
    <% Html.RenderPartial("CharacterDetails", Model); %>

</asp:Content>

