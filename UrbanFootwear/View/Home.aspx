<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UrbanFootwear.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .footwearImgContainer {
            display: flex;
            flex-wrap: wrap;
        }
        .footwearItem {
            text-align: center;
            margin-bottom: 5vh;
        }
        .footwearImg {
            width: 30vh;
            height: 30vh;
            margin-left: 2vh;
            margin-top: 2vh;
            cursor: pointer;
        }
        .footwearName {
            font-weight: bold;
        }
        .footwearActions {
            margin-top: 1vh;
        }
        .btn {
            margin-top: 2vh;
            margin-left: 2vh;
            margin-bottom: 6vh;
        }
    </style>
    <script type="text/javascript">
        function imageClicked(footwearId) {
            window.location.href = "FootwearDetails.aspx?footwearId=" + footwearId;
        }
        function updateFootwear(footwearId) {
            window.location.href = "UpdateFootwear.aspx?footwearId=" + footwearId;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="insertBtn" runat="server" onclick="btnInsert_Click" CssClass="btn btn-primary" Text="Insert Footwear" />
    <div class="footwearImgContainer">
        <asp:Repeater ID="footwearRepeater" runat="server">
            <ItemTemplate>
                <div class="footwearItem">
                    <img class="footwearImg" src='<%# ResolveUrl("../Assets/Footwears/" + Eval("FootwearImage")) %>' data-image-id='<%# Eval("FootwearID") %>' onclick='<%# "imageClicked(" + Eval("FootwearID") + "); return false;" %>' />
                    <br />
                    <span class="footwearName"><%# Eval("FootwearName") %></span>
                    <div class="footwearActions">
                        <asp:Button runat="server" Text="Update" CssClass="btn btn-primary" OnClientClick='<%# "updateFootwear(" + Eval("FootwearID") + "); return false;" %>' />
                        <asp:Button runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" ID="btnDelete" CommandArgument='<%# Eval("FootwearID") %>' />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
