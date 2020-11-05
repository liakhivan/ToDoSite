'use strict';


function addEventsOnFilters(statusMas) {
    const filters = document.getElementById('filters');

    for (let i = 0; i < 3; i++) {
        const itemFilter = document.createElement('li');

        const itemFilterLink = document.createElement('a');
        itemFilterLink.href = '/Task/Index/' + statusMas[i];
        itemFilterLink.textContent = (statusMas[i]);
        itemFilterLink.addEventListener('click', (e) => {
            e.target.className = 'checked';
        });

        itemFilter.appendChild(itemFilterLink);
        filters.appendChild(itemFilter);
    }
}


const statusTaskMass = [ 'All', 'Active', 'Completed'];
addEventsOnFilters(statusTaskMass);
