<%@ Page Title="Driver edit" Language="C#" MasterPageFile="~/DefaultSite.Master" AutoEventWireup="true" CodeBehind="Driver_Edit.aspx.cs" Inherits="WebForms.Driver_Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="title" runat="server" id="driverEditTitle"></div>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label>First name:</label>
                    <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control"/>
                    <asp:RequiredFieldValidator ErrorMessage="You forgot to enter a first name!" ControlToValidate="txtFirstName" runat="server" Display="Dynamic" ForeColor="Red"/>
                </div>
                <div class="form-group">
                    <label>Last name:</label>
                    <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control"/>
                    <asp:RequiredFieldValidator ErrorMessage="You forgot to enter a last name!" ControlToValidate="txtLastName" runat="server" Display="Dynamic" ForeColor="Red"/>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label>Mobile number:</label>
                    <asp:TextBox runat="server" ID="txtMobileNumber" CssClass="form-control"/>
                    <asp:RequiredFieldValidator ErrorMessage="You forgot to enter a mobile number!" ControlToValidate="txtMobileNumber" runat="server" Display="Dynamic" ForeColor="Red"/>
                </div>
                <div class="form-group">
                    <label>Driver license number:</label>
                    <asp:TextBox runat="server" ID="txtDriverLicenseNumber" CssClass="form-control"/>
                    <asp:RequiredFieldValidator ErrorMessage="You forgot to enter a driver license number!" ControlToValidate="txtDriverLicenseNumber" runat="server" Display="Dynamic" ForeColor="Red"/>
                </div>
            </div>
        </div>

        <div class="btn-group float-right my-5" role="group" aria-label="Basic example">
            <asp:Button ID="btnCancel" OnClick="btnCancel_Click" Text="Cancel" runat="server" CssClass="btn btn-secondary" CausesValidation="false"/>
            <asp:Button ID="btnSave" OnClick="btnSave_Click" Text="Save" runat="server" CssClass="btn btn-success" />
            <asp:Button ID="btnDelete" OnClick="btnDelete_Click" OnClientClick="return confirm('Do you really want delete the driver ?')" Text="Delete" runat="server" CssClass="btn btn-danger" />
        </div>
    </div>


</asp:Content>
