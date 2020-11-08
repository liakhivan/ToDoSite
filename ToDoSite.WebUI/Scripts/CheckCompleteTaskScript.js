$(document).ready(function () {
    $(document).on("change", ".completeCheck", function (e) {
        $.ajax({
            type: "POST",
            url: "Task/ChangeStatus",
            data: {
                id: e.target.parentNode.parentNode.id
            },
            success: function () {
                if (e.target.checked) {
                    e.target.parentNode.parentNode.querySelector('.taskName').className += ' checked';
                } else {
                    e.target.parentNode.parentNode.querySelector('.taskName').className = e.target.parentNode.parentNode.querySelector('.taskName').className.split(' ')[0];
                }
            }
        });
    });

    let mass = $('.completeCheck');
    for (var i = 0; i < mass.length; i++) {
        if (!mass[i].checked)
            continue;

        mass[i].parentNode.parentNode.querySelector('.taskName').className += ' checked';
    }
});