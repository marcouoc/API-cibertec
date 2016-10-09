﻿(function () {
    'use strict';

    angular.module('app')
    .controller('loginController', loginController);

    loginController.$inject = ['authenticationService']

    function loginController(authenticationService) {
       var vm = this;
       vm.user = {};
       vm.title = 'login';
       vm.login = login;

       function login() {
           authenticationService.login(vm.user);

       }
    }

})();