<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IdCheck.aspx.cs" Inherits="WebApplication1.Member.IdCheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>아이디 중복확인</title>
    <link rel="stylesheet" href="/Content/style.css"/>
    <link rel="stylesheet" href="/Content/bootstrap.css"/>
    <link rel="stylesheet" href="/Content/bootstrap-theme.css"/>
    <script src="/Scripts/memberScript.js"></script>
    <script src="/Scripts/jquery-3.3.1.min.js"></script>
</head>
<body>

    <div id="find_info" class="new_win">
    <h1 id="win_title">아이디 중복확인</h1>
    <div class="new_win_con">
      <form name="fpasswordlost" runat="server" method="post" autocomplete="off">
        <fieldset id="info_fs">
            
            <asp:Label runat="server" ID="lblNotice"><p>사용할 아이디를 입력해 주세요.</p></asp:Label>

            <asp:TextBox runat="server" ID="m_id" CssClass="form-control" MaxLength="20" placeholder="영문 소문자, 숫자, 5~20글자" required="required"></asp:TextBox>
            <asp:Label runat="server" ID="m_id_chk_msg" CssClass="m_id_chk_msg"></asp:Label>
            <asp:HiddenField runat="server" ID="checked_id" />
        </fieldset>

        <asp:Button runat="server" ID="BtnIDChk" Text="확인" CssClass="btn-submit" OnClientClick="return IdCheck()" OnClick="BtnIDChk_Click" />
        <asp:Button runat="server" ID="BtnRetry" Text="다른ID입력" CssClass="btn-submit" OnClick="BtnRetry_Click" />
        <asp:Button runat="server" ID="BtnIDUse" Text="사용하기" CssClass="btn-submit" OnClientClick="setId()" OnClick="BtnIDUse_Click" />
      </form>
    </div>

    <button type="button" onclick="window.close();" class="btn_close">창닫기</button>

</div>

<script>
    $("#m_id").keydown(function () {
        $("#m_id_chk_msg").empty();
    });

    function setId() {
        var m_id = $("#checked_id").val();
        //alert(m_id);
        
        opener.document.getElementById("MainContent_mb_id").value = m_id;
    }

</script>

</body>
</html>
