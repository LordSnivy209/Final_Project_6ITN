<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessLogin.aspx.cs" Inherits="Jaartaak_ASP.BusinessLogin" MasterPageFile="~/MainLayout.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <br />
                <h2 class="text-center mb-4">Business Login</h2>
                <div class="card">
                    <div class="card-body">
                        <form runat="server">
                            <div class="form-group position-relative">
                                <label for="username">Business Name</label>
                                <asp:TextBox type="text" class="form-control" ID="txtBusiness" runat="server" required="true" />
                            </div>
                            <div class="form-group position-relative">
                                <asplabel for="password">Password</asplabel>
                                <asp:TextBox type="password" class="form-control" ID="txtPassword" runat="server" required="true"></asp:TextBox>
                            </div>
                            <br />
                            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" class="btn btn-primary btn-block" />
                        </form>
                    </div>
                </div>
                </div>
            </div>

        </div>
    



</asp:Content>
