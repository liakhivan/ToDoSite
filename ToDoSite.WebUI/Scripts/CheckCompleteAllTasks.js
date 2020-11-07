$(document).ready(function () {
    $(document).on("click", "#checkAll", function (e) {
        let statusColl = $('.completeCheck');

        let countActive = 0;

        for (let i = 0; i < statusColl.length; i++) {
            if (!statusColl[i].checked) {
                countActive++;
            }
        }

        //TODO: Write code for change all status tasks on front. But REMEMBER ABOUT onchange for change status one task.

        $.ajax({
            type: "POST", url: "Task/ChangeAllStatuses", data: { status: ((countActive !== 0) ? true : false) }
        });
    });
});