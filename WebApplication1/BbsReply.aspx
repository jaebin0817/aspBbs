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
                    <asp:TextBox ID="r_wname" runat="server" placeholder="작성자" CssClass="form-control"></asp:TextBox>
                </div>                
                <div class="reply-pw">
                    <asp:TextBox ID="r_pw" runat="server" TextMode="Password" placeholder="비밀번호"  CssClass="form-control"></asp:TextBox>
                </div>
                <div class="reply-cont">
                    <asp:TextBox ID="r_content" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="3" Columns="300"></asp:TextBox>
                </div>
                <div class="reply-btn">
                    <asp:Button ID="btnReply" runat="server" Text="답글 작성" OnClick="BtnReply_Click" CssClass="btnReply"/>
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
    </div>
</asp:Content>