'use strict';

angular.
  module('personList').
  component('personList', {
    templateUrl: 'person-list/person-list.template.html',
    controller: ['Person',
      function PersonListController(Person) {
        this.people = Person.query();
      }
    ]
  });
