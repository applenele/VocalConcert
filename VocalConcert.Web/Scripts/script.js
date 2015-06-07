var lock = false;
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
                str += "<tr><td><img src='/Common/ShowGroupIcon/" + data[i].ID + "' width='100' height='100'  style='border-radius :50%;'  /></td><td><span><a href='/Concert/Show/" + data[i].ID + "'>" + data[i].Title + "</a> <br /> 人数："+data[i].Count+" @<a href='/User/" + data[i].UserID + "'>" + data[i].Username + "</a></span></td></tr>";
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
                str += "<div><h2 style='margin:0;'><a href='/Action/Show/" + data[i].ID + "'>" + data[i].Title + "</a></h2> <small>开始时间:"+data[i].Begin+"  结束时间:"+data[i].End+"</small><br/><div style='color: #eee;font-size:18px;margin-top:10px;'>"+data[i].Description+"</div></div>";
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
                str += "<tr><td><a href='/Music/Show/"+data[i].ID+"'>" + data[i].Title + "</a></td><td>" + data[i].MusicType + "</td><td>" + data[i].Username + "</td><td>" + data[i].Time + "</td><td>" + data[i].Score + "</td></tr>"
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
                    st = "<span style='background:green;color:#fff;padding:5px 10px;'>即将进行</span>"
                }
                if (data[i].StatusAsInt == 1) {
                    st = "<span style='background:red;color:#fff;padding:5px 10px;'>正在进行</span>"
                }
                if (data[i].StatusAsInt == 2) {
                    st = "<span style='background:blue;color:#fff;padding:5px 10px;'>已经结束</span>"
                }
                str += "<tr style='margin-top:10px'><td><img src='/Common/Icon/" + data[i].ID + "' style='width:180px;heigth:100px;' /></td><td><a href='/Product/Show/" + data[i].ID + "'>" + data[i].Title + "</a></span><span>@<a href='/User/" + data[i].UserID + "'>" + data[i].Username + "</a></span><br />" + st + "<span>活动时间：" + data[i].Begin + "-" + data[i].End + "</td></tr>";
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