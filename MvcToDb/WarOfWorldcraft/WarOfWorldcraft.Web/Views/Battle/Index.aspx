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
            column.For(monster => Html.ActionLink(monster.Name, "challenge", monster.Id.ToIdRoute()))
                  .Named("Name").DoNotEncode();
     		column.For(monster => monster.Level);
     	})
            .Empty(string.Format("There are no monsters right now. You can might want to {0}.", Html.ActionLink("generate monsters", "Generate", "Monster")))
%>
     	
</asp:Content>
