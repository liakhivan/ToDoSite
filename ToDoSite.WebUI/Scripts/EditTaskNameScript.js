'use strict';


function addEventsOnDoubleClick() {
    $(document).on('dblclick', '.itemTask', (e) => {
        e.target.parentNode.querySelector('.editTaskName').className += ' edited';
        e.target.parentNode.querySelector('.editTaskName').focus();
    });
}

function addEventsOnBlur() {
    $(document).on('blur', '.editTaskName', (e) => {
        e.target.className = e.target.className.split(' ')[0];
    });
}

function editTaskName() {
    $('.editTaskName').keypress(function (e) {
        if (e.which !== 13)
            return;

        $.ajax({
            type: "POST",
            url: "Task/ChangeTaskName",
            data: {
                id: e.target.parentNode.id,
                name: e.target.value
            },
            success: function () {
                e.target.parentNode.querySelector('.taskName').textContent = e.target.value;
                e.target.blur();
            }
        });
    });
}

addEventsOnDoubleClick();
addEventsOnBlur();
editTaskName();