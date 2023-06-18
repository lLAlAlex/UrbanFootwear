﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="FootwearDetails.aspx.cs" Inherits="UrbanFootwear.View.FootwearDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-2">Shoe Details</h2>

        <div class="alert alert-danger mt-4" id="alert" runat="server" style="display: none;">
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>

        <div class="card">
            <div class="card-body">
                <div>
                    <div>
                        <h5 class="card-title">
                            <asp:Label ID="AlbName" runat="server" Font-Bold="True" CssClass="albname"></asp:Label>
                        </h5>
                    </div>
                    <div>
                        <p class="card-text">
                            <asp:Image ID="AlbImage" runat="server" Height="200px" Width="200px" />
                        </p>
                    </div>
                    <div>
                        <p class="card-text">
                            <asp:Label ID="lblAlbDesc" runat="server" Text="Description: "></asp:Label>
                            <asp:Label ID="AlbDesc" runat="server" CssClass="albdetail"></asp:Label>
                        </p>
                    </div>
                    <div>
                        <p class="card-text">
                            <asp:Label ID="lblAlbPrice" runat="server" Text="Price: "></asp:Label>
                            <asp:Label ID="AlbPrice" runat="server" CssClass="albdetail"></asp:Label>
                        </p>
                    </div>
                    <div>
                        <p class="card-text">
                            <asp:Label ID="lblAlbStock" runat="server" Text="Stock: "></asp:Label>
                            <asp:Label ID="AlbStock" runat="server" CssClass="albdetail"></asp:Label>
                        </p>
                    </div>
                    <asp:Label ID="lblQuantity" class="form-label" runat="server" Text="Quantity"></asp:Label>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="tbQuantity" runat="server" class="form-control" Text="1"></asp:TextBox>
                    </div>
                    <% if (customer.CustomerRole.Equals("user"))
                        { %>
                    <asp:Button ID="btnAddToCart" class="btn btn-primary" runat="server" Text="Add To Cart" OnClick="btnAddToCart_Click" />
                    <% } %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
