<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestJoin.aspx.cs" Inherits="WebApplication1.TEST.TestJoin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>회원가입테스트</title>
    <script src="/Scripts/jquery-3.3.1.min.js"></script>
    <script src="/Scripts/moment-with-locales.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            아이디&nbsp;&nbsp;&nbsp; : 
                <asp:TextBox runat="server" name="mb_id" id="mb_id" MaxLength="20"></asp:TextBox>
                <br />
            비밀번호 : 
                <asp:TextBox TextMode="Password" runat="server" name="mb_pw" id="mb_pw" MaxLength="30"></asp:TextBox>
                <br />
            이름&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
                <asp:TextBox runat="server" name="mb_name" id="mb_name" MaxLength="20"></asp:TextBox>
                <br />
            이메일&nbsp;&nbsp;&nbsp; : 
                <asp:TextBox runat="server" name="email1" id="email1" maxlength="20" CssClass="reg_input" ></asp:TextBox>
			    <b>@</b>
                <asp:TextBox runat="server" name="email2" id="email2" maxlength="20" CssClass="reg_input"></asp:TextBox>
                <asp:DropDownList id="email3" runat="server" CssClass="reg_input">
                    <asp:ListItem value="">선택하세요</asp:ListItem>
                    <asp:ListItem value="d">직접입력</asp:ListItem>
                    <asp:ListItem value="aspnc.com">aspnc.com</asp:ListItem>
                    <asp:ListItem value="naver.com">naver.com</asp:ListItem>
                    <asp:ListItem value="daum.net">daum.net</asp:ListItem>
                    <asp:ListItem value="nate.com">nate.com</asp:ListItem>
                    <asp:ListItem value="gmail.com">gmail.com</asp:ListItem>
                    <asp:ListItem value="hanmail.com">hanmail.com</asp:ListItem>
                </asp:DropDownList>
                <br />
            휴대전화 : 
                <asp:DropDownList id="hp1" runat="server" CssClass="reg_input">
                        <asp:ListItem value="010">010</asp:ListItem>
                        <asp:ListItem value="011">011</asp:ListItem>
                        <asp:ListItem value="016">016</asp:ListItem>
                        <asp:ListItem value="017">017</asp:ListItem>
                        <asp:ListItem value="018">018</asp:ListItem>
                        <asp:ListItem value="019">019</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox runat="server" name="hp2" id="hp2" maxlength="4" CssClass="reg_input"></asp:TextBox>
                <asp:TextBox runat="server" name="hp3" id="hp3" maxlength="4" CssClass="reg_input"></asp:TextBox>
                <br />
            생년월일 : 
                <select id="birth1" class="reg_input">
                    <option value="">년도 선택</option>
                </select>
                <select id="birth2" class="reg_input">
                    <option value="">월 선택</option>
                </select>
                <select id="birth3" class="reg_input">
                </select>
                <asp:HiddenField ID="mb_birth" runat="server" />
                <br />
            성별&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
                <asp:RadioButton ID="m_gender_m" GroupName="m_gender" CssClass="gender-chk" Text="남자" runat="server" />&nbsp;&nbsp;
                <asp:RadioButton ID="m_gender_f" GroupName="m_gender" CssClass="gender-chk" Text="여자" runat="server" />

                
            <asp:Button runat="server" ID="btnJoin" CssClass="btn-submit" OnClick="BtnJoin_Click" Text="회원가입" />

        </div>
    </form>

    <script>

        $(document).ready(function () {
            createYearMonth();
            $("#email2").attr("readonly", true);
        });

        $("#email3").change(function () {
            var domain = $("#email3").val();
            //alert(domain);
            if (domain == "d") {
                $("#email2").val("");
                $("#email2").attr("readonly", false);
                $("#email2").focus();
            } else {                
                $("#email2").attr("readonly", true);
                $("#email2").prop("value", domain);
            }
        });

        function createYearMonth(){

            for(m=1; m<=12; m++){
                $("#birth2").append($("<option value='"+ m +"'>").text(m));
            }

            var cYear=moment().year();
            for(y=cYear; y>=cYear-120; y--){
                    $("<option value='"+ y +"'>").text(y).appendTo("#birth1");
            }

            $("#birth3").append("<option value=''>일 선택");

        }

        function createDate(year, month){
            $("#birth3").empty();            

            var endDay=moment(year+"-"+month).endOf("month").date();    
            for(d=0; d<=endDay; d++){

                if (d == 0) {
                    $("<option value=''>").text("일 선택").appendTo("#birth3");
                } else {
                    $("<option value='"+ d +"'>").text(d).appendTo("#birth3");
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
                $("#mb_birth").prop("value", mb_birth);
            }

        }); 

    </script>


</body>
</html>
