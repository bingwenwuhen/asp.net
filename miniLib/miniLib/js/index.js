(function($) {
    var initHome = function() {
        $.ajax({
                    url : 'services/rec/portal/conf/ad/list?adTypes=01&adTypes=08&adTypes=09&adTypes=10',
                    type : 'GET',
                    success : function(data) {
                        if (!data || !data.length) {
                            return;
                        }
                        var dataMap = {};
                        for (var i = 0; i < data.length; i++) {
                            var tmp = data[i];
                            if (!dataMap[tmp.adType]) {
                                dataMap[tmp.adType] = tmp;
                            }
                        }
                        if (dataMap['01']) {
                            $(document.body).append($('<div class="bgZone">').attr('data-page', 'home').append($('<img>').attr('src', getImgUrl(dataMap['01'].pictureAtttachId))));
                        }
                        if (dataMap['08']) {
                            $(document.body).append($('<div class="bgZone">').attr('data-page', 'home_campus').append($('<img>').attr('src', getImgUrl(dataMap['08'].pictureAtttachId))));
                        }
                        if (dataMap['09']) {
                            $(document.body).append($('<div class="bgZone">').attr('data-page', 'home_social').append($('<img>').attr('src', getImgUrl(dataMap['09'].pictureAtttachId))));
                        }
                        if (dataMap['10']) {
                            $(document.body).append($('<div class="bgZone">').attr('data-page', 'home_resume').append($('<img>').attr('src', getImgUrl(dataMap['10'].pictureAtttachId))));
                        }
                        $(".bgZone").hide().filter('[data-page="home"]').show();
                        $(".bgZone>img").fullBg();
                    }
                });
        $(".bannerMenu a").mouseover(function() {
                    var target = $(this);
                    var page = target.attr('id');
                    $(".bgZone").hide().filter('[data-page="' + page + '"]').show();
                });
        $(".bannerMenu a").mouseout(function() {
                    $(".bgZone").hide().filter('[data-page="home"]').show();
                });
    };
    $(initHome);
}(jQuery));