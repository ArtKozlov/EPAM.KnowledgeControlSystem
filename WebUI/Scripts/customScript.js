function deleteQuestion() {
    $("#results>div:nth-child(1)").detach();
}


function startTime(time) {
    if (time === 0)
        document.forms["finishForm"].submit();
    else {
    var s = checkTime(time%60);
    var m = Math.floor(time / 60);
    document.getElementById("countdown").innerHTML = m + ":" + s;

    setTimeout(function () { startTime(time-1) }, 1000);
    }
}

function checkTime(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}

var time = document.getElementById("time").innerHTML;
if (time != undefined) {
    time = time * 60;
    window.onload = startTime(time);
}