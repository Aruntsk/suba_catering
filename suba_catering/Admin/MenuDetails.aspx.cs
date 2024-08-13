using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static suba_catering.Models.CommonFn;

namespace suba_catering.Admin
{
    public partial class MenuDetails : System.Web.UI.Page
    {
        CommonFnx fn = new CommonFnx();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMenus();
                GetMenuDeatils();
                
            }
        }

        private void GetMenus()
        {
            DataTable dt = fn.fetch("Select * from menus");
            ddlMenu.DataSource = dt;
            ddlMenu.DataTextField = "title";
            ddlMenu.DataValueField = "id";
            ddlMenu.DataBind();
            ddlMenu.Items.Insert(0, "Select Menu");
        }

        private void GetMenuDeatils()
        {
            DataTable dt = fn.fetch("Select ROW_NUMBER() OVER (Order by md.id) as [Sr.No], md.id, m.title as [menu], md.type_name, md.description, md.price from menu_details md inner join menus m on m.id = md.menu_id");
            gridview1.DataSource = dt;
            gridview1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string menu = ddlMenu.SelectedItem.Text;
                DataTable dt = fn.fetch("Select * from menu_details where menu_id = '" + ddlMenu.SelectedItem.Value + "' and type_name = '" + txtTypeName.Text.Trim() + "'");
                if (dt.Rows.Count == 0)
                {
                    string query = "Insert into menu_details ( menu_id, type_name, description, price) values ('" + ddlMenu.SelectedItem.Value + "', '" + txtTypeName.Text.Trim() + "','" + txtDescription.Text.Trim() + "', '"+txtPrice.Text.Trim()+"')";
                    fn.Query(query);
                    lblMsg.Text = "Inserted Successfully";
                    lblMsg.CssClass = "alert alert-success";
                    ddlMenu.SelectedIndex = 0;
                    txtTypeName.Text = string.Empty;
                    txtDescription.Text = string.Empty;
                    txtPrice.Text = string.Empty;
                    GetMenuDeatils();
                }
                else
                {
                    lblMsg.Text = "TypeName Already Exits for <b> '" + menu + "' </b>";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview1.PageIndex = e.NewPageIndex;
            GetMenuDeatils();
        }

        protected void gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridview1.EditIndex = -1;
            GetMenuDeatils();
        }

        protected void gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridview1.EditIndex = e.NewEditIndex;
            GetMenuDeatils();
        }

        protected void gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gridview1.Rows[e.RowIndex];
                int mdId = Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Values[0]);
                string type_name = (row.FindControl("TxtTypeName") as TextBox).Text;
                string description = (row.FindControl("TxtDescription") as TextBox).Text;
                string price = (row.FindControl("TxtPrice") as TextBox).Text;
                string query = "Update menu_details set type_name= '" + type_name + "', description = '" + description + "', price = '" + price + "' where id = '" + mdId + "'";
                fn.Query(query);
                lblMsg.Text = "Updated Successfully";
                lblMsg.CssClass = "alert alert-success";
                gridview1.EditIndex = -1;
                GetMenuDeatils();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int mdId = Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Values[0]);
                fn.Query("Delete from menu_details where id = '" + mdId + "'");
                lblMsg.Text = "Deleted Successfully";
                lblMsg.CssClass = "alert alert-success";
                gridview1.EditIndex = -1;
                GetMenuDeatils();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}