<%@ Page Title="Backup/Restore" Language="C#" MasterPageFile="~/DefaultSite.Master" AutoEventWireup="true" CodeBehind="BackupRestore.aspx.cs" Inherits="WebForms.BackupRestore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card">
            <h5 class="card-header">Backup & restore database from XML</h5>
            <div class="card-body">
                <p class="card-text"><asp:Label ID="lblInfo" runat="server" /></p>
                <asp:Button ID="btnBackup" OnClick="btnBackup_Click" Text="Backup" runat="server" class="btn btn-success" />
                <asp:Button ID="btnRestore" OnClick="btnRestore_Click" Text="Restore" runat="server" class="btn btn-info" />
                <asp:Button ID="btnClearData" OnClick="btnClearData_Click" Text="Clear data" runat="server" class="btn btn-danger" />
            </div>
        </div>
    </div>
</asp:Content>
