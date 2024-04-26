using Jaartaak_Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Jaartaak_ASP
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                _controller = (Controller)HttpContext.Current.Session["_controller"];
            }
            else
            {
                if (HttpContext.Current.Session["_controller"] == null)
                {
                    _controller = new Controller();
                    HttpContext.Current.Session["_controller"] = _controller;
                }
                else
                {
                    _controller = (Controller)HttpContext.Current.Session["_controller"];
                }
            }
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtName.Text;
            string password = txtPassword.Text;
            if (_controller.Login(username, password))
            {
                Response.Redirect("ShowBucketList.aspx");
            }
            else
            {
                txtName.Focus();
                Response.Write("<script>alert('Error: User not found.')</script>");
            }
        }
    }
    
}