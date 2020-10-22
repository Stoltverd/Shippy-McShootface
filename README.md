# Shippy-McShootface
//Final//
//Instruciones de Uso//
usa las teclas wasd o las flecas direcionales para hacer mover la nave. Usa el click del mause para avanzar en el cómic y en la tienda 
para comprar los items que deses para mejorar ti nave. Durante el vuelo usa el click izq para dispara el blaster y el derecho para dispara misiles, estos últimos son limitados y deberás comprar más en la tienda.
Usa la barra espaciadora para propulsarte u moverte más rápido por un corto periodo de timepo, este boost, se recargara con el tiempo.

En la tienda odrás compar reparaciones, mejoras de velocidad, mayor capacidad de boost, y misilies adicionales.
//Elementos usados//
Los modelos 3d, sound effects, imágenes y particulas fueron extraídos de la asset strore, y como base el tutorial "space shooter" de unity learn.
La música corresponde a:
  - Intro: Ground Zero - JDB Artist (licenced)
  - Main Menu: Stranded - JDB Artist (licenced)
  - Game: Game Theme Song - Feel for music - Ubisoft. Under fair use (education), tomada del juego 'Space Junkies'.
El diagrama de clases del alpha se encuentra en la carpeta de assets del proyecto
las imagenes del cómic son montajes de nuestra autoría. Los iconos de la tienda fueron extraídos de los siguientes links:
https://www.flaticon.es/icono-gratis/misil_2590312 ---> icono Misil, flaction
https://www.freepik.com/free-icon/repair-tools_767674.htm ---> icono Reparación, Freepick
https://iconos8.es/icon/999/cohete Icons

//Código//

La versión final cuenta con todo los añadido en el alpha (pool, vida y money). Se han añadido las sigueintes funcionalidades:
Hay tres managers en el proyecto, el Gamemanager que funciona como el mayor comunicador dentro del juego, adminsitra las olas de enemigos y 
los guarda el progreso del juego.También se encarga de cambiar los textos UI del juego. El playerManager se encarga adminsitrar al player, su 
salud, el daño que hace y tiene un par de métoso que le sirven para que la tienda le aumente los atributos a cambio del dinero requerido. el Shop manager, que te perminte comprar objetos y mejoras, Lo que hace es acceder a los atributos puestos en el gamemanager o en el 
PlayerManager a cambio del costo de dinero indicado que son datos numericos y los boost, como la vida, la capacidad de compustible etc..

Hay otros códigos importantes como el Player movement que se encarga del moviemitno y controles del player, y el enemy controller que es lo mismo peros solo para los enemgos 

//Posibles bugs//
- SE DEBE JUGAR EN PANTALLA COMPLETA,nuestro Ui se peude no ver si no esta en este modo-

//Cambios sobre el GDD//
Han habido numerosos cambios sobre el GDD.
Es de notar que el alcance del juego se ha visto muy disminuido por los limitantes de tiempo. Los más significativos son:
- La historia se ha reducido a los elementos más básicos, contada por medio de una corta historieta sin dialogos.
- El número de enemigos se ha reducido considerablemente.
- Las mecánicas sobre los modulos y diferentes armas se ha fusionado con la mecánica de la tienda y se han reemplazado las armas únicas por boosts. Los modulos se han omitido por completo en cuanto a su aplicación.

//Link Simmer//
https://simmer.io/@Stoltverd/shippy-mcshootface
--------------------------------------------------------------------------------------------------------------------
Alpha scripting

//Elementos usados//
Los modelos 3d, sound effects, imágenes y particulas fueron extraídos de la asset strore, y como base el tutorial "space shooter" de unity learn.
La música corresponde a:
  - Intro: Ground Zero - JDB Artist (licenced)
  - Main Menu: Stranded - JDB Artist (licenced)
  - Game: Game Theme Song - Feel for music - Ubisoft. Under fair use (education), tomada del juego 'Space Junkies'.
El diagrama de clases del alpha se encuentra en la carpeta de assets del proyecto

//Código//
Esta versión Alpha cuenta con un pool para los objetos que se instanciarían repetidamente en la escena: bolst del player, bolts enemigos y los asteroides
Desde el objeto Game manager se copntrolan cosaas como los hazards (asteroides), el conteo de los mimsos y las olas de estoos objetos, así fácilmente se  seterían dificultades
Los objetos vueleven al pool y hay controles de bugs para que algunos otros no se salgan de los límites usando boundarys
Hay conteo de puntos que se traducen en "money", y el player tener salud que si llega a cero deberá comenzar de nuevo


//Posibles bugs//
-Bugs de gameplay-
Hay un bug de gameplay en el que una ola de asteroides salgan filados en una sola línea perpendicualr al eje Z
El hud se puede perder si no se tiene el tamaño de pantalla adecuado
Es posible conseguir puntos "money" chocando contra objetos


//Link del build en simmer//
https://simmer.io/@TheMetz001/mcshootface

