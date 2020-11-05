$(document).ready(function () {
    $(document).on("click", "#checkAll", function (e) {
        $.ajax({
            type: "POST", url: "Task/ChangeAllStatuses"
        });
    });


});