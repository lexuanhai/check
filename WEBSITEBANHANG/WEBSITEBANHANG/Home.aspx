<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WEBSITEBANHANG.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <style>
        /*products*/
        .products .item {
            width: 50%;
            float: left;
            border: 1px solid #ddd;
        }

        .products img {
            width: 100%;
            height: 250px;
            padding-bottom: 10px;
        }

        .products .item p {
            padding-left: 10px;
        }       
    </style>
     <div class="products" runat="server" id="Products">
    </div>
</asp:Content>
