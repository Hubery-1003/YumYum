
$('#button-login').on('click', function () {
    if ($('#login-account').val() == "") {
        alert("帳號未輸入")
        return
    }
    else if ($('#login-password').val() == "") {
        alert("密碼未輸入")
        return
    }
    const data = {
        Email: $('#login-account').val(),
        Password: $('#login-password').val()
    }
    console.log("資料"+data["Email"])

    $.ajax({
        url: '/User/LogInPage', // 請求的 URL
        type: 'POST', // 請求類型
        contentType: 'application/json', // 設定資料格式
        data: JSON.stringify(data), // 傳遞的 JSON 資料
        success: function (result) {
            console.log('成功:', result);
            if (result["errorMessage"] != null) {
                alert(`${result["errorMessage"]}`)
            }
            else {
                window.location.href = result["redirectUrl"]
            }
            
        },
        error: function (xhr, status, error) {
            console.error('錯誤:', error);
        }
    });
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