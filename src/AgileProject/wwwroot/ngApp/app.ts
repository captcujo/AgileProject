namespace AgileProject {

    angular.module('AgileProject', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: AgileProject.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: AgileProject.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: AgileProject.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: AgileProject.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: AgileProject.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: AgileProject.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('projectsHome', {
                url: '/projectsHome/:id',
                templateUrl: '/ngApp/views/projectsHome.html',
                controller: AgileProject.Controllers.ProjectsHomeController,
                controllerAs: 'controller'
            })
            .state('projectSprints', {
                url: '/projectSprints/:id',
                templateUrl: '/ngApp/views/projectSprints.html',
                controller: AgileProject.Controllers.ProjectSprintsController,
                controllerAs: 'controller'
            })
            .state('sprintRequirements', {
                url: '/sprintRequirements/:id',
                templateUrl: '/ngApp/views/sprintRequirements.html',
                controller: AgileProject.Controllers.SprintRequirementsController,
                controllerAs: 'controller'
            })
            .state('dashBoard', {
                url: '/dashBoard/:id',
                templateUrl: '/ngApp/views/dashBoard.html',
                controller: AgileProject.Controllers.DashBoardController,
                controllerAs: 'controller'
            })
            .state('StatusMaintenance', {
                url: '/StatusMaintenance',
                templateUrl: '/ngApp/views/StatusMaintenance.html',
                controller: AgileProject.Controllers.StatusMaintenanceController,
                controllerAs: 'controller'
            })
            .state('productBacklog', {
                url: '/productBacklog/:id',
                templateUrl: '/ngApp/views/productBacklog.html',
                controller: AgileProject.Controllers.productBacklogController,
                controllerAs: 'controller'
            })
            .state('tasks', {
                url: '/tasks/:id',
                templateUrl: '/ngApp/views/tasks.html',
                controller: AgileProject.Controllers.TasksController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });
        
        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('AgileProject').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('AgileProject').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
