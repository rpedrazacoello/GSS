/*Angular Modules take a name, best practice is lowerCamelCase, and a list of dependancies*/
/*added the second module as a dependancy */
angular.module('mainApp', ['productComponent', 'ui.bootstrap', 'ngRoute', 'productDetailComponent'])
.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.html5Mode(true);
    console.log("Configuration hook")
}])
.component('app', {
    templateUrl: 'Index.html',
    $routeConfig: [
        { path: '/', name: 'Products', component: 'productComponent', useAsDefault: true }
    ]
});