<%@ Page Title="" Language="C#" MasterPageFile="~/MainLayout.Master" AutoEventWireup="true" CodeBehind="MainLoggedInPage.aspx.cs" Inherits="Jaartaak_ASP.MainLoggedInPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <main>
        <section class="container">
            <hr />
            <hr />
            <hr />
             <h1>Welcome Back, <asp:Label ID="lblUsername" runat="server"></asp:Label>!</h1>
            <p>Start organizing your notes.</p>
        </section>
        <section class="container d-flex">
            <button type="button" class="btn btn-primary me-2">Personal Notes</button>
            <button type="button" class="btn btn-primary me-2">Business Notes</button>
            <asp:Button ID="btnAddNote" CssClass="btn btn-success ms-auto" runat="server" Text="Add note" OnClientClick="showModal(); return false;" />
        </section>
        <hr />
        <section class="container">
            <input type="text" class="form-control" placeholder="Search Notes...">
        </section>
        <section class="container">
            <h2>Recent Notes</h2>
            <!-- Display recent notes here -->
            <asp:Repeater ID="rptNotes" runat="server">
                <ItemTemplate>
                    <div class="card mb-3">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("TitleNote") %></h5>
                            <p class="card-text"><%# Eval("NoteContents") %></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </section>
    </main>

    <footer class="text-light bg-dark fixed-bottom">
        <div class="container-fluid">
            <div class="row justify-content-between">
                <div class="col-auto">Made by Flor Bosch</div>
                <div class="col-auto">&copy; 2024 NoteBookOnline. All rights reserved.</div>
            </div>
        </div>
    </footer>

    <!-- Add Note Modal -->
    <div class="modal fade" id="addNoteModal" tabindex="-1" aria-labelledby="addNoteModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="addNoteModalLabel">Add Note</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="noteTitle" class="form-label">Title</label>
                        <asp:TextBox ID="noteTitle" CssClass="form-control" runat="server" placeholder="Enter note title"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="noteContent" class="form-label">Note</label>
                        <asp:TextBox ID="noteContent" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server" placeholder="Enter note content"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                    <asp:Button ID="saveNoteBtn" CssClass="btn btn-primary" runat="server" Text="Save Note" OnClick="saveNoteBtn_Click1"/>
                </div>
            </div>
        </div>
    </div>

    <!-- Latest compiled JavaScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    <script>
        function showModal() {
            var myModal = new bootstrap.Modal(document.getElementById('addNoteModal'), {
                keyboard: false
            });
            myModal.show();
        }

        function hideModal() {
            var myModalEl = document.getElementById('addNoteModal');
            var modal = bootstrap.Modal.getInstance(myModalEl);
            modal.hide();
        }
    </script>
    </form>
</asp:Content>
