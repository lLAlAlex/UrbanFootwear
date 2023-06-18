<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UrbanFootwear.View.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <h2>Login</h2>
        <div class="form-group">
            <asp:Label ID="lblEmail" runat="server" Text="Email" AssociatedControlID="tbEmail"></asp:Label>
            <asp:TextBox ID="tbEmail" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblPassword" runat="server" Text="Password" AssociatedControlID="tbPassword"></asp:Label>
            <asp:TextBox ID="tbPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="form-group form-check ps-0">
            <asp:CheckBox ID="cbRemember" class="ps-0" runat="server" />
            <asp:Label ID="Label1" class="form-check-label" runat="server" Text="Remember Me" AssociatedControlID="cbRemember"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblError" class="text-danger" runat="server" Text=""></asp:Label>
        </div>
        <asp:Button ID="btnLogin" class="btn btn-primary" runat="server" Text="Login" OnClick="loginbtn_Click" />
    </div>
</asp:Content>
