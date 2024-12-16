console.log('hello world')

var token = null;
fetch('/cherishorders/gettoken')
    .then(response => response.json())
    .then(response => {
        token = response.token;
    })




var tradeCodeOld = -1;
var attrIdOld = 0;
var nameOld = null;

$('#status-sort input').on('change', function () {

    var tradeCode = $(this).val()
    var attrId = $('#order-foodattr').val()
    var name = $('#order-foodname').val()

    if (tradeCodeOld == tradeCode) return;


    
    $.ajax({
        url: '/cherishorders/sort',
        method: 'POST',
        headers: { 'RequestVerificationToken': token },
        contentType: 'application/json',
        data: JSON.stringify({ tradeCode: tradeCode }),

        success:function(data) {
            
            $('#orders').empty().html(data)
            tradeCodeOld = tradeCode;
            console.log('執行成功')
        },
        error: function (xhr) {
            alert(`執行失敗： ${xhr.responseJSON.message}`)
        }
    })
})