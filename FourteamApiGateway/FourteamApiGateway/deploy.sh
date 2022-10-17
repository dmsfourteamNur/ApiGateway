#!/bin/bash

# Build, deploy, and manage
# https://fsymbols.com/es/generadores/tarty/

# iniciar con sudo o entrar con su root
# ░██████╗██╗░░░██╗██████╗░░█████╗░
# ██╔════╝██║░░░██║██╔══██╗██╔══██╗
# ╚█████╗░██║░░░██║██║░░██║██║░░██║
# ░╚═══██╗██║░░░██║██║░░██║██║░░██║
# ██████╔╝╚██████╔╝██████╔╝╚█████╔╝
# ╚═════╝░░╚═════╝░╚═════╝░░╚════╝░
# sudo ./deploy.sh

docker build -t apigateway-image -f Dockerfile .
docker run -d -p 81:80 --name apigateway-contenedor apigateway-image
docker images
docker ps -a

# http://192.168.0.9:5080/api/user-posts