﻿<%@ Page Title="Kontobestätigung" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="SpielGutWebInterface.Account.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="content-card bright-background">
        <h1>Account Confirmation</h1>

        <div>
            <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
                <p>
                    Your Account has been confirmed, press <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">here</asp:HyperLink>  to login.
                </p>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
                <p class="text-danger">
                    Fehler
                </p>
            </asp:PlaceHolder>
    </div></div>
</asp:Content>
