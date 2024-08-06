using static suba_catering.Models.CommonFn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace suba_catering.Admin
{
    public partial class Addmenu : System.Web.UI.Page
    {
        CommonFnx fn = new CommonFnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMenuItems();
            }
        }

        private void GetMenuItems()
        {
            DataTable dt = fn.fetch("Select Row_NUMBER() over(Order by (select 1)) as [Sr.No], menuitemname, menupriceID from menuitems");
            gridview1.DataSource = dt;
            gridview1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = fn.fetch("Select * from menuitems where menuitemname = '" + Textbox1.Text.Trim() + "' ");
                if (dt.Rows.Count == 0) 
                {
                    string query = "Insert into menuitems values ('" + TextNo.Text.Trim() + "','" + Textbox1.Text.Trim() + "', '" + Textbox2.Text.Trim() + "')";
                    fn.Query(query);
                    lblMsg.Text = "Inserted Successfully";
                    lblMsg.CssClass = "alert alert-success";
                    Textbox1.Text = string.Empty;
                    Textbox2.Text = string.Empty;
                    GetMenuItems();
                }
                else
                {
                    lblMsg.Text = "Menu Item Already Exits";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}