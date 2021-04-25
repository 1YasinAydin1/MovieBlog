using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asp.Net_Entity_.entity;
namespace Asp.Net_Entity_.admin
{
    public partial class adminLogin : System.Web.UI.Page
    {
        EFblogEntities DB = new EFblogEntities();
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var admin = (from item in DB.adminTable
                         where item.adminName == TextBox1.Text && item.adminPassword == TextBox2.Text
                         select item);
            if (admin.Any())
            {
                Session.Add("admin", "admin");
                Response.Redirect("home.aspx");
            }
        }
    }
}