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
    public partial class Categories : System.Web.UI.Page
    {
        CommonFnx fn = new CommonFnx();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCategories();
            }
        }
        private void GetCategories()
        {
            DataTable dt = fn.fetch("Select Row_NUMBER() over(Order by (Select 1)) as [Sr.No], id, category, description, date_created from categories");
            gridview1.DataSource = dt;
            gridview1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = fn.fetch("Select * from categories where category = '" + txtCategory.Text.Trim() + "' ");
                if (dt.Rows.Count == 0)
                {                
                    string query = "Insert into categories (category, description) values ('" + txtCategory.Text.Trim() + "','" + txtDescription.Text.Trim() + "')";
                    fn.Query(query);
                    lblMsg.Text = "Inserted Successfully";
                    lblMsg.CssClass = "alert alert-success";
                    txtCategory.Text = string.Empty;
                    txtDescription.Text = string.Empty;
                    GetCategories();
                }
                else
                {
                    lblMsg.Text = "Category Name Already Exits";
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
            GetCategories();
        }

        protected void gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridview1.EditIndex = -1;
            GetCategories();
        }

        protected void gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridview1.EditIndex = e.NewEditIndex;
            GetCategories();
        }

        protected void gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gridview1.Rows[e.RowIndex];
                int cId = Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Values[0]);
                string category = (row.FindControl("TxtCategoryName") as TextBox).Text;
                string description = (row.FindControl("TxtDescription") as TextBox).Text;
                string query = "Update categories set category= '" + category + "', description = '" + description + "' where id = '" + cId + "'";
                fn.Query(query);
                lblMsg.Text = "Updated Successfully";
                lblMsg.CssClass = "alert alert-success";
                gridview1.EditIndex = -1;
                GetCategories();
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
                int cId = Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Values[0]);
                fn.Query("Delete from categories where id = '" + cId + "'");
                lblMsg.Text = "Deleted Successfully";
                lblMsg.CssClass = "alert alert-success";
                gridview1.EditIndex = -1;
                GetCategories();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}