<%@ Control Language="C#" Inherits="ViewUserControl<ViewCharacterDto>" %>
<%@ Import Namespace="WarOfWorldcraft.Domain.Services"%>

<fieldset>
<legend>Stats</legend>
Experience: <%= Model.Experience %> <br />
Hit Points: <%= Model.StatsHitPoints %>/<%= Model.StatsMaxHitPoints %> <br />
Attack: <%= Model.StatsAttack %><br />
Defense: <%= Model.StatsDefence %> <br />
</fieldset>

    <p>
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>


