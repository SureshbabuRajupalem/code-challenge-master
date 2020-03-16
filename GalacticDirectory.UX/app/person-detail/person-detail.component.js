'use strict';

angular.
  module('personDetail').
  component('personDetail', {
    templateUrl: 'person-detail/person-detail.template.html',
    controller: ['$routeParams', 'Person',
      function PersonDetailController($routeParams, Person) {
        var self = this;
        self.person = Person.get({personId: $routeParams.personId});
      }
    ]
  });
