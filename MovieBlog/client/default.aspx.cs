using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asp.Net_Entity_.entity;
namespace Asp.Net_Entity_.client
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        EFblogEntities DB;
        protected void Page_Load(object sender, EventArgs e)
        {
            DB = new EFblogEntities();
            var blogTables = DB.blogTable.ToList();

            foreach (blogTable item in blogTables)
            {
                int length = item.blogContent.Length * 30 / 100;
                item.blogContent = item.blogContent.Substring(0, length) + " ...";
            }

            Repeater1.DataSource = blogTables;
            Repeater1.DataBind();
        }
    }
}