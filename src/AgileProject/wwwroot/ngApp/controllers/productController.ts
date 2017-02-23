namespace AgileProject.Controllers
{
    export class ProductController
    {
        public products;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService)
        {
            this.$http.get('/api/projects').then((response) =>
            {
                this.products = response.data;
            });
        }
    }

    angular.module('AgileProject').controller('ProductController', ProductController);
}