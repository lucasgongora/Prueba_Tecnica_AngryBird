# Prueba_Tecnica_AngryBird

- Se realizó una copia muy simple del juego AngryBirds para realizarle algunas funcionalidades extras al prototipo.

- El prototipo base solo contenia la escena de Game con un solo personaje de ave para lanzar contra las cajas y enemigos.

- En primera instancia se generaron las escenas de Inicio y CharacterSelection, para que el usuario elija entre 3 personajes para jugar.
	* El personaje principal no tiene ninguna funcionalidad especial mas que el impacto directo.
	* El segundo personaje (Bomb) luego de lanzarlo tiene un pequeño retardo hasta que explota, generando 		daño no solo con su impacto directo sino tambien con su misma explosion.
	* El tercer personaje (Blue) a unos pocos instantes de ser lanzado se clona en el aire 2 veces, dejando 		como resultado 3 aves lanzadas hacia los enemigos, con las mismas capacidades de daño.
- En la escena de Inicio se colocó un fondo caracteristico del juego Angry Birds y un simple botón para cargar la siguiente escena de seleccion de personaje.

- En la segunda escena, ademas de buscar otro fondo y difuminarlo para el background, se utilizaron 3 ilustraciones de la pelicula de Angry Birds para los 3 personajes que van alternando con cada TAP que se ahce en la pantalla mayormente del lado derecho. En el extremo izquierdo de la pantalla, centrado, se colocó un botón simple para cargar la tercer y ultima escena, la de Game; que por medio de codigo se lleva el dato de seleccion de personaje desde la escena de Seleccion a la escena de Game para cargar el personaje correspondiente.

- En la tercer escena se generaron la mayoria de los scripts para las mecanicas de todo el juego. Se fueron creando individualmente para cada accion para luego ir unificando todo en menos scripts.
	* Asi se redujo de tener scrips para cada boton de cada escena a tener un solo script (SceneController) 		para todas las escenas.
	* Todas las variables serializadas se hicieron privadas para no ser modificadas desde otros scripts y 	para ser chequedas desde el inspector durante el desarrollo del juego.
 	* Se trató de respetar la regla "camelCase" para variables, "PascalCase" para los métodos(funciones), 	etiquetas y nombres de los elementos en la Jerarquia.
	* Se corrigieron todas las nomenclaturas para que mantengan un solo idioma (inglés), sin tener 	asignaciones en diferentes idiomas.
	* Se renombraron variables que no ayudaban a la identificacion inmediata con su simple lectura. Como por 	ejemplo "prefabCharacterDivisible1" y "prefabBomb". Ambas al leerlas ya se identifica a que elemento se 	refiere en el proyecto.

- Se destaca la falta de atlas en la carpeta de Sprites. Se sabe que la mejor forma de ordenar la parte grafica de un proyecto 2D es tener todos los elementos en un atlas de donde se obtengan todos los sprites juntos.

- Las carpetas se fueron creando desde el primer momento para su uso durante el desarrollo del juego segun ameritaba la necesidad debido a buenas prácticas aprendidas.

- Se buscó distribuir de la mejor forma los prefabs fijos en Jerarquia como hijos de un GameObject padre correspondiente, otros prefabs cargados manualmente en el Inspector y por último los prefabs cargados automaticamente por script.

- Se redujeron lineas de codigo unificando instrucciones que se hicieron de a partes al principio por una cuestion de ir resolviendo los puntos requeridos.

- La seleccion de characters en el script "CharacterSelection" la había realizado con codigo muy literal y poco profesional, Quedando muchas lineas de codigo para una función muy sencilla. Por esto se investigó un mejor método para optimizar el script y reducirlo al actual.

- Se agregó un boton con la imagen del personaje principal en la escena de Game para hacer mas práctico el testeo del proyecto. Su funcion simplemente es la de volver a cargar la escena anterior.

- Las animaciones de los puntos en el momento de la destruccion de objetos está hecha de manera muy simple pero funcional.

- Finalmente se agregó un script ScoreManager para manejar el puntaje en la UI independiente de los demas scripts pensando en que sea un proyecto escalable.

- Se agregaron cajas, tablas y mas enemigos para persibir mejor los efectos agregados en los personajes y las funcionalidades con animaciones.


****************************** ACLARACION PERSONAL ***********************************
Personalmente con mas tiempo disponible, ademas de cumplir con items faltantes, mejoraria varios puntos como:
* Realizaria el diagrama UML.
* Mostraria los puntos con un texto animado mas acorde al arte del juego.
* Sumaria animaciones tambien a los personajes agregados.
* Agregaria sonidos
* Sumaría etapas
* Concluiría efectivamente la funcionalidad delave que se divide en 3 direcciones separadas.
* Agregaria animaciones entre etapas para mostrar la evolucion del usuario.