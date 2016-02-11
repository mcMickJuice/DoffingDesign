(function () {
    $(function () {
        var $linksIcon = $('.site-links-icon'),
            $siteLinks = $('.site-links');

        $linksIcon.click(function () {
            $siteLinks.toggleClass('hide-me');
        });
    });


})()