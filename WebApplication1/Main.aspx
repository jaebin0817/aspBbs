<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WebApplication1.Main" %>


<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">

        <div class="col-1" id="intro">
            <h1>소개글 및 이미지</h1>
        </div>

        <asp:SqlDataSource runat="server" ID="dsrcProduct" ConnectionString="<%$ ConnectionStrings:BoardDB %>">
        </asp:SqlDataSource>
        
        <div id="rec-posts">
            <div id="hot-posts">
                <div class="rec-title" >
                  <p>인기글</p>
                </div>
                <div class="rec-post-left">
                  <p>
                      <asp:Label runat="server" ID="lblP_hot_thumb1" CssClass="rec-thumb-wrap"></asp:Label>
                  </p>
                  <p class="rec-post-title">
                      <asp:Label runat="server" ID="lblP_hot_title1"></asp:Label>
                  </p>
                </div>
                <div class="rec-post-right">
                  <p>
                       <asp:Label runat="server" ID="lblP_hot_thumb2" CssClass="rec-thumb-wrap"></asp:Label>
                  </p>
                  <p class="rec-post-title">
                      <asp:Label runat="server" ID="lblP_hot_title2"></asp:Label>
                  </p>
                </div>
            </div>
            <div id="new-posts">
                <div class="rec-title" >
                  <p>최신글</p>
                </div>
                <div class="rec-post-left">
                  <p>
                      <asp:Label runat="server" ID="lblP_new_thumb1" CssClass="rec-thumb-wrap"></asp:Label>
                  </p>
                  <p class="rec-post-title">
                      <asp:Label runat="server" ID="lblP_new_title1"></asp:Label>
                  </p>
                </div>
                <div class="rec-post-right">
                  <p>
                      <asp:Label runat="server" ID="lblP_new_thumb2" CssClass="rec-thumb-wrap"></asp:Label>
                  </p>
                  <p class="rec-post-title">
                      <asp:Label runat="server" ID="lblP_new_title2"></asp:Label>
                  </p>
                </div>
            </div>
        </div>

        
    </div>
</asp:Content>