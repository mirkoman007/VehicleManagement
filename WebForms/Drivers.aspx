<%@ Page Title="Drivers" Language="C#" MasterPageFile="~/DefaultSite.Master" AutoEventWireup="true" CodeBehind="Drivers.aspx.cs" Inherits="WebForms.Drivers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="title">Drivers</div>
        <asp:Repeater runat="server" ID="driverRepeater" >
            <HeaderTemplate>
                <table class="table table-hover">
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col">Name</th>
                            <th scope="col">Mobile number</th>
                            <th scope="col">Driver license number</th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# string.Concat(Eval("FirstName"), " ", Eval("LastName")) %>
                    </td>
                    <td>
                        <%# Eval("MobileNumber") %>
                    </td>
                    <td>
                        <%# Eval("DriverLicenseNumber") %>
                    </td>
                    <td>
                        <asp:Button ID="btnEdit" OnClick="btnEdit_Click" Text="Edit" runat="server" CssClass="btn btn-outline-warning btn-sm" CommandArgument='<%# Eval("IDDriver") %>' />
                        <asp:Button ID="btnDelete" OnClick="btnDelete_Click" OnClientClick="return confirm('Do you really want delete the driver ?')" Text="Delete" runat="server" CssClass="btn btn-outline-danger btn-sm" CommandArgument='<%# Eval("IDDriver") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>

            </FooterTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
