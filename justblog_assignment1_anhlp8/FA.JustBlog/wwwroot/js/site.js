$(document).ready(function () {
    $("#addCommentForm").submit(function (event) {
        var data2 = JSON.stringify({
            PostId: $("#PostId").val(),
            CommentHeader: $("#CommentHeader").val(),
            CommentText: $("#CommentText").val(),
        });
        $.ajax({
            type: "POST",
            url: "/Post/AddComment",
            data: data2,
            contentType: "application/json",
            encode: true,
        }).done(function (data) {
            console.log(data);
            if (data) {
                var comment = data;
                var formatedTime = getFormatedTime(comment.commandTime);
                var elem = '<div class="d-flex">' +
                    '<div class="ms-3">' +
                    '<div class="fw-bold">' + comment.name + ' at ' + formatedTime + '</div>' +
                    comment.commentText +
                    '</div>' +
                    '</div>';
                $("#commentContainer").prepend(elem);
                $("#CommentHeader").val('');
                $("#CommentText").val('');
            }
            else {
                console.log("none data");
            }
        });

        event.preventDefault();
    })
});

function getFormatedTime(time) {
    var datetime = new Date(time);
    var day = datetime.getDate();
    var month = datetime.getMonth();
    var year = datetime.getFullYear();
    var hour = datetime.getHours();
    var minute = datetime.getMinutes();
    var second = datetime.getSeconds();
    return getMoment(day, month, year, hour, minute, second);
}

function getMoment(day, month, year, hour, minute, second) {
    var now = new Date();
    if (year == now.getFullYear() && month == now.getMonth()) {
        var diffDay = now.getDate() - day;
        if (diffDay == 0) {
            var diffHour = now.getHours() - hour;
            if (diffHour == 0) {
                var diffMinute = now.getMinutes() - minute;
                if (diffMinute == 0) {
                    var diffSecond = now.getSeconds() - second;
                    if (diffSecond == 0)
                        return 'now';
                    return `${diffSecond} seconds ago`
                }
                return `${diffMinute} minutes ago`;
            }
            return `${diffHour} hours ago`;
        }
        if (diffDay == 1) {
            return `Yesterday ${hour > 12 ? hour - 12 : hour}:${minute}:${second} ${(hour >= 12) ? "PM" : "AM"}`;
        }
    }
    return `${day}/${month}/${year} ${hour > 12 ? hour - 12 : hour}:${minute}:${second} ${(hour >= 12) ? "PM" : "AM"}`;
}

$(document).ready(function () {
    $(".moment-time").each(function (i, elem) {
        var time = $(elem).html();
        var moment = getFormatedTime(time);
        $(elem).html(moment);
    });
});