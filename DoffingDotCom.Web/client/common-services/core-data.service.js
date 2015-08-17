/// <reference path="M:\My Documents\Development\DoffingDesign\DoffingDotCom.Web\Scripts/angular.js" />

(function () {
    function CoreDataService($http, API) {

        function buildUrl(endpoint) {
            return API + endpoint;
        }


        //get
        function get(endpoint, queryParams) {
            return $http({
                method: 'GET',
                url: buildUrl(endpoint),
                params: queryParams
            });
        }

        //put
        function put(endpoint, data) {
            return $http({
                method: 'PUT',
                url: buildUrl(endpoint),
                data: data
            });
        }

        //post
        function post(endpoint, data) {
            return $http({
                method: 'POST',
                url: buildUrl(endpoint),
                data: data
            });
        }

        return {
            get: get,
            put: put,
            post: post
        }
    }

    CoreDataService.$inject = ['$http', 'API'];


    angular.module('doffing-common-service')
        .factory('doffingCoreDataService', CoreDataService);
})();



