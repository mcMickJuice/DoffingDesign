/// <reference path="M:\My Documents\Development\DoffingDesign\DoffingDotCom.Web\Scripts/angular.js" />



(function (module) {
    function DoffingHomeComponent() {
        return {
            templateUrl: 'client/home/home.tmpl.html',
            replace: true,
            controller: 'doffingHomeCtrl',
            controllerAs: 'vm',
            scope: {}
        }
    }


    module.directive('doffingHome', DoffingHomeComponent);
})(angular.module('doffing-home'))