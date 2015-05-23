<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayError.aspx.cs" Inherits="GroomerApp.DisplayError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DisplayError</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Error</h1>
        <%= mMessage %>
        <p></p>
        <p><a href="Default.aspx">Click here to view your cart.</a></p>
    </form>
</body>
</html>
