<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PwCheck.aspx.cs" Inherits="WebApplication1.Member.PwCheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>회원 탈퇴</title>
    <link rel="stylesheet" href="/Content/style.css"/>
    <link rel="stylesheet" href="/Content/bootstrap.css"/>
    <link rel="stylesheet" href="/Content/bootstrap-theme.css"/>
    <script src="/Scripts/memberScript.js"></script>
    <script src="/Scripts/jquery-3.3.1.min.js"></script>
</head>
<body>

<div id="find_info" class="new_win">
    <h1 id="win_title">비밀번호 확인</h1>
    <div class="new_win_con">
      <form name="fpasswordlost" runat="server" method="post" autocomplete="off">
        <fieldset id="info_fs">
            
            <asp:Label runat="server" ID="lblPwtitle"></asp:Label>

            <asp:TextBox runat="server" TextMode="Password" ID="w_m_pw" CssClass="form-control" MaxLength="30" placeholder="비밀번호" required="required"></asp:TextBox>
            <asp:Label runat="server" ID="m_pw_chk_msg" CssClass="m_id_chk_msg"></asp:Label>

        </fieldset>

        <asp:Button runat="server" ID="BtnMUpdate" Text="수정" CssClass="btn-submit" OnClientClick="return PwCheck()" OnClick="BtnMUpdate_Click" />
        <asp:Button runat="server" ID="BtnConf" Text="탈퇴" CssClass="btn-submit" OnClientClick="return PwCheck()" OnClick="BtnConf_Click" />
      </form>
    </div>

    <button type="button" onclick="window.close();" class="btn_close">창닫기</button>

</div>

<script>
    $("#w_m_pw").keydown(function () {
        $("#m_pw_chk_msg").empty();
    });

    function PwCheck() {
        var m_pw = $("#w_m_pw").val();
        var pwRegExp = /^[a-zA-Z0-9]{8,30}$/;

        if (!pwRegExp.test(m_pw)) {
            $("#m_pw_chk_msg").append("비밀번호는 영문 대소문자와 숫자 8~30자리로 입력해주세요");
            $("#MainContent_m_pw").focus();
            return false;
        }
    }


</script>



</body>
</html>
