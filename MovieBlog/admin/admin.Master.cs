using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asp.Net_Entity_.entity;
namespace Asp.Net_Entity_.admin
{
    public partial class admin : System.Web.UI.MasterPage
    {
        EFblogEntities DB;
        protected void Page_Load(object sender, EventArgs e)
        {
            DB = new EFblogEntities();

            int blogCount = DB.blogTable.Count();
            foreach (blogTable item in DB.blogTable.ToList())
            {
                int asf = item.typeTable.typeID;
            }
            int filmCount = DB.blogTable.Where(i => i.blogType == 2).Count();
            int sequenceCount = DB.blogTable.Where(i => i.typeTable.typeID == 1).Count();
            int commentCount = DB.commentTable.Count();
            Guid commentMaxToBlog = (Guid)DB.commentTable.GroupBy(i => i.commentBlogID).OrderByDescending(i => i.Count()).Select(y => y.Key).FirstOrDefault();

            String commentMaxToBlogName = DB.blogTable.Find(commentMaxToBlog).blogTitle;

            Label1.Text = blogCount.ToString();
            Label2.Text = commentCount.ToString();
            Label3.Text = filmCount.ToString();
            Label4.Text = sequenceCount.ToString();
            Label5.Text = commentMaxToBlogName;
            HyperLink1.NavigateUrl = "../client/blogDetail.aspx?blogID=" + commentMaxToBlog;

        }
    }
}