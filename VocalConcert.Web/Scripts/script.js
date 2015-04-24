var lock = false;
var page = 0;



function LoadConcerts() {
    if (lock) {
        return;
    }
    else {
        lock=true;
        $.post("/Concert/GetConcerts", { "page": page }).done(function (data) {
            var str = "";
            for(var i=0;i<data.length;i++){
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

function Load() {

    if ($(".concertLst").length>0) {
        LoadConcerts();
    }
}

$(document).ready(function () {
    Load();
    $(window).scroll(
     function () {
         totalheight = parseFloat($(window).height())
            + parseFloat($(window).scrollTop());
         if ($(document).height() <= totalheight) {
             Load();
         }
     });


});