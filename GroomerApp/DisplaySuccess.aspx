<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainMaster.Master" AutoEventWireup="true" CodeBehind="DisplaySuccess.aspx.cs" Inherits="GroomerApp.DisplaySuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1>Payment Success</h1>
    <%= mMessage %>
    <p>
    </p>
    <p>
        <asp:Button id="btndone" runat="server" cssclass="btn" text="Next Appointment" onclick="btndone_Click"
            validationgroup="Payment_Validation" width="101px" />
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" runat="server">
</asp:Content>
