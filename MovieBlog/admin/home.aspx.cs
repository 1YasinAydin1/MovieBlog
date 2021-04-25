using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asp.Net_Entity_.entity;
namespace Asp.Net_Entity_.admin
{
    public partial class home : System.Web.UI.Page
    {
        EFblogEntities DB;
        protected void Page_Load(object sender, EventArgs e)
        {
            DB = new EFblogEntities();
            if (Request.QueryString["blogID"] != null)
            {
                Guid IID = Guid.Parse(Request.QueryString["blogID"]);

                foreach (var item in DB.blogDetailImage)
                    if (item.blogID == IID)
                        DB.blogDetailImage.Remove(item);
                foreach (var item in DB.commentTable)
                    if (item.commentBlogID == IID)
                        DB.commentTable.Remove(item);
                DB.SaveChanges();

                var DeleteBlog = DB.blogTable.Find(IID);
                DB.blogTable.Remove(DeleteBlog);
                DB.SaveChanges();
                Response.Redirect("home.aspx");
            }
            else if (Session["admin"] == null)
            {
                Response.Redirect("adminLogin.aspx");
            }
            else if (Request.QueryString["logOut"] != null)
            {
                Session["admin"] = null;
                Response.Redirect("adminLogin.aspx");
            }
            else if (Request.QueryString["logOutANDdefault"] != null)
            {
                Session["admin"] = null;
                Response.Redirect("../client/default.aspx");
            }
            else
            {
                var safsa = (from i in DB.blogTable
                             select new
                             {
                                 i.blogID,
                                 i.blogTitle,
                                 i.blogContent,
                                 i.categoryTable.categoryName,
                                 i.typeTable.typeName,
                                 i.blogDateTime,
                                 i.blogImageCover
                             }).ToList();
                //var blogTables = DB.blogTable.ToList();
                Repeater1.DataSource = safsa;
                Repeater1.DataBind();

            }
        }
    }
}