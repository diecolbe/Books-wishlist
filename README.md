# Books-wishlist
Web application that allow manage books wishlist

*Cada micro servicio tiene asociado un archivo Dockerfile el cual proporciona toda la informacion necesria para crear la imagen
para ejecutarla se debe ir a la raiz de cada proyecto y copiar la ruta, luego se debe ejecutar el siguente comando: docker build -t [usuario o ambito]/[nombre de la imagen]


------Imagenes------------
microservicio -seguridad:
docker build -t challenge/Seguridad .

microservicio -integracion:
docker build -t challenge/Integracion .

microservicio -integracion:
docker build -t challenge/microservicio-Gateway .

microservicio- lista de deseos:
docker build -t challenge/Bookswishlist


-----Crear contenedores-------------------
luego para crear los contenedores se deben ejecutar los sigueientes comandos,
los puertos sobre el cual se expone el anfitrion se pueden cambiar segun se quiera que se ejecute

docker run -d -p 8012:8080 --name=microservicio-Seguridad challenge/Seguridad
docker run -d -p 8020:8080 --name=microservicio-Integracion challenge/Integracion
docker run -d -p 8030:8080 --name=microservicio-Gateway challenge/Gateway
docker run -d -p 8040:8080 --name=microservicio-Bookswishlist challenge/Bookswishlist


----imagenes para servicios externos----------------
MYSQL 
docker run --name mysql-database --network microchallenge  -e MYSQL_ROOT_PASSWORD=Prueb@2022 -p 3307:3306 -p 33061:33060 -d mysql

MONGO
docker run -p 27018:27017 --network microchallenge --name mongo-database -d mongo

REDIS
docker run -d -p 6379:6379 --network microchallenge --name redis-database redis


------Diagrama arquitectonico-----


![mercado-libre-challenge-Emision 11-11-Architecture-Microservices](https://user-images.githubusercontent.com/67524326/177678296-d22c7c7b-3219-4ed8-b2a9-c604742e5a58.png)



-----Modelo C4- nivel 3---------


![mercado-libre-challenge-Emision 11-11-C4 Model-Level3](https://user-images.githubusercontent.com/67524326/177678307-88597c43-9597-40e3-bbf6-51d530c92931.png)



----Marco arquitectonico para el desarrollo de las APIS----

![CleanArchitecture](https://user-images.githubusercontent.com/67524326/177682188-4dfd19ab-8788-4ed1-b0e0-98bc6b4681d7.jpg)



ToDo
*Falta implmentar la funcionalidad guardado en cache las consultas de libros para de esta manera evitar varias peticiones hacia un mismo recurso
*Falta implementar el Front-End.
*Proceso de Auditoria

Estos requisitos no estaban plasmados en el documento, pero se enuncias para mejorar y complementar la aplicacion

