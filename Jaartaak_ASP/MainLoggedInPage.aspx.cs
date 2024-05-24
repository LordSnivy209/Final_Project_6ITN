using Jaartaak.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
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
                //reload notes
                fillControls();
            }
            else
            {
                // Handle validation errors
            }
        }
        protected void searchNotes(object sender, EventArgs e)
        {
            string title = txtSearchNotes.Text.Trim();
            int userID = _controller.LoggedInUser.UserID;
            List<Note> list = _controller.searchNotes(userID, title);
            rptNotes.DataSource = list;
            rptNotes.DataBind();
        }

        protected void EditNote_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            int noteID = int.Parse(btn.CommandArgument);

            // Fetch the note details from the database and populate the modal fields
            Note note = _controller.GetNoteById(noteID);
            txteditNoteTitle.Text = note.TitleNote;
            txteditNoteContent.Text = note.NoteContents;

            // Store the noteID in a session variable
            Session["EditingNoteID"] = noteID;

            // Show the modal
            ScriptManager.RegisterStartupScript(this, GetType(), "showEditModal", "showEditModal();", true);
        }
        protected void SaveChanges_Click(object sender, EventArgs e)
        {
            //retrieve the noteID from the session variable
            int noteID = (int)Session["EditingNoteID"];
            //get new title and content
            string newTitle = txteditNoteTitle.Text;
            string newContent = txteditNoteContent.Text;


            _controller.editNoteInDB(noteID, newTitle, newContent);

            //hide modal
            ScriptManager.RegisterStartupScript(this, GetType(), "hideEditModal", "hideEditModal();", true);
            //reload notes
            fillControls();
        }

        protected void btnDeleteNoteNO_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "hideDeleteConfirmationModal", "hideDeleteConfirmationModal();", true);
        }

        protected void btnDeleteNoteYES_Click(object sender, EventArgs e)
        {
            //retrieve the noteID from the session variable
            int noteID = (int)Session["DeleteNoteID"];

            _controller.deleteNoteFromDB(noteID);

            //reload notes
            fillControls();
        }

        protected void btnDeleteNote_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            int noteID = int.Parse(btn.CommandArgument);

            // Store the noteID in a session variable
            Session["DeleteNoteID"] = noteID;

            //confirm deletion
            ScriptManager.RegisterStartupScript(this, GetType(), "showDeleteConfirmationModal", "showDeleteConfirmationModal();", true);
        }
    }
}