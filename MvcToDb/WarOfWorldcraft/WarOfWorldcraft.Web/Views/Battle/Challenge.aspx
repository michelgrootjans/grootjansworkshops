<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<ViewChallengeDto>" %>
<%@ Import Namespace="WarOfWorldcraft.Domain.Services"%>

<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Challenge</h2>
    
    <div id="player">
    <%= Model.Player.Name %>
    <%= Model.Player.StatsHitPoints %> / <%= Model.Player.StatsMaxHitPoints %>
    </div>
    <div id="monster">
    <%= Model.Monster.Name %>
    <%= Model.Monster.StatsHitPoints%> / <%= Model.Monster.StatsMaxHitPoints%>
    </div>

</asp:Content>