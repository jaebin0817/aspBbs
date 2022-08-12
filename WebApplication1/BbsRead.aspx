<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BbsRead.aspx.cs" Inherits="WebApplication1.BbsRead" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <div class="wrap">
        <div class="post-wrap">
            <div class="post-cat"><asp:Label runat="server" ID="lblP_cat"></asp:Label></div>
            <div class="post-title"><asp:Label runat="server" ID="lblP_subject"></asp:Label></div>
            <div class="post-info">
                <asp:Label runat="server" ID="lblP_wname" Font-Bold="true"></asp:Label>&nbsp;|&nbsp;
                <asp:Label runat="server" ID="lblP_regdt"></asp:Label>&nbsp;|&nbsp;
                조회수&nbsp;<asp:Label runat="server" ID="lblP_readcnt"></asp:Label>
            </div>
            <div class="post-cont"><asp:Label runat="server" ID="lblP_content"></asp:Label></div>
            <div class="post-mng">
                <asp:Label runat="server" ID="lblMod"></asp:Label>
                ·
                <asp:Label runat="server" ID="lblDel"></asp:Label>
                
                ·
                <a href="BbsWrite.aspx">글쓰기</a>
            </div>
        </div>
        <div class="reply-wrap">
            <div class="reply-list-wrap">
                <table>
                <asp:SqlDataSource runat="server" ID="dsrcProduct" ConnectionString="<%$ ConnectionStrings:BoardDB %>">
                </asp:SqlDataSource>
                <asp:Repeater runat="server" ID="rptProduct">               
                    <ItemTemplate>
                            <tr>                          
                                <td>
                                    <%# ShowIndent((int)Eval("r_indent"))%>
                                    <%# ShowReplyIcon((int)Eval("r_indent"))%>
                                    <strong><%# Eval("r_wname") %></strong>&nbsp;&nbsp;
                                    <span id="r_redgt_td"><%# Eval("r_regdt") %>&nbsp;&nbsp;</span>
                                    <a href="BbsPwcheck.aspx?mode=r_mod&r_no=<%# Eval("r_no") %>">수정</a>&nbsp;
                                    <a href="BbsPwcheck.aspx?mode=r_del&r_no=<%# Eval("r_no") %>">삭제</a>&nbsp;
                                    <a href="BbsReply.aspx?mode=r_re&r_no=<%# Eval("r_no") %>">답글</a>&nbsp;
                                </td>
                            </tr>
                            <tr>                                
                                <td class="r_content_td" colspan="5">
                                    <%# ShowIndent((int)Eval("r_indent"))%>
                                    <%# ShowReplySpace((int)Eval("r_indent"))%>
                                    <%# Eval("r_content") %>
                                </td>
                            </tr>
                        
                    </ItemTemplate>
                </asp:Repeater> 
                </table>

            </div>
            <div class="reply-write-wrap">
                <div class="reply-writer">
                    <asp:TextBox ID="r_wname" runat="server" placeholder="작성자" CssClass="form-control"></asp:TextBox>
                </div>                
                <div class="reply-pw">
                    <asp:TextBox ID="r_pw" runat="server" TextMode="Password" placeholder="비밀번호"  CssClass="form-control"></asp:TextBox>
                </div>
                <div class="reply-cont">
                    <asp:TextBox ID="r_content" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="3" Columns="300"></asp:TextBox>
                </div>
                <div class="reply-btn">
                    <asp:Button ID="btnReply" runat="server" Text="댓글 작성" OnClick="BtnReply_Click" CssClass="btnReply"/><br />
                    <asp:RequiredFieldValidator ID="rfvR_wname" runat="server" ErrorMessage="작성자를 입력해주세요" 
                          Display="Dynamic" ControlToValidate="r_wname" SetFocusOnError="true">
                    </asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfvR_pw" runat="server" ErrorMessage="비밀번호를 입력해주세요" 
                          Display="Dynamic" ControlToValidate="r_pw" SetFocusOnError="true">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revR_pw" runat="server" ErrorMessage="비밀번호는 4자 이상 10자 이하여야 합니다"
                          Display="Dynamic" ControlToValidate="r_pw" SetFocusOnError="true" ValidationExpression="\w{4,10}">
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvR_content" runat="server" ErrorMessage="댓글 내용을 입력해주세요" 
                          Display="Dynamic" ControlToValidate="r_content" SetFocusOnError="true">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

        </div>
        <div class="btn-wrap">
          
            <asp:Button id="btnLeft" runat="server" Text="◁ 이전" CausesValidation="false" CssClass="btn-lists" OnClick="BtnLeft_Click" />
            <asp:Button id="btnList" runat="server" Text="목록" CausesValidation="false" CssClass="btn-lists" />
            <asp:Button id="btnRight" runat="server" Text="다음 ▷" CausesValidation="false" CssClass="btn-lists" OnClick="BtnRight_Click" />
                      
        </div>
    </div>`

</asp:Content>