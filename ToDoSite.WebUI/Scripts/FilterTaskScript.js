'use strict';


function addEventsOnFilters(statusMas) {
    const filters = document.getElementById('filters');

    for (let i = 0; i < 3; i++) {
        const itemFilter = document.createElement('li');

        const itemFilterLink = document.createElement('a');
        itemFilterLink.id = statusMas[i];
        itemFilterLink.href = '/Task/Index/' + statusMas[i];
        itemFilterLink.textContent = (statusMas[i]);

        itemFilter.appendChild(itemFilterLink);
        filters.appendChild(itemFilter);
    }
}

function markCurrentFilter(statusTaskMass) {
   
    let url = $(location).attr('href');

    let segmentsUrlMass = url.split('/');

    let isFilter = statusTaskMass.includes(segmentsUrlMass[segmentsUrlMass.length - 1]);

    if (isFilter) {
        document.getElementById(segmentsUrlMass[segmentsUrlMass.length - 1]).className += 'checked';
    } else {
        document.getElementById(statusTaskMass[0]).className = 'checked';
    }
  
}

const statusTaskMass = [ 'All', 'Active', 'Completed'];
addEventsOnFilters(statusTaskMass);
markCurrentFilter(statusTaskMass);
