/// <reference path="M:\My Documents\Development\DoffingDesign\DoffingDotCom.Web\Scripts/angular.js" />
/// <reference path="M:\My Documents\Development\DoffingDesign\DoffingDotCom.Web\Scripts/angular-ui-router.js" />


angular.module('doffing-admin-module', ['ui.router', 'app-components'])
    .run(function($rootScope) {
        $rootScope.$on('$stateChangeError', function(event, toState, toParams, fromState, fromParams) {
            console.error('An error occurred on state change');
            console.log('event', event);
            console.log('toState', toState);
            console.log('toParams', toParams);
            console.log('fromState', fromState);
            console.log('fromParams', fromParams);
        });
    })
    .config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state('init', {
                abstract: true,
                resolve: {
                    initValueStore: function (formValuesStore) {
                        return formValuesStore.initValueStore();
                    }
                },
                template: '<div ui-view></div>'
            })
            .state('home', {
                template: '<doffing-home></doffing-home>',
                url: '/',
                parent: 'init'
                
            })
            .state('edit', {
                template: '<div>Edit!</div>',
                url: '/edit/{id}',
                parent: 'init',
                resolve: {
                    init: function(initValueStore) { 
                        return initValueStore.promise;//ensure valueStore has resolved
                    }
                }
            })
            .state('edit.delete', {
                //delete specific project (this is available from edit screen)
            })
            .state('create', {
                template: '<doffing-create-project></doffing-create-project>',
                url: '/create',
                parent: 'init',
                resolve: {
                    init: function (initValueStore) { 
                        return initValueStore.promise;//ensure valueStore has resolved
                    }
                }
            });
    })