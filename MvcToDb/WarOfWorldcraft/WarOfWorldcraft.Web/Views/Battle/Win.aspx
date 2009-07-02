<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<ViewChallengeDto>" %>
<%@ Import Namespace="WarOfWorldcraft.Domain.Services"%>

<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">
You win
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">

    <h2>You killed the <%= Model.Monster.Name %></h2>
    <div id="player">
    <%= Model.Player.Name %>
    <%= Model.Player.HitPoints %> / <%= Model.Player.MaxHitPoints %>
    </div>
    <div id="monster">
    <%= Model.Monster.Name %>
    <%= Model.Monster.HitPoints%> / <%= Model.Monster.MaxHitPoints%>
    </div>

</asp:Content>