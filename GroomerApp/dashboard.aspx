<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainMaster.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="GroomerApp.dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="innercontent">

        <%--Region Error/Success message start--%>
            &nbsp;
            <div id="divMsg" runat="server">
                <asp:label id="lblMsg" runat="server" class="not_avail"></asp:label>
            </div>
        <div id="divError" runat="server">
            <asp:label id="lblError" runat="server" class="avail"></asp:label>
        </div>
        <div class="divrow" id="divDetails" runat="server">
            <div class="divrow">
                <div class="divcell_left">
                    <asp:label id="Label1" runat="server" cssclass="appnt_lbl">Appointment Date/Time:</asp:label>
                </div>
                <div class="divcell_right">
                    <asp:label id="lbl_time" runat="server" cssclass="appnt_detail" text=""></asp:label>
                </div>
            </div>
            <div class="divrow">
                <div class="divcell_left">
                    <asp:label id="Label2" runat="server" cssclass="appnt_lbl">String:</asp:label>
                </div>
                <div class="divcell_right">
                    <asp:label id="lbl_description" runat="server" cssclass="appnt_detail" text=""></asp:label>
                </div>
            </div>

        </div>
        <div class="divrow">
            <div class="go_btn">
                <asp:button id="Button1" runat="server" text="Go" tooltip="Go" cssclass="btn"
                    onclick="Button1_Click" />
            </div>
        </div>
        <div class="spacer10">
        </div>
        <div class="innercontent">
            <div class="bottombtn">
                <asp:button id="btnSubmit" runat="server" text="Submit" tooltip="Submit" visible="false" cssclass="btn" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" runat="server">
</asp:Content>
