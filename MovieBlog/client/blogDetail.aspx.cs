using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asp.Net_Entity_.entity;
namespace Asp.Net_Entity_.client
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        EFblogEntities DB;
        Guid IID;
        protected void Page_Load(object sender, EventArgs e)
        {
            DB = new EFblogEntities();

            IID = Guid.Parse(Request.QueryString["blogID"]);
            var blogTable = DB.blogTable.Where(i => i.blogID == IID).ToList();
            var blogDetailImage = DB.blogDetailImage.Where(i => i.blogID == IID).ToList();
            var commentTable = DB.commentTable.Where(i => i.commentBlogID == IID).ToList();


            Repeater1.DataSource = blogDetailImage;
            Repeater2.DataSource = blogTable;
            Repeater3.DataSource = blogTable;
            Repeater4.DataSource = commentTable;
            Repeater1.DataBind();
            Repeater2.DataBind();
            Repeater3.DataBind();
            Repeater4.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            commentTable comment = new commentTable();
            comment.commentBlogID = IID;
            comment.commentContent = TextBox3.Text;
            comment.commentEmail = TextBox2.Text;
            comment.commentName = TextBox1.Text;
            DB.commentTable.Add(comment);
            DB.SaveChanges();
            Response.Redirect("blogDetail.aspx?blogID=" + IID);
        }
    }
}