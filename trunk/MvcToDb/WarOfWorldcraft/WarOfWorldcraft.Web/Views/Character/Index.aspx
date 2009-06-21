<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<IEnumerable<ViewCharacterInfoDto>>" %>
<%@ Import Namespace="WarOfWorldcraft.Web.Helpers"%>
<%@ Import Namespace="WarOfWorldcraft.Utilities.Extensions"%>
<%@ Import Namespace="WarOfWorldcraft.Domain.Services"%>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="server">
	All characters in this game
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Characters</h2>

<% if (Model.HasNoItems()) { %>
    This game doesn't have any characters at the moment.
<% } else { %>
    <table>
        <thead>
        <tr>
            <th>Name</th>
            <th>HP</th>
            <th>XP</th>
            <th>Gold</th>
        </tr>       
        </thead>
        <tbody>
<% foreach (var character in Model) { %>
            <tr>
                <td><%= Html.ActionLink(character.Name, "detail", character.Id.ToIdRoute())%></td>
                <td><%= character.StatsMaxHitPoints%></td>
                <td><%= character.Experience%></td>
                <td><%= character.Gold%></td>
            </tr>        
<% } %>
        </tbody>
    </table>
<% } %>

<%= Html.ActionLink("Create new...", "new") %>
</asp:Content>
