console.log(123)
// token
var token = null;
fetch('/cherishorders/gettoken')
    .then(response => response.json())
    .then(response => {
        token = response.token;
    })

ResetAJAX();

// ---------【Global】----------------

var orderId;
var stateCode;
var rejectText;
var reasonId;

function downPopUp(jq_popup) {
    jq_popup.parent().hide()
}
function AllTextReset(jq_popup) {
    jq_popup.parent().find('input,textarea').val('')
}
function AllSelectReset(jq_popup) {
    jq_popup.parent().find('select').val('0')
}
function ResetAJAX() {
    orderId = 0;
    stateCode = 99;
    rejectText = null;
    reasonId = 99;
}
// -----------------------------------


/*
orderId
stateCode
reasonId
rejectText
*/ 



// 退回彈出視窗
$('#order-back').on('click', function () {
    $('#back-popup').show()
})
$('#back-popup-confirm').on('click', function () {

    var orderId = Number($('#orderID').val());
    var stateCode = 3;
    var rejectText = $('#back-popup').find('textarea').val();
    var reasonId = 4;

    $.ajax({
        url: '/cherishorders/EditStatus/',
        method:'POST',
        contentType: 'application/json',
        headers: { 'RequestVerificationToken': token }, // 添加防護令牌
        data: JSON.stringify({ 
            orderId: orderId, 
            stateCode: stateCode, 
            rejectText: rejectText, 
            reasonId: reasonId
        }),
        success: function (response) {
            alert(`執行成功：${response.message}`)
            ResetAJAX();
            window.location.href = response.redirectUrl;
        },
        error: function (response) {
            alert(`執行失敗：${response.responseJSON.message}`)
            // console.log(`執行失敗：${response.responseJSON.message}`)
            ResetAJAX();
        }
    })
    downPopUp($(this))
    AllTextReset($(this))
})
$('#back-popup-close').on('click', function () {
    downPopUp($(this))
    AllTextReset($(this))
})



// 已確認彈出視窗
$('#order-ok').on('click', function () {
    $('#ok-popup').show()
})
$('#ok-popup-confirm').on('click', function () {
    var orderId = Number($('#orderID').val());
    var stateCode = 2;
    var rejectText = null;
    var reasonId = null;

    $.ajax({
        url: '/cherishorders/EditStatus/',
        method: 'POST',
        contentType: 'application/json',
        headers: { 'RequestVerificationToken': token }, // 添加防護令牌
        data: JSON.stringify({
            orderId: orderId,
            stateCode: stateCode,
            rejectText: rejectText,
            reasonId: reasonId
        }),
        success: function (response) {
            alert(`執行成功：${response.message}`)
            ResetAJAX();
            window.location.href = response.redirectUrl;
        },
        error: function (response) {
            alert(`執行失敗：${response.responseJSON.message}`)
            // console.log(`執行失敗：${response.responseJSON.message}`)
            ResetAJAX();
        }
    })
    downPopUp($(this))
})
$('#ok-popup-close').on('click', function () {
    downPopUp($(this))
})


// 請他修改
$('#order-edit').on('click', function () {
    $('#edit-popup').show()
})
$('#edit-popup-confirm').on('click', function () {
    var orderId = Number($('#orderID').val());
    var stateCode = 4;
    var rejectText = null;
    var reasonId = Number($('#reasonSelect').val());

    $.ajax({
        url: '/cherishorders/EditStatus/',
        method: 'POST',
        contentType: 'application/json',
        headers: { 'RequestVerificationToken': token }, // 添加防護令牌
        data: JSON.stringify({
            orderId: orderId,
            stateCode: stateCode,
            rejectText: rejectText,
            reasonId: reasonId
        }),
        success: function (response) {
            alert(`執行成功：${response.message}`)
            ResetAJAX();
            window.location.href = response.redirectUrl;
        },
        error: function (response) {
            alert(`執行失敗：${response.responseJSON.message}`)
            // console.log(`執行失敗：${response.responseJSON.message}`)
            ResetAJAX();
        }
    })
    downPopUp($(this))
    AllSelectReset($(this))
})
$('#edit-popup-close').on('click', function () {
    downPopUp($(this))
    AllSelectReset($(this))
})




$('#validSet').on('click', function () {
    $(this).hide();
    $('#validShow').show();
})
$('#ValidClose').on('click', function () {
    $('#validShow').hide();
    $('#validSet').show();
})
$('#ValidSummit').on('click', function () {

    var date = $('#ValidDate').val();
    var cherishId = Number($('#orderID').val());
    $.ajax({
        url: '/cherishorders/validDate',
        method: 'POST',
        data: { date: date, cherishId: cherishId },
        success: function (xhr) {
            alert(xhr.message);
            location.reload();
        },
        error: function (xhr) {
            alert(xhr.responseJSON.message);
        }
    })

    $('#validShow').hide();
    $('#validSet').show();
})