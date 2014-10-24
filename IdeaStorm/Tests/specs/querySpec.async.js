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
  var query = breeze.EntityQuery;
  var em;
  var failed = fns.failed;

  beforeEach(function() {
    em = new breeze.EntityManager(fns.serviceName);
  });

  afterEach(function() {

  });

  it('should get at least one idea', function(done) {
    query.from("Ideas")
      .using(em)
      .execute()
      .then(success)
      .catch(failed)
      .finally(done);

    function success(data) {
      var results = data.results;
      expect(results.length).toBeGreaterThan(0);
    }
  });
});