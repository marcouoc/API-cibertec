/*iffe + tab tab
function + tabt tab */
(function () {
    'use strict';

    angular.module('app')
        .controller('personController', personController);

    personController.$inject = ['dataService'];

    function personController(dataService) {
        var vm = this;
        /*variables*/
        var apiUrl = 'http://localhost/WebDeveloper.API/Person/';
        vm.title = 'Person Controller';
        vm.personList = [];
        vm.person;
        vm.readOnly = false;
        vm.modalFunction;
        vm.buttonTitle = '';
        vm.totalRows = 0;
        vm.maxSize = 10;
        vm.rowSize = 15;
        vm.currentPage = 1;

        /*funciones*/
        vm.update = update;
        vm.details = details;
        vm.personUpdate = personUpdate;
        vm.delete = modalDelete;
        vm.create = create;
        vm.personCreate = personCreate;
        vm.getPersonDetail = getPersonDetail;
        vm.pageChanged = pageChanged;
        vm.setRowSize = setRowSize;

        init();

        function init()
        {
            totalRows();
            loadData();
        }

        function totalRows() {
            dataService.getData(apiUrl + 'totalrows')
            .then(function (result) {
                vm.totalRows = result.data;
            });
        }

        function pageChanged() {
            vm.personaList = [];
            loadData();
        }

        function setRowSize(rowSize)
        {
            if (vm.rowSize == rowSize) return;
            vm.rowSize = rowSize
            vm.currentPage = 1;
            loadData();
               
        }

        function loadData()
        {
            vm.personList = [];
            var url = apiUrl + 'list/'+ vm.currentPage +'/'+vm.rowSize;
            dataService.getData(url).
                then(function (result) {
                    vm.personList = result.data;
                },
                function(error){
                    console.log(error);
                });

        }

        function getPersonDetail(id) {
            var url = apiUrl + id;
            dataService.getData(url).then(
                function (result) {
                    vm.person = result.data;
                });
        }

        function update() {
            vm.readOnly = false;
            vm.isDelete = false;
            vm.buttonTitle = 'Update';
            vm.modalFunction = personUpdate;
        }

        function personUpdate() {
            dataService.postData(apiUrl, vm.person)
            .then(function () {
              
                loadData();
                closeModal();
            });
        }

        function details() {
            vm.readOnly = true;
            vm.isDelete = false;
        }

        function modalDelete() {
            vm.readOnly = true;
            vm.isDelete = true;
            vm.modalFunction = personDelete;
        }

        function create() {
            vm.person = {};
            vm.readOnly = false;
            vm.isDelete = false;
            vm.buttonTitle = 'Create';
            vm.modalFunction = personCreate;
        }

        function personCreate() {
            dataService.putData(apiUrl, vm.person)
           .then(function () {

               loadData();
               closeModal();
               totalRows();
           });
        }
        
        function personDelete() {
            dataService.deleteData(apiUrl+ vm.person.businessEntityID)
           .then(function () {

               loadData();
               closeModal();
               totalRows();
           });
        }

        function closeModal()
        {
            $('button[data-dismiss="modal"]').click();
        }
        

    }

    
})();
