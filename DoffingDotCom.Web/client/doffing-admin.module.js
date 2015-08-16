/// <reference path="M:\My Documents\Development\DoffingDesign\DoffingDotCom.Web\Scripts/angular.js" />
/// <reference path="M:\My Documents\Development\DoffingDesign\DoffingDotCom.Web\Scripts/angular-ui-router.js" />


angular.module('doffing-admin-module', ['ui.router'])
    .controller('mainCtrl', function ($scope) {
        $scope.title = 'This is a sanity check';
    })
    .config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state('home', {
                //list existing projects
            })
            .state('edit', {
                //edit specific project
            })
            .state('edit.delete', {
                //delete specific project (this is available from edit screen)
            })
            .state('create', {
                //create project
            });
    })