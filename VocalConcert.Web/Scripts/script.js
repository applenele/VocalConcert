﻿var lock = false;
var page = 0;
var city = "";

///加载歌友会
function LoadConcerts() {
    if (lock) {
        return;
    }
    else {
        lock = true;
        $.post("/Concert/GetConcerts", { "page": page,"city":city }).done(function (data) {
            var str = "";
            for (var i = 0; i < data.length; i++) {
                str += "<div><span><a href='/Concert/Show/" + data[i].ID + "'>" + data[i].Title + "</a> @<a href='/User/" + data[i].UserID + "'>" + data[i].Username + "</a> "+data[i].Time+"</span></div>";
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
        lock = true;
        $.post("/Action/GetActions", { "page": page,"city":city }).done(function (data) {
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
        lock = true;
        $.post("/Music/GetMusics", { "page": page }).done(function (data) {
            var str = "";
            for (var i = 0; i < data.length; i++) {
                str += "<div><span><a href='/Music/Show/" + data[i].ID + "'>" + data[i].Title + "</a></span>  <span>分数：" + data[i].Score + "</span>  <span>@<a href='/User/" + data[i].UserID + "'>" + data[i].Username + "</a></span><span>" + data[i].Time + "</span></div>";
            }
            $(".musicLst").append(str);

            if (data.length == 10) {
                lock = false;
                page++;
            }
        });
    }
}


//加载优惠产品
function LoadProducts() {
    if (lock) {
        return;
    }
    else {
        lock = true;
        $.post("/Product/GetProducts", { "page": page,"city":city }).done(function (data) {
            var str = "";
            var st = "";
            for (var i = 0; i < data.length; i++) {
                if (data[i].StatusAsInt == 0) {
                    st = "<span style='background:green'>即将进行</span>"
                }
                if (data[i].StatusAsInt == 1) {
                    st = "<span style='background:red'>正在进行</span>"
                }
                if (data[i].StatusAsInt == 2) {
                    st = "<span style='background:blue'>已经结束</span>"
                }
                str += "<div style='margin-top:10px'><div style='float:left'><img src='/Common/Icon/" + data[i].ID + "' style='width:60px;heigth:60px;' /></div><div style='float:left;margin-left:10px;'><a href='/Product/Show/" + data[i].ID + "'>" + data[i].Title + "</a></span><span>@<a href='/User/" + data[i].UserID + "'>" + data[i].Username + "</a></span><br />" + st + "<span>活动时间：" + data[i].Begin + "-" + data[i].End + "</div></div>";
                str += "<div class='clr'></div>";
            }
            $(".productLst").append(str);

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

    if ($(".productLst").length > 0) {
        LoadProducts();
    }
}

$(document).ready(function () {

    city = $("#localCity").text();

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
        var score = $("#score").val();
        var mid = $("#mid").val();
        $.post("/Comment/Add", { "content": content, "mid": mid, "score": score }).done(function (data) {
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