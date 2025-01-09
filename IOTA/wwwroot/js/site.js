// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).foundation();
$(document).ready(function () {
    $('.img-slider').slick({
        // prevArrows: ,
        // nextArrows: ,
        dots: true,
        mobileFirst: true,
        adaptiveHeight: true,
        speed: 500,
        fade: true,
        cssEase: 'linear',
        autoplay: true,
        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                    dots: true,
                },
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    respondTo: 'slider',
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    respondTo: 'slider',
                },
            },
        ],
    });
});