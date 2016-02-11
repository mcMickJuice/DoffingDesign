(function () {
    $(function () {
        var $linksIcon = $('.navigation'),
            $siteLinks = $('.site-links');

        $linksIcon.click(function () {
            $siteLinks.toggle();
        });
    });


})()