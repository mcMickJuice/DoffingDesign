(function(angular) {
    function ProjectCreateComponent() {
        return {
            templateUrl: 'client/project/create/project-create.tmpl.html',
            controller: 'projectCreateCtrl',
            controllerAs: 'vm',
            replace: true,
//            bindToController: true,
            scope: {
//                templates: '@',
//                projectTypes: '@'
            }
        }
    }

    angular.module('doffing-project')
        .directive('doffingCreateProject', ProjectCreateComponent);
})(angular)