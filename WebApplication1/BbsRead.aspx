<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BbsRead.aspx.cs" Inherits="WebApplication1.BbsRead" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <div class="wrap">
        <div class="post-wrap">
            <div class="post-cat"><asp:Label runat="server" ID="lblP_cat"></asp:Label></div>
            <div class="post-title"><asp:Label runat="server" ID="lblP_subject"></asp:Label></div>
            <div class="post-info">
                <asp:Label runat="server" ID="lblP_wname" Font-Bold="true"></asp:Label>&nbsp;|&nbsp;
                <asp:Label runat="server" ID="lblP_regdt"></asp:Label>&nbsp;|&nbsp;
                조회수&nbsp;<asp:Label runat="server" ID="lblP_readcnt"></asp:Label>
            </div>
            <div class="post-cont"><asp:Label runat="server" ID="lblP_content"></asp:Label></div>
            <div class="post-mng">
                <a href="#">수정</a>
                ·
                <a href="#">삭제</a>
                ·
                <a href="BbsWrite.aspx">글쓰기</a>
            </div>
        </div>
        <div class="reply-wrap">
            댓글영역
        </div>
        <div class="btn-wrap">
          
            <button>◁</button>
            <button>목록</button>
            <button>▷</button>        
          
        </div>
    </div>

</asp:Content>