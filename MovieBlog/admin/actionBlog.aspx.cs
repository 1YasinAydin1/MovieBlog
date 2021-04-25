using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asp.Net_Entity_.entity;
namespace Asp.Net_Entity_.admin
{
    public partial class actionBlog : System.Web.UI.Page
    {
        EFblogEntities DB;
        List<int> list;
        int i = 0;
        static Guid IID = Guid.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            DB = new EFblogEntities();
            if (Page.IsPostBack != true)
            {
                var typeTables = (from i in DB.typeTable select new { i.typeID, i.typeName }).ToList();
                var categoryTables = (from i in DB.categoryTable select new { i.categoryID, i.categoryName }).ToList();

                blogType.DataSource = typeTables;
                blogCategory.DataSource = categoryTables;
                blogType.DataBind();
                blogCategory.DataBind();

                for (i = 0; i <= 10; i++)
                    if (i == 0)
                        DropDownList3.Items.Add("Seç");
                    else
                        DropDownList3.Items.Add(i.ToString());
                DropDownList3.DataBind();

                if (Request.QueryString["blogID"] != null)
                {
                    action.Text = "Güncelle";
                    action.CssClass = "btn bg-warning btn-block text-white";
                    IID = Guid.Parse(Request.QueryString["blogID"]);
                    var blog = DB.blogTable.Where(i => i.blogID == IID).ToList();
                    foreach (blogTable item in blog)
                    {
                        IDTextBox.Text = item.blogID.ToString();
                        blogTitle.Text = item.blogTitle;
                        blogContent.Text = item.blogContent;
                        blogCategory.SelectedValue = item.blogCategory.ToString();
                        blogType.SelectedValue = item.blogType.ToString();
                        blogCoverImage.Text = item.blogImageCover;
                    }
                    blogDIFunction(0);
                }
                else Panel1.Visible = false;
            }
        }

        private void blogDIFunction(int dropDownNum)
        {
            var blogDI = DB.blogDetailImage.Where(i => i.blogID == IID).ToList();
            if (dropDownNum == 0) dropDownNum = blogDI.Count;
            list = new List<int>();
            for (i = 1; i <= dropDownNum; i++)
            {
                list.Add(i);
            }
            Repeater1.DataSource = list;
            Repeater1.DataBind();

            string[] blogDIPath = new string[blogDI.Count];
            for (i = 0; i < blogDI.Count; i++)
            {
                blogDIPath[i] = blogDI[i].blogImagePath;
            }
            i = 0;
            foreach (RepeaterItem item in Repeater1.Items)
            {
                if (blogDI.Count == i)
                    break;
                ((TextBox)item.FindControl("blogDetailImageTextBox")).Text = blogDIPath[i];
                i++;
            }
        }

        protected void action_Click(object sender, EventArgs e)
        {
            EFblogEntities DB1 = new EFblogEntities();
            blogTable blogT;
            if (IID != Guid.Empty)
                blogT = DB1.blogTable.Find(IID);
            else { blogT = new blogTable(); blogT.blogID = Guid.NewGuid(); }

            blogT.blogTitle = blogTitle.Text;
            blogT.blogContent = blogContent.Text;
            blogT.blogCategory = Convert.ToInt16(blogCategory.SelectedValue);
            blogT.blogType = Convert.ToInt16(blogType.SelectedValue);
            blogT.blogDateTime = DateTime.Now;
            blogT.blogImageCover = blogCoverImage.Text;
            DB1.SaveChanges();
            var asfasf = DB1.blogDetailImage.Where(i => i.blogID == IID).ToList();
            if (IID == Guid.Empty)
                DB1.blogTable.Add(blogT);
            else
            {
                foreach (var item in DB1.blogDetailImage)
                {
                    if (item.blogID == IID)
                        DB1.blogDetailImage.Remove(item);
                }
                DB1.SaveChanges();
            }
            var asfsafasf = DB.blogDetailImage.Where(i => i.blogID == IID).ToList();
            blogDetailImage blogDetailI;
            foreach (RepeaterItem item in Repeater1.Items)
            {
                blogDetailI = new blogDetailImage();
                blogDetailI.blogImageID = Guid.NewGuid();
                blogDetailI.blogID = blogT.blogID;
                blogDetailI.blogImagePath = ((TextBox)item.FindControl("blogDetailImageTextBox")).Text;
                DB1.blogDetailImage.Add(blogDetailI);
            }
            DB1.SaveChanges();
            Response.Redirect("../client/default.aspx");
        }

        protected void bring_Click(object sender, EventArgs e)
        {
            int dropDownNum = byte.Parse(DropDownList3.SelectedValue);
            list = new List<int>();
            for (i = 1; i <= dropDownNum; i++)
            {
                list.Add(i);
            }
            Repeater1.DataSource = list;
            Repeater1.DataBind();
            blogDIFunction(dropDownNum);
        }
    }
}