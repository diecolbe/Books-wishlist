# Books-wishlist
Web application that allow manage books wishlist

*Cada micro servicio tiene asociado un archivo Dockerfile el cual proporciona toda la informacion necesria para crear la imagen
para ejecutarla se debe ir a la raiz de cada proyecto y copiar la ruta, luego se debe ejecutar el siguente comando: docker build -t [usuario o ambito]/[nombre de la imagen]


**Crear Red**

docker network create --driver nat microchallenge


**Crear Imagenes**

microservicio -seguridad:
docker build -t challenge/Seguridad .

microservicio -integracion:
docker build -t challenge/Integracion .

microservicio -integracion:
docker build -t challenge/microservicio-Gateway .

microservicio- lista de deseos:
docker build -t challenge/Bookswishlist


**Crear contenedores**

Para crear los contenedores se deben ejecutar los sigueientes comandos,
los puertos sobre el cual se expone el anfitrion se pueden cambiar segun se quiera que se ejecute

docker run -d -p 8012:8080 --name=microservicio-Seguridad challenge/Seguridad

docker run -d -p 8020:8080 --name=microservicio-Integracion challenge/Integracion

docker run -d -p 8030:8080 --name=microservicio-Gateway challenge/Gateway

docker run -d -p 8040:8080 --name=microservicio-Bookswishlist challenge/Bookswishlist



**Imagenes para servicios externos**

>MYSQL

docker run --name mysql-database --network microchallenge  -e MYSQL_ROOT_PASSWORD=Prueb@2022 -p 3307:3306 -p 33061:33060 -d mysql

>MONGO
>
docker run -p 27018:27017 --network microchallenge --name mongo-database -d mongo

>REDIS

docker run -d -p 6379:6379 --network microchallenge --name redis-database redis


>**Diagrama Arquitectonico de la aplicacion**


![mercado-libre-challenge-Emision 11-11-Architecture-Microservices](https://user-images.githubusercontent.com/67524326/177800547-5e257471-76dc-4575-abc6-e770b84484c6.png)




>**Modelo C4- nivel 3**


![mercado-libre-challenge-Emision 11-11-C4 Model-Level3](https://user-images.githubusercontent.com/67524326/177784718-138acb19-1124-4fcb-b944-ca7ea7585a2d.png)




>**Marco Arquitectonico para el desarrollo de las APIS**

![CleanArchitecture](https://user-images.githubusercontent.com/67524326/177682188-4dfd19ab-8788-4ed1-b0e0-98bc6b4681d7.jpg)



**ToDo**

1-Guardado en cache las consultas de libros para de esta manera evitar varias peticiones hacia un mismo recurso
  y mejorar el rendimiento.

2-Front-End.

3-Proceso de Auditoria

4-HATEOAS

5- Unit Tests

Algunos de estos requisitos no estaban plasmados en el documento, pero se enuncian para mejorar y complementar la aplicacion.


**Documentacion APIS**

Para probar los servicios, estos cuentan con documentacion mediante Swagger.

**Api Key**

Esta se inyecta directamente en el servicio expuesto por el nugget Google.Apis.Books.v1

APiKey: AIzaSyDYP8VYA5Jo6RtL_N86knRjMWPGjfMOpcw

>**Busqueda de libros**

**Filtro por titulo**

[title]+intitle:clean clode

ejemplo:

clean clode+intitle:clean clode

**Filtro por autor**

[Author]+inauthor

ejemplo:

clean clode+inauthor: robert c martin

**Filtro por editorial**

[Editorial]+inpublisher

Ejemplo:

Financial Times/Prentice Hall+inpublisher:financial

