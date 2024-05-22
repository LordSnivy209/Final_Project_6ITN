using Jaartaak.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
            rptNotes.DataSource = list;
            rptNotes.DataBind();

            lblUsername.Text = _controller.LoggedInUser.UserName;
        }


        protected void saveNoteBtn_Click1(object sender, EventArgs e)
        {
            
            string title = noteTitle.Text.Trim();
            string content = noteContent.Text.Trim();
            DateTime dateTime = DateTime.Now;
            int userId = _controller.LoggedInUser.UserID;

            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(content))
            {
                //item in DB
                _controller.addNoteToDB(userId, title, content, dateTime);

                //clear input
                noteTitle.Text = "";
                noteContent.Text = "";

                //Hide the modal
                ScriptManager.RegisterStartupScript(this, GetType(), "HideModal", "hideModal();", true);
            }
            else
            {
                // Handle validation errors
                // e.g., display an error message
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowModal", "showModal();", true);
            }
        }
    }
}