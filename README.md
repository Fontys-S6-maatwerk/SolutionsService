# SolutionsService

### Getting started with docker
containers communicate with each other using a network. This should be created first and needs to be done only once. Run the following commandline in the folder where the docker compose file is located

```zsh
docker network create ggc-network
```

then run the following command to compose and run the containers via docker. --build is required to make a new build. Use -d to run docker compose in detached mode.

```zsh
docker compose up --build -d
```
