/// <reference path="../common-services/project.service.js" />


(function(mod) {
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

    mod.controller('doffingHomeCtrl', DoffingHomeCtrl);
})(angular.module('doffing-home'));