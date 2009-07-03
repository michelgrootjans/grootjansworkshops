<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<IEnumerable<ViewPlayerInfoDto>>" %>
<%@ Import Namespace="MvcContrib.UI.Grid"%>
<%@ Import Namespace="WarOfWorldcraft.Web.Helpers"%>
<%@ Import Namespace="WarOfWorldcraft.Utilities.Extensions"%>
<%@ Import Namespace="WarOfWorldcraft.Domain.Services"%>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="server">
	All players in game
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Players</h2>

<%=
    Html.Grid(Model).Columns(column => {
            column.For(player => Html.ActionLink(player.Name, "detail", player.Id.ToIdRoute()))
                  .Named("Name").DoNotEncode();
     		column.For(player => player.MaxHitPoints).Named("HP");
            column.For(player => player.Experience).Named("XP");
            column.For(player => player.Gold);
     	})
            .Empty("This game doesn't have any players at the moment.")
%>


<%= Html.ActionLink("Create new...", "new") %>
</asp:Content>
