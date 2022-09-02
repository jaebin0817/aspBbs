<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WebApplication1.Main" %>


<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">

        <div class="col-1" id="intro">
            <a href="/Bbs/BbsList.aspx" ><img id="mainimg" src="/images/main.png" /></a>            
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
        <div class="search-wrap">
              <asp:TextBox ID="navSearch" runat="server" CssClass="navsearch" placeholder="작성자, 제목, 내용"></asp:TextBox>              
              <asp:Button ID="btnSearch" runat="server" OnClick="BtnSearch_Click" Text="검색" CssClass="navbtn"></asp:Button><br />
<%--              <asp:RequiredFieldValidator ID="rfvSearch" runat="server" ErrorMessage="검색어를 입력해주세요" 
                    Display="Dynamic" ControlToValidate="navSearch" SetFocusOnError="true">
              </asp:RequiredFieldValidator>   --%>
        </div>
        <asp:HiddenField ID="hfCat" runat="server" />
        <asp:HiddenField ID="hfCno" runat="server" />
        
    </div>
</asp:Content>