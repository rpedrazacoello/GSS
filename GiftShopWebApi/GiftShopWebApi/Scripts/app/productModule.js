angular.module('productModule', [])
.config([function (){
	console.log("Configuration hook")
}])
.run([function (){
	console.log("Run hook")
}])
.controller('productCtrl', ['$scope', '$http', function($scope, $http){

    this.getProducts = function () {
		var scope = this;
		$http({
		    url: '/api/product',
		    method: 'GET',
		    params: {
		        quantity: 5,
		        page: 1
		    }
		})
        .success(function (data) {
            scope.products = data;
        });
	}

	this.getProducts();
}])