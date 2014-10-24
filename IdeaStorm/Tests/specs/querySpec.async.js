/// <reference path="../support/testFns.js"/>
/// <reference path="../../Scripts/angular.js" />
/// <reference path="../../Scripts/breeze.debug.js" />
/// <reference path="../../Scripts/breeze.directives.js" />
/// <reference path="../../Scripts/breeze.angular.js" />
/// <reference path="../../Scripts/breeze.to$q.shim.js" />

describe('When verifying the Jasmine test environment', function () {
  it('should run a true test', function() {
    expect(true).toBe(true);
  });
});

describe('when querying the breeze api', function() {
  'use strict';

  var fns = window.testFns;
  var em;
  var failed = fns.failed;

  beforeEach(function() {
    em = new breeze.EntityManager(fns.serviceName);
  });

  afterEach(function() {

  });

  it('should get at least one idea', function (done) {
    testQuery("Ideas", success, done);

    function success(data) {
      var results = data.results;
      expect(results.length).toBeGreaterThan(0);
    }
  });

  it('should get at least one experiment', function (done) {
    testQuery("Experiments", success, done);

    function success(data) {
      var results = data.results;
      expect(results.length).toBeGreaterThan(0);
    }
  });

  it('should find an idea with its experiments', function(done) {
    testQuery("Ideas", success, done, addToQuery);

    function addToQuery(query) {
      return query.top(5).expand('Experiments');
    }

    function success(data) {
      var results = data.results;
      expect(results.length).toBe(5);
      var idea = results[4];
      expect(idea.Experiments.length).toBeGreaterThan(0);
    }
  });

  it('should find idea with id 5', function (done) {
    testQuery("Ideas", success, done, addToQuery);

    function addToQuery(query) {
      return query.where('Id', 'eq', 5);
    }

    function success(data) {
      var results = data.results;
      expect(results.length).toBe(1);
      var idea = results[0];
      expect(idea.Id).toBe(5);
    }
  });

  function testQuery(resourceName, success, done, addToQuery) {
    var query = breeze.EntityQuery.from(resourceName).using(em);
    if (addToQuery) {
      query = addToQuery(query);
    }
    return query.execute()
      .then(success)
      .catch(failed)
      .finally(done);
  }
});