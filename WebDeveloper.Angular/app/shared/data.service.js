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
          service.postData = postaData;
          service.putData = putData;
          service.deleteData = deleteData;

          return service;

          function getData(url) {
            return $http.get(url);

          }
          function postaData(url,data) {
              return $http.post(url, data);

          }
          function putData(url, data) {
              return $http.put(url, data);

          }
          function deleteData(url) {
              return $http.delete(url);

          }

      }
})();