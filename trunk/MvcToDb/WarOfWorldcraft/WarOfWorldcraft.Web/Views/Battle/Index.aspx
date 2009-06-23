<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<IEnumerable<ViewMonsterInfoDto>>" %>
<%@ Import Namespace="MvcContrib.UI.Grid"%>
<%@ Import Namespace="WarOfWorldcraft.Web.Helpers"%>
<%@ Import Namespace="WarOfWorldcraft.Utilities.Extensions"%>
<%@ Import Namespace="WarOfWorldcraft.Domain.Services"%>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="server">
	Show all enemies
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h2>Battle arena</h2>

<h3>Choose an enemy to challenge:</h3>
<%=
    Html.Grid(Model).Columns(column => {
            column.For(x => Html.ActionLink(x.Name, "challenge", x.Id.ToIdRoute()))
                  .Named("Name").DoNotEncode();
     		column.For(x => x.StatsMaxHitPoints).Named("HP");
     	})
     	.Empty("There are no ennemies.")
%>
     	
</asp:Content>
