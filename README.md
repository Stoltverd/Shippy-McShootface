# Shippy-McShootface
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


//posibles bugs//
-Bugs de gameplay-
Hay un bug de gameplay en el que una ola de asteroides salgan filados en una sola línea perpendicualr al eje Z
El hud se puede perder si no se tiene el tamaño de pantalla adecuado
Es posible conseguir puntos "money" chocando contra objetos

//Link del build en simmer//
https://simmer.io/@TheMetz001/mcshootface
