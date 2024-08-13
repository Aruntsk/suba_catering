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
    public partial class SubCategories : System.Web.UI.Page
    {
        CommonFnx fn = new CommonFnx();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCategories();
                GetSubCategories();
            }
        }

        private void GetCategories()
        {
            DataTable dt = fn.fetch("Select * from categories");
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "category";
            ddlCategory.DataValueField = "id";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, "Select Category");
        }

        private void GetSubCategories()
        {
            DataTable dt = fn.fetch("Select ROW_NUMBER() OVER (Order by s.id) as [Sr.No], s.id, s.parent_id, c.category, s.sub_category, s.description from sub_categories s inner join categories c on c.id = s.parent_id");
            gridview1.DataSource = dt;
            gridview1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string category = ddlCategory.SelectedItem.Text;
                DataTable dt = fn.fetch("Select * from sub_categories where parent_id = '" + ddlCategory.SelectedItem.Value + "' and sub_category = '" + txtSubCategory.Text.Trim() + "'");
                if (dt.Rows.Count == 0)
                {                    
                    string query = "Insert into sub_categories (parent_id, sub_category, description) values ('" + ddlCategory.SelectedItem.Value + "','" + txtSubCategory.Text.Trim() + "','" + txtDescription.Text.Trim() + "')";
                    fn.Query(query);
                    lblMsg.Text = "Inserted Successfully";
                    lblMsg.CssClass = "alert alert-success";
                    ddlCategory.SelectedIndex = 0;
                    txtSubCategory.Text = string.Empty;
                    txtDescription.Text = string.Empty;
                    GetSubCategories();
                }
                else
                {
                    lblMsg.Text = "Sub Category Name Already Exits for Category <b> '"+ category + "' </b>";
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
            GetSubCategories();
        }

        protected void gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridview1.EditIndex = -1;
            GetSubCategories();
        }

        protected void gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridview1.EditIndex = e.NewEditIndex;
            GetSubCategories();
        }

        protected void gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gridview1.Rows[e.RowIndex];
                int cId = Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Values[0]);
                string sub_category = (row.FindControl("TxtSubCategoryName") as TextBox).Text;
                string description = (row.FindControl("TxtDescription") as TextBox).Text;
                string query = "Update sub_categories set sub_category= '" + sub_category + "', description = '" + description + "' where id = '" + cId + "'";
                fn.Query(query);
                lblMsg.Text = "Updated Successfully";
                lblMsg.CssClass = "alert alert-success";
                gridview1.EditIndex = -1;
                GetSubCategories();
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
                fn.Query("Delete from sub_categories where id = '" + cId + "'");
                lblMsg.Text = "Deleted Successfully";
                lblMsg.CssClass = "alert alert-success";
                gridview1.EditIndex = -1;
                GetSubCategories();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}