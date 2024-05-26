using Jaartaak.Business;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jaartaak_ASP
{
    public partial class MainBusinessPage : System.Web.UI.Page
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
                fillUsers();
            }
        }

        private void fillControls()
        {
            int orgID = _controller.LoggedInOrg.OrgID;
            List<Note> list = _controller.getOrgNotes(orgID);
            rptNotes.DataSource = list;
            rptNotes.DataBind();
            lblUsername.Text = _controller.LoggedInOrg.OrgName;
        }

        private void fillUsers()
        {
            int orgID = _controller.LoggedInOrg.OrgID;
            List<User> users = _controller.GetAllUsers(orgID);
            rptUsers.DataSource = users;
            rptUsers.DataBind();
        }

        protected void saveNoteBtn_Click1(object sender, EventArgs e)
        {
            string title = noteTitle.Text.Trim();
            string content = noteContent.Text.Trim();
            DateTime dateTime = DateTime.Now;
            int userId = _controller.LoggedInUser.UserID;

            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(content))
            {
                _controller.addNoteToDB(userId, title, content, dateTime);
                noteTitle.Text = "";
                noteContent.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "HideModal", "hideModal();", true);
                fillControls();
            }
            else
            {
                
            }
        }

        protected void EditNote_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            int noteID = int.Parse(btn.CommandArgument);
            Note note = _controller.GetNoteById(noteID);
            txteditNoteTitle.Text = note.TitleNote;
            txteditNoteContent.Text = note.NoteContents;
            Session["EditingNoteID"] = noteID;
            ScriptManager.RegisterStartupScript(this, GetType(), "showEditModal", "showEditModal();", true);
        }

        protected void SaveChanges_Click(object sender, EventArgs e)
        {
            int noteID = (int)Session["EditingNoteID"];
            string newTitle = txteditNoteTitle.Text;
            string newContent = txteditNoteContent.Text;
            _controller.editNoteInDB(noteID, newTitle, newContent);
            ScriptManager.RegisterStartupScript(this, GetType(), "hideEditModal", "hideEditModal();", true);
            fillControls();
        }

        protected void btnDeleteNoteNO_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "hideDeleteConfirmationModal", "hideDeleteConfirmationModal();", true);
        }

        protected void btnDeleteNoteYES_Click(object sender, EventArgs e)
        {
            int noteID = (int)Session["DeleteNoteID"];
            _controller.deleteNoteFromDB(noteID);
            fillControls();
        }

        protected void btnDeleteNote_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            int noteID = int.Parse(btn.CommandArgument);
            Session["DeleteNoteID"] = noteID;
            ScriptManager.RegisterStartupScript(this, GetType(), "showDeleteConfirmationModal", "showDeleteConfirmationModal();", true);
        }

        protected void AddToNetwork_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            int userID = int.Parse(btn.CommandArgument);
            int businessID = _controller.LoggedInOrg.OrgID;

            _controller.addUserToOrg(businessID, userID);

            // Provide feedback to the user (optional)
            Response.Write("<script>alert('User added to the network.')</script>");
        }

        protected void btnHideNotes_Click(object sender, EventArgs e)
        {
            rptNotes.Visible = false;
            btnHideNotes.Visible = false;
            btnShowNotes.Visible = true;
        }

        protected void btnShowNotes_Click(object sender, EventArgs e)
        {
            rptNotes.Visible= true;
            btnShowNotes.Visible= false;
            btnHideNotes.Visible = true;

        }

        protected void btnShowUsers_Click(object sender, EventArgs e)
        {
            rptUsers.Visible = true;
            btnShowUsers.Visible = false;
            btnHideUsers.Visible = true;
        }

        protected void btnHideUsers_Click(object sender, EventArgs e)
        {
            rptUsers.Visible = false;
            btnShowUsers.Visible= true;
            btnHideUsers.Visible= false;
        }
    }
}
