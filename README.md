# Prueba-tecnica-WayGroup
Prueba tecnica para WayGroup 
 
Documentacion del proyecto.

# Movimiento simple del jugador  
____

Para el movimiento del jugador,se tiene la funcion *Move()* donde se esta calculando mediante las fisicas del riggibody, se está moviendo con respecto el forward de la cámara para que se mueva siempre en la dirección de la cámara.
![image](https://github.com/juanestebanct/Prueba-tecnica-WayGroup/assets/78618669/044e3c24-1178-406f-be43-160dbe833dff)
codigo que rota al jugador con el forward de la camara  
![image](https://github.com/juanestebanct/Prueba-tecnica-WayGroup/assets/78618669/af6b2451-ebbf-4688-92ea-599fe640c61b)

Además de esto para el movimiento se detecta constantemente si el jugador está en contacto con el suelo con el fin de. Primero saber si el jugador puede saltas y segundo para poder modificar el drag del jugador para
hacer que el movimiento cambie si está en el suelo o en aire.

Se tiene la función TouchGround() para calcular con un raycast si una parte del cuerpo(o en este caso una posicion media del jugador), si no detecta nada, regresa un false y con este se guarda en la variable 
*isGrounded* y con esto se decide si el jugador puede saltar y se decide tambien el valor del drag en todo momento.

![image](https://github.com/juanestebanct/Prueba-tecnica-WayGroup/assets/78618669/63c380d3-7267-4b34-88ff-d94bf0aec47a)

 Para el salto se aplica la fuerza al *vector.up* y se cambia el drag para dar un sentimiento de friccion en el aire y en el suelo  
 
![image](https://github.com/juanestebanct/Prueba-tecnica-WayGroup/assets/78618669/b6fd634d-677e-4648-923f-04220306659c)

en el move, se cambia el drag. 

![image](https://github.com/juanestebanct/Prueba-tecnica-WayGroup/assets/78618669/82d11259-a5d9-45e1-9e0d-1f036df40631)

# Agarrar los objetos y tirarlos 
____


