
(function () {
    function DoffingProjectService(doffingCoreDataService) {
        var endpoint = 'projects';
        var _projects = [];

        //getAllProjects
        function getAllProjects() {
            return doffingCoreDataService.get(endpoint)
                .then(function(response) {
                    return response.data;
                });
        }

        function getProject(id) {
            return doffingCoreDataService.get(endpoint, { id: id })
                .then(function (response) {
                    return response.data;
                });
        }

        function createProject(projectInfo) {
            return doffingCoreDataService.post(endpoint, projectInfo)
                .then(function(response) {
                    return response.data; //should be projectId returned
                });
        }
        
        function updateProject(project) {
            
        }

        function deleteProject(id) {
            
        }

        return {
            getAllProjects: getAllProjects,
            getProject: getProject,
            createProject: createProject,
            updateProject: updateProject,
            deleteProject: deleteProject,
        }
    }

    DoffingProjectService.$inject = ['doffingCoreDataService'];
    angular.module('doffing-common-service')
          .factory('doffingProjectService', DoffingProjectService);
})();