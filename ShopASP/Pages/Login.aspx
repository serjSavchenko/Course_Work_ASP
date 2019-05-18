<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShopASP.Pages.Login" 
    MasterPageFile="~/Pages/Cakes.Master" %>

<asp:Content ID="ContentLogin" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <div id="LoginForm" class="loginContainer" runat="server">
            <div>
                <label for="Name">Логин:</label>
                <input id="Name" name="Name" runat="server" />
            </div>
            <div>
                <label for="Password">Пароль:</label>
                <input type="password" id="Password" name="Password" runat="server" />
            </div>
            <button type="submit">Войти</button>
            <a id="csLinkRegister" runat="server">Регистрация</a>
        </div>
        <div id="PersonalArea" runat="server">
            <div class="outerContainer">
                <table id="ordersTable">
                    <tr>
                        <th>Имя заказчика</th>
                        <th>Город</th>
                        <th>Позиций в заказе</th>
                        <th>Сумма</th>
                        <th>Статус</th>
                    </tr>
                    <tbody>
                         <asp:Repeater ID="RepeaterOrders" runat="server" SelectMethod="GetOrders"
                             ItemType="ShopASP.Models.Order">
                             <ItemTemplate>
                                 <tr>
                                     <td><%#: Item.Name %></td>
                                     <td><%#: Item.City %></td>
                                     <td><%#  Item.OrderLines.Sum(ol => ol.Quantity) %></td>
                                     <td><%#  Total(Item.OrderLines).ToString("C") %> </td>
                                     <td><%#  Item.Status %></td>
                                 </tr>
                             </ItemTemplate>
                         </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

</asp:Content>


