<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<IEnumerable<ViewEnemyInfoDto>>" %>
<%@ Import Namespace="MvcContrib.UI.Grid"%>
<%@ Import Namespace="WarOfWorldcraft.Web.Helpers"%>
<%@ Import Namespace="WarOfWorldcraft.Utilities.Extensions"%>
<%@ Import Namespace="WarOfWorldcraft.Domain.Services"%>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="server">
	Show all enemies
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>All available enemies</h2>

<% if (Model.HasNoItems()) { %>
    This game doesn't have any enemies at the moment.
<% } else { %>
    <table>
        <thead>
        <tr>
            <th>Name</th>
            <th>HP</th>
        </tr>       
        </thead>
        <tbody>
<% foreach (var ennemy in Model) { %>
            <tr>
                <td><%= Html.ActionLink(ennemy.Name, "detail", ennemy.Id.ToIdRoute())%></td>
                <td><%= ennemy.StatsMaxHitPoints%></td>
            </tr>        
<% } %>
        </tbody>
    </table>
<% } %>

<%=
    Html.Grid(Model).Columns(column => {
            column.For(x => Html.ActionLink(x.Name, "detail", x.Id.ToIdRoute())).Named("Name").DoNotEncode();
     		column.For(x => x.StatsMaxHitPoints).Named("HP");
     	})
     	.Empty("There are no ennemies.")
%>
     	
</asp:Content>
