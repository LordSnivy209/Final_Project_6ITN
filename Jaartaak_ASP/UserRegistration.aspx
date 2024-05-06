<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="Jaartaak_ASP.UserRegistration" MasterPageFile="~/MainLayout.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <br />
                <h2 class="text-center mb-4">User Registration</h2>
                <div class="card">
                    <div class="card-body">
                        <form runat="server">
                            <div class="form-group position-relative">
                                <asp:label runat="server" for="fullName">Username</asp:label>
                                <input type="text" class="form-control" id="fullName" runat="server" required/>
                            </div>
                            <div class="form-group position-relative">
                                <asp:label runat="server" for="password">Password</asp:label>
                                <input type="password" class="form-control" id="lblPassword" runat="server" required/>
                            </div>
                            <div class="form-group position-relative">
                                <asp:label runat="server" for="confirmPassword">Confirm Password</asp:label>
                                <input type="password" class="form-control" id="lblConfirmPassword" runat="server" required/>
                            </div>
                            <br />
                            <asp:button runat="server" type="submit" class="btn btn-primary btn-block" id="btnRegister" OnClick="btnRegister_Click" Text="Register"></asp:button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
