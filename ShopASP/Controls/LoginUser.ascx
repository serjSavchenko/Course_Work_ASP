<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginUser.ascx.cs" Inherits="ShopASP.Controls.LoginUser" %>

<div id="LoginUser">
    <a id="csLinkLogin" style="margin-right: .5em;" runat="server">Вход</a>
    |
    <button id="ButtonExit" style="margin-left: .5em; font-size: .7em; color: White; text-decoration: none; padding: .15em 1.5em .2em 1.5em; background-color: #353535; border: 1px solid black;" onserverclick="ButtonExit_ServerClick" runat="server">Выход</button>
    <a id="csLinkRegister" style="margin-left: .5em;" runat="server">Регистрация</a>
</div>


