$(document).ready(function () {
    // Counter animation
    $('.counter').each(function () {
        $(this).prop('Counter', 0).animate({
            Counter: $(this).data('target')
        }, {
            duration: 2000,
            easing: 'swing',
            step: function (now) {
                // Fix: added missing closing parenthesis for toLocaleString
                $(this).text(Math.ceil(now).toLocaleString('fa-IR'));
            }
        });
    });

    // Smooth scrolling for anchor links
    $('a[href*="#"]').on('click', function (e) {
        e.preventDefault();

        var target = $(this).attr('href');
        var $targetEl = $(target);
        if ($targetEl.length) {
            $('html, body').animate(
                {
                    scrollTop: $targetEl.offset().top - 70
                },
                500,
                'linear'
            );
        }
    });

    // Change navbar style on scroll
    $(window).on('scroll', function () {
        if ($(this).scrollTop() > 100) {
            $('.navbar').addClass('navbar-scrolled');
        } else {
            $('.navbar').removeClass('navbar-scrolled');
        }
    });
});


$(function () {
    var $win = $(window);
    var $elem = $('#myElement');    // the element to fade in
    var loaded = false;              // ensure fadeIn only runs once

    // Hide element initially
    $elem.hide();

    function checkAndFadeIn() {
        if (loaded) return;

        var scrollTop = $win.scrollTop();
        var windowHeight = $win.height();
        var elemTop = $elem.offset().top;
        var elemBottom = elemTop + $elem.outerHeight();

        // If element enters viewport
        if (elemTop < scrollTop + windowHeight && elemBottom > scrollTop) {
            loaded = true;
            $elem.fadeIn(600);
        }
    }

    // Run on load & on scroll
    $win.on('scroll', checkAndFadeIn);
    checkAndFadeIn();
});
