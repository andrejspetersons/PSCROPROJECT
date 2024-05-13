<%@ Page Async="true" Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" EnableEventValidation="false" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create Account.</h4>
        <hr />
        <!---FirstName-->
        <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">First name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                    CssClass="text-danger" ErrorMessage="First Name field is required." />
            </div>
        </div>
        <!---SureName-->
        <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Second name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                    CssClass="text-danger" ErrorMessage="Last Name field is required." />
            </div>
        </div>
        <!---UserName-->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Login" CssClass="col-md-2 control-label">Login</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Login" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Login"
                    CssClass="text-danger" ErrorMessage="Login field is required." />
            </div>
        </div>
        <!---Phone-->
        <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="PhoneNumber" CssClass="col-md-2 control-label">Phone Number</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="PhoneNumber" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNumber"
                    CssClass="text-danger" ErrorMessage="The phone number field is required." />
            </div>
        </div>
        <!---Email-->
        <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="Email address number field is required." />
            </div>
        </div>
        <!---Register Button-->
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

