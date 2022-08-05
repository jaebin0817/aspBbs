<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SqlDataSourceTest.aspx.cs" Inherits="WebApplication1.SqlDataSourceTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:SqlDataSource runat="server" ID="dsrcProduct" ConnectionString="<%$ ConnectionStrings:BoardDB %>"
                SelectCommand="SELECT * FROM bbs_post ORDER BY p_no">
            </asp:SqlDataSource>
            

                <asp:Repeater runat="server" ID="rptProduct">
                    <ItemTemplate>
                        <div class="posts-wrap">
                          <a href="BbsRead.aspx?p_no=<%# Eval("p_no") %>">
                            <div class="posts-title"><%# Eval("p_subject") %></div>
                            <div class="posts-cont"><%# Eval("p_content") %></div>
                            <div class="posts-info">
                                <%# Eval("p_wname") %> <%# Eval("p_readcnt") %>
                            </div>
                            <div class="posts-thumb"><img src="/Uploads/<%# Eval("p_thumb") %>" class="thumb-img" /></div>
                          </a>
                         </div>
                    </ItemTemplate>
                </asp:Repeater> 


        </div>        
    </form>
</body>
</html>
