function replyCheck() {

    var namelen = $("#MainContent_r_wname").val().length;
    var pwlen = $("#MainContent_r_pw").val().length;
    var contlen = $("#MainContent_r_content").val().length;

    if (namelen < 2 || namelen > 10) {
        alert("작성자는 2글자 이상 10글자 이하로 입력해주세요");
        $("#MainContent_r_wname").focus();
        return false;
    }

    if (pwlen < 4 || pwlen > 10) {
        alert("비밀번호는 4글자 이상 10글자 이하로 입력해주세요");
        $("#MainContent_r_pw").focus();
        return false;
    }

    if (contlen == 0) {
        alert("댓글 내용을 입력해주세요");
        $("#MainContent_r_content").focus();
        return false;
    }

    if (contlen > 250) {
        alert("댓글 내용은 250자 이하로 입력해주세요");
        var cont = $("#MainContent_r_content").val().substring(0, 250);
        $("#MainContent_r_content").val(cont);
        $("#MainContent_r_content").focus();
        return false;
    }

    return true;

}


function rContCheck() {

    var contlen = $("#MainContent_r_content").val().length;

    if (contlen > 250) {
        alert("댓글 내용은 250자 이하로 입력해주세요");
        $("#MainContent_r_content").focus();
    }
}