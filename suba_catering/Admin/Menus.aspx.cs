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
    public partial class Menus : System.Web.UI.Page
    {
        CommonFnx fn = new CommonFnx();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCategories();
                GetMenus();
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
            // Ensure the selected category ID is valid
            if (int.TryParse(ddlCategory.SelectedItem.Value, out int categoryId) && categoryId > 0)
            {
                DataTable dt = fn.fetch($"SELECT * FROM sub_categories WHERE parent_id = {categoryId}");
                ddlSubCategory.DataSource = dt;
                ddlSubCategory.DataTextField = "sub_category";
                ddlSubCategory.DataValueField = "id";
                ddlSubCategory.DataBind();
                ddlSubCategory.Items.Insert(0, new ListItem("Select Sub Category", "0"));
            }
            else
            {
                // Clear sub-category dropdown if no valid category is selected
                ddlSubCategory.Items.Clear();
                ddlSubCategory.Items.Insert(0, new ListItem("Select Sub Category", "0"));
            }
        }

        private void GetMenus()
        {
            DataTable dt = fn.fetch("Select ROW_NUMBER() OVER (Order by m.id) as [Sr.No], m.id, c.category, sc.sub_category, m.title, m.description from menus m inner join categories c on c.id = m.category_id inner join sub_categories sc on m.sub_category_id = sc.id");
            gridview1.DataSource = dt;
            gridview1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string sub_category = ddlSubCategory.SelectedItem.Text;
                DataTable dt = fn.fetch("Select * from menus where sub_category_id = '" + ddlSubCategory.SelectedItem.Value + "' and title = '" + txtTitle.Text.Trim() + "'");
                if (dt.Rows.Count == 0)
                {
                    string query = "Insert into menus (category_id, sub_category_id, title, description) values ('" + ddlCategory.SelectedItem.Value + "', '" + ddlSubCategory.SelectedItem.Value + "', '" + txtTitle.Text.Trim() + "','" + txtDescription.Text.Trim() + "')";
                    fn.Query(query);
                    lblMsg.Text = "Inserted Successfully";
                    lblMsg.CssClass = "alert alert-success";
                    ddlCategory.SelectedIndex = 0;
                    txtTitle.Text = string.Empty;
                    txtDescription.Text = string.Empty;
                    GetMenus();
                }
                else
                {
                    lblMsg.Text = "Title Already Exits for <b> '" + sub_category + "' </b>";
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
            GetMenus();
        }

        protected void gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridview1.EditIndex = -1;
            GetMenus();
        }

        protected void gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridview1.EditIndex = e.NewEditIndex;
            GetMenus();
        }

        protected void gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gridview1.Rows[e.RowIndex];
                int mId = Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Values[0]);
                string title = (row.FindControl("TxtTitle") as TextBox).Text;
                string description = (row.FindControl("TxtDescription") as TextBox).Text;
                string query = "Update menus set title= '" + title + "', description = '" + description + "' where id = '" + mId + "'";
                fn.Query(query);
                lblMsg.Text = "Updated Successfully";
                lblMsg.CssClass = "alert alert-success";
                gridview1.EditIndex = -1;
                GetMenus();
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
                int mId = Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Values[0]);
                fn.Query("Delete from menus where id = '" + mId + "'");
                lblMsg.Text = "Deleted Successfully";
                lblMsg.CssClass = "alert alert-success";
                gridview1.EditIndex = -1;
                GetMenus();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSubCategories();
        }
    }
}