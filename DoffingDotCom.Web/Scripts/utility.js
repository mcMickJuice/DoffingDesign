var ns = ns || {};

(function (namespace) {

    function isValidEmail(text) {
        var result = /^[\w\.]+@[\w].+$/.test(text);

        return result;
    }

    namespace.isValidEmail = isValidEmail;
})(ns);
