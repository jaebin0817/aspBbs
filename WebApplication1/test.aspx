<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebApplication1.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button id="catInsert" runat="server" OnClick="CatInsert_Click" Text="카테고리 추가" />
<%--            <input type="button" id="catInsert2" runat="server" onclick="CatInsert_Click" value="카테고리 추가" /><!--이건안됨!-->--%>

            <asp:Button ID="getIP" runat="server" OnClick="GetIP_Click" Text="IP얻기" />



        </div>
    </form>
</body>
</html>
