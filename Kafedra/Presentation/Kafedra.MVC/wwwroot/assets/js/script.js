// window.onscroll = () => {
//   if (
//     document.body.scrollTop > 80 ||
//     document.documentElement.scrollTop > 120
//   ) {
//     //asagida
//     document.getElementById("header").style.backgroundColor = "rgb(14, 32, 91)";
//     document.getElementById("header").style.boxShadow =
//       "0px 0px 10px 0px rgb(0, 0, 0)";
//     document.getElementById("header").style.transition = "all .25s";
//     // document.getElementById("aztulogo").src = "./img/ktk-little-logo.png";
//     // document.getElementById("aztulogo").style.width = "5.5rem";

//     var signout = document.getElementById("signout");
//     if (signout != null) {
//       signout.style.fontSize = "14px";
//       document.getElementById("username").style.fontSize = "14px";
//       document.getElementById("usersurname").style.fontSize = "14px";
//     } else {
//       document.getElementById("login").classList.remove("login-top");
//       document.getElementById("login").classList.add("login-bot");
//       document.getElementById('login').style.display='none'
//       document.getElementById('login-logo').style.fontSize='2rem'


//     }
//   } else {
//     //yuxarida
//     document.getElementById("header").style.backgroundColor = "transparent";
//     document.getElementById("header").style.boxShadow = "none";
//     // document.getElementById("aztulogo").src = "./img/ktk-big-logo.png";
//     // document.getElementById("aztulogo").style.width = "8rem";

//     var signout = document.getElementById("signout");
//     if (signout != null) {
//       document.getElementById("username").style.fontSize = "12px";
//       document.getElementById("usersurname").style.fontSize = "12px";
//       document.getElementById("signout").style.fontSize = "12px";
//     } else {
//       document.getElementById("login").classList.add("login-top");
//       document.getElementById("login").classList.remove("login-bot");
//       document.getElementById('login').style.display='block'
//       document.getElementById('login-logo').style.fontSize='1.5rem'
//     }
//   }
// };


$(document).ready(function () {
    $(".owl-carousel").owlCarousel({
        items: 4,
        loop: true,
        autoplay: true,
        autoplayTimeout: 7000,
        autoplayHoverPause: false,
        responsive: {
            1000: {
                items: 3
            },

            700: {
                items: 2
            },
            400: {
                items: 1
            },
            0: {
                items: 1
            }
        },
    });

});
