<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Jaartaak_ASP._default" MasterPageFile="~/MainLayout.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <br />
                <h2 class="text-center mb-4">Login</h2>
                <div class="text-center mb-3">
                    <a href="UserRegistration.aspx" class="btn btn-primary mr-2">User Registration</a>
                    <a href="BusinessRegistration.aspx" class="btn btn-secondary">Business Registration</a>
                </div>
                <div class="card">
                    <div class="card-body">
                        <form runat="server">
                            <div class="form-group position-relative">
                                <label for="username">Username</label>
                                <asp:TextBox type="text" class="form-control" id="txtName" runat="server" required/>
                            </div>
                            <div class="form-group position-relative">
                                <asplabel for="password">Password</asplabel>
                                <asp:TextBox type="password" class="form-control" ID="txtPassword" runat="server" required></asp:TextBox>
                            </div>
                            <br />
                            <asp:Button ID="btnLogin" runat="server" Text="Login" onclick="btnLogin_Click" class="btn btn-primary btn-block" />
                            <p class="text-center mt-3">If you want to log in as a business, <a href="BusinessLogin.aspx">click here</a>.</p>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
