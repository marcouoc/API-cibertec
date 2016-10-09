﻿//guardara la autentication en el local storage
//pero no sera visible localStorageService es de angular-local-storage.js

(function () {
    'use strict';

    angular.module('app')
     .factory('authenticationService', authenticationService);

    authenticationService.$inject = ['$http', '$state', 'localStorageService'];

    function authenticationService($http, $state, localStorageService) {
        var apiUrl = 'http://localhost/WebDeveloper.API/';

        var service = {}
        service.login = login;

        return service;

        function login(user) {
            var url = apiUrl + 'Token';
            var data =
                'grant_type=password&username=' + user.userName
                + '&password=' + user.password;
            $http.post(url, data,
                {
                    headers: {
                        'Content-Type':
                        'application/x-www-form-urlencoded'
                    }
                })
            .then(function (result) {
                   localStorageService.set('authorizationData',
                {
                    token: result.access_token,
                    userName: user.userName
                });
                $state.go('person');
            });
        }
    }

})();