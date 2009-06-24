<%@ Control Language="C#" Inherits="ViewUserControl<ViewPlayerDto>" %>
<%@ Import Namespace="WarOfWorldcraft.Domain.Services"%>

<fieldset>
<legend>Stats</legend>
Experience: <%= Model.Experience %> <br />
Hit Points: <%= Model.HitPoints %>/<%= Model.MaxHitPoints %> <br />
Attack: <%= Model.Attack %><br />
Defense: <%= Model.Defence %> <br />
</fieldset>

    <p>
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>


