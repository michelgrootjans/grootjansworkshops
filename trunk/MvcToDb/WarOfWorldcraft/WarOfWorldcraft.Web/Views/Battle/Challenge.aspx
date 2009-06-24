<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<ViewChallengeDto>" %>
<%@ Import Namespace="WarOfWorldcraft.Domain.Services"%>

<asp:Content ID="Content2" ContentPlaceHolderID="titleContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">

    <h2>Challenge</h2>
    <h3>TODO: show progress bar instead of numbers</h3>
    <div id="player">
    <%= Model.Player.Name %>
    	<div id="progressbar"></div><%= Model.Player.HitPoints %> / <%= Model.Player.MaxHitPoints %>
    <script type="text/javascript">
    $(function() {
        $("#progressbar").progressbar({value: <%= Model.Player.PercentHitPoints %>});
    });
    </script>



<div class="demo">


</div><!-- End demo -->
    </div>
    <div id="monster">
    <%= Model.Monster.Name %>
    <%= Model.Monster.HitPoints%> / <%= Model.Monster.MaxHitPoints%>
    </div>
    
    <% using (Html.BeginForm("Attack", "Battle")) { %>
    <%= Html.Hidden("monsterId", Model.Monster.Id) %>
    <%= this.SubmitButton("Attack") %>
    <% } %>

</asp:Content>