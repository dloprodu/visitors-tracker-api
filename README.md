
# Visitors Tracker API (.Net Core 3.1 app service)

API that sets out two methods:

`/visit`

Logs a user's visit

`/visits/show`

Returns the recorded visits and allows filters to be performed.

The API uses **swagger** to expose a the documentation.

[https://visitors-tracker-api.azurewebsites.net](https://visitors-tracker-api.azurewebsites.net)

## It is implemented in four layers

### 1. VisitorsTracker.API

API entry point that exposes HTTP methods.

### 2. VisitorsTracker.BLL

Business Logic Layer. Defines the logic per use case. Each use case must be implemented by inheriting from the BaseActionManager base class. 

BaseActionManager may encapsulate logic common to all implemented use cases, such as unified error handling, data validation or caching, 

### 3. VisitorsTracker.DBL

Data Base Layer. Layer in charge of the implementation of the drivers for data storage access. In this case we use as storage CosmosDB with MongoDB interface.

###4. VisitorsTracker.Models

Defines the necessary models of the business logic.

# Build solution
dotnet publish -c Release

# Docker build
docker build -t visitorstrackerapi-image -f Dockerfile .

# Deploy Image
[Deploy to Azure Web App for Containers](https://docs.microsoft.com/en-us/azure/devops/pipelines/apps/cd/deploy-docker-webapp?view=azure-devops&tabs=java)