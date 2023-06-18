<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="InsertFootwear.aspx.cs" Inherits="UrbanFootwear.View.InsertFootwear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Insert Footwear</h2>
        <asp:Panel ID="insertFootwearPanel" runat="server">
            <div class="form-group">
                <label for="footwearName">Footwear Name:</label>
                <input type="text" id="footwearName" name="footwearName" runat="server" class="form-control"/>
            </div>
            <div class="form-group">
                <label for="footwearBrand">Footwear Brand:</label>
                <asp:DropDownList ID="footwearBrand" name="footwearBrand" runat="server" class="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="footwearDescription">Footwear Description:</label>
                <input type="text" id="footwearDescription" name="footwearDescription" runat="server" class="form-control"/>
            </div>
            <div class="form-group">
                <label for="footwearPrice">Footwear Price:</label>
                <input type="number" id="footwearPrice" name="footwearPrice" runat="server" class="form-control"/>
            </div>
            <div class="form-group">
                <label for="footwearStock">Footwear Stock:</label>
                <input type="number" id="footwearStock" name="footwearStock" runat="server" class="form-control"/>
            </div>
            <div class="form-group">
                <label for="footwearImage">Footwear Image:</label>
                <asp:Label ID="fileNameLabel" runat="server" CssClass="file-name-label"></asp:Label>
                <input type="file" id="footwearImage" name="footwearImage" runat="server" class="form-control" accept="image/*"/>
            </div>
            <div>
                <asp:Label class="text-danger" ID="insertError" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-group">
                <asp:Button ID="insertButton" runat="server" Text="Insert" OnClick="insertButton_Click" class="btn btn-primary"/>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
