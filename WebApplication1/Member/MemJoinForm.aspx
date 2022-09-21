<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemJoinForm.aspx.cs" Inherits="WebApplication1.MemJoinForm" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
  <script src="/Scripts/moment-with-locales.js"></script>

  <div class="wrap">

    <h2 class="join-title"><asp:Label runat="server" ID="lblTitle"></asp:Label></h2>

      <asp:Label runat="server" ID="lblCheck"></asp:Label>

    <div id="join-form">
      <h3>기본정보 <span class="req">&nbsp;&nbsp;필수입력사항</span></h3>

      <div class="regi_table">
	    <table>
          <tbody>
			<tr>
			  <th scope="row"><label for="reg_mb_id" class="req">아이디</label></th>
			  <td>
                <asp:TextBox runat="server" name="mb_id" id="mb_id" required="required" CssClass="reg_input" MaxLength="20" placeholder="아이디 중복확인 버튼을 눌러주세요"></asp:TextBox>
                <asp:LinkButton Height="40px" runat="server" id="idCheck" CssClass="btn_frmline" Text="아이디 중복확인" OnClientClick="OpenIdcheck()" />
			    <span id="msg_mb_id" class="reg_msg"></span>
			  </td>
			</tr>
			<tr>
              <asp:HiddenField runat="server" ID="modeStatus"></asp:HiddenField>
			  <th scope="row"><label id="pwlbl1" for="mb_pw" class="req">비밀번호</label></th>
			  <td>
                <asp:TextBox TextMode="Password" runat="server" name="mb_pw" id="mb_pw" required="required" CssClass="reg_input" MaxLength="15" placeholder="영문(대소문자 구분), 숫자, 8~15글자"></asp:TextBox>
			    <span id="msg_mb_pw" class="reg_msg"></span>
              </td>
			</tr>
			<tr>
			  <th scope="row"><label id="pwlbl2" for="mb_pw_re" class="req">비밀번호 확인</label></th>
			  <td>
			    <input type="password" name="mb_pw_re" id="mb_pw_re" required class="reg_input" maxlength="15">
			    <span id="msg_mb_pw_re" class="reg_msg"></span>
			  </td>
			</tr>
			<tr>
			  <th scope="row"><label for="reg_mb_name" class="req">이름</label></th>
			  <td>
                <asp:TextBox runat="server" name="mb_name" id="mb_name" required="required" CssClass="reg_input" MaxLength="20" placeholder="한글 2~20글자"></asp:TextBox>
			  </td>
			</tr>
			
			<tr>
			  <th scope="row"><label for="reg_mb_email" class="req">이메일</label></th>
			  <td>
                <asp:HiddenField runat="server" ID="old_email" />
			    <div class="emailselect_wrap">
                    <asp:TextBox runat="server" name="email1" id="email1" maxlength="20" CssClass="reg_input" required="required"></asp:TextBox>
			      <b>@</b>
                    <asp:TextBox runat="server" name="email2" id="email2" maxlength="20" CssClass="reg_input" required="required"></asp:TextBox>

                    <asp:DropDownList id="email3" runat="server" CssClass="reg_input" required="required">
                        <asp:ListItem value="">선택하세요</asp:ListItem>
                        <asp:ListItem value="d">직접입력</asp:ListItem>
                        <asp:ListItem value="aspnc.com">aspnc.com</asp:ListItem>
                        <asp:ListItem value="naver.com">naver.com</asp:ListItem>
                        <asp:ListItem value="daum.net">daum.net</asp:ListItem>
                        <asp:ListItem value="nate.com">nate.com</asp:ListItem>
                        <asp:ListItem value="gmail.com">gmail.com</asp:ListItem>
                        <asp:ListItem value="hanmail.com">hanmail.com</asp:ListItem>
                    </asp:DropDownList>
			    </div>
<%--			    <input type="hidden" name="mb_email" value="" id="reg_mb_email">--%>
                <asp:Label runat="server" ID="msg_mb_email" CssClass="reg_msg"></asp:Label>

			  </td>
            </tr>

			<tr>
			  <th scope="row"><label for="reg_mb_hp">휴대전화</label></th>
			  <td>
                <asp:HiddenField runat="server" ID="old_hp" />
				<div class="telselect_wrap">
                    <asp:DropDownList id="hp1" runat="server" CssClass="reg_input">
                        <asp:ListItem value="010">010</asp:ListItem>
                        <asp:ListItem value="011">011</asp:ListItem>
                        <asp:ListItem value="016">016</asp:ListItem>
                        <asp:ListItem value="017">017</asp:ListItem>
                        <asp:ListItem value="018">018</asp:ListItem>
                        <asp:ListItem value="019">019</asp:ListItem>
                    </asp:DropDownList>
                    <b>-</b>
                    <asp:TextBox runat="server" name="hp2" id="hp2" maxlength="4" CssClass="reg_input"></asp:TextBox>
				    <b>-</b>
                    <asp:TextBox runat="server" name="hp3" id="hp3" maxlength="4" CssClass="reg_input"></asp:TextBox>
				</div>                
                  <asp:Label runat="server" ID="msg_mb_hp" CssClass="reg_msg"></asp:Label>
<%--				  <input type="hidden" name="mb_hp" value="" id="reg_mb_hp">
				  <input type="hidden" name="old_mb_hp" value="">--%>
			  </td>            
			</tr>

            <tr>
			  <th scope="row"><label for="m_birth" >생년월일</label></th>
			  <td>
                <div class="birselect_wrap">
                    <select id="birth1" class="reg_input">
                        <option value="">년도 선택</option>
                    </select>
                  <b>&nbsp;</b>
                    <select id="birth2" class="reg_input">
                        <option value="">월 선택</option>
                    </select>
                  <b>&nbsp;</b>
                    <select id="birth3" class="reg_input"></select>
                    <asp:HiddenField ID="mb_birth" runat="server" />
                    <asp:HiddenField ID="oldBirth1" runat="server" />
                    <asp:HiddenField ID="oldBirth2" runat="server" />
                    <asp:HiddenField ID="oldBirth3" runat="server" />
                </div>
			  </td>           
			</tr>

            <tr>
			  <th scope="row"><label for="m_gender" >성별</label></th>
			  <td>
                <asp:RadioButton ID="m_gender_m" GroupName="m_gender" CssClass="gender-chk" Text="남자" runat="server" />&nbsp;&nbsp;
                <asp:RadioButton ID="m_gender_f" GroupName="m_gender" CssClass="gender-chk" Text="여자" runat="server" />
			  </td>           
			</tr>

<%--			<tr>
				<th scope="row"><label for="reg_mb_zip" class="req">주소</label></th>
				<td>
					<input type="text" name="mb_zip" value="" id="reg_mb_zip" required class="reg_input" maxlength="6"  placeholder="우편번호" readonly>
					<button type="button" class="btn_frmline" onclick="win_zip('fregisterform', 'mb_zip', 'mb_addr1', 'mb_addr2', 'mb_addr3', 'mb_addr_jibeon');">주소검색</button><br>

					<input type="text" name="mb_addr1" value="" id="reg_mb_addr1" required class="reg_input" placeholder="기본주소" readonly>
					<label for="reg_mb_addr1" class="sound_only">기본주소<strong> 필수</strong></label><br>

					<input type="text" name="mb_addr2" value="" id="reg_mb_addr2" class="reg_input" placeholder="상세주소">
					<label for="reg_mb_addr2" class="sound_only">상세주소</label><br>					
				</td>
            </tr>--%>

          </tbody>
	    </table>
      </div>
      <div class="btn-confirm">
        <asp:LinkButton Height="55px" runat="server" CssClass="btn-cancel" PostBackUrl="/Main.aspx" Text="취소" />	
        <asp:Button runat="server" ID="btnJoin" CssClass="btn-submit" OnClientClick="return JoinCheck()" OnClick="BtnJoin_Click" Text="회원가입" />
        <asp:Button runat="server" ID="btnUpdate" CssClass="btn-submit" OnClientClick="return UpdateCheck()" OnClick="BtnUpdate_Click" Text="수정" />
      </div>

      
     </div>   
    </div>

    <script>

        function OpenIdcheck() {
            window.open('/Member/IdCheck.aspx', 'idcheck', 'width = 500, height = 270, top = 100, left = 100');
        }
        
        $(document).ready(function () {
            createYearMonth();
            $("#MainContent_email2").attr("readonly", true);
            $("#MainContent_mb_id").attr("readonly", true);

            var modeStatus = $("#MainContent_modeStatus").val();
            if (modeStatus == "update") {
                $("#pwlbl1").attr("class", "");
                $("#pwlbl1").text("신규 비밀번호 ").prepend();
                $("#MainContent_mb_pw").attr("required", false);
                $("#pwlbl2").attr("class", "");
                $("#pwlbl2").text("비밀번호 확인 ").prepend();
                $("#mb_pw_re").attr("required", false);
                $("#MainContent_email3").attr("required", false);
            }
        });


        $("#MainContent_mb_pw").blur(function () {

            var mb_pw = $("#MainContent_mb_pw").val();
            var pwRegExp = /^[a-zA-Z0-9]{8,15}$/;

            if (!pwRegExp.test(mb_pw)) {
                $("#msg_mb_pw").empty();
                $("#msg_mb_pw").append("비밀번호는 영문 대소문자와 숫자 8~15자리로 입력해야합니다");
                //$(this).focus();
            }
        });

        $("#MainContent_mb_pw").keydown(function () {
            $("#msg_mb_pw").empty();
        });

        $("#mb_pw_re").blur(function () {

            var mb_pw = $("#MainContent_mb_pw").val();
            var mb_pw_re = $(this).val();

            if (mb_pw != mb_pw_re) {
                $("#msg_mb_pw_re").empty();
                $("#msg_mb_pw_re").append("비밀번호가 일치하지 않습니다");
            }
        });

        $("#mb_pw_re").keydown(function () {
            $("#msg_mb_pw_re").empty();
        });

        function createYearMonth(){

            var oldYear = $("#MainContent_oldBirth1").val();
            var oldMonth = $("#MainContent_oldBirth2").val();

            for (m = 1; m <= 12; m++){

                if (oldMonth == m) {
                    $("#birth2").append($("<option value='"+ m +"'>").text(m).attr("selected", "selected"));
                } else {
                    $("#birth2").append($("<option value='"+ m +"'>").text(m));
                }                
            }

            var cYear=moment().year();
            for (y = cYear; y >= cYear - 120; y--){
                if (oldYear == y) {
                    $("<option value='"+ y +"'>").text(y).attr("selected", "selected").appendTo("#birth1");
                } else {
                    $("<option value='"+ y +"'>").text(y).appendTo("#birth1");
                }
                    
            }
            if (oldYear == "") {
                $("#birth3").append("<option value=''>일 선택");
            } else {
                createDate(oldYear, oldMonth)
            }
            

        }

        function createDate(year, month){
            $("#birth3").empty();            
            var oldDay = $("#MainContent_oldBirth3").val();

            var endDay=moment(year+"-"+month).endOf("month").date();    
            for(d=0; d<=endDay; d++){

                if (d == 0) {
                    $("<option value=''>").text("일 선택").appendTo("#birth3");
                } else {
                    if (oldDay == d) {
                        $("<option value='"+ d +"'>").text(d).attr("selected", "selected").appendTo("#birth3");
                    } else {
                        $("<option value='"+ d +"'>").text(d).appendTo("#birth3");
                    }
                    
                }               
            }
        }

        $("#birth1, #birth2").change(function () {

            $("#mb_birth").prop("value", "");

            var year = $("#birth1").val();
            var month = $("#birth2").val();

            if (year != "" && month != "") { createDate(year, month) }

        }); 

        $("#birth3").change(function () {

            var year = $("#birth1").val();
            var month = $("#birth2").val();
            var day = $("#birth3").val();

            var mb_birth = year + "-" + month + "-" + day

            if (year != "" && month != "" && day != "") {
                $("#MainContent_mb_birth").prop("value", mb_birth);
            }

        }); 


        $("#MainContent_email3").change(function () {
            var domain = $("#MainContent_email3").val();
            //alert(domain);
            if (domain == "d") {
                $("#MainContent_email2").val("");
                $("#MainContent_email2").attr("readonly", false);
                $("#MainContent_email2").focus();
            } else {                
                $("#MainContent_email2").attr("readonly", true);
                $("#MainContent_email2").prop("value", domain);
            }
        });


    </script>



</asp:Content>
