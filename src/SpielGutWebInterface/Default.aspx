<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SpielGutWebInterface._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="content-card bright-background">
        <h1>
            <asp:Label runat="server" ID="MainTitleLabel">
            Welcome to SpielGut Toy Rentals
            </asp:Label>

        </h1>

        <p>
            <asp:Label runat="server" ID="MainTextLabel">
            To use our online renting system, please login.<br />
            If you do not yet have an account, you can sign up for a free account.<br />
            </asp:Label>
        </p>
    </div>
    <div class="content-card bright-background">
        <h2>About Us</h2>
        <p>
            <!-- text credit: http://corporate.marksandspencer.com/aboutus -->
            Founded in 1884, SpielGut has grown from a single market stall to an international, 
            multi-channel toy rental. We offer high quality,
            great value products for rent to 32 million customers
            through our 914 UK stores and our new online renting system.
        </p>
    </div>
    <div class="content-card bright-background">
        <h2>Opening Times</h2>
        <p>
            In all our stores, our opening times are as follows:<br />
            <!-- text credit: http://www.kunsthaus.ch/en/information/ -->
            Tue/Fri–Sun 10 a.m.–6 p.m.<br />
            Wed/Thu 10 a.m.–8 p.m.<br />
            <br />
            Groups and school classes by prior appointment only<br />
            Tel. +41 (0)44 253 84 84<br />
            <br />
            Please note our general house rules.<br />
        </p>
    </div>

</asp:Content>
