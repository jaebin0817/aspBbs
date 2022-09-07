<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BbsWrite.aspx.cs" Inherits="WebApplication1.BbsWrite" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="wrap">
        <asp:HiddenField runat="server" ID="loginStatus" />
        <div class="page-title" id="page-title">게시글 작성</div>
          <table class="table write-form">
              <tr id="NonMember1">
                  <th>작성자</th>
                  <td>
                      <asp:TextBox id="p_wname" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvP_wname" runat="server" ErrorMessage="작성자를 입력해주세요" 
                          Display="Dynamic" ControlToValidate="p_wname" SetFocusOnError="true">
                      </asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr id="NonMember2">
                  <th>비밀번호</th>
                  <td>
                      <asp:TextBox id="p_pw" runat="server" TextMode="Password" MaxLength="10" CssClass="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvP_pw" runat="server" ErrorMessage="비밀번호를 입력해주세요" 
                          Display="Dynamic" ControlToValidate="p_pw" SetFocusOnError="true">
                      </asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="revP_pw" runat="server" ErrorMessage="비밀번호는 4자 이상 10자 이하여야 합니다"
                          Display="Dynamic" ControlToValidate="p_pw" SetFocusOnError="true" ValidationExpression="\w{4,10}">
                      </asp:RegularExpressionValidator>
                  </td>
              </tr>
              <tr>
                  <th>카테고리</th>
                  <td>
                      <asp:DropDownList id="c_no" runat="server" CssClass="form-control">
                          <asp:ListItem value="">카테고리선택</asp:ListItem>
                          <asp:ListItem value="1">카테고리1</asp:ListItem>
                          <asp:ListItem value="2">카테고리2</asp:ListItem>
                          <asp:ListItem value="3">카테고리3</asp:ListItem>
                          <asp:ListItem value="4">카테고리4</asp:ListItem>
                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <th>제목</th>
                  <td>
                      <asp:TextBox id="p_subject" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvP_subject" runat="server" ErrorMessage="제목을 입력해주세요" 
                          Display="Dynamic" ControlToValidate="p_subject" SetFocusOnError="true">
                      </asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <th>내용</th>
                  <td>
                      <asp:TextBox id="p_content" runat="server" TextMode="MultiLine" Height="400px" CssClass="form-control"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="rfvP_content" runat="server" ErrorMessage="내용을 입력해주세요" 
                          Display="Dynamic" ControlToValidate="p_content">
                      </asp:RequiredFieldValidator>
                  </td>
              </tr>
              <tr>
                  <th>썸네일 이미지</th>
                  <td>
                      <asp:FileUpload id="p_thumb" runat="server" CssClass="form-control" ></asp:FileUpload>
                      <h6>이미지 파일(.jpg, .jpeg, .png, .gif)만 업로드 가능합니다</h6>
                  </td>
              </tr>
              <tr>
                   <th>게시글 공개</th>
                   <td>
                        <asp:RadioButton ID="p_open_y" GroupName="p_open" Text="공개" Checked="true" runat="server" />
                        <asp:RadioButton ID="p_open_n" GroupName="p_open" Text="비공개" runat="server" />
                   </td>
              </tr>
              <tr>
                  <th></th>
                   <th class="tb-btns">
                       <asp:Button id="btnWrite" runat="server" OnClientClick="return bbsWriteCheck()" OnClick="BtnWrite_Click" Text="쓰기"/>
                       <asp:Button id="btnCancel" runat="server" OnClick="BtnCancel_Click" Text="취소"/>
                       <asp:Button id="btnList" runat="server" Text="HOME" PostBackUrl="~/Main.aspx" CausesValidation="false" />  
                   </th>
              </tr>
          </table>


    </div>
    <script>

        $(document).ready(function () {
            var loginStatus = $("#MainContent_loginStatus").val();
            if (loginStatus == "Y") {
                $("#NonMember1").css("display", "none");
                $("#NonMember2").css("display", "none");
            }
        });

        $("#MainContent_p_thumb").change(function () {
            imgFileCheck();
        });

    </script>
 </asp:Content>