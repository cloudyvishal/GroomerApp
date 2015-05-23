<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="GroomerApp.forgotpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fritzy's :: Groomer Forgot Password</title>
    <%-- SCREEN STYLE --%>
    <link href="Style/screen.css" rel="stylesheet" media="all" type="text/css" id="stylesheet" />
</head>
<body>
    <div class="maindiv">
        <form id="form1" runat="server">
            <!-- LOGO IMAGE DIV STATRS -->
            <div class="maincontainer">
            </div>
            <!-- LOGO IMAGE DIV ENDS-->
            <div class="contentainer" style="width: 30%;">
                <div class="containwrapper">
                    <!-- HEADER STARTS -->
                    <div class="header">
                        <div class="top_t">
                            <div class="top_tl">
                                <div class="top_tr">
                                    <div class="top_content">
                                        <h1>Groomer Forgot Password</h1>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- HEADER ENDS -->
                    <!-- CONTENT STATRS -->
                    <div class="content">
                        <div class="t">
                            <div class="b">
                                <div class="r">
                                    <div class="l">
                                        <div class="bl">
                                            <div class="br">
                                                <div class="tl">
                                                    <div class="tr">
                                                        <div class="contentbg" style="width: 260px;">
                                                            <div class="logindiv">
                                                                <%--Region Error/Success message start--%>
                                                                <div style="width: 95%;" id="divError" runat="server">
                                                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                                                </div>
                                                                <%--Region Error/Success message end--%>
                                                                <div class="divrow">
                                                                    <div class="divcell_left">
                                                                        <asp:Label ID="lblEmail" runat="server" CssClass="lbl">Email:</asp:Label></div>
                                                                    <div class="divcell_right">
                                                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="txt txt150"></asp:TextBox>
                                                                        <br />
                                                                        <asp:RequiredFieldValidator ID="req" runat="server" ErrorMessage="Please Enter Email id" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="divrow">
                                                                    <div class="divcell_left">&nbsp;</div>
                                                                    <div class="divcell_right">
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="Submit" AccessKey="1" CssClass="btn" OnClick="btnSubmit_Click" />
                                                                        <asp:Button ID="btnBack" runat="server" Text="Back" ToolTip="Back" AccessKey="1" CssClass="btn" OnClick="btnBack_Click" CausesValidation="false" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- CONTENT ENDS -->
                </div>
            </div>
        </form>
    </div>
</body>
</html>
