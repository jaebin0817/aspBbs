<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IdPwFind.aspx.cs" Inherits="WebApplication1.Member.IdPwFind" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="/Content/style.css"/>
    <link rel="stylesheet" href="/Content/bootstrap.css"/>
    <link rel="stylesheet" href="/Content/bootstrap-theme.css"/> 
    <script src="/Scripts/memberScript.js"></script>
    <script src="/Scripts/jquery-3.3.1.min.js"></script>
</head>
<body>

  <div id="find_info" class="new_win">
    <h1 id="win_title">회원정보 찾기</h1>
    <div class="new_win_con">
      <form name="fpasswordlost" runat="server">
        <fieldset id="info_fs">
            <p>
                회원가입 시 등록한 이름과 이메일 주소를 입력해 주세요.<br/><br/>
            </p>

            <label for="f_m_name" class="sound_only">이름</label>
            <asp:TextBox runat="server" ID="f_m_name" CssClass="form-control" required="required" MaxLength="20" placeholder="한글 2~20글자" ></asp:TextBox>
            <span id="name_msg"></span>
            <br />
            <label for="m_email" class="sound_only">E-mail</label>
            <asp:TextBox runat="server" ID="f_m_email" CssClass="form-control" required="required" MaxLength="40" placeholder="oooo@oooo.ooo" ></asp:TextBox>
            <span id="email_msg"></span>
            <asp:Label runat="server" ID="lblFindmsg"></asp:Label>
        </fieldset>
        <br />
        <asp:Button runat="server" ID="BtnFind" OnClientClick="return FindCheck()" OnClick="BtnFind_Click" CssClass="btn-submit" Text="확인" />
      </form>
    </div>

    <button type="button" onclick="window.close();" class="btn_close">창닫기</button>

  </div>
    
  <script>

      $("#f_m_name").keydown(function () {
          $("#name_msg").empty();
      });

      $("#f_m_email").keydown(function () {
          $("#email_msg").empty();
      });

      function FindCheck() {
          var f_m_name = $("#f_m_name").val();
          var nameRegExp = /^[가-힣]{2,20}$/;

          if (f_m_name.length == 0) {
              $("#name_msg").empty();
                $("#name_msg").append("이름을 입력해주세요");
                $("#f_m_name").focus();
                return false;
          } else {                        
              if (!nameRegExp.test(f_m_name)) {
                    $("#name_msg").empty();
                    $("#name_msg").append("이름은 한글 2~20글자로 입력해주세요");
                    $("#f_m_name").focus();
                    return false;
              }
          }

          var f_m_email = $("#f_m_email").val();
          var emailRegExp = /^[A-Za-z0-9_\.\-]+@[A-Za-z0-9\-\.]+\.[A-Za-z]{2,3}$/;
          if (f_m_email.length == 0) {
                $("#email_msg").empty();
                $("#email_msg").append("이메일을 입력해주세요");
                $("#f_m_email").focus();
                return false;
          } else {
              if (!emailRegExp.test(f_m_email)) {
                  $("#email_msg").empty();
                  $("#email_msg").append("올바른 이메일 형식이 아닙니다");
                  $("#f_m_email").focus();
                  return false;
              }
          }
          //$("#lblFindmsg").append("유효성 통과");
          return true;
      }

  </script>


</body>
</html>
