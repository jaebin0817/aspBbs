<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemLog.aspx.cs" Inherits="WebApplication1.Member.MemLog" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">
        <h2 class="join-title">로그인</h2>
	    <div id="join-form">
            <div class="regi_table">
		        <table>
		        <tbody>
			        <tr>
				        <th scope="row"><label for="login_id">ID</label></th>
				        <td>
					        <asp:TextBox runat="server" name="m_id" id="m_id" required="required" CssClass="reg_input" MaxLength="20"></asp:TextBox>
                            <span id="msg_m_id" class="reg_msg"></span>
				        </td>
			        </tr>
			        <tr>
				        <th scope="row"><label for="login_pw">PASSWORD</label></th>
				        <td>
                            <asp:TextBox TextMode="Password" runat="server" name="m_pw" id="m_pw" required="required" CssClass="reg_input" MaxLength="30"></asp:TextBox>
				            <span id="msg_m_pw" class="reg_msg"></span>
                            <asp:Label ID="msg_login" runat="server"></asp:Label>
                        </td>
			        </tr>
		        </tbody>
		        </table>
	        </div>
            <div class="btn-login">	
                <asp:Button runat="server" ID="BtnLogin" CssClass="btn-submit" OnClientClick="return LoginCheck()" OnClick="BtnLogin_Click" Text="로그인" />
                <asp:LinkButton runat="server" CssClass="btn-link" OnClientClick="IdPwFindOpen()" Text="아이디·비밀번호 찾기" />
                <asp:LinkButton runat="server" CssClass="btn-link" PostBackUrl="/Member/MemJoin.aspx" Text="회원가입" />
            </div>                        
        </div>
    </div>



    <script>
        function IdPwFindOpen() {
            window.open('/Member/IdPwFind.aspx', 'idpwfind', 'width = 500, height = 400, top = 100, left = 100')
        }

        $("#MainContent_m_id").blur(function () {

            $("#msg_m_id").empty();

            var m_id = $("#MainContent_m_id").val();
            //alert(m_id);
            var idRegExp = /^[a-z0-9]{5,20}$/;

            if (!idRegExp.test(m_id)) {
                $("#msg_m_id").append("아이디는 영문 소문자와 숫자 5~20자리로 입력해주세요");
                $("#MainContent_m_id").focus();
                return false;
            }

        });

        $("#MainContent_m_id").change(function () {
            $("#msg_m_id").empty();
            $("#MainContent_msg_login").empty();
        });



        $("#MainContent_m_pw").blur(function () {

            $("#msg_m_pw").empty();

            var m_pw = $("#MainContent_m_pw").val();
            var pwRegExp = /^[a-zA-Z0-9]{8,30}$/;

            if (!pwRegExp.test(m_pw)) {
                $("#msg_m_pw").append("비밀번호는 영문 대소문자와 숫자 8~30자리로 입력해주세요");
                $("#MainContent_m_pw").focus();
                return false;
            }

        });

        $("#MainContent_m_pw").change(function () {
            $("#msg_m_pw").empty();
            $("#MainContent_msg_login").empty();
        });


    </script>
</asp:Content>
