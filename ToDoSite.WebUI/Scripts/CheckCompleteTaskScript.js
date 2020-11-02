$(document).ready(function () {
    $(document).on("click", ".completeCheck", function (e) {
        $.ajax({
            type: "POST", url: "Task/ChangeStatus", data: { id: e.target.id }
        });
    });
});