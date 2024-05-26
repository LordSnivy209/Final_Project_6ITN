<%@ Page Title="" Language="C#" MasterPageFile="~/MainLayout.Master" AutoEventWireup="true" CodeBehind="MainBusinessPage.aspx.cs" Inherits="Jaartaak_ASP.MainBusinessPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <main>
            <section class="container">
                <hr />
                <hr />
                <hr />
                <h1>Welcome to the note portal of
                    <asp:Label ID="lblUsername" runat="server"></asp:Label>!</h1>
                <p>Start managing your network.</p>
            </section>
            <hr />
            <section class="container">
                <h2>Your Networks Notes</h2>
                <asp:Button Text="Hide Notes" runat="server" id="btnHideNotes" CssClass="btn btn-danger" OnClick="btnHideNotes_Click" Visible="false"/>
                <asp:Button Text="Show Notes" runat="server" id="btnShowNotes" CssClass="btn btn-success" OnClick="btnShowNotes_Click" Visible="true"/>
                <hr />
                <asp:Repeater ID="rptNotes" runat="server" Visible="false">
                    <ItemTemplate>
                        <div class="card mb-3">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("TitleNote") %></h5>
                                <p class="card-text"><%# Eval("NoteContents") %></p>
                                <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#noteModal<%# Eval("NoteID") %>">
                                    View Details
                                </button>
                            </div>
                        </div>

                        <div class="modal fade" id="noteModal<%# Eval("NoteID") %>" tabindex="-1" aria-labelledby="noteModalLabel<%# Eval("NoteID") %>" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="noteModalLabel<%# Eval("NoteID") %>"><%# Eval("TitleNote") %></h5>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                        <p><%# Eval("NoteContents") %></p>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnEditNote" CssClass="btn btn-secondary" runat="server" Text="Edit" CommandArgument='<%# Eval("NoteID") %>' OnClick="EditNote_Click" />
                                        <asp:Button ID="btnDeleteNote" CssClass="btn btn-danger" runat="server" Text="Delete" CommandArgument='<%# Eval("NoteID") %>' OnClick="btnDeleteNote_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </section>
            <section class="container">
                <h2>Add Users to Your Network</h2>
                <asp:Button Text="Hide Users" runat="server" id="btnHideUsers" CssClass="btn btn-danger" OnClick="btnHideUsers_Click" Visible="false"/>
                <asp:Button Text="Show Users" runat="server" id="btnShowUsers" CssClass="btn btn-success" OnClick="btnShowUsers_Click" Visible="true"/>
                <hr />
                <asp:Repeater ID="rptUsers" runat="server" Visible="false">
                    <ItemTemplate>
                        <div class="card mb-3">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Username") %></h5>
                                <asp:Button ID="btnAddToNetwork" CssClass="btn btn-primary" runat="server" Text="Add to Network" CommandArgument='<%# Eval("UserID") %>' OnClick="AddToNetwork_Click" />
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
                        <asp:Button ID="saveNoteBtn" CssClass="btn btn-primary" runat="server" Text="Save Note" OnClick="saveNoteBtn_Click1" />
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="editNoteModal<%# Eval("NoteID") %>" tabindex="-1" aria-labelledby="editNoteModalLabel<%# Eval("NoteID") %>" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="editNoteModalLabel<%# Eval("NoteID") %>">Edit Note</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="mb-3">
                            <label for="editNoteTitle" class="form-label">Title</label>
                            <asp:TextBox ID="txteditNoteTitle" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="editNoteContent" class="form-label">Note</label>
                            <asp:TextBox ID="txteditNoteContent" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                        <asp:Button ID="btnSaveChanges" CssClass="btn btn-primary" runat="server" Text="Save Changes" CommandArgument='<%# Eval("NoteID") %>' OnClick="SaveChanges_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="deleteConfirmationModal" tabindex="-1" aria-labelledby="deleteConfirmationModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="deleteConfirmationModalLabel">Confirm Delete</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <p>Are you sure you want to delete this note? (We will not be able to recover it)</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button type="button" ID="btnDeleteNoteNO" CssClass="btn btn-secondary" runat="server" data-bs-dismiss="modal" OnClick="btnDeleteNoteNO_Click" Text="No"></asp:Button>
                        <asp:Button type="button" ID="btnDeleteNoteYES" CssClass="btn btn-danger" runat="server" data-bs-dismiss="modal" OnClick="btnDeleteNoteYES_Click" Text="Yes"></asp:Button>
                    </div>
                </div>
            </div>
        </div>

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
            function hideEditModal() {
                var myModalEl = document.getElementById("editNoteModal<%# Eval("NoteID") %>");
                var modal = bootstrap.Modal.getInstance(myModalEl);
                modal.hide();
            }
            function showEditModal() {
                var myModal = new bootstrap.Modal(document.getElementById("editNoteModal<%# Eval("NoteID") %>"), {
                    keyboard: false
                });
                myModal.show();
            }
            function showDeleteConfirmationModal() {
                var myModal = new bootstrap.Modal(document.getElementById('deleteConfirmationModal'), {
                    keyboard: false
                });
                myModal.show();
            }
            function hideDeleteConfirmationModal() {
                var myModalEl = document.getElementById('deleteConfirmationModal');
                var modal = bootstrap.Modal.getInstance(myModalEl);
                modal.hide();
            }
        </script>
    </form>
</asp:Content>
