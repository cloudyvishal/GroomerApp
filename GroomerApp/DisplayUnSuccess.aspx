<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainMaster.Master" AutoEventWireup="true" CodeBehind="DisplayUnSuccess.aspx.cs" Inherits="GroomerApp.DisplayUnSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1>Payment UnSuccessful</h1>
    <%= mMessage %>
    <p>
    </p>
    <%= Transresult%>
    <p>
    </p>
    <p>
        <asp:button id="btndone" runat="server" cssclass="btn" text="Try Again" onclick="btndone_Click"
            validationgroup="Payment_Validation" width="101px" />
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" runat="server">
</asp:Content>
