<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BbsReply.aspx.cs" Inherits="WebApplication1.BbsReply" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">

        <div class="reply-wrap">
            <div class="reply-list-wrap">
                <table>
                <asp:SqlDataSource runat="server" ID="dsrcProduct" ConnectionString="<%$ ConnectionStrings:BoardDB %>">
                </asp:SqlDataSource>
                <asp:Repeater runat="server" ID="rptProduct">
                    <ItemTemplate>
                        
                            <tr>
                                <td><strong><%# Eval("r_wname") %></strong>&nbsp;&nbsp;</td>
                                <td id="r_redgt_td"><%# Eval("r_regdt") %>&nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="r_content_td" colspan="2"><%# Eval("r_content") %></td>
                            </tr>
                        
                    </ItemTemplate>
                </asp:Repeater> 
                </table>
            </div>
            <div class="reply-write-wrap">
                <div class="reply-writer">
                    <asp:TextBox ID="r_wname" runat="server" placeholder="작성자" MaxLength="20" CssClass="form-control"></asp:TextBox>
                </div>                
                <div class="reply-pw">
                    <asp:TextBox ID="r_pw" runat="server" TextMode="Password" placeholder="비밀번호" MaxLength="10" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="reply-cont">
                    <asp:TextBox ID="r_content" runat="server" TextMode="MultiLine" MaxLength="500" CssClass="form-control" Rows="3" Columns="300"></asp:TextBox>
                </div>
                <div class="reply-btn">
                    <asp:Button ID="btnReply" runat="server" Text="답글 작성" OnClientClick="return replyCheck()" OnClick="BtnReply_Click" CssClass="btnReply"/>
                </div>
            </div>
            <div id="btn-back">
                <asp:HyperLink runat="server" ID="hyperBack"><img src="/Images/back.png" /></asp:HyperLink>
            </div>
        </div>
        
    </div>

    <script>
        $("MainContent_btnReply").click(function () {
            replyCheck();
        });

    </script>

</asp:Content>