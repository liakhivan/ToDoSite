$(document).ready(function () {
    $(document).on("click", "#checkAll", function (e) {
        let statusColl = $('.completeCheck');

        let countActive = 0;

        for (let i = 0; i < statusColl.length; i++) {
            if (!statusColl[i].checked) {
                countActive++;
            }
        }

        $.ajax({
            type: "POST",
            url: "Task/ChangeAllStatuses",
            data: {
                status: ((countActive !== 0) ? true : false)
            },
            success: function () {
                let newStatus = ((countActive !== 0) ? true : false);

                for (let i = 0; i < statusColl.length; i++) {
                    if (statusColl[i].checked === newStatus)
                        continue;

                    statusColl[i].checked = newStatus;
                    if (statusColl[i].checked) {
                        statusColl[i].parentNode.parentNode.querySelector('.taskName').className += ' checked';
                    } else {
                        statusColl[i].parentNode.parentNode.querySelector('.taskName').className = statusColl[i].parentNode.parentNode.querySelector('.taskName').className.split(' ')[0];
                    }
                }
            }
        });
    });
});