echo login to docker
IMAGE_NAME=sabkent/aspnet
echo image name is $IMAGE_NAME
docker build --tag $IMAGE_NAME:$(date +%s) --tag $IMAGE_NAME:latest --file "PaymentGateway/Dockerfile"  . 
docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD
docker push $IMAGE_NAME