## aspnetcore-docket-azure-devops

[![Build Status](https://flaviosilva1110.visualstudio.com/GitHubProjects/_apis/build/status/flavio1110.aspnetcore-docket-azure-devops)](https://flaviosilva1110.visualstudio.com/GitHubProjects/_build/latest?definitionId=5)

- ASP .net core application (src/netcore-api-docker.Api)
- Dummy dockerfile with two phase image build (src/netcore-api-docker.Api/Dockerfile)
- Unit testing (src/netcore-api-docker.Api.UnitTests)
- Component testing (src/netcore-api-docker.Api.IntegrationTests)
- [CI using Azure DevOps](https://flaviosilva1110.visualstudio.com/GitHubProjects/_build?definitionId=5)
- [Coverlet](https://github.com/tonerdo/coverlet) used for compute the code coverage
- [ReportGenerator](https://github.com/danielpalme/ReportGenerator) used for consolidate and generate coverage report
- Build definition as code for AzureDevops (azure-pipelines.yml)