/// <reference path="../common-services/project.service.js" />


(function(module) {
    function DoffingHomeCtrl(doffingProjectService) {
        var self = this;

        function init() {
            //get projects
            doffingProjectService.getAllProjects()
                .then(function(projects) {
                    self.projects = projects;
                });
        }

        init();
    }

    DoffingHomeCtrl.$inject = ['doffingProjectService'];

    module.controller('doffingHomeCtrl', DoffingHomeCtrl);
})(angular.module('doffing-home'));