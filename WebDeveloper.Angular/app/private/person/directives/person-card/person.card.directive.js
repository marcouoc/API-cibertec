/*
E=> Element
A=> attribute
cada letra mayuscula en una var se transforma en "-minuscula" en una directiva
firstName = first-name
*/
(function () {
    'use strict';
    angular.module('app')
        .directive('personCard', personCard);

    function personCard() {
        return {
            templateUrl: 'app/private/person/directives/person-card/person-card.html',
            restrict: 'E',
            scope: {
                personId: '@',
                firstName: '@',
                lastName: '@',
                modifiedDate: '@'

            }

        }
    }

})();