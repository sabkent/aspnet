echo login to docker
IMAGE_NAME = sabkent/aspnet:$(date +%s)
docker build --tag $IMAGE_NAME --file "PaymentGateway/Dockerfile"  . 
docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD
docker push $IMAGE_NAME