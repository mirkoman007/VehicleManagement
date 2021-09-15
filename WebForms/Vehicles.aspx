<%@ Page Title="Vehicles" Language="C#" MasterPageFile="~/DefaultSite.Master" AutoEventWireup="true" CodeBehind="Vehicles.aspx.cs" Inherits="WebForms.Vehicles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="title">Vehicles</div>
        <asp:Repeater runat="server" ID="vehicleRepeater" >
            <HeaderTemplate>
                <table class="table table-hover">
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col">Make</th>
                            <th scope="col">Vehicle type</th>
                            <th scope="col">First registration</th>
                            <th scope="col">Mileage</th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("Make") %>
                    </td>
                    <td>
                        <%# Eval("VehicleType") %>
                    </td>
                    <td>
                        <%# Eval("FirstRegistration") %>
                    </td>
                    <td>
                        <%# Eval("Mileage") %>
                    </td>
                    <td>
                        <asp:Button ID="btnEdit" OnClick="btnEdit_Click" Text="Edit" runat="server" CssClass="btn btn-outline-warning btn-sm" CommandArgument='<%# Eval("IDVehicle") %>' />
                        <asp:Button ID="btnDelete" OnClick="btnDelete_Click" OnClientClick="return confirm('Do you really want delete the vehicle ?')" Text="Delete" runat="server" CssClass="btn btn-outline-danger btn-sm" CommandArgument='<%# Eval("IDVehicle") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>

            </FooterTemplate>
        </asp:Repeater>
        <div class="btn-group float-right mb-5" role="group">
            <asp:Button ID="btnAdd" OnClick="btnAdd_Click" Text="Add new vehicle" runat="server" CssClass="btn btn-secondary" />
        </div>
    </div>


</asp:Content>
