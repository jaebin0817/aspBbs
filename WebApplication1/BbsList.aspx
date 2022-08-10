<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BbsList.aspx.cs" Inherits="WebApplication1.BbsList" %>


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
            <input type="hidden" id="nowPage" value="1" />
            <input type="hidden" id="no" value="1" />
            <input type="button" id="more-btn" class="more-btn" value="목록 더보기" />
        </div>

        <div class="search-wrap">
              <asp:TextBox ID="navSearch" runat="server" CssClass="navsearch" placeholder="작성자, 제목, 내용"></asp:TextBox>              
              <asp:Button ID="btnSearch" runat="server" OnClick="BtnSearch_Click" Text="검색" CssClass="navbtn"></asp:Button>   
        </div>
        <input type="hidden" id="keyword"/>



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


        $("#more-btn").click(function () {  		    			
			var nowPage=parseInt($('#nowPage').val());
			var newNowPage = nowPage+1;				
			$('#nowPage').attr('value', newNowPage);		            

            loadNext();
        });

        function loadNext() {

            var num = parseInt($("#no").val());

            alert($('#nowPage').val());
            $.ajax({
                url: "morecontents.aspx",
                type: "get",
                data: {
                    nowPage: $('#nowPage').val(),
                    c_no: searchParam('c_no'),
                    keyword: searchParam('keyword'),
                },
                success: function (data) {
                    $.each(data, function (index, value) {
                        $(".posts-list").append("<div class='posts-wrap' id='morepost" + num + "'>");

                        $("#morepost" + num).append("<a id='morepostLink" + num + " href='BbsRead.aspx?c_no=" + value.c_no + "&p_no=" + value.p_no + "'>");

                        $("#morepostLink" + num).append("<div class='posts-title'>" + value.p_subject + "</div>");
                        $("#morepostLink" + num).append("<div class='posts-cont'>" + value.p_content + "</div>");
                        $("#morepostLink" + num).append("<div class='posts-info'><strong>" + value.p_wname + "</strong>&nbsp;|&nbsp; 조회수" + value.p_readcnt + "</div>");
                        $("#morepostLink" + num).append("<div class='posts-thumb'><img src='/Uploads/" + value.p_thumb + "' class='thumb-img' /></div>");
                        num++;
                    })
                    $('#no').attr('value', num);
                },
                error: function (error) {
                    alert("에러: " + error);
                }	

            });
        }

    </script>

</asp:Content>