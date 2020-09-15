docker stop MessageBoard
docker rm MessageBoard
docker rmi messageboard

docker build -t messageboard .
docker run -p 5001:5001 --name MessageBoard messageboard