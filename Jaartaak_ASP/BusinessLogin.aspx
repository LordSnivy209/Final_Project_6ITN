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
                            <div class="form-group position-relative">
                                <label for="email">Email</label>
                                <input type="email" class="form-control" id="email" runat="server" />
                            </div>
                            <div class="form-group position-relative">
                                <label for="password">Password</label>
                                <div class="input-group">
                                    <input type="password" class="form-control" id="password" runat="server" />
                                </div>
                    </div>
                    <br />
                    <button type="submit" class="btn btn-primary btn-block">Login</button>
                </div>
            </div>
        </div>
    </div>
    

    
</asp:Content>
