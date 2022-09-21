<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BbsReply.aspx.cs" Inherits="WebApplication1.BbsReply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>게시판 개발 : 댓글</title>
    <link rel="stylesheet" href="/Content/style.css"/>
    <link rel="stylesheet" href="/Content/bootstrap.css"/>
    <link rel="stylesheet" href="/Content/bootstrap-theme.css"/>
    <script src="/Scripts/memberScript.js"></script>
    <script src="/Scripts/jquery-3.3.1.min.js"></script>
    <script src="/Scripts/bbsReplyScript.js"></script>
</head>
<body>

  <div id="find_info" class="new_win">
    <form runat="server">
    <h1 id="win_title"><asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
    <div class="new_win_con">
          
            <div class="reply-write-wrap">
                <div class="reply-writer">
                    <asp:TextBox ID="r_wname" runat="server" placeholder="작성자" MaxLength="20" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblText" runat="server" Visible="false">답글 내용을 입력해주세요</asp:Label>
                </div>                
                <div class="reply-pw">
                    <asp:TextBox ID="r_pw" runat="server" TextMode="Password" placeholder="비밀번호" MaxLength="10" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="reply-cont">
                    <asp:TextBox ID="r_content" runat="server" TextMode="MultiLine" MaxLength="500" CssClass="form-control" Rows="3" Columns="350"></asp:TextBox>
                </div>
            </div>
                
                <asp:Button ID="btnReply" runat="server" Text="답글 작성" OnClientClick="return replyCheck2()" OnClick="BtnReply_Click" CssClass="btn-submit"/>
                <asp:Button ID="btnReplyMod" runat="server" Text="댓글 수정" OnClientClick="return replyCheck2()" OnClick="BtnReplyMod_Click" CssClass="btn-submit"/>                   
                <asp:HiddenField ID="hdSID" runat="server" Value="" />
          
        </div>
        <button type="button" onclick="window.close();" class="btn_close">창닫기</button>
    </form>
  </div>

    <script>
        $("MainContent_btnReply").click(function () {
            replyCheck();
        });

    </script>

</body>
</html>