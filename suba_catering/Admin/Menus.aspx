<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Menus.aspx.cs" Inherits="suba_catering.Admin.Menus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container p-md-4 p-sm-4">
    <div>
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
    <h3 class="text-center">Manage Menus</h3>
    <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
        <div class="col-md-6">
            <label for="ddlCategory">Category</label>
            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Category is Required." ControlToValidate="ddlCategory" Display="Dynamic" ForeColor="Red" InitialValue="Select Category" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-2">
        <div class="col-md-6">
            <label for="ddlSubCategory">Sub Category</label>
            <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Sub Category is Required." ControlToValidate="ddlSubCategory" Display="Dynamic" ForeColor="Red" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-2">
        <div class="col-md-6">
            <label for="txtTitle">Title</label>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder="Enter Menu Title" required="true"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-2">
        <div class="col-md-6">
            <label for="txtDescription">Description</label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeholder="Enter Description" required="true"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-2">
        <div class="col-md-3 col-md-offset-2 mb-3">
            <asp:Button ID="btnAdd" Text="Submit" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
        </div>
    </div>

    <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-2">
        <div class="col-md-12">
            <asp:GridView ID="gridview1" runat="server" CssClass="table table-hover table-bordered" DataKeyNames="id" EmptyDataText="No record to display" AutoGenerateColumns="False" OnRowEditing="gridview1_RowEditing" OnPageIndexChanging="gridview1_PageIndexChanging" OnRowCancelingEdit="gridview1_RowCancelingEdit" OnRowUpdating="gridview1_RowUpdating" AllowPaging="True" PageSize="5" OnRowDeleting="gridview1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Sr.No" HeaderText="Sr.No" ReadOnly="True">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField DataField="category" HeaderText="Category" ReadOnly="True">
                         <ItemStyle HorizontalAlign="Center"></ItemStyle>
                     </asp:BoundField>
                    <asp:BoundField DataField="sub_category" HeaderText="Sub Category" ReadOnly="True">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Title">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtTitle" runat="server" Text='<%# Eval("title") %>' CssClass="form-control"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblTitle" runat="server" Text='<%# Eval("title") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtDescription" runat="server" Text='<%# Eval("description") %>' CssClass="form-control"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblDescription" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:CommandField CausesValidation="False" HeaderText="Operation" ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>
</asp:Content>
