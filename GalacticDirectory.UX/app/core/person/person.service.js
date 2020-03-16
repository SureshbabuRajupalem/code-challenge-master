'use strict';

const testData = {
  "id": 1,
  "name": "Luke Skywalker",
  "height": "172",
  "mass": "77",
  "hair_color": "blond",
  "skin_color": "fair",
  "eye_color": "blue",
  "birth_year": "19BBY",
  "gender": "male"
};

angular.
  module('core.person').
  service('Person', [
    function () {

      this.query = function () {
        return [testData];
      };

      this.get = function (personId) {
        return testData;
      };

      this.set = function (personId, person) {
        testData.name = person.name;
        testData.height = person.height;
        testData.mass = person.mass;
        testData.hair_color = person.hair_color;
        testData.skin_color = person.skin_color;
        testData.eye_color = person.eye_color;
        testData.birth_year = person.birth_year;
        testData.gender = person.gender;
      };

    }
  ]);
