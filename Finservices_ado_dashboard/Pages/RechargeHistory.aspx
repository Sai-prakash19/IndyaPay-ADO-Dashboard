<%@ Page Title="Recharge History" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RechargeHistory.aspx.cs" Inherits="Finservices_ado_dashboar.Pages.RechargeHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Recharge History</h2>

    <div class="row mb-3">
        <div class="col-md-3">
            <label>Operator</label>
            <asp:DropDownList ID="ddlOperator" runat="server" CssClass="form-control">
                <asp:ListItem Text="--All--" Value="" />
                <asp:ListItem Text="Airtel" Value="Airtel" />
                <asp:ListItem Text="Jio" Value="Jio" />
                <asp:ListItem Text="Vi" Value="Vi" />
                <asp:ListItem Text="BSNL" Value="BSNL" />
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
            <label>From Date</label>
            <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" TextMode="Date" />
        </div>
        <div class="col-md-3">
            <label>To Date</label>
            <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" TextMode="Date" />
        </div>
        <div class="col-md-3 mt-4 pt-2">
            <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-primary" OnClick="btnFilter_Click" />
        </div>
    </div>

    <asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
        <Columns>
            <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" />
            <asp:BoundField DataField="Operator" HeaderText="Operator" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:C}" />
            <asp:BoundField DataField="RechargedAt" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy HH:mm}" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblCount" runat="server" Font-Bold="true" />
</asp:Content>
