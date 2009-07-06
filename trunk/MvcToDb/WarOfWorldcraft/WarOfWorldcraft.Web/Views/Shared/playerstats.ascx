<%@ Control Language="C#" Inherits="ViewUserControl<ViewPlayerDto>" %>
<%@ Import Namespace="WarOfWorldcraft.Domain.Services"%>

<table class="playerstats">
<tr>
    <td colspan="2"><%= Model.Name %></td>
</tr>
<tr>
    <td>Hit points</td>
    <td><%= Model.HitPoints %>/<%= Model.MaxHitPoints %> (<%= Model.PercentHitPoints %> %)</td>
    <td>ATK</td>
    <td><%= Model.Attack %></td>
    <td>DEF</td>
    <td><%= Model.Defence %></td>
</tr>
</table>