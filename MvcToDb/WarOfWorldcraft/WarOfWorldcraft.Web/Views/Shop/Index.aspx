<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ViewShopDto>" %>
<%@ Import Namespace="WarOfWorldcraft.Web.Helpers"%>
<%@ Import Namespace="WarOfWorldcraft.Utilities.Extensions"%>
<%@ Import Namespace="WarOfWorldcraft.Web.Helpers"%>
<%@ Import Namespace="MvcContrib.UI.Grid"%>
<%@ Import Namespace="WarOfWorldcraft.Domain.Services"%>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContent" runat="server">
	Gandalf's BestBuy
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Welcome to Gandalf's Best Buy</h2>
    
    <% if(ViewData["notification"].IsNotNull()){ %>
    <div class="notification"><%= ViewData["notification"] %></div>
    <% } %>
    
    <h3>Shop</h3>
    <%=
        Html.Grid(Model.Catalog.ToList())
            .Empty(Html.ActionLink("I'm sorry, we're sold out at the moment.", "generate", "items"))
            .Columns(column =>
                                             {
                                                 column.For(item => Html.ActionLink(item.Name, "buy", item.Id.ToIdRoute()))
                                                     .Named("Name")
                                                     .DoNotEncode();
                                                 column.For(item => item.Price);
                                             }) %>
    <br />
    <h3>Your inventory</h3>
    <%=
        Html.Grid(Model.PlayerInventory.ToList())
            .Empty("You don't have anything in your backpack")
            .Columns(column =>
                                             {
                                                 column.For(item => Html.ActionLink(item.Name, "buy", item.Id.ToIdRoute()))
                                                     .Named("Name")
                                                     .DoNotEncode();
                                                 column.For(item => item.Price);
                                             }) %>

</asp:Content>
