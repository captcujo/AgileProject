namespace AgileProject.Controllers
{

    export class HomeController
    {
        public message = 'Hello from the home page!';
    }

    export class SecretController
    {
        public secrets;

        constructor($http: ng.IHttpService)
        {
            $http.get('/api/secrets').then((results) =>
            {
                this.secrets = results.data;
            });
        }
    }

    export class AboutController
    {
        public message = 'Hello from the about page!';
    }

    export class ProjectsHomeController
    {
        public projects;

        public project;

        public projectSprints;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService)
        {
            let id = this.$stateParams['id'];

            this.$http.get('/api/projects/' + id).then((response) =>
            {
                this.projects = response.data;
            });
        }

        public preFillProjectForm(id: number)
        {
            this.$http.get('/api/projects/' + id).then((response) =>
            {
                this.project = response.data;
            });
        }

        public DashBoardData(id: number)
        {
            this.$http.get('/api/projects/' + id).then((response) =>
            {
                this.projectSprints = response.data;
            });
        }

        public updateProject()
        {
            this.$http.post('/api/projects', this.project).then((response) =>
            {
                this.$state.reload();
            });
        }

        public deleteProject(id:number)
        {
            this.$http.delete('/api/projects/' + id ).then((r) =>
            {
                this.$state.reload();
            });
        }

        public clearForm()
        {
            this.project = null;
        }
    }

    export class ProjectSprintsController
    {
        public projectSprints;

        public sprint;

        public sprintToUpdateAdd;

        public projects;

        public projectId;

        public projectName;

        public statuses;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService)
        {
            let projectId = this.$stateParams['id'];

            this.$http.get('/api/projects/' + projectId).then((response) =>
            {
                this.projectSprints = response.data;

                this.projectId = this.projectSprints.id;

                this.projectName = this.projectSprints.projectName;
            });

            this.$http.get('/api/projects/').then((response) =>
            {
                this.projects = response.data;
            });

            this.$http.get('/api/statuses/').then((s) =>
            {
                this.statuses = s.data;
            });
        }

        public preFillSprintForm(id: number)
        {
            this.$http.get('/api/sprints/' + id).then((response) =>
            {
                this.sprint = response.data;
            });
        }

        public updateSprint()
        {
            //this.sprint.project.id = this.projectSprints.id;

            //this.sprint.project.projectName = this.projectSprints.projectName;

            this.sprint.requirements = null;
            
            this.$http.post('/api/sprints/', this.sprint).then((response) =>
            {
                this.$state.reload();
            });
        }

        public deleteSprint(id: number)
        {
            this.$http.delete('/api/sprints/' + id).then((response) =>
            {
                this.$state.reload();
            });
        }

        public grabProjectInfo()
        {
            this.sprint.project.id = this.projectId;
            this.sprint.project.name = this.projectName;
        }

        public clearForm()
        {
            this.sprint = null;
        }
    }

    export class SprintRequirementsController
    {
        public sprints;

        public sprintRequirements;

        public req;

        public statuses;
                
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService)
        {
            let sprintId = $stateParams['id'];

            this.$http.get('/api/sprints/' + sprintId).then((response) =>
            {
                this.sprintRequirements = response.data;
            });

            this.$http.get('/api/sprints/').then((response) =>
            {
                this.sprints = response.data;
            });

            this.$http.get('/api/requirementstatuses').then((r) =>
            {
                this.statuses = r.data;
            });
        }

        public preFillReqForm(id:number)
        {
            this.$http.get('/api/requirements/' + id).then((response) =>
            {
                this.req = response.data;
            });
        }

        public updateRequirement()
        {
            //this.req.sprint.sprintName = this.sprintRequirements.sprintName;
            //this.req.sprint.id = this.sprintRequirements.id;

            this.$http.post('/api/requirements', this.req).then((response) =>
            {
                this.$state.reload();
            });
        }

        public deleteRequirement(id: number)
        {
            this.$http.delete('/api/requirements/' + id).then((response) =>
            {
                this.$state.reload();
            });
        }

        public clearForm()
        {
            this.req = null;
        }
    }

    export class DashBoardController
    {
        public projectSprints;

        public projectName;

        public project;

        constructor(private $http: ng.IHttpService, $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService)
        {
            let id = $stateParams['id'];

            this.$http.get('/api/sprints/' + id).then((response) =>
            {
                this.projectSprints = response.data;
            });

            //this.projectName = this.projectSprints.projectName;

            var data = angular.toJson(this.projectSprints);
            var projectData = angular.fromJson(data);
            console.log(projectData);

            //var projectData = JSON.parse(data);

            //this.project = angular.fromJson(this.projectSprints);
        }
    }

    export class StatusMaintenanceController
    {
        public requirementStatuses;

        public sprintStatuses;

        public status;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService)
        {
            this.$http.get('/api/requirementstatuses/').then((response) =>
            {
                this.requirementStatuses = response.data;
            });

            this.$http.get('/api/statuses').then((r) =>
            {
                this.sprintStatuses = r.data;
            });
        }

        public addReqStatus()
        {
            this.$http.post('/api/requirementstatuses/', this.status).then((response) =>
            {
                this.$state.reload();
            });
        }

        public addSprintStatus()
        {
            this.$http.post('/api/statuses/', this.status).then((p) =>
            {
                this.$state.reload();
            });
        }

        public deleteReqStatus(id: number)
        {
            this.$http.delete('/api/requirementstatuses/' + id).then((response) =>
            {
                this.$state.reload();
            });
        }

        public deleteSprintStatus(id: number)
        {
            this.$http.delete('/api/statuses/' + id).then((response) =>
            {
                this.$state.reload();
            });
        }

        public prefillReqStatus(id: number)
        {
            this.$http.get('/api/requirementstatuses/' + id).then((response) =>
            {
                this.status = response.data;
            });
        }

        public prefillSprintStatus(id: number)
        {
            this.$http.get('/api/statuses/' + id).then((response) =>
            {
                this.status = response.data;
            });
        }

        public clearForm()
        {
            this.status = null;
            this.$state.reload();
        }
    }

    export class productBacklogController
    {
        public storiesByProduct;

        public story;

        public stories;

        public sprints;

        public statuses;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService)
        {
            let id = $stateParams['id'];

            this.$http.get('/api/requirements/product/' + id).then((response) =>
            {
                this.storiesByProduct = response.data;
            });

            this.$http.get('/api/requirements/').then((s) =>
            {
                this.stories = s.data;
            });

            this.$http.get('/api/sprints/').then((s) =>
            {
                this.sprints = s.data;
            });
        }

        public prefillStory(id:number)
        {
            this.$http.get('/api/requirements/' + id).then((r) =>
            {
                this.story = r.data;
            });
        }

        public assignUpdateStory()
        {
            this.$http.post('/api/requirements/', this.story).then((response) =>
            {
                this.$state.reload();
            });
        }

        public clearForm()
        {
            this.story = null;

            this.$http.get('/api/requirementstatuses').then((r) =>
            {
                this.statuses = r.data;
            });
        }

        public addStory()
        {
            this.$http.post('/api/requirements', this.story).then((response) =>
            {
                this.$state.reload();
            });
        }

        public deleteStory(id: number)
        {
            this.$http.delete('/api/requirements/' + id).then((d) =>
            {
                this.$state.reload();
            });
        }
    }

    export class TasksController
    {
        public tasks;

        public task;

        public stories;

        public story;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService)
        {
            let id = $stateParams['id'];

            this.$http.get('/api/tasks/tsks/' + id).then((response) =>
            {
                this.tasks = response.data;
            });

            this.$http.get('/api/requirements/' + id ).then((response) =>
            {
                this.story = response.data;
            });

            this.$http.get('/api/requirements').then((response) =>
            {
                this.stories = response.data;
            });
        }

        public deleteTask(id:number)
        {
            this.$http.delete('/api/tasks/' + id).then((t) =>
            {
                this.$state.reload();
            });
        }

        public preFillTaskForm(id: number)
        {
            this.$http.get('/api/tasks/' + id).then((t) =>
            {
                this.task = t.data;
            });
        }

        public updateTask()
        {
            this.$http.post('/api/tasks/', this.task).then((t) =>
            {
                this.$state.reload();
            });
        }

        public clearForm()
        {
            this.task.story.id = this.story.id;
            this.task.taskName = null;
            this.task.description = null;
            //this.task = null;
        }
    }
}
