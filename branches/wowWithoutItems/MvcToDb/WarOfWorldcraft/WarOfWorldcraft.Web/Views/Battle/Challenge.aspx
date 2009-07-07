<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<ViewChallengeDto<ViewPlayerDto, ViewMonsterDto>>" %>
<%@ Import Namespace="WarOfWorldcraft.Domain.Dto"%>

<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">

<h2>Challenge</h2>

<div id="player">
    <%= Model.Player.Name %>
	<%= Model.Player.HitPoints %> / <%= Model.Player.MaxHitPoints %>
</div>

<div id="monster">
    <%= Model.Monster.Name %>
    <%= Model.Monster.HitPoints%> / <%= Model.Monster.MaxHitPoints%>
</div>
    
<% using (Html.BeginForm("Attack", "Battle")) { %>
    <%= Html.Hidden("monsterId", Model.Monster.Id) %>
    <%= this.SubmitButton("Attack") %>
<% } %>

<br />
<%= Html.ActionLink("Back to list ...", "index") %>
</asp:Content>