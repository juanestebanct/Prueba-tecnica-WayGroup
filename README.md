## Prueba-tecnica-WayGroup
____
Prueba tecnica para WayGroup 
 
Documentacion del proyecto.

## Movimiento simple del jugador  
____

Para el movimiento del jugador,se tiene la funcion *Move()* donde se esta calculando mediante las fisicas del rigibody, se está moviendo con respecto el forward de la cámara para que se mueva siempre en la dirección de la cámara.<br>
![image](https://github.com/juanestebanct/Prueba-tecnica-WayGroup/assets/78618669/044e3c24-1178-406f-be43-160dbe833dff) <br>
codigo que rota al jugador con el forward de la camara.este codigo esta en *CameraController*, en especifico en la funcion Rotation()
![image](https://github.com/juanestebanct/Prueba-tecnica-WayGroup/assets/78618669/827d5215-43ba-46c9-9510-c29d485cdc30)

Además de esto para el movimiento se detecta constantemente si el jugador está en contacto con el suelo con el fin de. Primero saber si el jugador puede saltas y segundo para poder modificar el drag del jugador para
hacer que el movimiento cambie si está en el suelo o en aire.

Se tiene la función TouchGround() para calcular con un raycast si una parte del cuerpo(o en este caso una posicion media del jugador), si no detecta nada, regresa un false y con este se guarda en la variable 
*isGrounded* y con esto se decide si el jugador puede saltar y se decide tambien el valor del drag en todo momento.

![image](https://github.com/juanestebanct/Prueba-tecnica-WayGroup/assets/78618669/63c380d3-7267-4b34-88ff-d94bf0aec47a)<br>
 Para el salto se aplica la fuerza al *vector.up* y se cambia el drag para dar un sentimiento de friccion en el aire y en el suelo  
![image](https://github.com/juanestebanct/Prueba-tecnica-WayGroup/assets/78618669/b6fd634d-677e-4648-923f-04220306659c)<br>
en el move, se cambia el drag. <br>
![image](https://github.com/juanestebanct/Prueba-tecnica-WayGroup/assets/78618669/82d11259-a5d9-45e1-9e0d-1f036df40631)

## Agarrar los objetos y tirarlos 
____
En el codigo de *PlayerController* se implemento el sistema de agarrar objetos, soltarlos y lanzarlos.

# Agarrar objeto 

Para este sistema lo primero fue implementar una funcion *DetectObject()* que se encargara de detectar los objetos que se puedan agarrar con un raycast , estos objetos estan con un tag "Grabbed" 
 para que cuando el rayo los colicione 
este recolecte la informacion de este y le da la posibilidad al jugador de agarrarlo con la tecla Q <br>
![image](https://github.com/juanestebanct/Prueba-tecnica-WayGroup/assets/78618669/37167e28-872d-47de-bd7c-79c20b25978c) <br>
si decide agarrar el objeto,el objeto desactiva la gravedad, activa el condicional kinectic(rigibody) del objeto , se coloca el objeto como hijo de la mano, para mas comodidad, el jugador no puede tener mas de 1 objeto agarrarlo al tiempo, haciendo que se desactive el Raycast activando el codicional *isGrabbed*.

# Soltar o lanzar el objeto 

En la función *DetectObject()* hay un if que detecta el condicional de *isGrabbed* y si detecta que se activo llamara a la funcion * ThrowObject();* <br>
![image](https://github.com/juanestebanct/Prueba-tecnica-WayGroup/assets/78618669/80bf6615-9d64-4a98-bcf0-bf352352ace6) <br>
En esta funcion se va a encargar de revisar si va dejar caer el objeto, lo va a tirar y la fuerza de esta  <br>
![image](https://github.com/juanestebanct/Prueba-tecnica-WayGroup/assets/78618669/fdac4234-a25d-41e6-b411-cabc99efb01d)<br>
si lo suelta(precionando q de nuevo) se va a llamar a la funcion *DropGrabbed()* donde se va a activar la gravedad , desactivar el condicional kinectic(rigibody) y dejar al objeto si el padre para que este se mueva con normalidad. <br>
![image](https://github.com/juanestebanct/Prueba-tecnica-WayGroup/assets/78618669/90958ba8-cf65-4c2e-a3f0-743ddb4a650a)<br>
Para tirarlo hay que dejar precionado el click derecho (KeyCode.Mouse1) cuando detecte el primer click se activa el condicional throwable, entre mas tiempo pase el lanzamiento tendra mas fuerza hasta un limite.<br>
cuando se suelte la tecla se va a llamar de nuevo la funcion *DropGrabbed()* , este va a detecta el condicional activado de *throwable* y se va a aplicar fuerza a la direccion forward del personaje y se lanzara con la fuerza. La fuerza se calcula con el tiempo que a mantenido el click hasta un tope maximo de 2 seg.<br>
![image](https://github.com/juanestebanct/Prueba-tecnica-WayGroup/assets/78618669/e727b7dd-0d20-4b3e-a946-9e8f1403371f)<br>

En cualquiera de los dos casos (soltarlo o tirarlo) se va a activar de nuevo el raycast y descativar el condicional de *isGrabbed*.
 


