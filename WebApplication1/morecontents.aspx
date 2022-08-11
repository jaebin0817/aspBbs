<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoreContents.aspx.cs" Inherits="WebApplication1.MoreContents" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <link rel="stylesheet" href="/Content/bootstrap.css"/>
  <link rel="stylesheet" href="/Content/bootstrap-theme.css"/> 
  <link rel="stylesheet" href="/Content/style.css"/>

    <title></title>
</head>
<body>

<form id="form1" runat="server">
  <div class="posts-list" id="posts-list">
    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true">
      <Scripts>
        <asp:ScriptReference Name="MsAjaxBundle" />
        <asp:ScriptReference Name="jquery" />
        <asp:ScriptReference Name="bootstrap" />
        <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
        <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
        <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
        <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
        <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
        <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
        <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
        <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
        <asp:ScriptReference Name="WebFormsBundle" />
      </Scripts>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    
  </div>
  
  <div class="more-wrap">
    
    <asp:HiddenField ID="nowPage" runat="server" />
    <asp:Button ID="btnMore" CssClass="more-btn" runat="server" Text="목록 더보기" />
    
  </div>

  <script>


        $("#btnMore").click(function () {  		    			
			var nowPage=parseInt($('#nowPage').val());
			var newNowPage = nowPage+1;				
			$('#nowPage').attr('value', newNowPage);		            

            loadNext();
        });

        function loadNext() {

            //Alert($('#nowPage').val());
            $.ajax({
                url: "MoreContents.aspx/MorePosts",
                type: "POST",
                dataType: "json",
                data: {
                    nowPage: $('#nowPage').val(),
                    c_no: searchParam('c_no'),
                    keyword: searchParam('keyword'),
                },
                success: function (response) {
                    alert(msg.d);
                },
                error: function (response) {
                    alert("에러: " + response);
                }	

            });
        }

  </script>

</form>

</body>
</html>