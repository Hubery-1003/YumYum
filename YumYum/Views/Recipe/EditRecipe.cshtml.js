

$('#recipe-introduction').on('input', function () {
    $('#recipe-introcount').text(`${$('#recipe-introduction').val().length}/100`);
})

$('#recipe-name').on('input', function () {
    $('#recipe-namecount').text(`${$('#recipe-name').val().length}/15`);
})



//接收步驟的變數
var steps = $('#all-steps').find('.card').length;


$('#step-plus').on('click', function () {
    steps += 1;
    //如果step是偶數的話就在right-steps下append新的步驟框
    if (steps == 1) {
        var stepLeft = $('<div>', {
            id: `step0${steps}`,
            class: 'card mt-5 step',    // 設定 class 屬性
            style: 'width: 18rem; margin-left: 7rem',
            html: `<img b-wbveynjuki  src="/img/icon/AddPhoto.png" class="card-img-top img-load" alt="哈哈" style="height: 13rem;"><div b-wbveynjuki class= "text-center m-0 step-bk"><p b-wbveynjuki class="m-0 mt-1" style="font-size: 1.5rem;">STEP 0${steps}</p></div ><div b-wbveynjuki class="card-body" style="width:286px;height:152px"><textarea b-wbveynjuki id="step-text0${steps}" class="card-text" style="width:100%;height:100%;border-color:transparent" placeholder="點我輸入內容"></textarea></div>`
        }).attr('b-wbveynjuki', '');
        //把前一個步驟的mb-200屬性移除
        $(`#step-countdiv0${steps - 1}`).removeClass('mb-200')
        //中間連線
        $('#left-steps').append('<div b-wbveynjuki style="position: absolute;margin-top: 15.2rem;margin-left: 24.7rem;color:var(--yum-secondary-4)"> ─────────────<img b-b-wbveynjuki class="remove-steps" style="width:50px;height:50px" src="/img/icon/close.svg"/></div>')
        //步驟本人
        $('#left-steps').append(stepLeft);
        //計數
        $('#left-steps').append(`<div id="step-countdiv0${steps}" class="d-flex mb-200" style="margin-right: 260px"><label id ="step-count0${steps}" class="d-flex ms-auto">0/100</label></div>`);
        //新增計數邏輯
        $('#left-steps').append(`<script>$('#step-text0${steps}').on('input', function () {$('#step-count0${steps}').text(\`\${$('#step-text0${steps}').val().length}/100\`);}) </script>`)
    }
    else if (steps % 2 == 0 && steps != 0) {

        var stepRight = $('<div>', {
            id: `step0${steps}`,
            class: 'card step-right step',    // 設定 class 屬性
            html: `<img b-wbveynjuki src="/img/icon/AddPhoto.png" class="card-img-top img-load" alt="哈哈" style="height: 13rem;"><div b-wbveynjuki class= "text-center m-0 step-bk"> <p b-wbveynjuki class="m-0 mt-1" style="font-size: 1.5rem;">STEP 0${steps}</p></div ><div b-wbveynjuki class="card-body" style="width:286px;height:152px"><textarea b-wbveynjuki id=step-text0${steps} class="card-text" style="width:100%;height:100%;border-color:transparent" placeholder="點我輸入內容"></textarea></div>`
        }).attr('b-wbveynjuki', '');
        //把前一個步驟的mb-200屬性移除
        $(`#step-countdiv0${steps - 1}`).removeClass('mb-200')
        //中間連線
        $('#right-steps').append('<div b-wbveynjuki style="position: absolute;margin-top: 50.2rem;margin-left:-26px;color:var(--yum-secondary-4)"><img b-wbveynjuki class="remove-steps" style="width:50px;height:50px" src="/img/icon/close.svg" />─────────────</div>')
        //步驟本人
        $('#right-steps').append(stepRight);
        //計數
        $('#right-steps').append(`<div b-wbveynjuki class="d-flex mb-200" id="step-countdiv0${steps}" style="margin-right:146px"><label b-wbveynjuki id ="step-count0${steps}" class= "d-flex ms-auto">0/100</label></div>`);
        //新增計數邏輯
        $('#right-steps').append(`<script>$('#step-text0${steps}').on('input', function () {$('#step-count0${steps}').text(\`\${$('#step-text0${steps}').val().length}/100\`);}) </script>`)
        //如果step是奇數的話就在left-steps下append新的步驟框
    } else {
        var stepLeft = $('<div>', {
            id: `step0${steps}`,
            class: 'card step-left step',    // 設定 class 屬性
            html: `<img b-wbveynjuki  src="/img/icon/AddPhoto.png" class="card-img-top img-load" alt="哈哈" style="height: 13rem;"><div b-wbveynjuki class= "text-center m-0 step-bk"><p b-wbveynjuki class="m-0 mt-1" style="font-size: 1.5rem;">STEP 0${steps}</p></div ><div b-wbveynjuki class="card-body" style="width:286px;height:152px"><textarea b-wbveynjuki id="step-text0${steps}" class="card-text" style="width:100%;height:100%;border-color:transparent" placeholder="點我輸入內容"></textarea></div>`
        }).attr('b-wbveynjuki', '');
        //把前一個步驟的mb-200屬性移除
        $(`#step-countdiv0${steps - 1}`).removeClass('mb-200')
        //中間連線
        $('#left-steps').append('<div b-wbveynjuki style="position: absolute;margin-top: 50.2rem;margin-left: 24.7rem;color:var(--yum-secondary-4)"> ─────────────<img b-mc3u0u1te1 class="remove-steps" style="width:50px;height:50px" src="/img/icon/close.svg"/></div>')
        //步驟本人
        $('#left-steps').append(stepLeft);
        //計數
        $('#left-steps').append(`<div id="step-countdiv0${steps}" class="d-flex mb-200" style="margin-right: 260px"><label id ="step-count0${steps}" class="d-flex ms-auto">0/100</label></div>`);
        //新增計數邏輯
        $('#left-steps').append(`<script>$('#step-text0${steps}').on('input', function () {$('#step-count0${steps}').text(\`\${$('#step-text0${steps}').val().length}/100\`);}) </script>`)
    }


})

//刪除步驟邏輯
$(document).on('click', '.remove-steps', function () {
    steps -= 1;
    console.log(steps)
    //取得現在刪除的步驟幾
    var step = $(this).parent().next().attr('id').slice(-1)
    let stepInt = parseInt(step)
    //取得總步驟數也是最後一步的數字
    var stepCount = $('#all-steps').find('.step').length;
    let stepCountInt = parseInt(stepCount)
    //要執行迴圈的次數
    let forTimes = stepCountInt - stepInt
    //for迴圈
    for (let i = 0; i < forTimes; i++) {
        //將現在所在的元素找出來->將下一個步驟的內容替換現在的步驟
        //取得下一個步驟的內容
        console.log("我我我")
        var nextStepText = $(`#step0${stepInt + i + 1}`).find('textarea').val();
        //將現在步驟內容換成下一個步驟的內容
        var thisStepText = $(`#step0${stepInt + i}`).find('textarea').val(nextStepText);
        //------------------------------------------------------------------------------
        //取得下一個步驟的照片內容
        var nextStepImg = $(`#step0${stepInt + i + 1}`).find('img').attr('src');
        //步驟照片
        var thisStepImg = $(`#step0${stepInt + i}`).find('img').attr('src', nextStepImg);
    }
    //最後一個步驟刪除
    //把他的上一個div刪除也就是中間連線的部分
    $(`#step0${stepCount}`).prev().remove()
    //把他的下一個div刪除也就是計數
    $(`#step0${stepCount}`).next().remove()
    //把自己刪除
    $(`#step0${stepCount}`).remove()
})



let selectedFile = null
//上傳圖片
$(document).on('click', '.img-load', function () {
    //將點擊的img元素賦值給一個變數
    const imgElement = $(this);
    //設定file-load的data將imgElement的元素裝到targerImg這個容器裡
    $('#file-load').data('targetImg', imgElement)
    $('#file-load').click();
});
$('#file-load').on('change', function (event) {
    //選取使用者選擇的第一個檔案
    selectedFile = event.target.files[0]
    const targetImg = $(this).data('targetImg')
    //將圖片載入到步驟的圖片
    if (selectedFile && targetImg) {
        //讀取檔案
        const reader = new FileReader();
        reader.onload = function (e) { targetImg.attr('src', e.target.result) }
        reader.readAsDataURL(selectedFile);
    }
})