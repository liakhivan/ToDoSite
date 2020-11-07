$(document).ready(function () {
    $(document).on("change", ".completeCheck", function (e) {
        $.ajax({
            type: "POST", url: "Task/ChangeStatus", data: { id: e.target.parentNode.parentNode.id }
        });
    });
});