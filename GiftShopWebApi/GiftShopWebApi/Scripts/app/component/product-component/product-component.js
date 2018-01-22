angular.module('productComponent', ['ngAnimate'])
.component('productComponent', {
    templateUrl: 'Scripts/app/component/product-component/product-component.html',
    controllerAs: 'productCtrl',
    controller: function ($http, $scope, $log) {

        $scope.itemsPerPage = 6;
        $scope.currentPage = 1;

        this.getProducts = function () {
            var scope = this;
            $http({
                method: 'GET',
                url: '/api/product',
                params: {
                    quantity: $scope.itemsPerPage,
                    page: $scope.currentPage
                }
            }).then(function successCallBack(response) {
                console.log(response.data);
                scope.products = response.data;
            })
        };

        this.send = function () {
            this.getProducts();
        }

        this.getProducts();

        //Pagination Stuff
        this.totalItems = 64;

        $scope.setPage = function (pageNo) {
            $scope.currentPage = pageNo;
        };

        this.pageChanged = function () {
            console.log($scope.currentPage);
            this.getProducts();
        };

        this.maxSize = 5;
        this.bigTotalItems = 175;
        this.bigCurrentPage = 1;
    }
});