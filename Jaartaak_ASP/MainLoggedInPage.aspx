﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainLayout.Master" AutoEventWireup="true" CodeBehind="MainLoggedInPage.aspx.cs" Inherits="Jaartaak_ASP.MainLoggedInPage" %>

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
            <asp:Button ID="btnAddNote" CssClass="btn btn-success" runat="server" Text="Add note" OnClientClick="showModal(); return false;" />
        </section>
        <hr />
        <section class="container">
            <asp:TextBox runat="server" ID="txtSearchNotes" type="text" class="form-control" placeholder="Search Notes..."/>
            <asp:Button ID="btnSearchNotes" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="searchNotes"/>
        </section>
         <section class="container">
                <h2>Sort Notes</h2>
                <asp:DropDownList ID="ddlSortNotes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSortNotes_SelectedIndexChanged">
                    <asp:ListItem Text="Old to New" Value="creationDateAsc" />
                    <asp:ListItem Text="New to Old" Value="creationDateDesc" />
                    <asp:ListItem Text="a-z" Value="alphabeticallyAsc" />
                    <asp:ListItem Text="z-a" Value="alphabeticallyDesc" />
                </asp:DropDownList>
            </section>
        <section class="container">
            <h2>Your Notes</h2>
            <!-- Display recent notes here -->
            <asp:Repeater ID="rptNotes" runat="server">
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

                    <!-- Note Modal for editing/deleting -->
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
                                    <asp:Button ID="btnDeleteNote" CssClass="btn btn-danger" runat="server" Text="Delete" CommandArgument='<%# Eval("NoteID") %>' onclick="btnDeleteNote_Click" />
                                </div>
                            </div>
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
                    <asp:Button ID="saveNoteBtn" CssClass="btn btn-primary" runat="server" Text="Save Note" OnClick="saveNoteBtn_Click1"/>
                </div>
            </div>
        </div>
    </div>

        <!-- Edit Note Modal -->
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

        <!-- Delete Confirmation Modal -->
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
                <asp:button type="button" id="btnDeleteNoteNO" Cssclass="btn btn-secondary" runat="server" data-bs-dismiss="modal" OnClick="btnDeleteNoteNO_Click" Text="No"></asp:button>
                <asp:button type="button" id="btnDeleteNoteYES" Cssclass="btn btn-danger" runat="server" data-bs-dismiss="modal" OnClick="btnDeleteNoteYES_Click" Text="Yes"></asp:button>
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
