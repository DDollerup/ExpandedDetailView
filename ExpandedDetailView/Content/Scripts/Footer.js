$(document).ready(function () {
    var x = 0;

    window.setInterval(function () {

        if (x == 0) {

            $("footer").animate({
                "padding-left": "94%"
            }, 5000)

            x = 1;
        }
        else {
            $("footer").animate({
                "padding-left": "0%"
            }, 5000)

            x = 0;
        }
    }, 5000);

    var newMoved = -10;

    window.setInterval(function () {


        if (newMoved >= 110) {

            newMoved = -10

            $("#right").css(
             {
                 "left": newMoved  + "%"
             })

            $("#left").css(
              {
                  "left": newMoved -120 + "%"
              })
        }

        else {
            $("#left").css(
               {
                   "left": newMoved - 120 + "%"
               })

            $("#right").css(
                {
                    "left": newMoved + "%"
                })

            newMoved += 0.1

        }
    }, 1)

})