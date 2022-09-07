function searchParam(key) {
    return new URLSearchParams(location.search).get(key);
};

//SQL Injection 주의 문자 : < > ( ) ' " ; = + | & - # ..
const spExp = /[~!@$%^*_?:]/;
const numExp = /[0-9]/;
const engExp = /[a-zA-Z]/;
const engUpExp = /[A-Z]/;
const engLowExp = /[a-z]/;
const korExp = /[ㄱ-ㅎ|ㅏ-ㅣ|가-힣]/;
const korComExp = /[가-힣]/;

function bbsWriteCheck() {

    let pNamelen = $("#MainContent_p_wname").val().length;
    let pPwlen = $("#MainContent_p_pw").val().length;
    let pSublen = $("#MainContent_p_subject").val().length;
    let pContlen = $("#MainContent_p_content").val().length;
    let loginStatus = $("#MainContent_loginStatus").val();
    //alert(pSublen);

    if (pNamelen < 2 || pNamelen > 10) {
        alert("작성자는 2글자 이상 10글자 이하로 입력해주세요");
        $("#MainContent_p_wname").focus();
        return false;
    }

    if ((pPwlen < 4 || pPwlen > 10) && loginStatus == "N") {
        alert("비밀번호는 4글자 이상 10글자 이하로 입력해주세요");
        $("#MainContent_p_pw").focus();
        return false;
    }

    if (pSublen < 2 || pSublen > 50) {
        alert("제목은 2글자 이상 50글자 이하로 입력해주세요");
        $("#MainContent_p_subject").focus();
        return false;
    }

    if (pContlen == 0) {
        alert("내용을 입력해주세요");
        $("#MainContent_p_content").focus();
        return false;
    }

    if (pContlen > 20000) {
        alert("게시글 내용은 20000자 이하로 입력해주세요");
        var cont = $("#MainContent_p_content").val().substring(0, 20000);
        $("#MainContent_p_content").val(cont);
        $("#MainContent_p_content").focus();
        return false;
    }

    return true;

}



function imgFileCheck() {
    let filename = $("#MainContent_p_thumb").val();
    let filesize = $("#MainContent_p_thumb")[0].files[0].size;
    let maxsize = 3 * 1024 * 1024;
    let thumbname = filename.slice(filename.lastIndexOf("\\") + 1);

    //alert(filesize);
    //alert(filename);
    //alert(thumbname.length);

    if (filename != "") {
        var ext = filename.slice(filename.lastIndexOf(".") + 1).toLowerCase();
        var imgExt = ["jpg", "jpeg", "png", "gif"];

        if (!(imgExt.includes(ext))) {
            alert("이미지 파일만 업로드 가능합니다");
            $("#MainContent_p_thumb").val("");
        } else {
            if (filesize > maxsize) {
                alert("3MB 이하의 파일만 업로드 가능합니다");
                $("#MainContent_p_thumb").val("");
            }
            if (thumbname.length > 20) {
                alert("이미지 파일명은 확장자명 포함 20자 이하만 가능합니다");
                $("#MainContent_p_thumb").val("");
            }
        }

    }
}


function pwcheck() {

    let pw = $("#p_pw").val();
    let number = pw.search(/[0-9]/g);
    let english = pw.search(/[a-z]/ig);
    let spece = pw.search(/[`~!@@#$%^&*|₩₩₩'₩";:₩/?]/gi);
        let reg = /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/;

        if (pw.length < 8 || pw.length > 20) {
        alert("8자리 ~ 20자리 이내로 입력해주세요.");
    return false;

        } else if (pw.search(/\s/) != -1) {
        alert("비밀번호는 공백 없이 입력해주세요.");
    return false;

        } else if (number < 0 || english < 0 || spece < 0) {
        alert("영문,숫자,특수문자를 혼합하여 입력해주세요.");
    return false;

        } else if ((number < 0 && english < 0) || (english < 0 && spece < 0) || (spece < 0 && number < 0)) {
        alert("영문,숫자, 특수문자 중 2가지 이상을 혼합하여 입력해주세요.");
    return false;

        } else if (/(\w)\1\1\1/.test(pw)) {
        alert('같은 문자를 4번 이상 사용하실 수 없습니다.');
    return false;

        } else if (pw.search(id) > -1) {
        alert("비밀번호에 아이디가 포함되었습니다.");
    return false;
        } else {
        alert("비밀번호가 정상적으로 입력되었습니다.");
    return true;
}

        if (false === reg.test(pw)) {
        alert('비밀번호는 8자 이상이어야 하며, 숫자/대문자/소문자/특수문자를 모두 포함해야 합니다.');
    return false;
        } else {
        alert("비밀번호가 정상적으로 입력되었습니다.");
    return true;
}

}





