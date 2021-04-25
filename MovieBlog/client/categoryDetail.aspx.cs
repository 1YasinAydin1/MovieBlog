using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asp.Net_Entity_.entity;
namespace Asp.Net_Entity_.client
{
    public partial class categoryDetail : System.Web.UI.Page
    {
        EFblogEntities DB;
        protected void Page_Load(object sender, EventArgs e)
        {
            DB = new EFblogEntities();
            int IID = Convert.ToInt16(Request.QueryString["categoryID"]);

            var blogTables = (from item in DB.blogTable
                              where item.categoryTable.categoryID == IID
                              select new
                              {
                                  item.blogTitle,
                                  item.blogContent,
                                  item.categoryTable.categoryName,
                                  item.typeTable.typeName,
                                  item.blogImageCover,
                                  item.blogDateTime,
                                  item.blogID
                              }).ToList();
            var category = DB.categoryTable.Where(i => i.categoryID == IID).ToList();
            Repeater1.DataSource = blogTables;
            Repeater1.DataBind();
            Repeater2.DataSource = category;
            Repeater2.DataBind();
        }
    }
}