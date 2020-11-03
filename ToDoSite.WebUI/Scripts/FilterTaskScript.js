'use strict';


function addEventsOnFilters() {
    let filters = document.getElementById("filters");

    for (let i = 1; i < filters.childElementCount; i += 2) {
        let childElement = filters.childNodes[i].lastChild;
        childElement.addEventListener("click", (e) => {
            let filters = document.getElementById("filters");

            for (let i = 0; i < filters.childElementCount; i++) {
                filters.childNodes[i].firstChild().className = "";
            }

            e.target.className = "checked";
        });
    }
}



addEventsOnFilters();
