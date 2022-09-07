<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BbsList.aspx.cs" Inherits="WebApplication1.BbsList" %>


<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">
        
        <asp:SqlDataSource runat="server" ID="dsrcProduct" ConnectionString="<%$ ConnectionStrings:BoardDB %>">
        </asp:SqlDataSource>

        <div class="list-title" id="list-title"><asp:Label runat="server" ID="lblTitle"></asp:Label></div>
        <div class="list-write" id="list-write">
            총 게시글 수 : <asp:Label ID="lblCount" runat="server" /> (page : <asp:Label ID="lblNowPage" runat="server" /> / <asp:Label ID="lblPage" runat="server" />) &nbsp;&nbsp;&nbsp;
            <asp:HyperLink runat="server" ID="HlWrite" Text="[ 글쓰기 ]"></asp:HyperLink>
            <%--<a href="BbsWrite.aspx">[ 글쓰기 ]</a>--%>
        </div>
        <div class="posts-list" id="posts-list">
        <asp:Repeater runat="server" ID="rptProduct">
            <ItemTemplate>
                <div class="posts-wrap">
                    <a href="<%# Eval("p_open").ToString() == "Y" ? "BbsRead.aspx?" : "BbsPwcheck.aspx?mode=read&"%>p_no=<%# Eval("p_no") %>&p_member=<%# Eval("p_member") %><%if (Request["c_no"] != null) { Response.Write("&c_no="+Request["c_no"]); } %><%if (Request["keyword"] != null) { Response.Write("&keyword="+Request["keyword"]); } %><%if (Request["nowPage"] != null) { Response.Write("&nowPage="+Request["nowPage"]); } %>">                                              
                        <div class="posts-title"><%# Eval("p_subject") %></div>
                        <div class="posts-cont"><%# Eval("p_open").ToString() =="Y" ? Eval("p_content") : "비공개 게시글입니다" %></div>
                        <div class="posts-info">
                            <strong><%# Eval("p_wname") %></strong> &nbsp;|&nbsp; 조회수 <%# Eval("p_readcnt") %>
                        </div>
                        <div class="posts-thumb">
                            <img src="/Uploads/<%# Eval("p_open").ToString() =="Y" ?  Eval("p_thumb") : "noopen.png" %>" class="thumb-img" />
                        </div>
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
        <asp:HiddenField ID="hfCat" runat="server" />
        <asp:HiddenField ID="hfCno" runat="server" />
        <asp:HiddenField ID="hfKeyword" runat="server" />
        <asp:HiddenField ID="hfNowPage" runat="server" />


        <div class="search-wrap">
              <asp:TextBox ID="navSearch" runat="server" CssClass="navsearch" placeholder="작성자, 제목, 내용"></asp:TextBox>              
              <asp:Button ID="btnSearch" runat="server" OnClick="BtnSearch_Click" Text="검색" CssClass="navbtn"></asp:Button><br />
        </div>



    </div>

</asp:Content>