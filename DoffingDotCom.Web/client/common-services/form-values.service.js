///This service is initialized at the start of the app booting up. 
//Values are cached and include project templates, project types and other stuff

(function (angular) {
    function FormValuesStore($q, doffingCoreDataService) {
        var _templates = [],
            _projectTypes = [],
            _readyPromise; //promise that's resolved when initValue is run


        function initValueStore() {
            _readyPromise = $q.defer();
            doffingCoreDataService.get('projectValues')
                .then(function (response) {
                    var data = response.data;
                    _templates = data.templates;
                    _projectTypes = data.projectTypes;

                    _readyPromise.resolve();
                })
            .catch(function (reason) {
                _readyPromise.reject(reason);

            });

            return _readyPromise;
        }


        function getAvailableTemplates() {
            return _templates;
        }

        function getProjectTypes() {
            return _projectTypes;
        }



        return {
            initValueStore: initValueStore,
            getAvailableTemplates: getAvailableTemplates,
            getProjectTypes: getProjectTypes
        }
    }

    FormValuesStore.$inject = ['$q', 'doffingCoreDataService'];

    angular.module('doffing-common-service')
        .factory('formValuesStore', FormValuesStore);
})(angular)