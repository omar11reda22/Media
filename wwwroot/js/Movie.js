window.addEventListener('load', function () {
    // wanna to catching or select any change happen on select lest to catch value selected

    var selected = this.document.querySelectorAll('select')[1];
    var showing = this.document.getElementById("selectedGenres");
    selected.addEventListener('change', function () {
       // showing.innerHTML = "";
        console.log(this.selectedOptions);
        let selectedOptions = [...selected.selectedOptions].map(o => o.text);
        selectedOptions.forEach(s => {
            let badge = document.createElement("span");
            badge.classList.add("badge", "bg-primary", "m-1", "p-2");
            badge.textContent = s;
            showing.appendChild(badge);
            badge.addEventListener('click', function () {
                showing.removeChild(this);
            }); // end of event
        });
       // console.log(event.name);
    }); // end of event



}); // end of load