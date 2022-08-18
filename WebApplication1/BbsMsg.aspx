<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BbsMsg.aspx.cs" Inherits="WebApplication1.BbsMsg" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">

        <div id="msg-wrap">
            <asp:Label runat="server" ID="lblMsg" Font-Bold="true"></asp:Label>
            <a href="Main.aspx"><h3><strong>홈으로 이동</strong></h3></a>
        </div>

    </div>
    <script>
        history.replaceState({}, null, location.pathname);
    </script>
</asp:Content>
