window.addEventListener('load', function () {
    var animo = document.getElementById("animo");

    animo.addEventListener('click', function (event) {

        var id = this.getAttribute("data-model-id");
        // pass it to href

        window.location.href = `GetByid/${id}`; 


    }); // end of event 



}); // end of loading 