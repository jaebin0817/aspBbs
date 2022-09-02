<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IdPwFindResult.aspx.cs" Inherits="WebApplication1.Member.IdPwFindResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>아이디·비밀번호 찾기</title>
    <link rel="stylesheet" href="/Content/style.css"/>
    <link rel="stylesheet" href="/Content/bootstrap.css"/>
    <link rel="stylesheet" href="/Content/bootstrap-theme.css"/> 
    <script src="/Scripts/memberScript.js"></script>
    <script src="/Scripts/jquery-3.3.1.min.js"></script>
</head>
<body>

  <div id="find_info" class="new_win">
    <h1 id="win_title">회원정보</h1>
    <div class="new_win_con">
      <form runat="server">
        <fieldset id="info_fs">
            <p>
                입력한 정보와 일치하는 회원 아이디와 임시 비밀번호입니다.<br/>
                임시 비밀번호는 로그인 후 바로 수정해주세요.<br/><br/>
            </p>
            <table>
                <tr>
                    <th>아이디 &nbsp;&nbsp;</th>
                    <td><asp:Label runat="server" ID="lblId"></asp:Label></td>
                </tr>
                <tr>
                    <th>임시 비밀번호 &nbsp;&nbsp;</th>
                    <td><asp:Label runat="server" ID="lblTmpPw"></asp:Label></td>
                </tr>
            </table>
        </fieldset>
        <br />
       <asp:Button runat="server" ID="BtnClose" OnClientClick="window.close();" CssClass="btn-submit" Text="창닫기" />
      </form>
    </div>

    <button type="button" onclick="window.close();" class="btn_close">창닫기</button>

  </div>
</body>
</html>
