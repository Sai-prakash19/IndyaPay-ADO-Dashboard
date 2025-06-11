<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Finservices_ado_dashboard.Pages.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Welcome to IndyaPay Dashboard</h2>

    <div class="row mb-4">
        <div class="col-md-6">
            <div class="card text-white bg-success">
                <div class="card-body">
                    <h5 class="card-title">Total Recharges</h5>
                    <asp:Label ID="lblTotalRecharges" runat="server" CssClass="display-6" />
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="card text-white bg-primary">
                <div class="card-body">
                    <h5 class="card-title">Total Recharge Amount</h5>
                    <asp:Label ID="lblTotalAmount" runat="server" CssClass="display-6" />
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="card border border-success">
                <div class="card-body">
                    <h5 class="card-title">Recharge</h5>
                    <p>Simulate a recharge operation.</p>
                    <a href="RechargeAPI.aspx" class="btn btn-success">Go to Recharge</a>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="card border border-info">
                <div class="card-body">
                    <h5 class="card-title">Recharge History</h5>
                    <p>View all past recharge records.</p>
                    <a href="RechargeHistory.aspx" class="btn btn-info">Go to History</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
