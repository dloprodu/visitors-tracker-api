
# Build solutiom
dotnet publish -c Release

# Docker build
docker build -t visitorstrackerapi-image -f Dockerfile .

# Deploy Image
[Deploy to Azure Web App for Containers](https://docs.microsoft.com/en-us/azure/devops/pipelines/apps/cd/deploy-docker-webapp?view=azure-devops&tabs=java)