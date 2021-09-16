<%@ Page Title="Vehicle add" Language="C#" MasterPageFile="~/DefaultSite.Master" AutoEventWireup="true" CodeBehind="Vehicle_Add.aspx.cs" Inherits="WebForms.Vehicle_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="container">
        <div class="title">Add new vehicle</div>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label>Make:</label>
                    <asp:TextBox runat="server" ID="txtMake" CssClass="form-control"/>
                    <asp:RequiredFieldValidator ErrorMessage="You forgot to enter the make!" ControlToValidate="txtMake" runat="server" Display="Dynamic" ForeColor="Red"/>
                </div>
                <div class="form-group">
                    <label>Vehicle type:</label>
                    <asp:TextBox runat="server" ID="txtVehicleType" CssClass="form-control"/>
                    <asp:RequiredFieldValidator ErrorMessage="You forgot to enter the vehicle type!" ControlToValidate="txtVehicleType" runat="server" Display="Dynamic" ForeColor="Red"/>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label>First registration:</label>
                    <asp:TextBox runat="server" ID="txtFirstRegistration" CssClass="form-control"/>
                    <asp:RequiredFieldValidator ErrorMessage="You forgot to enter the first registration!" ControlToValidate="txtFirstRegistration" runat="server" Display="Dynamic" ForeColor="Red"/>
                </div>
                <div class="form-group">
                    <label>Mileage:</label>
                    <asp:TextBox runat="server" ID="txtMileage" CssClass="form-control"/>
                    <asp:RequiredFieldValidator ErrorMessage="You forgot to enter the mileage!" ControlToValidate="txtMileage" runat="server" Display="Dynamic" ForeColor="Red"/>
                </div>
            </div>
        </div>
        <div class="btn-group float-right my-5" role="group">
            <asp:Button ID="btnCancel" OnClick="btnCancel_Click" Text="Cancel" runat="server" CssClass="btn btn-secondary" CausesValidation="false"/>
            <asp:Button ID="btnSave" OnClick="btnSave_Click" Text="Save" runat="server" CssClass="btn btn-success" />
        </div>
    </div>

</asp:Content>
