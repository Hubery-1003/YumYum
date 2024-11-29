$(document).ready(
	function () {
		$("#btn-save").click(
			function (event) {
				var facebookUrl = $("#input-facebook-link").val();
				var youtubeUrl = $("#input-youtube-link").val();
				var facebookRegex = /^(http|https)\:\/\/(www\.)?facebook\.com\/.*$/;
				var youtubeRegex = /^(http|https)\:\/\/(www\.)?youtube\.com\/.*$/;
				var isValid = true;
				if (facebookUrl !== "" && !facebookRegex.test(facebookUrl)) { alert("請輸入有效的Facebook網址"); isValid = false; }
				if (youtubeUrl !== "" && !youtubeRegex.test(youtubeUrl)) { alert("請輸入有效的YouTube網址"); isValid = false; }
				if (!isValid) { event.preventDefault(); }
				var avatar = $("#avatar-upload").val();
				if (avatar == null) {
					$('#urlForm').submit();
				}

			});
		function updateCount() {
			var cs = $(this).val().length;
			if (this.id == "input-intro") {
				$('#text-intro').text(`${cs}/200`);
			}
			else if (this.id == "input-nickname") {
				$('#text-nickname').text(`${cs}/16`);
			}
		}

		$("#user-avatar").on('click', () => {
			console.log("123");
			document.getElementById("avatar-upload").click();
		});
		//$('button[form="urlForm"]').on('click', function () {  });



		//函式綁定事件
		$('textarea').keydown(updateCount);
		$('textarea').keyup(updateCount);
		$('textarea').on('paste', updateCount);
		$('input').keydown(updateCount);
		$('input').keyup(updateCount);
		$('input').on('paste', updateCount);

		$("#close-instagram").on('click', () => {
			document.getElementById("instagram-edit").click();
		})
		$("#close-facebook").on('click', () => {
			document.getElementById("facebook-edit").click();
		})
		$("#close-youtube").on('click', () => {
			document.getElementById("youtube-edit").click();
		})
		$("#close-create").on('click', () => {
			document.getElementById("create-edit").click();
		})




	});




