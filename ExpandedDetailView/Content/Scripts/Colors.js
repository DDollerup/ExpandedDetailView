$(document).ready(function () {





    window.setInterval(function () {
        var colorCode = "";

        for (i = 0; i < 6; i++) {
            var rnd = Math.round((Math.random() * 6));

            colorCode += rnd;
        }

        var multiply = 1;



        $("header").animate(
        {

            "background-color": "#" + colorCode

        }, 5000)

        $("#contentWrapper").animate(
    {

        "background-color": "#" + colorCode / 2

    }, 5000)

        $(" nav").animate(
    {

        "background-color": "#" + colorCode * 2

    }, 5000)

        $("footer").animate(
    {

        "background-color": "#" + colorCode / 4

    }, 3000)



    })

})