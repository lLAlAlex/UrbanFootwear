<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="MyCart.aspx.cs" Inherits="UrbanFootwear.View.MyCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Shopping Cart</h2>
        <div class="row">
            <div class="table-responsive">
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Footwear Picture</th>
                            <th scope="col">Footwear Name</th>
                            <th scope="col">Quantity</th>
                            <th scope="col">Price</th>
                            <th scope="col">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <!-- Cart Item Loop -->
                        <asp:Repeater ID="rptCart" runat="server" OnItemCommand="rptCart_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Image ID="imgArtist" alt="Footwear Picture" class="img-thumbnail" runat="server" Height="100" ImageUrl='<%# "~/Assets/Footwears/" + Eval("Footwear.FootwearImage") %>' />
                                    <td><%# Eval("Footwear.FootwearName") %></td>
                                    <td><%# Eval("qty") %></td>
                                    <td><%# Eval("Footwear.FootwearPrice") %></td>
                                    <td>
                                        <asp:LinkButton ID="lbRemove" class="btn btn-danger btn-remove" runat="server" CommandName="Remove" CommandArgument='<%# Eval("FootwearID") %>'>Remove</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <!-- End Cart Item Loop -->
                    </tbody>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <asp:Button ID="btnCheckout" class="btn btn-primary" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
            </div>
        </div>
    </div>
</asp:Content>
