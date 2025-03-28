window.addEventListener('load', function () {
    // wanna to catching or select any change happen on select lest to catch value selected

    var selected = this.document.querySelectorAll('select')[1];

    selected.addEventListener('change', function (event) {
        console.log(event.target.value);
       // console.log(event.name);
    }); // end of event



}); // end of load