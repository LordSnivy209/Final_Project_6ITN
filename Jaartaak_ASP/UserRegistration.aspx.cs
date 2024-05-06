// start working on code behind here use bucketlist
using Jaartaak.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Jaartaak_ASP
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        Controller _controller;
        
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Retrieve user input
            string username = fullName.Value;
            string password = lblPassword.Value;
            string confirmPassword = lblConfirmPassword.Value;

            // Perform validation
            if (password != confirmPassword)
            {
                Response.Write("<script>alert('Error: Passwords do not match.')</script>");
                return;
            }
            else
            {//logs the user in DB then sends them to login page
                _controller.Register(0, username, password);
                Response.Write("<script>alert('Registration succesful!')</script>");
                Response.Redirect("default.aspx");
            }
            //
        }
    }
}