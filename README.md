# battleship-state-tracker

## Additional mechanics
1. A hit on a position previously occupied by a sunk ship will report "miss"
2. If all positions occupied by a ship are hit, report "sunk"
3. If all ships are sunk, report "win"

## How to run the project locally

### Using Visual Studio
1. This project was developed using .NET 5 on Visual Studio 16.9.2 so it is recommended to have the same version of Visual Studio

### Using Docker on Windows
1. Install Docker and set it to use Linux containers
2. Open Powershell and run the following command: `docker run -p 127.0.0.1:80:80 romlozano/battleship-state-tracker:latest`
3. Visit http://localhost/swagger/index.html on your browser

## CI/CD Overview
1. Automated build and test on submission of a PR
2. Automated build and test on merge to main. If this is successful, a docker image is published to [Docker Hub](https://hub.docker.com/r/romlozano/battleship-state-tracker)
3. If step 2 succeeds, the docker image is deployed to AWS ECS

## Tech Stack Overview
1. .NET 5 ASP.NET Web API
2. Github
3. Github Actions
4. Docker
4. Docker Hub
5. AWS EC2
6. AWS ECS
7. AWS Route53
8. MSTest
9. TDD
10. Moq
11. Automapper
12. Swagger

## TODO's (Due to time constraints)

### App
1. Logging
2. Integration Tests
3. Distributed caching (e.g., Redis)
4. More TODO's marked in the code

### CI/CD
1. Tag docker images
2. Infrastructure as Code

## Limitations
1. Only dev environment is setup for deployment
