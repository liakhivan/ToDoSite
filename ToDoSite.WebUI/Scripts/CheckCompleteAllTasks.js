$(document).ready(function () {
    $(document).on("click", "#checkAll", function (e) {
        let statusColl = document.getElementsByClassName('completeCheck');

        let countActive = 0;

        for (let i = 0; i < statusColl.length; i++) {
            if (!statusColl[i].checked) {
                countActive++;
            }
        }

        $.ajax({
            type: "POST", url: "Task/ChangeAllStatuses", data: { status: ((countActive !== 0) ? true : false) }
        });
    });
});