$(function () {
    // Declare a proxy to reference the hub.
    var chat = $.connection.chatServiceHub;
    // 接受信息
    chat.client.receiveMessage = function (message) {
        receiveMessage(message);
    };
    var hubStartDone = function () {
        $.connection.hub.start().done();
    };
    hubStartDone();

    $.connection.hub.disconnected(function () {
        setTimeout(function () {
            console.log("disconnected");
            hubStartDone();
        }, 50000); // Restart connection after 50 seconds.
    });

    // 左边列表
    $('.conLeft li').on('click', function () {
        $(this).addClass('bg').siblings().removeClass('bg');
        var intername = $(this).children('.liRight').children('.intername').text();
        $('.headName').text(intername);
        $('.newsList').html('');
    });

    //发送信息
    $('.sendBtn').on('click', function () {
        var news = $('#dope').val();
        if (news == '') {
            alert('不能为空');
        } else {
            chat.server.sendMessage(news);
            sendMessage(news);
            $('#dope').val('');
        }
    });

    function sendMessage(message) {
        var str = '';
        str += '<li>' +
                '<div class="nesHead"><img src="/Images/qq/1004.jpg"/></div>' +
                '<div class="news"><img class="jiao" src="/Images/qq/20170926103645_03_02.jpg">' + message + '</div>' +
            '</li>';
        $('.newsList').append(str);
        $('.conLeft').find('li.bg').children('.liRight').children('.infor').text(message);
        $('.RightCont').scrollTop($('.RightCont')[0].scrollHeight);
    }

    function receiveMessage(message) {
        var answer = '';
        answer += '<li>' +
					'<div class="answerHead"><img src="/Images/qq/1003.jpg"/></div>' +
					'<div class="answers"><img class="jiao" src="/Images/qq/jiao.jpg">' + message + '</div>' +
				'</li>';
        $('.newsList').append(answer);
        $('.RightCont').scrollTop($('.RightCont')[0].scrollHeight);
    }
});





