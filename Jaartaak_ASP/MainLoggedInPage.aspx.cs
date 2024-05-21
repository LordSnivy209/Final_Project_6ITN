using Jaartaak.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jaartaak_ASP
{
    public partial class MainLoggedInPage : System.Web.UI.Page
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
                    Response.Redirect("default.aspx");
                }
                else
                {
                    _controller = (Controller)HttpContext.Current.Session["_controller"];
                }


                fillControls();


            }
        }
        private void fillControls()
        {
            List<Note> list = _controller.GetNotes();
            foreach (Note item in list)
            {
                    //item in de lijst
                    lbList.Items.Add(item.ToString());
                
            }

            lblUsername.Text = _controller.LoggedInUser.UserName;
            
        }
    }
}