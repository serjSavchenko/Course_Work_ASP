﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="ShopASP.Pages.Listing" 
    MasterPageFile="~/Pages/Cakes.Master" %>
<%@ Import Namespace="System.Web.Routing" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
            <asp:Repeater ItemType="ShopASP.Models.Cake"
                SelectMethod="GetCakes" runat="server">
                <ItemTemplate>
                    <div class="item">
                        <img src="/Content/cake-slice.svg" alt="this_cake" style="float: left; width: 75px; height: 75px; margin-right: 1.5%;"/>
                        <h3><%# Item.Name %></h3>
                        <%# Item.Description %>
                        <h4><%# Item.Price.ToString("c") %></h4>
                        <button name="add" type="submit" value="<%# Item.CakeId %>">
                            Добавить в корзину
                        </button>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    <div class="pager">
        <%
            for (int i = 1; i <= MaxPage; i++)
            {
                 string category = (string)Page.RouteData.Values["category"]
                    ?? Request.QueryString["category"];

                string path = RouteTable.Routes.GetVirtualPath(null, null,
                    new RouteValueDictionary() { { "page", i } }).VirtualPath;
                Response.Write(
                    String.Format("<a href='{0}' {1}>{2}</a>",
                        path, i == CurrentPage ? "class='selected'" : "", i));
            }
        %>
    </div>
</asp:Content>
