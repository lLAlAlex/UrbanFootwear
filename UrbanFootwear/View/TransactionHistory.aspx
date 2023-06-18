<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="UrbanFootwear.View.TransactionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img-thumbnail {
            width: 100px; /* Adjust the width as per your requirement */
            height: auto; /* Maintain aspect ratio */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Transaction History</h2>

        <!-- Transaction Headers -->
        <div class="row">
            <% foreach (var t in trans)
                { %>
            <div class="col-md-12 mb-4">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Transaction ID: <%= t.TransactionID %></h5>
                        <p class="card-text">Transaction Date: <%= t.TransactionDate.ToShortDateString() %></p>
                        <p class="card-text">Customer Name: <%= t.Customer.CustomerName %></p>
                    </div>
                    <div class="table-responsive">
                        <div class="card-footer">
                            <h6 class="card-subtitle mb-2 text-muted">Transaction Details</h6>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th scope="col">Footwear Picture</th>
                                        <th scope="col">Footwear Name</th>
                                        <th scope="col">Quantity</th>
                                        <th scope="col">Price</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <% foreach (var detail in t.TransactionDetails)
                                        { %>
                                    <tr>
                                        <td>
                                            <img src="<%= Page.ResolveUrl("~/Assets/Footwears/" + detail.Footwear.FootwearImage) %>" alt="Footwear Picture" class="img-thumbnail"></td>
                                        <td><%= detail.Footwear.FootwearName %></td>
                                        <td><%= detail.Qty %></td>
                                        <td><%= detail.Footwear.FootwearPrice %></td>
                                    </tr>
                                    <% } %>
                                    <!-- End Transaction Detail Loop -->
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <% } %>
        </div>
        <!-- End Transaction Headers -->
    </div>
</asp:Content>
