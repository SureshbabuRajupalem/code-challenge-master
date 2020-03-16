'use strict';

angular.
  module('app').
  config(['$routeProvider',
    function config($routeProvider) {
      $routeProvider.
        when('/people', {
          template: '<person-list></person-list>'
        }).
        when('/people/:personId', {
          template: '<person-detail></person-detail>'
        }).
        when('/people/:personId/edit', {
          template: '<person-update></person-update>'
        }).
        otherwise('/people');
    }
  ]);
