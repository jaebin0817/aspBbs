<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WebApplication1.Main" %>


<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">

        <div class="col-1" id="intro">
            <h1>소개글 및 이미지</h1>
        </div>

        
        <div id="rec-posts">
            <div id="hot-posts">
                <div class="rec-title" >
                  <p>인기글</p>
                </div>
                <div class="rec-post-left">
                  <p><img src="/images/img.jpg" class="rec-thumb"/></p>
                  <p class="rec-post-title">인기글1 제목</p>
                </div>
                <div class="rec-post-right">
                  <p><img src="/images/img.jpg" class="rec-thumb"/></p>
                  <p class="rec-post-title">인기글2 제목</p>
                </div>
            </div>
            <div id="new-posts">
                <div class="rec-title" >
                  <p>최신글</p>
                </div>
                <div class="rec-post-left">
                  <p><img src="/images/img.jpg" class="rec-thumb"/></p>
                  <p class="rec-post-title">최신글1 제목</p>
                </div>
                <div class="rec-post-right">
                  <p><img src="/images/img.jpg" class="rec-thumb"/></p>
                  <p class="rec-post-title">최신글2 제목</p>
                </div>
            </div>
        </div>

        
    </div>
</asp:Content>