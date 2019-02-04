# Información sobre CDmon API

Este documento solo provee de una copia de la información del api de cdmon.
URL original: https://ticket.cdmon.com/es/support/solutions/articles/7000005922-api-de-actualizaci%C3%B3n-de-ip-del-dns-gratis-din%C3%A1mico

*Fecha artículo original: Mar, 5 Julio, 2016 at 8:17 AM*

# Referencia rápida de uso

Para poder actualizar su IP tiene que hacer una llamada a la siguiente URL:

**[https://dinamico.cdmon.org/onlineService.php](https://dinamico.cdmon.org/onlineService.php)**

con los argumentos via GET siguientes:

-   **enctype=MD5**
-   **n=nombre_de_usuario**
-   **p=contraseña_codificada_con_md5**

si la IP que quiere actualizar es diferente a la IP que le asigna el sistema puede definir una IP propia con el argumento "cip",

**cip=x.x.x.x**

de modo que tendremos:

https://dinamico.cdmon.org/onlineService.php?enctype=MD5&n=usuario&p=1bc29b36f623ba82aaf6724fd3b16718&cip=x.x.x.x

donde cip es opcional ya que al hacer la petición via URL el servidor devuelve un resultado.

## Respuestas de servidor

Cuando se hace una petición sin la variable cip y la autentificación ha sido correcta, se nos devuelve la IP actual que detecta el servidor.
**`&resultat=guardatok&newip=x.x.x.x&`**

Cuando hemos mandado nuestra IP mediante la variable cip y la autentificación ha sido satisfactoria.
**`&resultat=customok&`**

Nos devuelve este resultado cuando la autentificación ha sido satisfactoria pero la IP es errónea.
**`&resultat=badip&`**

Nos devuelve este resultado cuando la autentificación no ha sido satisfactoria.
**`&resultat=errorlogin&`**

Nos devuelve este resultado en raras ocasiones, sólo cuando modificamos el archivo que procesa todas las peticiones para obligar a todos los usuarios a actualizar a una nueva versión de la aplicación. En su caso sólo tendrá que ponerse en contacto con nosotros para obtener la nueva URL para hacer la petición.
**`&resultat=novaversio&`**

Nos devuelve este resultado, para informarnos que se ha guardado bien la configuración y que los cambios no estarán operativos hasta pasados 20 minutos.
**`&resultat=guardatok&temps=1200000&`**


*Creado con: https://stackedit.io/ - 04/02/2019 13:13*