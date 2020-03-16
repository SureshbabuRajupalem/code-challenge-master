'use strict';

angular.
  module('personUpdate').
  component('personUpdate', {
    templateUrl: 'person-update/person-update.template.html',
    controller: ['$routeParams', '$location', 'Person',
      function PersonUpdateController($routeParams, $location, Person) {
        var self = this;
        self.person = Person.get({ personId: $routeParams.personId });
        self.edit = {
          "name": self.person.name,
          "height": self.person.height,
          "mass": self.person.mass,
          "hair_color": self.person.hair_color,
          "skin_color": self.person.skin_color,
          "eye_color": self.person.eye_color,
          "birth_year": self.person.birth_year,
          "gender": self.person.gender
        };
        self.submit = function () {
          Person.set($routeParams.personId, self.edit);
          $location.path('/');
        };
      }
    ]
  });
