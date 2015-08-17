(function(angular) {
    function ProjectCreateCtrl($state,doffingProjectService, formValuesStore) {
        var self = this,
            defaultProject = {};

        self.templates = formValuesStore.getAvailableTemplates();
        self.projectTypes = formValuesStore.getProjectTypes();
        self.project = {} //put default project values in here
        

        self.createProject = function() {
            doffingProjectService.createProject(self.project)
                .then(function(id) {
                    //navigate to edit screen with project info item selected???
                    //notification that project was created?
                    $state.go('edit', { id: id });
                });
        }

        self.clearFields = function() {
            self.project = defaultProject;
        }

        self.isDirty = function() {
            //use $scope.watch?
        }
    }

    ProjectCreateCtrl.$inject = ['$state', 'doffingProjectService', 'formValuesStore'];

    angular.module('doffing-project')
        .controller('projectCreateCtrl', ProjectCreateCtrl);
})(angular)