echo login to docker
docker build --tag sabkent/aspnet:$(date +%s) --file "PaymentGateway/Dockerfile"  . 
docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD