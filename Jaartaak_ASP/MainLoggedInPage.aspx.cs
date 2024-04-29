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
            /*List<BucketListItemPersonal> list = _controller.getPersonalItems();
            int teller = 0;
            foreach (BucketListItemPersonal item in list)
            {

                if (item.IsDone)
                {
                    //item in de lijst
                    cbxPersonalList.Items.Add(item.ToString());
                    //item aanvinken
                    cbxPersonalList.Items[teller].Selected = true;
                    //item disable
                    cbxPersonalList.Items[teller].Enabled = false;
                }
                else
                {
                    //item in de lijst
                    cbxPersonalList.Items.Add(item.ToString());
                }
                teller++;
            }*/

            lblUsername.Text = _controller.LoggedInUser.UserName;

        }
    }
}