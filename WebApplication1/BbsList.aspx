<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BbsList.aspx.cs" Inherits="WebApplication1.BbsList" %>


<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">
        
        <asp:SqlDataSource runat="server" ID="dsrcProduct" ConnectionString="<%$ ConnectionStrings:BoardDB %>">
        </asp:SqlDataSource>

        <div class="list-title" id="list-title"></div>
        <div class="list-write" id="list-write">
            총 게시글 수 : <asp:Label ID="lblCount" runat="server" /> (page : <asp:Label ID="lblNowPage" runat="server" /> / <asp:Label ID="lblPage" runat="server" />) &nbsp;&nbsp;&nbsp;
            <a href="BbsWrite.aspx">[ 글쓰기 ]</a>
        </div>
        <div class="posts-list" id="posts-list">
        <asp:Repeater runat="server" ID="rptProduct">
            <ItemTemplate>
                <div class="posts-wrap">
                    <a href="BbsRead.aspx?c_no=<%# Eval("c_no") %>&p_no=<%# Eval("p_no") %><%if (Request["keyword"] != null) { Response.Write("&keyword="+Request["keyword"]); } %>">                       
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


        <div class="more-wrap">
          <table class="paging-tb">
            <tr>
             <td>
              <asp:Button ID="btnPrev10" runat="server" CssClass="btn-paging" Font-Bold="true" Text="[이전 10]" ></asp:Button>
              <asp:Label ID="lblPaging" runat="server" CssClass="btn-paging"></asp:Label>         
              <asp:Button ID="btnNext10" runat="server" CssClass="btn-paging" Font-Bold="true" Text="[다음 10]" ></asp:Button>
             </td>
            </tr>
            <tr>
             <td>
              <asp:Button ID="btnFirst" runat="server" CssClass="btn-lists" Text="◀◀ 처음" ></asp:Button>
              <asp:Button ID="btnPrev" runat="server" CssClass="btn-lists" Text="◀ 이전 페이지" ></asp:Button>
              <asp:Button ID="btnNext" runat="server" CssClass="btn-lists" Text="다음 페이지 ▶"></asp:Button> 
              <asp:Button ID="btnLast" runat="server" CssClass="btn-lists" Text="끝 ▶▶" ></asp:Button>
             </td>
            </tr>
          </table>
        </div>

        <div class="search-wrap">
              <asp:TextBox ID="navSearch" runat="server" CssClass="navsearch" placeholder="작성자, 제목, 내용"></asp:TextBox>              
              <asp:Button ID="btnSearch" runat="server" OnClick="BtnSearch_Click" Text="검색" CssClass="navbtn"></asp:Button>   
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