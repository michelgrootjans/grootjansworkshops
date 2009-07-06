<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<ViewAllPlayersDto>" %>
<%@ Import Namespace="WarOfWorldcraft.Domain.Dto"%>
<%@ Import Namespace="MvcContrib.UI.Grid"%>
<%@ Import Namespace="WarOfWorldcraft.Web.Helpers"%>
<%@ Import Namespace="WarOfWorldcraft.Utilities.Extensions"%>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="server">
	Players
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="tabs">
    <ul>
        <li><a href="#livingPlayers">Players</a></li>
        <li><a href="#deadPlayers">Cemetary</a></li>
    </ul>
</div>

<div id="livingPlayers">
    <%=
        Html.Grid(Model.LivingPlayers).Columns(column => {
                column.For(player => Html.ActionLink(player.Name, "detail", player.Id.ToIdRoute()))
                      .Named("Name").DoNotEncode();
     		    column.For(player => player.MaxHitPoints).Named("HP");
                column.For(player => player.Experience).Named("XP");
                column.For(player => player.Gold);
     	    })
                    .Empty(Html.ActionLink("There's nobody here. You might want to join...", "new"))
    %>
</div>

<div id="deadPlayers">
    <h3>Players who are no longer with us...</h3>
    <%=
        Html.Grid(Model.DeadPlayers).Columns(column => {
                column.For(player => Html.ActionLink(player.Name, "detail", player.Id.ToIdRoute()))
                      .Named("Name").DoNotEncode();
     		    column.For(player => player.MaxHitPoints).Named("HP");
                column.For(player => player.Experience).Named("XP");
                column.For(player => player.Gold);
     	    })
                .Empty("Nobody died... yet.")
    %>
</div>


</asp:Content>
