﻿<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BbsList.aspx.cs" Inherits="WebApplication1.BbsList" %>


<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">
        
        <asp:SqlDataSource runat="server" ID="dsrcProduct" ConnectionString="<%$ ConnectionStrings:BoardDB %>">
        </asp:SqlDataSource>


        <div class="list-title" id="list-title"></div>
        <div class="list-write" id="list-write"><a href="BbsWrite.aspx">글쓰기</a></div>

        <asp:Repeater runat="server" ID="rptProduct">
            <ItemTemplate>
                <div class="posts-wrap">
                    <a href="BbsRead.aspx?c_no=<%# Eval("c_no") %>&p_no=<%# Eval("p_no") %>">
                    <div class="posts-title"><%# Eval("p_subject") %></div>
                    <div class="posts-cont"><%# Eval("p_content") %></div>
                    <div class="posts-info">
                        <strong><%# Eval("p_wname") %></strong> &nbsp;|&nbsp; 조회수 <%# Eval("p_readcnt") %>
                    </div>
                    <div class="posts-thumb"><img src="/Uploads/<%# Eval("p_thumb") %>" class="thumb-img" /></div>
                    </a>
                    </div>
            </ItemTemplate>
        </asp:Repeater> 



        <div class="more-wrap">
            <button class="more-btn">목록 더보기</button>
        </div>




    </div>
    
    
    <script>

        var title = searchParam('bbs_cat');
        var keyword = searchParam('keyword');

        $(document).ready(function () {

            if (title != null) {
                $("#list-title").html(title + " 게시글 목록");
            } else if (keyword != null) {
                $("#list-title").html("\"" + keyword + "\"" + " 검색 결과");
            } else {
                $("#list-title").html("게시글 목록");
            }
        
        });    

    </script>

</asp:Content>