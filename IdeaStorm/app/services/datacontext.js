(function () {
  'use strict';

  var serviceId = 'datacontext';
  angular.module('app').factory(serviceId, ['common', 'entityManagerFactory', datacontext]);

  function datacontext(common, entityManagerFactory) {
    var $q = common.$q;
    var manager = entityManagerFactory.newManager();

    var getLogFn = common.logger.getLogFn;
    var log = getLogFn(serviceId);
    var logError = getLogFn(serviceId, 'error');
    var logSuccess = getLogFn(serviceId, 'success');
    
    var service = {
      getIdeas: getIdeas,
      getPeople: getPeople,
      getMessageCount: getMessageCount
    };

    return service;

    function getMessageCount() { return $q.when(72); }

    function getPeople() {
      var people = [
          { firstName: 'John', lastName: 'Papa', age: 25, location: 'Florida' },
          { firstName: 'Ward', lastName: 'Bell', age: 31, location: 'California' },
          { firstName: 'Colleen', lastName: 'Jones', age: 21, location: 'New York' },
          { firstName: 'Madelyn', lastName: 'Green', age: 18, location: 'North Dakota' },
          { firstName: 'Ella', lastName: 'Jobs', age: 18, location: 'South Dakota' },
          { firstName: 'Landon', lastName: 'Gates', age: 11, location: 'South Carolina' },
          { firstName: 'Haley', lastName: 'Guthrie', age: 35, location: 'Wyoming' }
      ];
      return $q.when(people);
    }

    function getIdeas() {
      return breeze.EntityQuery.from("Ideas")
        .using(manager)
        .execute()
        .then(success)
        .catch(fail);

      function success(resp) {
        var ideas = resp.results;
        logSuccess("Fetched " + ideas.length + " ideas", null, true);
        return ideas;
      }

      function fail(error) {
        logError("Failed to fetch ideas: " + error, null, true);
      }
    }
  }
})();