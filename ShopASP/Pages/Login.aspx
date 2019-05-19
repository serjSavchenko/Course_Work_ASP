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
            <br />
            <a id="csLinkRegister" runat="server">Регистрация</a>
        </div>
        <div id="PersonalArea" runat="server">
            <div class="outerContainer">
                <div id="FilterButtons">
                    <button id="AllOrders" class="actionButtons" onserverclick="AllOrders_ServerClick" runat="server">Все заказы</button>
                    <button id="NewOrders" class="actionButtons" onserverclick="NewOrders_ServerClick" runat="server">Новые</button>
                    <button id="DeliverOrders" class="actionButtons" onserverclick="DeliverOrders_ServerClick" runat="server">В доставке</button>
                    <button id="ReadyOrders" class="actionButtons" onserverclick="ReadyOrders_ServerClick" runat="server">Готовы/Отменены</button>
                </div>
                <table id="ordersTable">
                    <thead>
                        <tr>
                            <th>Имя заказчика</th>
                            <th>Город</th>
                            <th>Позиций в заказе</th>
                            <th>Сумма</th>
                            <th>Статус</th>
                        </tr>
                    </thead>
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
                <h3 id="ClearTable" runat="server">Здесь пока-что пусто</h3>
                <p class="actionButtons">
                    <a href="<%= ReturnUrl %>">Продолжить покупки</a>
                </p>
            </div>
        </div>
    </div>

</asp:Content>


