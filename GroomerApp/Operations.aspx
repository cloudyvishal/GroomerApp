<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainMaster.Master" AutoEventWireup="true" CodeBehind="Operations.aspx.cs" Inherits="GroomerApp.Operations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <h2>Appointment Reporting</h2>
                <div style="width: 80%;" id="divError" runat="server">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </div>
                <table width="100%">
                    <tr>
                        <td align="center" style="width: 60%">
                            <asp:Button ID="btnStartApt" runat="server" Text="Start Appt." CssClass="btn" OnClick="btnStartApt_Click" />
                        </td>
                        <td align="center">
                            <asp:Button ID="btnEndApt" runat="server" Text="End Appt." CssClass="btn" OnClick="btnEndApt_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                        <caption>
                            &nbsp;
                        </caption>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Appt. Start Time:-" CssClass="appnt_lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblApptStartTime" runat="server" CssClass="appnt_detail"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text="Appt. End Time:-" CssClass="appnt_lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblApptEndTime" runat="server" CssClass="appnt_detail"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 300px">
                            <asp:Label ID="Label3" runat="server" Text="Pet Time:-" CssClass="appnt_lbl"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblApptCompleteTime" runat="server" CssClass="appnt_detail"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div class="innercontent">
                    <div class="divrow" id="divDetails" runat="server">
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="Label11" runat="server" CssClass="appnt_lbl">Appt. Date/Time:</asp:Label>
                            </div>
                            <div class="divcell_right" style="font-weight: normal;">
                                <asp:Label ID="lbl_time" runat="server" CssClass="appnt_detail" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="Label12" runat="server" CssClass="appnt_lbl">String:</asp:Label>
                            </div>
                            <div class="divcell_right" style="font-weight: normal !important;">
                                <asp:Label ID="lbl_description" runat="server" CssClass="appnt_detail" Text=""></asp:Label>
                            </div>
                        </div>
                        <div style="width: 85%;">
                            <asp:Label ID="lblAppSubmit" runat="server" ForeColor="Red" Text=""></asp:Label>
                            <asp:Label ID="lblAppSubmit1" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </div>
                    </div>
                    <div style="width: 85%;" id="div1" runat="server">
                        <asp:Label ID="lblErrorDate" runat="server" ForeColor="red" Visible="false"></asp:Label>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblDates" runat="server" CssClass="appnt_lbl">Date:</asp:Label>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtDate" ReadOnly="true" runat="server" CssClass="txt txt117" MaxLength="20"
                                TabIndex="1"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblLastName" runat="server" CssClass="appnt_lbl" Text="Last Name:"></asp:Label><span
                                style="color: Red">*</span>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtCustLastName" runat="server" CssClass="txt txt117" MaxLength="20"
                                TabIndex="2" AutoCompleteType="Disabled"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblJob" runat="server" CssClass="appnt_lbl" Text="Job Mileage:"></asp:Label><span
                                style="color: Red">*</span>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtJob" runat="server" CssClass="txt txt117" MaxLength="20" TabIndex="3"
                                AutoCompleteType="Disabled"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblZipCode" runat="server" CssClass="appnt_lbl" Text="Zip Code:"></asp:Label><span
                                style="color: Red">*</span>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtZipCode" runat="server" CssClass="txt txt117" MaxLength="5" TabIndex="4"
                                AutoCompleteType="Disabled"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblPets" runat="server" CssClass="appnt_lbl" Text="Pets:"></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtPets" runat="server" CssClass="txt txt117" MaxLength="2" TabIndex="5"
                                AutoCompleteType="Disabled"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblRebook" runat="server" CssClass="appnt_lbl">Rebook:</asp:Label>
                        </div>
                        <div class="divcell_right_two">
                            <asp:RadioButtonList RepeatDirection="Horizontal" ID="rdoRebook" runat="server" CellPadding="1"
                                CellSpacing="0" CssClass="radiobtn" AutoPostBack="True" OnSelectedIndexChanged="rdoRebook_SelectedIndexChanged"
                                TabIndex="6">
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="innercontent" id="divNextAppoint" runat="server">
                            <h2>Next Appointment</h2>
                            <div>
                                <asp:Label ID="lbldatevalmsg" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label>
                            </div>
                            <div class="divrow">
                                <div class="divcell_left">
                                    Date:<span style="color: Red">*</span>
                                </div>
                                <div class="divcell_right_two" style="margin-bottom: 5px;">
                                    <asp:DropDownList ID="ddlMonth" runat="server" Style="margin-left: 20px; font-size: 11px;">
                                        <asp:ListItem Text="January" Value="01"></asp:ListItem>
                                        <asp:ListItem Text="February" Value="02"></asp:ListItem>
                                        <asp:ListItem Text="March" Value="03"></asp:ListItem>
                                        <asp:ListItem Text="April" Value="04"></asp:ListItem>
                                        <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                        <asp:ListItem Text="June" Value="06"></asp:ListItem>
                                        <asp:ListItem Text="July" Value="07"></asp:ListItem>
                                        <asp:ListItem Text="August" Value="08"></asp:ListItem>
                                        <asp:ListItem Text="September" Value="09"></asp:ListItem>
                                        <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="dddDay" runat="server">
                                        <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                        <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                        <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                        <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                        <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                        <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                        <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                        <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                        <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                        <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                        <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                        <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                        <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                        <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                        <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                        <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                        <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                        <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlYear" runat="server">
                                        <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                                        <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                                        <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                                        <asp:ListItem Text="2013" Value="2013" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                        <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                        <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                        <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                                        <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                        <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                        <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                        <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="divrow">
                                    <div class="divrow">
                                        <div class="divcell_left">
                                            <asp:Label ID="lblNextTime" runat="server" CssClass="appnt_lbl">Start Time:<span style="color:Red">*</span></asp:Label>
                                        </div>
                                        <div class="divcell_right_two">
                                            <span class="lbl" style="font-weight: normal;">Hrs</span>
                                            <asp:DropDownList ID="ddlhr" CssClass="appTextFldtime" runat="server">
                                                <asp:ListItem Text="7:00" Value="7"></asp:ListItem>
                                                <asp:ListItem Text="8:00" Value="8"></asp:ListItem>
                                                <asp:ListItem Text="9:00" Value="9"></asp:ListItem>
                                                <asp:ListItem Text="10:00" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="11:00" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="12:00" Value="12"></asp:ListItem>
                                                <asp:ListItem Text="1:00" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2:00" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3:00" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="4:00" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="5:00" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="6:00" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="7:00" Value="7"></asp:ListItem>
                                            </asp:DropDownList>
                                            <span class="lbl" style="font-weight: normal;">Min</span><asp:DropDownList ID="ddlMin1"
                                                CssClass="appTextFldAm" runat="server">
                                                <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                                <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                                <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                                <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlmin" CssClass="appTextFldAm" runat="server">
                                                <asp:ListItem Value="AM" Text="AM"></asp:ListItem>
                                                <asp:ListItem Value="PM" Text="PM"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="divrow">
                                        <div class="divcell_left">
                                            <asp:Label ID="Label10" runat="server" CssClass="appnt_lbl">End Time:<span style="color:Red">*</span></asp:Label>
                                        </div>
                                        <div class="divcell_right_two">
                                            <span class="appnt_lbl" style="font-weight: normal;">Hrs</span>
                                            <asp:DropDownList ID="ddlEndTimeHrs" CssClass="appTextFldtime" runat="server">
                                                <asp:ListItem Text="7:00" Value="7"></asp:ListItem>
                                                <asp:ListItem Text="8:00" Value="8"></asp:ListItem>
                                                <asp:ListItem Text="9:00" Value="9"></asp:ListItem>
                                                <asp:ListItem Text="10:00" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="11:00" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="12:00" Value="12"></asp:ListItem>
                                                <asp:ListItem Text="1:00" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2:00" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3:00" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="4:00" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="5:00" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="6:00" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="7:00" Value="7"></asp:ListItem>
                                            </asp:DropDownList>
                                            <span class="appnt_lbl" style="font-weight: normal;">Min</span><asp:DropDownList
                                                ID="ddlEndTimeMin1" CssClass="appTextFldAm" runat="server">
                                                <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                                <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                                <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                                <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                                <asp:ListItem>00</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlEndTimeMin" CssClass="appTextFldAm" runat="server">
                                                <asp:ListItem Value="AM" Text="AM"></asp:ListItem>
                                                <asp:ListItem Value="PM" Text="PM"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="divrow">
                                    <div class="divcell_left">
                                        <asp:Label ID="lblServicesforPet1" runat="server" CssClass="appnt_lbl">Services for Pet-1:</asp:Label>
                                    </div>
                                    <div class="divcell_right_two">
                                        <asp:TextBox ID="txtServicesforPet1" runat="server" CssClass="txt txt117" MaxLength="256"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="divrow">
                                    <div class="divcell_left">
                                        <asp:Label ID="lblServicesforPet2" runat="server" CssClass="appnt_lbl">Services for Pet-2:</asp:Label>
                                    </div>
                                    <div class="divcell_right_two">
                                        <asp:TextBox ID="txtServicesforPet2" runat="server" CssClass="txt txt117" MaxLength="256"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="divrow">
                                    <div class="divcell_left">
                                        <asp:Label ID="lblServicesforPet3" runat="server" CssClass="appnt_lbl">Services for Pet-3:</asp:Label>
                                    </div>
                                    <div class="divcell_right_two">
                                        <asp:TextBox ID="txtServicesforPet3" runat="server" CssClass="txt txt117" MaxLength="256"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="divrow">
                                    <div class="divcell_left">
                                        <asp:Label ID="lblServicesforPet4" runat="server" CssClass="appnt_lbl">Services for Pet-4:</asp:Label>
                                    </div>
                                    <div class="divcell_right_two">
                                        <asp:TextBox ID="txtServicesforPet4" runat="server" CssClass="txt txt117" MaxLength="256"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="divrow">
                                    <div class="divcell_left">
                                        <asp:Label ID="lblServicesforPet5" runat="server" CssClass="appnt_lbl">Services for Pet-5:</asp:Label>
                                    </div>
                                    <div class="divcell_right_two">
                                        <asp:TextBox ID="txtServicesforPet5" runat="server" CssClass="txt txt117" MaxLength="256"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="divrow">
                                    <div class="divcell_left">
                                        <asp:Label ID="lblServicesforPet6" runat="server" CssClass="appnt_lbl">Services for Pet-6:</asp:Label>
                                    </div>
                                    <div class="divcell_right_two">
                                        <asp:TextBox ID="txtServicesforPet6" runat="server" CssClass="txt txt117" MaxLength="256"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="spacer10">
                            </div>
                        </div>
                        <div class="divrow" id="dvfromrebook" runat="server" visible="false">
                            <div class="divcell_left">
                                <asp:Label ID="lblFromRebook" runat="server" CssClass="appnt_lbl">From Rebook:</asp:Label>
                            </div>
                            <div class="divcell_right_two">
                                <asp:RadioButtonList RepeatDirection="Horizontal" ID="rdoFromRebook" runat="server"
                                    CellPadding="1" CellSpacing="0" CssClass="radiobtn" TabIndex="7">
                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="divrow" id="dvnew" runat="server" visible="false">
                            <div class="divcell_left">
                                <asp:Label ID="lblNew" runat="server" CssClass="appnt_lbl">New:</asp:Label>
                            </div>
                            <div class="divcell_right_two">
                                <asp:RadioButtonList RepeatDirection="Horizontal" ID="rdoNew" runat="server" CellPadding="1"
                                    CellSpacing="0" CssClass="radiobtn" TabIndex="8">
                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                    <div class="spacer10">
                    </div>
                    <div style="display: none">
                        <div class="divcell_left">
                            <asp:Label ID="lblTimeIn" runat="server" CssClass="appnt_lbl">Time In:<span style="color:Red">*</span></asp:Label>
                        </div>
                        <div class="divcell_right_two">
                            <span class="lbl" style="font-weight: normal;">Hrs</span>
                            <asp:DropDownList ID="ddlTimeIn" CssClass="appTextFldtime" runat="server" onchange="javascript: CalculatePetTime(this);"
                                CausesValidation="false" TabIndex="9">
                                <asp:ListItem Text="07:00" Value="7"></asp:ListItem>
                                <asp:ListItem Text="08:00" Value="8"></asp:ListItem>
                                <asp:ListItem Text="09:00" Value="9"></asp:ListItem>
                                <asp:ListItem Text="10:00" Value="10"></asp:ListItem>
                                <asp:ListItem Text="11:00" Value="11"></asp:ListItem>
                                <asp:ListItem Text="12:00" Value="12"></asp:ListItem>
                                <asp:ListItem Text="01:00" Value="1"></asp:ListItem>
                                <asp:ListItem Text="02:00" Value="2"></asp:ListItem>
                                <asp:ListItem Text="03:00" Value="3"></asp:ListItem>
                                <asp:ListItem Text="04:00" Value="4"></asp:ListItem>
                                <asp:ListItem Text="05:00" Value="5"></asp:ListItem>
                                <asp:ListItem Text="06:00" Value="6"></asp:ListItem>
                                <asp:ListItem Text="07:00" Value="7"></asp:ListItem>
                            </asp:DropDownList>
                            <span class="lbl" style="font-weight: normal;">Min</span>
                            <asp:DropDownList ID="ddlMinIN" CssClass="appTextFldAm" runat="server" onchange="javascript: CalculatePetTime(this);"
                                CausesValidation="false" TabIndex="10">
                                <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                <asp:ListItem Text="55" Value="55"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlIN" CssClass="appTextFldtime" runat="server" onchange="javascript: CalculatePetTime(this);"
                                CausesValidation="false" TabIndex="11">
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="lblTimeOut" runat="server" CssClass="appnt_lbl">Time Out:<span style="color:Red">*</span></asp:Label>
                            </div>
                            <div class="divcell_right_two">
                                <span class="lbl" style="font-weight: normal;">Hrs</span>
                                <asp:DropDownList ID="ddlTimeout" CssClass="appTextFldtime" runat="server" onchange="javascript: CalculatePetTime(this);"
                                    CausesValidation="false" TabIndex="12">
                                    <asp:ListItem Text="07:00" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="08:00" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="09:00" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="10:00" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11:00" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12:00" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="01:00" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="02:00" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="03:00" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="04:00" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="05:00" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="06:00" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="07:00" Value="7"></asp:ListItem>
                                </asp:DropDownList>
                                <span class="lbl" style="font-weight: normal;">Min</span>
                                <asp:DropDownList ID="ddlMinOUT" CssClass="appTextFldAm" runat="server" onchange="javascript: CalculatePetTime(this);"
                                    CausesValidation="false" TabIndex="13">
                                    <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                    <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                    <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlOUT" CssClass="appTextFldtime" runat="server" onchange="javascript: CalculatePetTime(this);"
                                    CausesValidation="false" TabIndex="14">
                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtPetTime" runat="server" Width="0px" CssClass="pet_time" MaxLength="20"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="spacer10">
                    </div>
                    <h2>Supplies</h2>
                    <div class="innercontent">
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="lblFleaandTick22" runat="server" CssClass="appnt_lbl" Text="Flea & Tick–22:"></asp:Label>
                                <span style="color: Red">*</span>
                            </div>
                            <div class="divcell_right_two">
                                <asp:TextBox ID="txtFleaandTick22" runat="server" CssClass="txt txt117" MaxLength="8"
                                    TabIndex="15" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="lblFleaandTick44" runat="server" CssClass="appnt_lbl" Text="Flea & Tick–44:"></asp:Label>
                                <span style="color: Red">*</span>
                            </div>
                            <div class="divcell_right_two">
                                <asp:TextBox ID="txtFleaandTick44" runat="server" CssClass="txt txt117" MaxLength="8"
                                    TabIndex="16" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="lblFleaandTick88" runat="server" CssClass="appnt_lbl" Text="Flea & Tick–88:"></asp:Label>
                                <span style="color: Red">*</span>
                            </div>
                            <div class="divcell_right_two">
                                <asp:TextBox ID="txtFleaandTick88" runat="server" CssClass="txt txt117" MaxLength="8"
                                    TabIndex="17" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="lblFleaandTick132" runat="server" CssClass="appnt_lbl" Text="Flea & Tick–132:"></asp:Label>
                                <span style="color: Red">*</span>
                            </div>
                            <div class="divcell_right_two">
                                <asp:TextBox ID="txtFleaandTick132" runat="server" CssClass="txt txt117" MaxLength="8"
                                    TabIndex="18" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="lblFleaandTickCat" runat="server" CssClass="appnt_lbl" Text="Flea & Tick–Cat:"></asp:Label>
                                <span style="color: Red">*</span>
                            </div>
                            <div class="divcell_right_two">
                                <asp:TextBox ID="txtFleaandTickCat" runat="server" CssClass="txt txt117" MaxLength="8"
                                    TabIndex="19" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="lblTB" runat="server" CssClass="appnt_lbl" Text="TB:"></asp:Label>
                                <span style="color: Red">*</span>
                            </div>
                            <div class="divcell_right_two">
                                <asp:TextBox ID="txtTB" runat="server" CssClass="txt txt117" MaxLength="4" TabIndex="20"
                                    AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="lblWham" runat="server" CssClass="appnt_lbl">Wham:</asp:Label>
                                <span style="color: Red">*</span>
                            </div>
                            <div class="divcell_right_two">
                                <asp:TextBox ID="txtWham" runat="server" CssClass="txt txt117" MaxLength="4" TabIndex="21"
                                    AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="spacer10">
                    </div>
                    <h2>Revenue<span style="color: Red">*</span></h2>
                    <div class="innercontent">
                        <div class="divrow">
                            <div class="divcell_left">
                                &nbsp;
                            </div>
                            <div class="divcell_right_two">
                                <asp:RadioButtonList ID="rdoRevenue" runat="server" CssClass="radiobtn" onclick="javascript: getCheckedRevnue(this);"
                                    OnSelectedIndexChanged="rdoRevenue_SelectedIndexChanged" AutoPostBack="True"
                                    TabIndex="22" Width="126px">
                                    <asp:ListItem Text=" Credit Card" Value="0"></asp:ListItem>
                                    <asp:ListItem Value="1">CCY</asp:ListItem>
                                    <asp:ListItem Text="Check" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Cash" Value="3" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Invoice" Value="4"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="lblExtraServices0" runat="server" CssClass="appnt_lbl">Revenue 
                                Amt($)</asp:Label><span style="color: Red">*</span>
                            </div>
                            <div class="divcell_right_two">
                                <asp:TextBox ID="txtRevenue" runat="server" CssClass="txt txt117" MaxLength="8" TabIndex="23"
                                    AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="lblExtraServices" runat="server" CssClass="appnt_lbl">Appt Changes:</asp:Label>
                                <asp:Label ID="lblaptchangesreq" runat="server" CssClass="appnt_lbl" ForeColor="Red"
                                    Visible="False">*</asp:Label>
                            </div>
                            <div class="divcell_right_two">
                                <asp:TextBox ID="txtExtraServices" runat="server" CssClass="txt txt117" Height="40px"
                                    MaxLength="256" TabIndex="24" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div id="divaptchangesrequired" class="divrow" visible="false" runat="server">
                            <asp:Label ID="lblaptchange" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="lblComment" runat="server" CssClass="appnt_lbl">Comments:</asp:Label>
                                <asp:Label ID="lblCommentsreq" runat="server" CssClass="appnt_lbl" ForeColor="Red"
                                    Visible="False"></asp:Label>
                            </div>
                            <div class="divcell_right_two">
                                <asp:TextBox ID="txtComments" runat="server" CssClass="txt txt117" Height="60px"
                                    MaxLength="500" TabIndex="25" AutoCompleteType="Disabled" TextMode="MultiLine"
                                    Font-Size="Small"></asp:TextBox><br />
                                <br />
                            </div>
                            <div class="divcell_left">
                                <asp:Label ID="lblDriveTime" runat="server" CssClass="appnt_lbl">Drive Time</asp:Label>
                                <span style="color: Red">*</span>                               
                            </div>
                            <div class="divcell_right_two">
                                <asp:RadioButtonList ID="rdoDriveTime" runat="server" CssClass="radiobtn" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow" OnSelectedIndexChanged="rdoDriveTime_SelectedIndexChanged"
                                    AutoPostBack="true">
                                    <asp:ListItem Value="1">Good</asp:ListItem>
                                    <asp:ListItem Value="0">Bad</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator runat="server" ID="radRfvDriveTime" ControlToValidate="rdoDriveTime"
                                    InitialValue="" EnableClientScript="false" ErrorMessage="" SetFocusOnError="true"
                                    ValidationGroup="submit"><br />Enter Time Assessment(s).</asp:RequiredFieldValidator>
                                <br />
                                <br />
                            </div>
                            <div class="divcell_left">
                                <asp:Label ID="lblPetTime" runat="server" CssClass="appnt_lbl">Pet Time</asp:Label>
                                <span style="color: Red">*</span>
                            </div>
                            <div class="divcell_right_two">
                                <asp:RadioButtonList ID="rdoPetTime" runat="server" RepeatDirection="Horizontal"
                                    RepeatLayout="Flow" CssClass="radiobtn" OnSelectedIndexChanged="rdoPetTime_SelectedIndexChanged"
                                    AutoPostBack="true">
                                    <asp:ListItem Value="1">Good</asp:ListItem>
                                    <asp:ListItem Value="0">Bad</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator runat="server" ID="radRfvPetTime" ControlToValidate="rdoPetTime"
                                    InitialValue="" EnableClientScript="false" ErrorMessage="" SetFocusOnError="true"
                                    ValidationGroup="submit"><br />Enter Time Assessment(s).</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="spacer10">
                    </div>
                    <h2>Product</h2>
                    <div class="innercontent">
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="Label8" runat="server" CssClass="appnt_lbl" Text="Product Price:"></asp:Label>
                            </div>
                            <div class="divcell_right_two">
                                <asp:TextBox ID="txtProductPrice" runat="server" CssClass="txt txt117" MaxLength="8"
                                    TabIndex="25" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="Label9" runat="server" CssClass="appnt_lbl" Text="Sales Tax:"></asp:Label>
                            </div>
                            <div class="divcell_right_two">
                                <asp:TextBox ID="txtSalestax" runat="server" CssClass="txt txt117" MaxLength="8"
                                    TabIndex="26" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="spacer10">
                    </div>
                    <h2>Tip</h2>
                    <div class="innercontent">
                        <div class="divrow">
                            <div class="divcell_left">
                                &nbsp;
                            </div>
                            <div class="divcell_right_two">
                                <asp:RadioButtonList ID="rdoTip" runat="server" CssClass="radiobtn" onclick="javascript: getCheckedRevnue(this);"
                                    AutoPostBack="True" OnSelectedIndexChanged="rdoTip_SelectedIndexChanged" TabIndex="27">
                                    <asp:ListItem Text="Credit Card" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Check" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Cash" Value="2" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Invoice" Value="3"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="lblExtraServices1" runat="server" CssClass="appnt_lbl">Tip Amt ($):</asp:Label>
                            </div>
                            <div class="divcell_right_two">
                                <asp:TextBox ID="txtTip" runat="server" CssClass="txt txt117" MaxLength="8" TabIndex="27"
                                    AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="spacer10">
                    </div>
                    <h2>Prior Revenue</h2>
                    <div class="innercontent">
                        <div class="divrow">
                            <div class="divcell_left">
                                &nbsp;
                            </div>
                            <div class="divcell_right_two">
                                <asp:RadioButtonList ID="rdoPrior" runat="server" CssClass="radiobtn" onclick="javascript: getCheckedRevnue(this);"
                                    AutoPostBack="True" OnSelectedIndexChanged="rdoPrior_SelectedIndexChanged" TabIndex="28">
                                    <asp:ListItem Text=" Credit Card" Value="0"></asp:ListItem>
                                    <asp:ListItem Text=" Check" Value="1"></asp:ListItem>
                                    <asp:ListItem Text=" Cash" Value="2" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="divrow">
                            <div class="divcell_left">
                                <asp:Label ID="lblpriorrevamt" runat="server" CssClass="appnt_lbl">Prior Rev.Amt($):</asp:Label><asp:Label
                                    ID="Label7" runat="server" CssClass="lbl">&nbsp;</asp:Label>
                            </div>
                            <div class="divcell_right_two">
                                <asp:TextBox ID="txtPriorRevenue" runat="server" CssClass="txt txt117" MaxLength="8"
                                    TabIndex="29" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <div class="spacer10">
                        </div>
                        <div id="chkdetails" runat="server">
                            <h2>Check Details</h2>
                            <br />
                            <table border="0" width="100%" align="center" class="">
                                <tr>
                                    <td style="width: 209px">
                                        <asp:Label ID="lblcustname" runat="server" CssClass="appnt_lbl">Name on check:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcname" runat="server" CssClass="txt txt117" MaxLength="200" ValidationGroup="submit"
                                            AutoCompleteType="Disabled"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblcustaddress" runat="server" CssClass="appnt_lbl">Address on 
                        check:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcaddr" runat="server" CssClass="txt txt117" MaxLength="250" ValidationGroup="submit"
                                            AutoCompleteType="Disabled"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="spacer10">
                    </div>
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="Submit" CssClass="btn"
                                    OnClientClick="return validate();" OnClick="btnSubmit_Click" ValidationGroup="submit"
                                    TabIndex="30" />
                            </td>
                        </tr>
                    </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="rdoRevenue" />
                <asp:AsyncPostBackTrigger ControlID="rdoTip" />
                <asp:AsyncPostBackTrigger ControlID="rdoPrior" />
                <asp:AsyncPostBackTrigger ControlID="rdoRebook" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="rdoPetTime" />
                <asp:AsyncPostBackTrigger ControlID="rdoDriveTime" />
            </Triggers>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Visible="true"
            CssClass="btnConfirm" Height="0px" Width="0px" BorderStyle="None" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" runat="server">
    <asp:ScriptManager ID="MyScriptManager" runat="server" />
    <script src="Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script lang="JavaScript" type="text/javascript">
        window.onbeforeunload = confirmExit;
        function confirmExit() {
            var clickButton = document.getElementById("<%= btnConfirm.ClientID %>");
            clickButton.click();
            return true;
        }
    </script>

    <script type="text/javascript" language="javascript">
        function AppTimeError() {
            alert('Appt.timings required.');
        }
    </script>

    <script type="text/javascript" language="javascript">
        function AppChangesError() {
            alert('Appt Changes required.');
        }
    </script>

    <script language="javascript" type="text/javascript">

        function Reebook(mytext3) {
            var radioButtons = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoRebook");

            for (var x = 0; x < radioButtons.length; x++) {
                if (radioButtons[x].checked) {
                    if (radioButtons[x].value == 0) {
                        document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
                    }
                    else {
                        document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
                    }

                }

            }

        }
        function CalculatePetTime(ddl) {
            var TimeIn = document.getElementById('<%= ddlTimeIn.ClientID %>').options[document.getElementById('<%= ddlTimeIn.ClientID %>').selectedIndex].value;
            var TimeMinIN = document.getElementById('<%= ddlMinIN.ClientID %>').options[document.getElementById('<%= ddlMinIN.ClientID %>').selectedIndex].value;
            var TimeAMPM = document.getElementById('<%= ddlIN.ClientID %>').options[document.getElementById('<%= ddlIN.ClientID %>').selectedIndex].value;

            var TimeOut = document.getElementById('<%= ddlTimeout.ClientID %>').options[document.getElementById('<%= ddlTimeout.ClientID %>').selectedIndex].value;
            var TimeMinOut = document.getElementById('<%= ddlMinOUT.ClientID %>').options[document.getElementById('<%= ddlMinOUT.ClientID %>').selectedIndex].value;
            var TimeAMPMOut = document.getElementById('<%= ddlOUT.ClientID %>').options[document.getElementById('<%= ddlOUT.ClientID %>').selectedIndex].value;


            var mydate2 = new Date();
            var theyear2 = mydate2.getFullYear();
            var themonth2 = mydate2.getMonth() + 1;
            var thetoday2 = mydate2.getDate();

            var currentdate2 = themonth2 + "/" + thetoday2 + "/" + theyear2;
            var dtIn = TimeIn + ":" + TimeMinIN + ":01 " + TimeAMPM;
            var dtOut = TimeOut + ":" + TimeMinOut + ":01 " + TimeAMPMOut;

            var date1 = new Date();
            var date2 = new Date();
            var diff = new Date();

            var date1temp = new Date(currentdate2 + " " + dtIn);
            date1.setTime(date1temp.getTime());

            var date2temp = new Date(currentdate2 + " " + dtOut);
            date2.setTime(date2temp.getTime());

            if (date1.getTime() > date2.getTime()) {
                diff.setTime(Math.abs(date1.getTime() - date2.getTime()));

                var timediff = diff.getTime();

                var hours = Math.floor(timediff / (1000 * 60 * 60));
                timediff -= hours * (1000 * 60 * 60);

                var mins = Math.round(timediff / (1000 * 60));
                timediff -= mins * (1000 * 60);

                var timespent = eval(hours + (mins / 60));
                timespent = Math.round(timespent * 100) / 100;

                document.getElementById('<%=txtPetTime.ClientID %>').value = "-" + timespent;
            }
            else {

                diff.setTime(Math.abs(date1.getTime() - date2.getTime()));

                var timediff = diff.getTime();

                var hours = Math.floor(timediff / (1000 * 60 * 60));
                timediff -= hours * (1000 * 60 * 60);

                var mins = Math.round(timediff / (1000 * 60));
                timediff -= mins * (1000 * 60);

                var timespent = eval(hours + (mins / 60));
                timespent = Math.round(timespent * 100) / 100;

                document.getElementById('<%=txtPetTime.ClientID %>').value = timespent;

            }
        }

        function getCheckedRevnue(mytext3) {
            var radioButtons3 = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoRevenue");
            var RevnueValue;
            for (var x = 0; x < radioButtons3.length; x++) {
                if (radioButtons3[x].checked) {
                    if (radioButtons3[x].value == 0) {

                        RevnueValue = 0;
                    }
                    else {
                        RevnueValue = 1;
                    }
                }
            }

            var radioButtons = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoTip");
            var TipValue;
            for (var x = 0; x < radioButtons.length; x++) {
                if (radioButtons[x].checked) {
                    if (radioButtons[x].value == 0) {

                        TipValue = 0;
                    }
                    else {
                        TipValue = 1;
                    }
                }
            }
            var radioButtons2 = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoPrior");
            var PriorValue;
            for (var x = 0; x < radioButtons2.length; x++) {
                if (radioButtons2[x].checked) {
                    if (radioButtons2[x].value == 0) {

                        PriorValue = 0;
                    }
                    else {
                        PriorValue = 1;
                    }
                }
            }
            if (PriorValue == 0 || TipValue != 0 || RevnueValue != 0) {

                document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
            }
            else {
                document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
            }
            if (PriorValue != 0 || TipValue == 0 || RevnueValue != 0) {

                document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
            }
            else {
                document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
            }
            if (PriorValue != 0 || TipValue != 0 || RevnueValue == 0) {

                document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
            }
            else {
                document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
            }

        }
    </script>
    <script lang="javascript" type="text/javascript">
        function validate() {

            if (document.getElementById('<%=txtCustLastName.ClientID %>').value == "") {
                alert("Please Enter Last Name.");
                document.getElementById('<%=txtCustLastName.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtJob.ClientID %>').value == "") {
                alert("Please Enter Job Mileage.");
                document.getElementById('<%=txtJob.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtJob.ClientID %>').value) == false) {
                alert("Not a valid Job Mileage.");
                document.getElementById('<%=txtJob.ClientID %>').focus();
                return false;
            }
            var JobMileage = '<%= Session["BeginningMileage"]%>';
            var jobtextvalue = parseInt(document.getElementById('<%=txtJob.ClientID %>').value);
            if (jobtextvalue < JobMileage) {
                alert("Job mileage should be greater than or equal to begning mileage.");
                document.getElementById('<%=txtJob.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtZipCode.ClientID %>').value == "") {
                alert("Please Enter Zip Code.");
                document.getElementById('<%=txtZipCode.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtZipCode.ClientID %>').value) == false) {
                alert("Not a valid Zip code.");
                document.getElementById('<%=txtZipCode.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtPets.ClientID %>').value == "") {
                alert("Please Enter Pets.");
                document.getElementById('<%=txtPets.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtFleaandTick22.ClientID %>').value == "") {
                alert("Please Enter FleaandTick22.");
                document.getElementById('<%=txtFleaandTick22.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtFleaandTick44.ClientID %>').value == "") {
                alert("Please Enter FleaandTick44.");
                document.getElementById('<%=txtFleaandTick44.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtFleaandTick88.ClientID %>').value == "") {
                alert("Please Enter FleaandTick88.");
                document.getElementById('<%=txtFleaandTick88.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtFleaandTick132.ClientID %>').value == "") {
                alert("Please Enter FleaandTick132.");
                document.getElementById('<%=txtFleaandTick132.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtFleaandTickCat.ClientID %>').value == "") {
                alert("Please Enter FleaandTickCat.");
                document.getElementById('<%=txtFleaandTickCat.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtTB.ClientID %>').value == "") {
                alert("Please Enter TB.");
                document.getElementById('<%=txtTB.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtWham.ClientID %>').value == "") {
                alert("Please Enter Wham.");
                document.getElementById('<%=txtWham.ClientID %>').focus();
                return false;
            }
            var radioButtonsReebok = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoRebook");
            var ReebokValue;
            for (var x = 0; x < radioButtonsReebok.length; x++) {
                if (radioButtonsReebok[x].checked) {
                    if (radioButtonsReebok[x].value == 0) {
                        ReebokValue = 0;
                    }
                    else {
                        ReebokValue = 1;
                    }
                }
            }
            if (ReebokValue == 1) {
                var mydate1 = new Date();
                var theyear1 = mydate1.getFullYear();
                var themonth1 = mydate1.getMonth() + 1;
                var thetoday1 = mydate1.getDate();

                var currentdate1 = themonth1 + "/" + thetoday1 + "/" + theyear1;
                var NextAppMonth = document.getElementById('<%= ddlMonth.ClientID %>').options[document.getElementById('<%= ddlMonth.ClientID %>').selectedIndex].value;
                var NextAppDay = document.getElementById('<%= dddDay.ClientID %>').options[document.getElementById('<%= dddDay.ClientID %>').selectedIndex].value;
                var NextAppYear = document.getElementById('<%= ddlYear.ClientID %>').options[document.getElementById('<%= ddlYear.ClientID %>').selectedIndex].value;
                var NextAppDate = NextAppMonth + "/" + NextAppDay + "/" + NextAppYear;
                if (Date.parse(NextAppDate) < Date.parse(currentdate1)) {
                    alert("Next App. Date. :" + "  " + " Next Appointment date should be future date !!!");
                    document.getElementById('<%=ddlMonth.ClientID %>').focus();
                    return false;
                }
                if (document.getElementById('<%=txtServicesforPet1.ClientID %>').value == "") {
                    alert("Services for pet 1 :" + "  " + "Please provide services for pet 1.");
                    document.getElementById('<%=txtServicesforPet1.ClientID %>').focus();
                    return false;
                }
            }
            if (IsNumeric(document.getElementById('<%=txtPets.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblPets.ClientID %>').innerText + "  " + "Not a valid Pets.");
                document.getElementById('<%=txtPets.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtFleaandTick22.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblFleaandTick22.ClientID %>').innerText + "  " + "Not a valid Flea and Tick-22.");
                document.getElementById('<%=txtFleaandTick22.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtFleaandTick44.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblFleaandTick44.ClientID %>').innerText + "  " + "Not a valid Flea and Tick-44.");
                document.getElementById('<%=txtFleaandTick44.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtFleaandTick88.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblFleaandTick88.ClientID %>').innerText + "  " + "Not a valid Flea and Tick-88.");
                document.getElementById('<%=txtFleaandTick88.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtFleaandTick132.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblFleaandTick132.ClientID %>').innerText + "  " + "Not a valid Flea and Tick-132.");
                document.getElementById('<%=txtFleaandTick132.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtFleaandTickCat.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblFleaandTickCat.ClientID %>').innerText + "  " + "Not a valid Flea and Tick-Cat.");
                document.getElementById('<%=txtFleaandTickCat.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtTB.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblTB.ClientID %>').innerText + "  " + "Not a valid TB.");
                document.getElementById('<%=txtTB.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtWham.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblWham.ClientID %>').innerText + "  " + "Not a valid Wham.");
                document.getElementById('<%=txtWham.ClientID %>').focus();
                return false;
            }
            if (IsNumericRev(document.getElementById('<%=txtRevenue.ClientID %>').value) == false) {
                alert("Revenue :" + "  " + "Not a valid Revenue.");
                document.getElementById('<%=txtRevenue.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtRevenue.ClientID %>').value == "") {
                alert("Revenue :" + "  " + "Please Enter Revenue.");
                document.getElementById('<%=txtRevenue.ClientID %>').focus();
                return false;
            }
            var ApptRevenue = parseFloat(document.getElementById('<%=txtRevenue.ClientID %>').value);
            var ApptPetTime = parseFloat(document.getElementById('<%=txtPetTime.ClientID %>').value);
            var ExpectedRev = parseFloat('<%= Session["ExpectedRev"]%>');
            var ExpectedPetTime = parseFloat('<%= Session["ExpectedPetTime"]%>');

            if (IsNumericRev(document.getElementById('<%=txtProductPrice.ClientID %>').value) == false) {
                alert(document.getElementById('<%=Label8.ClientID %>').innerText + "  " + "Not a valid Product Price.");
                document.getElementById('<%=txtProductPrice.ClientID %>').focus();
                return false;
            }
            if (IsNumericRev(document.getElementById('<%=txtSalestax.ClientID %>').value) == false) {
                alert(document.getElementById('<%=Label9.ClientID %>').innerText + "  " + "Not a valid Sales Tax.");
                document.getElementById('<%=txtSalestax.ClientID %>').focus();
                return false;
            }
            if (IsNumericRev(document.getElementById('<%=txtTip.ClientID %>').value) == false) {
                alert("Tip :" + "  " + "Not a valid Tip.");
                document.getElementById('<%=txtTip.ClientID %>').focus();
                return false;
            }
            if (IsNumericRev(document.getElementById('<%=txtPriorRevenue.ClientID %>').value) == false) {
                alert("Prior Revenue :" + "  " + "Not a valid Prior Revenue.");
                document.getElementById('<%=txtPriorRevenue.ClientID %>').focus();
                return false;
            }

            var radioButtons3 = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoRevenue");
            var RevnueValue;
            for (var x = 0; x < radioButtons3.length; x++) {
                if (radioButtons3[x].checked) {
                    if (radioButtons3[x].value == 0) {
                        RevnueValue = 0;
                    }
                    else {
                        RevnueValue = 1;
                    }
                }
            }

            var radioButtons = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoTip");
            var TipValue;
            for (var x = 0; x < radioButtons.length; x++) {
                if (radioButtons[x].checked) {
                    if (radioButtons[x].value == 0) {
                        TipValue = 0;
                    }
                    else {
                        TipValue = 1;
                    }

                }

            }

            var radioButtons2 = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoPrior");
            var PriorValue;
            for (var x = 0; x < radioButtons2.length; x++) {
                if (radioButtons2[x].checked) {
                    if (radioButtons2[x].value == 0) {
                        PriorValue = 0;
                    }
                    else {
                        PriorValue = 1;
                    }
                }
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
