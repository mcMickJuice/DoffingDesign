/// <reference path="M:\My Documents\Development\DoffingDesign\DoffingDotCom.Web\Scripts/angular.js" />



(function (mod) {
    function DoffingHomeComponent() {
        return {
            templateUrl: 'client/home/home.tmpl.html',
            replace: true,
            controller: 'doffingHomeCtrl',
            controllerAs: 'vm',
            scope: {}
        }
    }


    mod.directive('doffingHome', DoffingHomeComponent);
})(angular.module('doffing-home'))