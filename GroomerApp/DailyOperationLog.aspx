<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainMaster.Master" AutoEventWireup="true" CodeBehind="DailyOperationLog.aspx.cs" Inherits="GroomerApp.DailyOperationLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h2>Daily Operations Log</h2>
    <div class="innercontent">
        <%--Region Error/Success message start--%>
        <div style="width: 80%;" id="divError" runat="server">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
        <%--Region Error/Success message end--%>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="Label1" runat="server" CssClass="lbl">Date:</asp:Label>
            </div>
            <div class="divcell_right">
                <asp:TextBox ID="txtDate" runat="server" ReadOnly="true" CssClass="txt txt117" MaxLength="20"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblVanID" runat="server" CssClass="lbl">Van ID:<span style="color:Red">*</span></asp:Label>
            </div>
            <div class="divcell_right">
                <asp:TextBox ID="txtVanID" runat="server" CssClass="txt txt117" MaxLength="10"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblBeginningMileage" runat="server" CssClass="lbl">Beginning Mileage:<span style="color:Red">*</span></asp:Label>
            </div>
            <div class="divcell_right">
                <asp:TextBox ID="txtBeginningMileage" runat="server" CssClass="txt txt117" MaxLength="8"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblTotalHours" runat="server" CssClass="lbl">Total Hours:<span style="color:Red">*</span></asp:Label>
            </div>
            <div class="divcell_right">
                <asp:TextBox ID="txtTotalHours" runat="server" CssClass="txt txt117" MaxLength="8"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblEndingMileage" runat="server" CssClass="lbl">Ending Mileage:<span style="color:Red">*</span></asp:Label>
            </div>
            <div class="divcell_right">
                <asp:TextBox ID="txtEndingMileage" runat="server" CssClass="txt txt117" MaxLength="8"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblFuelPurchased" runat="server" CssClass="lbl">Fuel Purchased:<span style="color:Red">*</span></asp:Label>
            </div>
            <div class="divcell_right">
                <asp:TextBox ID="txtFuelPurchased" runat="server" CssClass="txt txt117" MaxLength="8"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblPriceperGallon" runat="server" CssClass="lbl">Price per Gallon:<span style="color:Red">*</span></asp:Label>
            </div>
            <div class="divcell_right">
                <asp:TextBox ID="txtPriceperGallon" runat="server" CssClass="txt txt117" MaxLength="8"></asp:TextBox>
            </div>
        </div>
        <div class="spacer10">
        </div>
        <div class="innercontent">
            <div class="bottombtnNew">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="Submit" OnClientClick="return validate();"
                    CssClass="btn" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" runat="server">
    <script lang="javascript" type="text/javascript">
        function validate() {

            if (document.getElementById('<%=txtVanID.ClientID %>').value == "") {
                alert("Van ID" + " : " + "Please Enter Van ID.");
                document.getElementById('<%=txtVanID.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtBeginningMileage.ClientID %>').value == "") {
                alert("Beginning Mileage" + " : " + "Please Enter Beginning Mileage.");
                document.getElementById('<%=txtBeginningMileage.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtBeginningMileage.ClientID %>').value != "") {

                var a = document.getElementById('<%= txtBeginningMileage.ClientID %>').value;
                if (parseInt(a) <= 0) {
                    alert("Beginning Mileage" + " : " + "Not a valid Beginning Mileage.");
                    document.getElementById('<%=txtBeginningMileage.ClientID %>').focus();
                    return false;

                }

            }
            if (IsNumeric(document.getElementById('<%=txtBeginningMileage.ClientID %>').value) == false) {
                alert("Beginning Mileage" + " : " + "Not a valid Beginning Mileage.");
                document.getElementById('<%=txtBeginningMileage.ClientID %>').focus();
                return false;
            }
            if (IsNumericRev(document.getElementById('<%=txtTotalHours.ClientID %>').value) == false) {
                alert("Total Hours" + " : " + "Not a valid Total Hours.");
                document.getElementById('<%=txtTotalHours.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtEndingMileage.ClientID %>').value) == false) {
                alert("Ending Mileage" + " : " + "Not a valid Ending Mileage.");
                document.getElementById('<%=txtEndingMileage.ClientID %>').focus();
                return false;
            }
            var Bmileage = document.getElementById('<%=txtBeginningMileage.ClientID %>').value;
            var Emileage = document.getElementById('<%=txtEndingMileage.ClientID %>').value;
            if (document.getElementById('<%=txtEndingMileage.ClientID %>').value != "") {
                if (parseInt(Emileage) < parseInt(Bmileage)) {
                    alert("Ending Mileage" + " : " + "Ending mileage should be more than beginning mileage.");
                    document.getElementById('<%=txtEndingMileage.ClientID %>').focus();
                    return false;
                }
            }
            if (IsNumericRev(document.getElementById('<%=txtFuelPurchased.ClientID %>').value) == false) {
                alert("Fuel Purchased" + " : " + "Not a valid Fuel Purchased.");
                document.getElementById('<%=txtFuelPurchased.ClientID %>').focus();
                return false;
            }
            if (IsNumericRev(document.getElementById('<%=txtPriceperGallon.ClientID %>').value) == false) {
                alert("Price Per Gallon" + " : " + "Not a valid Price Per Gallon.");
                document.getElementById('<%=txtPriceperGallon.ClientID %>').focus();
                return false;
            }
        }

        function IsNumeric(sText) {
            var ValidChars = "0123456789";
            var IsNumber = true;
            var Char;


            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (ValidChars.indexOf(Char) == -1) {
                    IsNumber = false;
                }
            }
            return IsNumber;

        }
        function IsNumericRev(sText) {
            var ValidChars = "0123456789.";
            var IsNumber = true;
            var Char;


            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (ValidChars.indexOf(Char) == -1) {
                    IsNumber = false;
                }
            }
            return IsNumber;

        }

    </script>
</asp:Content>
