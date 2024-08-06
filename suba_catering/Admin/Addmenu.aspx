<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Addmenu.aspx.cs" Inherits="suba_catering.Admin.Addmenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container p-md-4 p-sm-4">
        <div>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <h3 class="text-center">Menu Items</h3>
        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="txtitemno">Item No</label>
                <asp:TextBox ID="TextNo" runat="server" CssClass="form-control" placeholder="Enter Item No" required></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-2">
            <div class="col-md-6">
                <label for="txtitemname">Item Name</label>
                <asp:TextBox ID="Textbox1" runat="server" CssClass="form-control" placeholder="Enter Item Name" required></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-2">
            <div class="col-md-6">
                <label for="txtitemprice">Item Price</label>
                <asp:TextBox ID="Textbox2" runat="server" CssClass="form-control" placeholder="Enter Item Price" required></asp:TextBox>
            </div>
        </div>
        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-2">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnAdd" Text="Submit" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-2">
            <div class="col-md-6">
                <asp:GridView ID="gridview1" runat="server" CssClass="table table-hover table-bordered"></asp:GridView>
            </div>
        </div>
    </div>
    <div class="container p-md-4 p-sm-4">&nbsp;</div>
</asp:Content>
