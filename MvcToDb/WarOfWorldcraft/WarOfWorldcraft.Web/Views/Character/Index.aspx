<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<IEnumerable<ViewCharacterInfoDto>>" %>
<%@ Import Namespace="WarOfWorldcraft.Web.Helpers"%>
<%@ Import Namespace="WarOfWorldcraft.Utilities.Extensions"%>
<%@ Import Namespace="WarOfWorldcraft.Domain.Services"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	All characters available in this game
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
        </tr>       
        </thead>
        <tbody>
<% foreach (var character in Model) { %>
            <tr>
                <td><%= Html.ActionLink(character.Name, "detail", character.Id.ToIdRoute())%></td>
            </tr>        
<% } %>
        </tbody>
    </table>
<% } %>
</asp:Content>
