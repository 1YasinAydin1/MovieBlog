using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asp.Net_Entity_.entity;
namespace Asp.Net_Entity_.client
{
    public partial class client : System.Web.UI.MasterPage
    {
        EFblogEntities DB;
        protected void Page_Load(object sender, EventArgs e)
        {
            DB = new EFblogEntities();
            var blogTables = DB.blogTable.ToList();
            Repeater2.DataSource = blogTables;
            Repeater2.DataBind();
            for (int i = 0; i < blogTables.Count; i++)
                if (0 < blogTables.Count - 5)
                    blogTables.RemoveAt(0);

            var categoryTables = DB.categoryTable.ToList();
            Repeater3.DataSource = categoryTables;
            Repeater3.DataBind();


            var typeTables = DB.typeTable.ToList();
            Repeater4.DataSource = typeTables;
            Repeater4.DataBind();

            var commentTables = DB.commentTable.ToList();
            for (int i = 0; i < commentTables.Count; i++)
                if (0 < commentTables.Count - 5)
                    commentTables.RemoveAt(0);
            Repeater1.DataSource = commentTables;
            Repeater1.DataBind();
        }
    }
}