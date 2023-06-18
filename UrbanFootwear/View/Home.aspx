<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UrbanFootwear.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="mt-4">Shoes</h1>

        <% if (customer != null && customer.CustomerRole.Equals("admin"))
            { %>
        <!-- Admin Actions -->
        <div class="mt-4">
            <asp:Button ID="btnInsertFootwear" class="btn btn-success" runat="server" Text="Insert Artist" OnClick="btnInsertFootwear_Click" />
        </div>
        <% } %>

        <!-- Artist Cards -->
        <div class="row mt-4">
            <asp:Repeater ID="footwearRepeater" runat="server" OnItemCommand="footwearRepeater_ItemCommand">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <asp:HyperLink ID="hl" NavigateUrl='<%# "~/View/FootwearDetails.aspx?id=" + Eval("FootwearID") %>' runat="server">
                            <div class="card">
                                <asp:Image ID="imgArtist" class="card-img-top" alt="Artist Image" runat="server" ImageUrl='<%# "~/Assets/Footwears/" + Eval("FootwearImage") %>' />
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("FootwearName") %></h5>
                                    <p class="card-title"><%# Eval("Brand.BrandName") %></p>
                                    <% if (customer != null && customer.CustomerRole.Equals("admin"))
                                        { %>
                                    <div>
                                        <asp:LinkButton ID="lbUpdate" class="btn btn-info mt-2 me-2" runat="server" CommandName="update" CommandArgument='<%# Eval("FootwearID") %>'>Update</asp:LinkButton>
                                        <asp:LinkButton ID="lbDelete" class="btn btn-danger mt-2" runat="server" CommandName="delete" CommandArgument='<%# Eval("FootwearID") %>'>Delete</asp:LinkButton>
                                    </div>
                                    <% } %>
                                </div>
                            </div>
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
