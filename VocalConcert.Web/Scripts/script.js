var lock = false;
var page = 0;


///加载歌友会
function LoadConcerts() {
    if (lock) {
        return;
    }
    else {
        lock = true;
        $.post("/Concert/GetConcerts", { "page": page }).done(function (data) {
            var str = "";
            for (var i = 0; i < data.length; i++) {
                str += "<div><span><a href='/Concert/Show/" + data[i].ID + "'>" + data[i].Title + "</a></span></div>";
            }
            $(".concertLst").append(str);

            if (data.length == 10) {
                lock = false;
                page++;
            }
        });
    }
}

//加载同城活动
function LoadActions() {
    if (lock) {
        return;
    }
    else {
        $.post("/Action/GetActions", { "page": page }).done(function (data) {
            var str = "";
            for (var i = 0; i < data.length; i++) {
                str += "<div><span><a href='/Action/Show/" + data[i].ID + "'>" + data[i].Title + "</a></span></div>";
            }
            $(".actionLst").append(str);

            if (data.length == 10) {
                lock = false;
                page++;
            }
        });
    }
}

//加载歌曲
function LoadMusics() {
    if (lock) {
        return;
    }
    else {
        $.post("/Music/GetMusics", { "page": page }).done(function (data) {
            var str = "";
            for (var i = 0; i < data.length; i++) {
                str += "<div><span><a href='/Music/Show/" + data[i].ID + "'>" + data[i].Title + "</a></span></div>";
            }
            $(".musicLst").append(str);

            if (data.length == 10) {
                lock = false;
                page++;
            }
        });
    }
}


function Load() {

    if ($(".concertLst").length > 0) {
        LoadConcerts();
    }
    if ($(".actionLst").length > 0) {
        LoadActions();
    }

    if ($(".musicLst").length > 0) {
        LoadMusics();
    }
}

$(document).ready(function () {

    $('#begin').datetimepicker({
        format: 'yyyy-mm-dd hh:ii',
        weekStart: 1,
        autoclose: true,
        todayBtn: 'linked',
        language: 'zh-CN'
    });
    $('#end').datetimepicker({
        format: 'yyyy-mm-dd hh:ii',
        weekStart: 1,
        autoclose: true,
        todayBtn: 'linked',
        language: 'zh-CN'
    });

    Load();
    $(window).scroll(
     function () {
         totalheight = parseFloat($(window).height())
            + parseFloat($(window).scrollTop());
         if ($(document).height() <= totalheight) {
             Load();
         }
     });


    $("#btnSubReplyMusic").click(function () {
        var content = $("#comment_content").val();
        var mid = $("#mid").val();
        $.post("/Comment/Add", { "content": content, "mid": mid }).done(function (data) {
            if (data == "nouser") {
                alert("请先登录，在进行评论！");
            }
            else if (data == "ok") {
                alert("评论成功！");
                location.reload();
            }
            else {
                alert("评论失败！");
                //location.reload();
            }
        })
    });

});