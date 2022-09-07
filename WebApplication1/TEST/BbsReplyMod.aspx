<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BbsReplyMod.aspx.cs" Inherits="WebApplication1.BbsReplyMod" %>


<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">

        <div class="reply-wrap">
            <div class="reply-write-wrap">

                <div class="reply-writer">
                    <asp:TextBox ID="r_wname" runat="server" placeholder="작성자" MaxLength="20" CssClass="form-control"></asp:TextBox>
                </div>                
                <div class="reply-pw">
                    <asp:TextBox ID="r_pw" runat="server" TextMode="Password" placeholder="비밀번호" MaxLength="10" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="reply-cont">
                    <asp:TextBox ID="r_content" runat="server" TextMode="MultiLine" MaxLength="500" CssClass="form-control" Rows="3" Columns="300"></asp:TextBox>
                </div>
                <div class="reply-btn">
                    <asp:Button ID="btnReply" runat="server" Text="댓글 수정" OnClientClick="return replyCheck()" OnClick="BtnReplyMod_Click" CssClass="btnReply"/>                   
                    <asp:Button ID="btnBack" runat="server" Text="게시글 보기" OnClick="BtnBack_Click" CssClass="btnReply"/> 
                </div>

            </div>

        </div>
    </div>
    <script>
        $("MainContent_btnReply").click(function () {
            replyCheck();
        });

    </script>
</asp:Content>
