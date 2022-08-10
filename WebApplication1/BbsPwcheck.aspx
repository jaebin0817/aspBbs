<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BbsPwcheck.aspx.cs" Inherits="WebApplication1.BbsPwcheck" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">

        <table class="pw-table">

            <tr>
                <td id="mode-info" colspan="3"></td>
            </tr>

            <tr>
                <th>비밀번호</th>
                <td>
                    <asp:TextBox ID="typed_pw" runat="server" TextMode="Password" OnLoad="Typed_pw_OnLoad"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnCheck" runat="server" Text="확인" OnClick="BtnCheck_Click" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td id="alert-field" colspan="2">
                    <asp:RequiredFieldValidator ID="rfvP_pw" runat="server" ErrorMessage="비밀번호를 입력해주세요" 
                          Display="Dynamic" ControlToValidate="typed_pw" SetFocusOnError="true">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revP_pw" runat="server" ErrorMessage="비밀번호는 4자 이상 10자 이하여야 합니다"
                          Display="Dynamic" ControlToValidate="typed_pw" SetFocusOnError="true" ValidationExpression="\w{4,10}">
                    </asp:RegularExpressionValidator>
                    <asp:Label runat="server" ID="lblAlert"></asp:Label>
                </td>
                
            </tr>

        </table>
        

    </div>

    <script>

        var mode = searchParam('mode');

        $(document).ready(function () {

            if (mode == 'del') {
                $("#mode-info").prepend().text("삭제를 위해 글 작성시 입력했던 비밀번호를 입력해주세요");
            } else if (mode == 'mod') {
                $("#mode-info").prepend().text("수정을 위해 글 작성시 입력했던 비밀번호를 입력해주세요");
            } else if (mode == 'r_mod') {
                $("#mode-info").prepend().text("댓글 수정을 위해 댓글 작성시 입력한 비밀번호를 입력해주세요");
            } else if (mode == 'r_del') {
                $("#mode-info").prepend().text("댓글 삭제를 위해 댓글 작성시 입력한 비밀번호를 입력해주세요");
            }

            $("#p_pw").focus();

        });

        $("#p_pw").focus(function () {
            $("#alert-field").empty();
        });


    </script>

</asp:Content>
