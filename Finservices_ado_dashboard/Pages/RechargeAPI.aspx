<%@ Page Title="Recharge API" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RechargeAPI.aspx.cs" Inherits="Finservices_ado_dashboar.Pages.RechargeAPI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Simulate Recharge</h2>
    <div class="form-group">
        <label>Mobile Number</label>
        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label>Operator</label>
        <asp:TextBox ID="txtOperator" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label>Amount</label>
        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" />
    </div>
    <br />
    <asp:Button ID="btnRecharge" runat="server" CssClass="btn btn-success" Text="Recharge" OnClick="btnRecharge_Click" />
    <br /><br />
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
</asp:Content>
