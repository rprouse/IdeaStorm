(function () {
  'use strict';
  var controllerId = 'admin';
  angular.module('app').controller(controllerId, ['common', 'datacontext', admin]);

  function admin(common, datacontext) {
    var getLogFn = common.logger.getLogFn;
    var log = getLogFn(controllerId);

    var vm = this;
    vm.title = 'Admin';

    activate();

    function activate() {
      common.activateController([], controllerId)
          .then(function () { log('Activated Admin View'); });

      datacontext.getIdeas()
        .then(function(ideas) {
        logSuccess('Fetched ' + ideas.length + 'ideas', null, true);
      })
    }
  }
})();