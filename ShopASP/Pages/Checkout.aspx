<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="ShopASP.Pages.Checkout" 
    MasterPageFile="~/Pages/Cakes.Master"%>

<asp:Content ID="ContentOrder" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">

        <div id="checkoutForm" class="checkout" runat="server">
            <h2>Оформить заказ</h2>
            Пожалуйста, введите свои данные, и мы отправим Ваш товар прямо сейчас!

        <div id="errors" data-valmsg-summary="true">
            <ul>
                <li style="display:none"></li>
            </ul>
            <asp:ValidationSummary ID="ValidationSummaryOrder" runat="server" />
        </div>

            <h3>Заказчик</h3>
            <div>
                <label for="Name">Имя:</label>
                <input id="Name" name="Name" runat="server" />
            </div>

            <h3>Адрес доставки</h3>
            <div>
                <label for="Line1">Адрес 1:</label>
                <input id="Line1" name="Line1" runat="server" />
            </div>
            <div>
                <label for="Line2">Адрес 2:</label>
                <input id="Line2" name="Line2" runat="server" />
            </div>
            <div>
                <label for="Line3">Адрес 3:</label>
                <input id="Line3" name="Line3" runat="server" />
            </div>
            <div>
                <label for="City">Город:</label>
                <input id="City" name="City" runat="server" />
            </div>

            <h3>Детали заказа</h3>
            <input type="checkbox" id="iscash" name="iscash" value="true" />
            Оплата наличными при получении?
        
        <p class="actionButtons">
            <button class="actionButtons" type="submit">Обработать заказ</button>
        </p>
        </div>
        <div id="checkoutMessage" runat="server">
            <h2>Спасибо!</h2>
            Спасибо что выбрали наш магазин! Мы постараемся максимально быстро отправить ваш заказ   
        </div>
    </div>
</asp:Content>
