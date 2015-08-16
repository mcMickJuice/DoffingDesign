
(function (module) {
    function DoffingProjectService(doffingCoreDataService) {
        var endpoint = 'ProjectAdminApi';
        var _projects = [];

        //getAllProjects
        function getAllProjects() {
            return doffingCoreDataService.get(endpoint)
                .then(function(response) {
                    return response.data;
                });
        }
        
        function getProject(id) {
            
        }

        function updateProject(project) {
            
        }

        function deleteProject(id) {
            
        }

        return {
            getAllProjects: getAllProjects,
            getProject: getProject,
            updateProject: updateProject,
            deleteProject: deleteProject
        }
    }

    DoffingProjectService.$inject = ['doffingCoreDataService'];
    module.factory('doffingProjectService', DoffingProjectService);
})(angular.module('doffing-common-service'));