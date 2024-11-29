var regEamil = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}(?:\.[a-zA-Z]{2,})*$/;
var regPwd=/^(?=.*[a-zA-Z])(?=.*\d)[\w.?]{6,}$/
$('#register-submit').on("click", function () {

    if ($('#register-nickname').val() == '') {
        alert("暱稱未填寫，請重新輸入")
    }
    else if (!regEamil.test($('#register-email').val())) {
        alert("信箱不符合格式，請重新輸入")
    }
    else if (!regPwd.test($('#register-pwd').val())) {
        alert("密碼不符合格式，請重新輸入")
    }
    else if ($('#register-pwd').val() != $('#register-pwddb').val() ){
        alert("確認密碼與註冊密碼不同，請重新輸入")
    }
    else {
        //要傳遞的註冊資料
        let data = {
            UserNickname: $('#register-nickname').val(),
            Email: $('#register-email').val(),
            Password: $('#register-pwd').val(),
        }
        //傳遞資料給server->controller
        $.ajax({
            url: '/User/RegisterPage',
            type: 'Post',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (result) {
                console.log('成功')
                if (result['registerdMessage'] != null) {
                    alert(result['registerdMessage'])
                }
                else if (result['mailsuccess'] != null) {
                    alert(result['mailsuccess'])
                    window.location.href = result["action"];
                }
                else if (result['message'] != null) {
                    alert(result['message'])
                }
                else {
                    alert("未寄送成功信件")
                }
            },
            error: function (xhr, status, error,) {
                console.error('錯誤', error)
            }
        });
    }
})
$('.input-pwd').hover(
    function () {
        $(this).children('img').removeClass('d-none')
    }, function () {
        $(this).children('img').addClass('d-none')
    });

$('.input-pwd').children('img').on('click', function () {
    var pwdState = $(this).prev().attr('type')
    if (pwdState == 'password') {
        $(this).prev().attr('type', 'text')
    }
    else {
        $(this).prev().attr('type', 'password')
    }
})