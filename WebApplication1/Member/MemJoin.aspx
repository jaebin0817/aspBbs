<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemJoin.aspx.cs" Inherits="WebApplication1.Member.MemJoin" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">

        <h2 class="join-title">회원가입</h2>

        <div id="agreement-wrap">
	        <h3><strong>약관 동의</strong></h3>

            <div id="agree-chkall" class="checks">
		        <input type="checkbox" name="chk-all"  value="1"  id="chk-all">
                <label for="chk-all">회원가입 약관에 모두 동의합니다</label>
            </div>

            <section id="agree-term">
		        <div class="join-agree checks">            
                    <input type="checkbox" name="agree" value="1" id="agree11">
			        <label for="agree11">이용약관 동의<span>(필수)</span></label>
                </div>
        
                <textarea readonly>
제1조(목적)

이 약관은 업체 회사(전자상거래 사업자)가 운영하는 업체 사이버 몰(이하 “몰”이라 한다)에서 제공하는 인터넷 관련 서비스(이하 “서비스”라 한다)를 이용함에 있어 사이버 몰과 이용자의 권리․의무 및 책임사항을 규정함을 목적으로 합니다.
 
※「PC통신, 무선 등을 이용하는 전자상거래에 대해서도 그 성질에 반하지 않는 한 이 약관을 준용합니다.」

 
제2조(정의)
 
① “몰”이란 업체 회사가 재화 또는 용역(이하 “재화 등”이라 함)을 이용자에게 제공하기 위하여 컴퓨터 등 정보통신설비를 이용하여 재화 등을 거래할 수 있도록 설정한 가상의 영업장을 말하며, 아울러 사이버몰을 운영하는 사업자의 의미로도 사용합니다.
 
② “이용자”란 “몰”에 접속하여 이 약관에 따라 “몰”이 제공하는 서비스를 받는 회원 및 비회원을 말합니다.
 
③ ‘회원’이라 함은 “몰”에 회원등록을 한 자로서, 계속적으로 “몰”이 제공하는 서비스를 이용할 수 있는 자를 말합니다.
 
④ ‘비회원’이라 함은 회원에 가입하지 않고 “몰”이 제공하는 서비스를 이용하는 자를 말합니다.
                  </textarea>        
            </section>

            <section id="agree-private">
            <fieldset class="join-agree checks">            
                <input type="checkbox" name="agree2" value="1" id="agree21">
			    <label for="agree21">개인정보 수집 및 이용 동의<span>(필수)</span></label>
            </fieldset>

            <textarea readonly>
개인정보처리방침

1. 총칙

본 업체 사이트는 회원의 개인정보보호를 소중하게 생각하고, 회원의 개인정보를 보호하기 위하여 항상 최선을 다해 노력하고 있습니다. 
1) 회사는 「정보통신망 이용촉진 및 정보보호 등에 관한 법률」을 비롯한 모든 개인정보보호 관련 법률규정을 준수하고 있으며, 관련 법령에 의거한 개인정보처리방침을 정하여 이용자 권익 보호에 최선을 다하고 있습니다.
2) 회사는 「개인정보처리방침」을 제정하여 이를 준수하고 있으며, 이를 인터넷사이트 및 모바일 어플리케이션에 공개하여 이용자가 언제나 용이하게 열람할 수 있도록 하고 있습니다.
3) 회사는 「개인정보처리방침」을 통하여 귀하께서 제공하시는 개인정보가 어떠한 용도와 방식으로 이용되고 있으며 개인정보보호를 위해 어떠한 조치가 취해지고 있는지 알려드립니다.
4) 회사는 「개인정보처리방침」을 홈페이지 첫 화면 하단에 공개함으로써 귀하께서 언제나 용이하게 보실 수 있도록 조치하고 있습니다.
5) 회사는  「개인정보처리방침」을 개정하는 경우 웹사이트 공지사항(또는 개별공지)을 통하여 공지할 것입니다.

2. 개인정보 수집에 대한 동의

귀하께서 본 사이트의 개인정보보호방침 또는 이용약관의 내용에 대해 「동의 한다」버튼 또는 「동의하지 않는다」버튼을 클릭할 수 있는 절차를 마련하여, 「동의 한다」버튼을 클릭하면 개인정보 수집에 대해 동의한 것으로 봅니다.

3. 개인정보의 수집 및 이용목적

본 사이트는 다음과 같은 목적을 위하여 개인정보를 수집하고 있습니다.
서비스 제공을 위한 계약의 성립 : 본인식별 및 본인의사 확인 등
서비스의 이행 : 상품배송 및 대금결제
회원 관리 : 회원제 서비스 이용에 따른 본인확인, 개인 식별, 연령확인, 불만처리 등 민원처리
기타 새로운 서비스, 신상품이나 이벤트 정보 안내
단, 이용자의 기본적 인권 침해의 우려가 있는 민감한 개인정보(인종 및 민족, 사상 및 신조, 출신지 및 본적지, 정치적 성향 및 범죄기록, 건강상태 등)는 수집하지 않습니다.

4. 수집하는 개인정보 항목

본 사이트는 회원가입, 상담, 서비스 신청 등을 위해 아래와 같은 개인정보를 수집하고 있습니다. 
1) 개인정보 수집방법 : 홈페이지(회원가입)
2) 수집항목 : 이름 , 생년월일 , 성별 , 로그인ID , 비밀번호 , 전화번호 , 주소 , 휴대전화번호 , 이메일 , 주민등록번호 , 접속 로그 , 접속 IP 정보 , 결제기록

                </textarea>
            </section>

    <div class="btn-confirm">
        <asp:Button runat="server" CssClass="btn-cancel" PostBackUrl="/Main.aspx" Text="취소" />	
        <asp:Button runat="server" ID="btnSubmit" CssClass="btn-submit" OnClientClick="return submitCheck()" OnClick="BtnSubmit_Click" Text="다음" />
    </div>

    </div>
    </div>
    <script>
        //history.replaceState({}, null, location.pathname);

        function submitCheck() {
            if (!$("#agree11").is(":checked")) {
                    alert("이용약관에 동의해야 회원가입이 가능합니다.");
                    $("#agree11").focus();
                    return false;
            }

            if (!$("#agree21").is(":checked")) {
                alert("개인정보처리방침안내의 동의해야 회원가입이 가능합니다.");
                $("#agree21").focus();
                return false;
            }
            return true;
        }
    
        jQuery(function($){
            // 모두선택
            $("input[name=chk-all]").click(function() {
                if ($(this).prop('checked')) {
                    $("input[name^=agree]").prop('checked', true);
                } else {
                    $("input[name^=agree]").prop("checked", false);
                }
            });
        });

    </script>
</asp:Content>

