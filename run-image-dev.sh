#!/bin/bash
docker rm netcoreapi
docker run -d -p 8080:80 --name netcoreapi aspnetapp