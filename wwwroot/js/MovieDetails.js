// asp-action="Edit" asp-route-id="@item.MediaId"

window.addEventListener('load', function () {
    var ttr = this.document.querySelectorAll("tr");
    ttr.forEach(s => {
        s.addEventListener('click', function (event) {
            // event.target.asp - action="Details";
            var idd = this.getAttribute("data-media-id");
            if (idd) {
                window.location.href = `Details/${idd}`;
            }

            //this.setAttribute("asp-action", "Details");
            //this.setAttribute("asp-route-id", "@item.MediaId"); 


        }); // end of event 
    });
    

}); // end of load 