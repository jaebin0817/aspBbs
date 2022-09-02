<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BbsPwcheck.aspx.cs" Inherits="WebApplication1.BbsPwcheck" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">

        <table class="pw-table">

            <tr>
                <td id="mode-info" colspan="3">
                    <asp:Label runat="server" ID="lblModeInfo"></asp:Label>위해 글 작성시 입력했던 비밀번호를 입력해주세요
                </td>
            </tr>

            <tr>
                <th>비밀번호</th>
                <td>
                    <asp:TextBox ID="typed_pw" runat="server" MaxLength="10" TextMode="Password" OnLoad="Typed_pw_OnLoad"></asp:TextBox>
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
            <tr>
                <td id="btn-back" colspan="2">
                    <asp:HyperLink runat="server" ID="hyperBack"><img src="/Images/back.png" /></asp:HyperLink>
                </td>
            </tr>

        </table>
        

    </div>

    <script>

        $("#MainContent_typed_pw").focusin(function () {
            $("#MainContent_lblAlert").empty();
        });
            

    </script>

</asp:Content>
