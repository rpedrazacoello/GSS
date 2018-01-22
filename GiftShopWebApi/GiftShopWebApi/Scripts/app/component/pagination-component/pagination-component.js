angular.module('ui.bootstrap')
    .component('paginationComponent', {
        templateUrl: "Scripts/app/component/pagination-component/pagination-component.html",
        bindings: {
            totalItems : "="
        }
    })
    .controller('PaginationDemoCtrl', function ($scope, $log) {
    $scope.totalItems = 0;
    $scope.currentPage = 1;

    $scope.setPage = function (pageNo) {
        $scope.currentPage = pageNo;
    };

    $scope.pageChanged = function () {
        $log.log('Page changed to: ' + $scope.currentPage);
    };

    $scope.maxSize = 5;
    $scope.bigTotalItems = 175;
    $scope.bigCurrentPage = 1;
});