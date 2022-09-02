function IdCheck() {
    var m_id = $("#m_id").val();
    //alert(m_id);
    var idRegExp = /^[a-z0-9]{5,20}$/;

    if (!idRegExp.test(m_id)) {
        alert("아이디는 영문 소문자와 숫자 5~20자리로 입력해주세요");
        $("#m_id").focus();
        return false;
    }

    return true;

}


function LoginCheck() {
    var m_id = $("#MainContent_m_id").val();
    if (m_id.length == 0) {
        alert("아이디를 입력해주세요");
        $("#MainContent_m_id").focus();
        return false;
    }

    var m_pw = $("#MainContent_m_pw").val()
    if (mb_pw.length == 0) {
        alert("비밀번호를 입력해주세요");
        $("#MainContent_m_pw").focus();
        return false;
    } 

    return true;
}


function JoinCheck() {
    //1)아이디 유효성
    var m_id = $("#MainContent_mb_id").val();
    if (m_id == "") {
        alert("아이디 중복확인을 클릭해 아이디를 입력해주세요");
        return false;
    }

    //2)비밀번호 유효성
    var mb_pw = $("#MainContent_mb_pw").val();
    var mb_pw_re = $("#mb_pw_re").val();
    var pwRegExp = /^[a-zA-Z0-9]{8,30}$/;
    if (mb_pw.length == 0) {
        alert("비밀번호를 입력해주세요");
        $("#MainContent_mb_pw").focus();
        return false;
    } else {
        if (!pwRegExp.test(mb_pw)) {
            alert("비밀번호는 영문 대소문자와 숫자 8~30자리로 입력해주세요");
            $("#MainContent_mb_pw").focus();
            return false;
        }
    }
    if (mb_pw_re.length == 0) {
        alert("비밀번호 확인을 입력해주세요");
        $("#mb_pw_re").focus();
        return false;
    } else if (mb_pw_re != mb_pw) {
        alert("비밀번호가 같지 않습니다");
        $("#mb_pw_re").focus();
        return false;
    }

    //3)이름 유효성
    var mb_name = $("#MainContent_mb_name").val();
    var nameRegExp = /^[가-힣]{2,20}$/;
    if (mb_name.length == 0) {
        alert("이름을 입력해주세요");
        $("#MainContent_mb_name").focus();
        return false;
    } else {
        if (!nameRegExp.test(mb_name)) {
            alert("이름은 한글 2~20글자로 입력해주세요");
            $("#MainContent_mb_name").focus();
            return false;
        }
    }


    //4)이메일 유효성
    var email = $("#MainContent_email1").val();
    var domain = $("#MainContent_email2").val();
    var emailRegExp = /^[A-Za-z0-9_\.\-]{5,20}$/;
    var domainRegExp = /^[A-Za-z0-9\-\.]+\.[A-Za-z]{2,3}$/;
    if (email.length == 0) {
        alert("이메일을 입력해주세요");
        $("#MainContent_email1").focus();
        return false;
    } else if (domain.length == 0) {
        alert("도메인을 입력해주세요");
        $("#MainContent_email2").focus();
        return false;
    } else {
        if (!emailRegExp.test(email)) {
            alert("올바른 이메일 형식이 아닙니다");
            $("#MainContent_email1").focus();
            return false;
        }
        if (!domainRegExp.test(domain)) {
            alert("올바른 도메일 형식이 아닙니다");
            $("#MainContent_email2").focus();
            return false;
        }
    }


    //5)휴대전화 유효성 (선택항목)
    var hp2 = $("#MainContent_hp2").val();
    var hp3 = $("#MainContent_hp3").val();
    var hpRegExp = /^[0-9]{3,4}$/;
    if (hp2.length != 0) {//입력되었다면 유효성 검사
        if (!hpRegExp.test(hp2) || hp2.length<3) {
            alert("휴대전화는 숫자 3~4글자로 입력해주세요");
            $("#MainContent_hp2").focus();
            return false;
        }
        if (hp3.length == 0) {
            alert("휴대전화 뒷자리를 입력해주세요");
            $("#MainContent_hp3").focus();
            return false;
        }
    }
    if (hp3.length != 0) {//입력되었다면 유효성 검사
        if (!hpRegExp.test(hp3) || hp3.length < 4) {
            alert("휴대전화는 숫자 4글자로 입력해주세요");
            $("#MainContent_hp3").focus();
            return false;
        }
        if (hp2.length == 0) {
            alert("휴대전화 가운데자리를 입력해주세요");
            $("#MainContent_hp2").focus();
            return false;
        }
    }
    //alert("유효성 검사 통과");
    return true;
}


function UpdateCheck() {

    //비밀번호 유효성
    var mb_pw = $("#MainContent_mb_pw").val();
    var mb_pw_re = $("#mb_pw_re").val();
    var pwRegExp = /^[a-zA-Z0-9]{8,30}$/;
    if (mb_pw.length != 0) {

        if (!pwRegExp.test(mb_pw)) {
            alert("비밀번호는 영문 대소문자와 숫자 8~30자리로 입력해주세요");
            $("#MainContent_mb_pw").focus();
            return false;
        }

        if (mb_pw_re.length == 0) {
            alert("비밀번호 확인을 입력해주세요");
            $("#mb_pw_re").focus();
            return false;
        } else if (mb_pw_re != mb_pw) {
            alert("비밀번호가 같지 않습니다");
            $("#mb_pw_re").focus();
            return false;
        }
    } 


    //이름 유효성
    var mb_name = $("#MainContent_mb_name").val();
    var nameRegExp = /^[가-힣]{2,20}$/;
    if (mb_name.length == 0) {
        alert("이름을 입력해주세요");
        $("#MainContent_mb_name").focus();
        return false;
    } else {
        if (!nameRegExp.test(mb_name)) {
            alert("이름은 한글 2~20글자로 입력해주세요");
            $("#MainContent_mb_name").focus();
            return false;
        }
    }


    //4)이메일 유효성
    var email = $("#MainContent_email1").val();
    var domain = $("#MainContent_email2").val();
    var emailRegExp = /^[A-Za-z0-9_\.\-]{5,20}$/;
    var domainRegExp = /^[A-Za-z0-9\-]+\.[A-Za-z0-9\-]+/;
    if (email.length == 0) {
        alert("이메일을 입력해주세요");
        $("#MainContent_email1").focus();
        return false;
    } else if (domain.length == 0) {
        alert("도메인을 입력해주세요");
        $("#MainContent_email2").focus();
        return false;
    } else {
        if (!emailRegExp.test(email)) {
            alert("올바른 이메일 형식이 아닙니다");
            $("#MainContent_email1").focus();
            return false;
        }
        if (!domainRegExp.test(domain)) {
            alert("올바른 도메일 형식이 아닙니다");
            $("#MainContent_email2").focus();
            return false;
        }
    }


    //휴대전화 유효성 (선택항목)
    var hp2 = $("#MainContent_hp2").val();
    var hp3 = $("#MainContent_hp3").val();
    var hpRegExp = /^[0-9]{3,4}$/;
    if (hp2.length != 0) {//입력되었다면 유효성 검사
        if (!hpRegExp.test(hp2) || hp2.length < 3) {
            alert("휴대전화는 숫자 3~4글자로 입력해주세요");
            $("#MainContent_hp2").focus();
            return false;
        }
        if (hp3.length == 0) {
            alert("휴대전화 뒷자리를 입력해주세요");
            $("#MainContent_hp3").focus();
            return false;
        }
    }
    if (hp3.length != 0) {//입력되었다면 유효성 검사
        if (!hpRegExp.test(hp3) || hp3.length < 4) {
            alert("휴대전화는 숫자 4글자로 입력해주세요");
            $("#MainContent_hp3").focus();
            return false;
        }
        if (hp2.length == 0) {
            alert("휴대전화 가운데자리를 입력해주세요");
            $("#MainContent_hp2").focus();
            return false;
        }
    }

    //alert("유효성 검사 통과");
    //return false;

}










