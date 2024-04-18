<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessRegistration.aspx.cs" Inherits="Jaartaak_ASP.BusinessRegistration" MasterPageFile="~/MainLayout.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <br />
                <h2 class="text-center mb-4">Business Registration</h2>
                <div class="card">
                    <div class="card-body">
                        <form runat="server">
                            <div class="form-group position-relative">
                                <label for="businessName">Business Name</label>
                                <input type="text" class="form-control" id="businessName" runat="server" required/>
                            </div>
                            <div class="form-group position-relative">
                                <label for="email">Email</label>
                                <input type="email" class="form-control" id="email" runat="server" />
                            </div>
                            <div class="form-group position-relative">
                                <label for="password">Password</label>
                                <input type="password" class="form-control" id="password" runat="server" required/>
                            </div>
                            <div class="form-group position-relative">
                                <label for="confirmPassword">Confirm Password</label>
                                <input type="password" class="form-control" id="confirmPassword" runat="server" required/>
                            </div>
                            <br />
                            <button type="submit" class="btn btn-primary btn-block">Register</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
