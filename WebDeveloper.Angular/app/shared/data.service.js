/*'use strict'; valida que todas las var esten definidas y utilizadas*/
(function(){
      'use strict';
    
      angular.module('app')
        .factory('dataService', dataService);

      dataService.$inject = ['$http'];

      function dataService($http)
      {
          var service = {}
          service.getData = getData;
          return service;

          function getData(url) {

              return $http.get(url);

          }
      }
})();