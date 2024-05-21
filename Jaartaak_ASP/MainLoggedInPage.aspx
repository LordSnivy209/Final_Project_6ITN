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
            <button class="btn btn-primary me-2">Personal Notes</button>
            <button class="btn btn-primary me-2">Business Notes</button>
            <button id="btnAddNote" class="btn btn-success ms-auto">Add note</button>
        </section>
        
        <section class="container">
            <input type="text" class="form-control" placeholder="Search Notes...">
        </section>
        <section class="container">
            <h2>Recent Notes</h2>
            <!-- Display recent notes here -->
            <asp:ListBox ID="lbList" runat="server"></asp:ListBox>
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

    <!-- Latest compiled JavaScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
        </form>
</asp:Content>
