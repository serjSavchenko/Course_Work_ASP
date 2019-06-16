<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Pages/Admin/Admin.Master" 
    AutoEventWireup="true" 
    CodeBehind="Orders.aspx.cs" 
    Inherits="ShopASP.Pages.Admin.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="outerContainer">
        <table id="ordersTable">
            <tr>
                <th>Имя заказчика</th>
                <th>Город</th>
                <th>Позиций в заказе</th>
                <th>Сумма</th>
                <th>Статус</th>
                <th></th>
                <th></th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" SelectMethod="GetOrders"
                ItemType="ShopASP.Models.Order">
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Name %></td>
                        <td><%#: Item.City %></td>
                        <td><%# Item.OrderLines.Sum(ol => ol.Quantity) %></td>
                        <td><%# Total(Item.OrderLines).ToString("C") %> </td>
                        <td><%#: Item.Status %></td>
                        <td> 
                            <button type="submit" name="dispatch" value="<%# Item.OrderId %>">Отправить в службу доставки</button> 
                        </td>
                        <td>
                            <button type="submit" name="ready" value="<%# Item.OrderId %>">Подтвердить завершение заказа</button>   
                        </td>
                        <td>
                            <button type="submit" name="getPositions" value="<%# Item.OrderId %>">Показать позиции из заказа</button>   
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

    <div id="ordersCheck">
        <asp:CheckBox ID="showDispatched" runat="server" Checked="false" AutoPostBack="true" />
        Показать отправленные в службу доставки заказы?
    </div>
    <div id="readyOrdersCheck">
		<asp:CheckBox ID="showReady" runat="server" Checked="false" AutoPostBack="true" />
        Показать выполненые/отмененные заказы?
    </div>
    
</asp:Content>
