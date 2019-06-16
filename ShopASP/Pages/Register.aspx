<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ShopASP.Pages.Register" 
    MasterPageFile="~/Pages/Cakes.Master" %>

<asp:Content ID="ContentRegister" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <div id="LoginForm" class="loginContainer" runat="server">

            <div id="errors" data-valmsg-summary="true">
                <ul>
                    <li style="display:none"></li>
                </ul>
                <asp:ValidationSummary ID="ValidationSummaryOrder" runat="server" />
            </div>

            <h2>Введите данные для регистрации ниже:</h2>
            <div>
                <label for="Name">Логин:</label>
                <input id="Name" name="Name" data-val="true" data-val-required="Введите логин!" runat="server" />
            </div>
            <div>
                <label for="Password">Пароль:</label>
                <input type="password" id="Password" data-val="true" data-val-required="Введите пароль!" name="Password" runat="server" />
            </div>
            <div>
                <label for="Phone">Телефон:</label>
                <input type="tel" id="Phone" data-val="true" data-val-required="Введите телефон!" name="Phone" runat="server" />
            </div>
            <div>
                <label for="Mail">Электронная почта:</label>
                <input type="email" id="Mail" data-val="true" data-val-required="Введите электронную почту!" name="Mail" runat="server" />
            </div>
            <br />
            <button type="submit">Зарегистрироваться</button>
            <br />
            <br />
            <p>* пароль должен состоять, как минимимум, из 8 символов</p>
        </div>
        <div id="Welcome" name="Welcome" runat="server">
            <h2>Приветствуем!</h2> <br />
            <h3>Спасибо за регистрацию! Теперь вы можете войти в свой аккаунт!</h3>
        </div>
        <div id="ifRegister" name="ifRegister" runat="server">
             <h2>Вы уже зарегестрированы!</h2>
        </div>
    </div>

</asp:Content>

