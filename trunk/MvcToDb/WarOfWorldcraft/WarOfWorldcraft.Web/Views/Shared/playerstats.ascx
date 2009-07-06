<%@ Control Language="C#" Inherits="ViewUserControl<ViewPlayerDto>" %>
<%@ Import Namespace="WarOfWorldcraft.Domain.Services"%>

<% if (Model is NullPlayerDto) {%>
    You don't have a player yet. <%= Html.ActionLink("You can create one here...", "new", "player")%>
<% } else { %>
    <table class="playerstats">
    <tr>
        <td colspan="2"><%= Model.Name %></td>
    </tr>
    <tr>
        <td>Gold</td>
        <td><%= Model.Gold %></td>
    </tr>
    <tr>
        <td>Hit points</td>
        <td><%= Model.HitPoints %>/<%= Model.MaxHitPoints %> (<%= Model.PercentHitPoints %> %)</td>
    </tr>
    <tr>
        <td>Level</td>
        <td><%= Model.Level %></td>
    </tr>
    <tr>
        <td>XP</td>
        <td><%= Model.Experience %></td>
    </tr>
    <tr>
        <td>ATK</td>
        <td><%= Model.Attack %></td>
    </tr>
    <tr>
        <td>DEF</td>
        <td><%= Model.Defence %></td>
    </tr>
    </table>
<% } %>
