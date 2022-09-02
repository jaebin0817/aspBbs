<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemMypage.aspx.cs" Inherits="WebApplication1.Member.MemMypage" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">

        <h2 class="join-title">마이페이지</h2>
	    <div id="join-form">
            <div>
                <asp:Label runat="server" ID="LblSid"></asp:Label>
            </div>
            <div class="btn-login">	
                <asp:Button runat="server" ID="BtnUpdate" CssClass="btn-submit" OnClientClick="UpdateCheck()" Text="회원정보수정" />
                <br /><br />
                <asp:Button runat="server" ID="BtnWdraw" CssClass="btn-submit" OnClientClick="WdrawCheck()" Text="회원탈퇴" />
                <br /><br />
                <asp:Button runat="server" ID="BtnLogout" CssClass="btn-submit" OnClick="BtnLogout_Click" Text="로그아웃" />
            </div>
        </div>


    </div>
    <script>
        function WdrawCheck() {
            window.open('/Member/PwCheck.aspx?mode=withdraw', 'pwcheck', 'width = 500, height = 300, top = 100, left = 100')
        }

       function UpdateCheck() {
            window.open('/Member/PwCheck.aspx?mode=update', 'pwcheck', 'width = 500, height = 300, top = 100, left = 100')
        }

    </script>
</asp:Content>