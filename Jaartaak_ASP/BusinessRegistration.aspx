<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessRegistration.aspx.cs" Inherits="Jaartaak_ASP.BusinessRegistration" MasterPageFile="~/MainLayout.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <br />
                <h2 class="text-center mb-4">Business Application</h2>
                <div class="card">
                    <div class="card-body">
                        <p>Please fill out the form below to apply for a business account. We will review your application and get back to you shortly.</p>
                        <form runat="server">
                            <div class="form-group position-relative">
                                <label for="businessName">Business Name</label>
                                <input type="text" class="form-control" id="businessName" runat="server" required />
                            </div>
                            <div class="form-group position-relative">
                                <label for="contactName">Contact Name</label>
                                <input type="text" class="form-control" id="contactName" runat="server" required />
                            </div>
                            <div class="form-group position-relative">
                                <label for="contactNumber">Contact Number</label>
                                <input type="text" class="form-control" id="contactNumber" runat="server" required />
                            </div>
                            <div class="form-group position-relative">
                                <label for="email">Email</label>
                                <input type="email" class="form-control" id="email" runat="server" required />
                            </div>
                            <div class="form-group position-relative">
                                <label for="password">Password</label>
                                <input type="password" class="form-control" id="password" runat="server" required />
                            </div>
                            <div class="form-group position-relative">
                                <label for="confirmPassword">Confirm Password</label>
                                <input type="password" class="form-control" id="confirmPassword" runat="server" required />
                            </div>
                            <div class="form-group position-relative">
                                <label for="businessDetails">Business Details</label>
                                <textarea class="form-control" id="businessDetails" runat="server" rows="4" placeholder="Please provide some details about your business" required></textarea>
                            </div>
                            <br />
                            <button type="submit" class="btn btn-primary btn-block">Apply</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
