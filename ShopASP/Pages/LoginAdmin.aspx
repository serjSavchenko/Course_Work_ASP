﻿<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Pages/Admin/Admin.Master" 
    AutoEventWireup="true" 
    CodeBehind="LoginAdmin.aspx.cs" 
    Inherits="ShopASP.Pages.LoginAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="SingleParagraph" CssClass="error" />

    <div class="loginContainer">
        <div>
            <label for="name">Имя:</label>
            <input name="name" />
        </div>
        <div>
            <label for="password">Пароль:</label>
            <input type="password" name="password" />
        </div>
        <button type="submit">Войти</button>
    </div>
</asp:Content>
