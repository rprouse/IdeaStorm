(function() {
    'use strict';
    
    var serviceId = 'entityManagerFactory';
    angular.module('app').factory(serviceId,
      ['breeze', 'config', emFactory]);

    function emFactory(breeze, config) {
            newManager: newManager
        };

        function newManager() {
            return new breeze.EntityManager(config.remoteServiceName);
        }
    }
})();