<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="ShopASP.Pages.CartView" MasterPageFile="~/Pages/Cakes.Master" %>

<asp:Content ID="ContentCart" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <h2>Ваша корзина</h2>
        <table id="cartTable">
            <thead>
                <tr>
                    <th>Кол-во товара</th>
                    <th>Название</th>
                    <th>Цена</th>
                    <th>Общая стоимость</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RepeaterCart" ItemType="ShopASP.Models.CartLine"
                    SelectMethod="GetCartLines" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <button type="submit" class="actionButtons" name="delItem"
                                    value="<%#Item.Cake.CakeId %>">
                                    -</button>
                                <%# Item.Quantity %>
                                <button type="submit" class="actionButtons" name="addItem"
                                    value="<%#Item.Cake.CakeId %>">
                                    +</button>
                            </td>
                            <td><%# Item.Cake.Name %></td>
                            <td><%# Item.Cake.Price.ToString("c")%></td>
                            <td><%# ((Item.Quantity * 
                                Item.Cake.Price).ToString("c"))%></td>
                            <td>
                                <button type="submit" class="actionButtons" name="remove"
                                    value="<%#Item.Cake.CakeId %>">
                                    Удалить</button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3">Итого:</td>
                    <td><%= CartTotal.ToString("c") %></td>
                </tr>
            </tfoot>
        </table>
        <p class="actionButtons">
            <a href="<%= ReturnUrl %>">Продолжить покупки</a>
            <a href="<%= CheckoutUrl %>">Оформить заказ</a>
        </p>
    </div>
</asp:Content>
