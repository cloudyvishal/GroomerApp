<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainMaster.Master" AutoEventWireup="true" CodeBehind="CalendarView.aspx.cs" Inherits="GroomerApp.CalendarView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="calendar">
        <asp:Calendar ID="calapptDate" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
            BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" ShowGridLines="True"
            OnDayRender="calDate_DayRender" OnSelectionChanged="calDate_SelectionChanged">
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
        </asp:Calendar>
    </div>
    <div class="date_box">
        <asp:Label ID="lbldate" runat="server" Text="Date:">
        </asp:Label>
        <strong>
            <asp:Label ID="lbldtval" runat="server">
            </asp:Label></strong>
    </div>
    <div>
    </div>
    <asp:Panel ID="PnldispAppt" runat="server">
        <div class="mail_table">
            <asp:GridView ID="gvapptdet" runat="server" CellPadding="4" Font-Names="Times New Roman"
                Font-Size="Small" ForeColor="#333333" AutoGenerateColumns="False" DataKeyNames="APPOINTMENTID"
                OnRowCommand="gvapptdet_RowCommand">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Time">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Time") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtntime" runat="server" ForeColor="#003399" OnClick="lnkbtntime_Click"
                                Text='<%# Bind("Time") %>' CommandName="View" CommandArgument='<%# Eval("APPOINTMENTID") %>'></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="zipcode" HeaderText="ZipCode">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Customer Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtcname" runat="server" Text='<%# Bind("cname") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtncname" runat="server" ForeColor="#003399" OnClick="lnkbtntime_Click"
                                Text='<%# Bind("cname") %>' CommandName="View" CommandArgument='<%# Eval("APPOINTMENTID") %>'
                                Font-Underline="False" Font-Names="Times New Roman" Font-Size="10pt" Font-Strikeout="False"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        </div>
    </asp:Panel>
    <asp:Panel ID="Pnldispapptdet" runat="server" Visible="false">
        <table class="details_list" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" width="120">
                    <asp:Label ID="lblnameofcustomer" CssClass="appnt_lbl" Text="Customer Name:" runat="server"></asp:Label>
                </td>
                <td align="left">
                    <asp:Label ID="lblcustnameval" runat="server" CssClass="appnt_lbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="lblapptstring" Text="Appt. String:" CssClass="appnt_lbl" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblapptstrval" runat="server" CssClass="appnt_lbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblappexpstime" Text="Start Time:" CssClass="appnt_lbl" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblapptexpstimeval" runat="server" CssClass="appnt_lbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblapptexpendtime" Text="End Time:" runat="server" CssClass="appnt_lbl"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblapptexpetimeval" runat="server" CssClass="appnt_lbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblapptStatus" Text="Status:" runat="server" CssClass="appnt_lbl"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblapptstatusval" runat="server" CssClass="appnt_lbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">&nbsp;
                </td>
                <td>
                    <asp:Button ID="btnback" runat="server" CssClass="appnt_lbl btn" OnClick="btnback_Click"
                        Text="Back" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" runat="server">
</asp:Content>
