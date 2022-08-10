<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="BbsSearch.aspx.cs" Inherits="WebApplication1.BbsSearch" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">
        
        <asp:SqlDataSource runat="server" ID="dsrcProduct" ConnectionString="<%$ ConnectionStrings:BoardDB %>">
        </asp:SqlDataSource>

        <div class="list-title" id="list-title"></div>
        <div class="list-write" id="list-write"><a href="BbsWrite.aspx">글쓰기</a></div>
        <div class="posts-list" id="posts-list">
        <asp:Repeater runat="server" ID="rptProduct">
            <ItemTemplate>
                <div class="posts-wrap">
                    <a href="BbsRead.aspx?c_no=<%# Eval("c_no") %>&p_no=<%# Eval("p_no") %><%if (Request["keyword"] != "") { Response.Write("&keyword="+Request["keyword"]); } %>">                        
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
        </div>


        <div class="search-wrap">
              <asp:TextBox ID="navSearch" runat="server" CssClass="navsearch" placeholder="작성자, 제목, 내용"></asp:TextBox>              
              <asp:Button ID="btnSearch" runat="server" OnClick="BtnSearch_Click" Text="검색" CssClass="navbtn"></asp:Button>   
        </div>
        



    </div>
    
    
    <script>

        var keyword = searchParam('keyword');

        $(document).ready(function () {
                $("#list-title").html("\"" + keyword + "\"" + " 검색 결과");
        });

    </script>

 

</asp:Content>
