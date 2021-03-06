/**
 * jQuery.fullBg Version 1.0 Copyright (c) 2010 c.bavota - http://bavotasan.com
 * Dual licensed under MIT and GPL. Date: 02/23/2010
 */
(function($) {
    $.fn.fullBg = function() {
        var bgImg = $(this);

        bgImg.addClass('fullBg');
        function resizeImg() {
            var imgwidth = 1680;
            var imgheight = 983;
            var winwidth = $(window).width();
            var winheight = $(window).height();
            if (winwidth < 970) {
                winwidth = 970;
            };

            var widthratio = winwidth / imgwidth;
            var heightratio = winheight / imgheight;

            var widthdiff = heightratio * imgwidth;
            var heightdiff = widthratio * imgheight;

            if (heightdiff > winheight) {
                bgImg.css({
                            width : winwidth + 'px',
                            height : heightdiff + 'px'
                        });
            } else {
                bgImg.css({
                            width : widthdiff + 'px',
                            height : winheight + 'px'
                        });
            }
        }
        resizeImg();
        $(window).resize(function() {
                    resizeImg();
                });
    };
})(jQuery);