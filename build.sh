#!/bin/bash

coverlet ./netcore-api-docker.Api.UnitTests/bin/Debug/netcoreapp2.1/netcore-api-docker-Api.UnitTests.dll --target "dotnet" --targetargs "test --no-build" --output ./coverage.json

coverlet ./netcore-api-docker.Api.IntegrationTests/bin/Debug/netcoreapp2.1/netcore-api-docker-Api.IntegrationTests.dll --target "dotnet" --targetargs "test --no-build" --merge-with ./coverage.json