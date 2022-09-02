<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestList.aspx.cs" Inherits="WebApplication1.ListTest" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">
        
        <asp:SqlDataSource runat="server" ID="dsrcProduct" ConnectionString="<%$ ConnectionStrings:BoardDB %>">
        </asp:SqlDataSource>

        <div class="list-title" id="list-title"><asp:Label runat="server" ID="lblTitle"></asp:Label></div>
        <div class="list-write" id="list-write">
            ★테스트★ 총 게시글 수 : <asp:Label ID="lblCount" runat="server" /> (page : <asp:Label ID="lblNowPage" runat="server" /> / <asp:Label ID="lblPage" runat="server" />) &nbsp;&nbsp;&nbsp;
            <a href="BbsWrite.aspx">[ 글쓰기 ]</a>
        </div>
        <div class="posts-list" id="posts-list">
        <asp:Repeater runat="server" ID="rptProduct">
            <ItemTemplate>
                <div class="posts-wrap">
                    <a href="TestRead.aspx?c_no=<%# Eval("c_no") %>&p_no=<%# Eval("p_no") %>">                       
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
            <asp:HiddenField ID="hfCat" runat="server" />
            <asp:HiddenField ID="hfCno" runat="server" />
        </div>

        <div class="search-wrap">
              <asp:TextBox ID="navSearch" runat="server" CssClass="navsearch" placeholder="작성자, 제목, 내용"></asp:TextBox>              
              <asp:Button ID="btnSearch" runat="server" OnClick="BtnSearch_Click" Text="검색" CssClass="navbtn"></asp:Button><br />
        </div>



    </div>

</asp:Content>
