<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MenuDetails.aspx.cs" Inherits="suba_catering.Admin.MenuDetails" %>
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
            <label for="ddlMenu">Menu</label>
            <asp:DropDownList ID="ddlMenu" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Menu is Required." ControlToValidate="ddlMenu" Display="Dynamic" ForeColor="Red" InitialValue="Select Menu" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>
    </div>   
    <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-2">
        <div class="col-md-6">
            <label for="txtTypeName">Type Name</label>
            <asp:TextBox ID="txtTypeName" runat="server" CssClass="form-control" placeholder="Enter Type Name" required="true"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-2">
        <div class="col-md-6">
            <label for="txtDescription">Description</label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeholder="Enter Description" required="true"></asp:TextBox>
        </div>
    </div>
    <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-2">
        <div class="col-md-6">
            <label for="txtPrice">Price</label>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" placeholder="Enter Price" required="true"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="Please enter a valid price."  Display="Dynamic" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$" InitialValue="0"></asp:RegularExpressionValidator>
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
                     <asp:BoundField DataField="menu" HeaderText="Menu" ReadOnly="True">
                         <ItemStyle HorizontalAlign="Center"></ItemStyle>
                     </asp:BoundField>
                    <asp:TemplateField HeaderText="TypeName">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtTypeName" runat="server" Text='<%# Eval("type_name") %>' CssClass="form-control"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblType" runat="server" Text='<%# Eval("type_name") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="Price">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtPrice" runat="server" Text='<%# Eval("price") %>' CssClass="form-control"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("price") %>'></asp:Label>
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
