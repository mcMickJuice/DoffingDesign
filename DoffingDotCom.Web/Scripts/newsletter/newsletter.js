var ns = ns || {};

(function (namespace) {
    function isValidEmail(text) {
        var result = /^[\w\.]+@[\w].+$/.test(text);

        return result;
    }

    function initNewsletterForm(headerVal) {
        var $button = $('#subscribe'),
            $emailForm = $('#emailInput'),
            initialButtonText = $button.text(),
            buttonResetDuration = 3000;

        $button.click(function(evt) {
            evt.preventDefault();

            var inputText = $emailForm.val();

            var data = {
                email: inputText
            };

            if (isValidEmail(inputText) === false) {

                $button.text('Invalid Email');
                $button.addClass('invalid');

                resetButtonTimeout(function() {
                    $button.text(initialButtonText);
                    $button.removeClass('invalid');
                });

                return;
            }

            $button.text('Submitting...');

            $.ajax("/api/contact/newsletter", {
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(data),

                dataType: 'json',
                headers: {
                    RequestVerificationToken: headerVal
                },
                success: onSuccess,
                error: function() {
                    console.error('An error occurred subscribing to newsletter');
                }
            });
        });

        function onSuccess() {
            $button.text('Submitted!');
            $emailForm.val('');
            resetButtonTimeout(function() {
                $button.text(initialButtonText);
            });
        }

        function resetButtonTimeout(callback) {
            setTimeout(callback, buttonResetDuration);
        }

        //figure this out someday...
        //function countDownLetters(selectorFunc, setterFunc) {
        //    var timeToDelay = 30;
        //    var val = selectorFunc();
        //    while (val !== '') {
        //        var oldVal = val;
        //        val = oldVal.substring(0, oldVal.length - 1);
        //        setTimeout(function() {
        //            setterFunc(val);
        //        }, timeToDelay);
        //    }
        //}


    };


    namespace.initNewsletterForm = initNewsletterForm;
})(ns)