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
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>

            </FooterTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
