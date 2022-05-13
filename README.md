# IA Proyecto Final
Este repositorio alberga el proyecto final de la asignatura de IAV del curso 21-22.

## Propuesta

Para el proyecto final se hará una IA parecida a la de los combates que se aprecian en los juegos de Pokémon, para ello se usará un sistema parecido al que tiene pokemon, pero más básico, como por ejemplo: se ignoraran las habilidades de los pokémon como pueden ser: intimidación , presión, bromista,... sin embargo si se tendrá en cuenta la diferencia de tipos, los tipos de ataque, la diferencia entre ataque físico y ataque especial.

Para ello nuestra IA simulará ser un lider de Gimnasio por lo que tendrá de 2 a 4 pokemons, como mínimo uno sera tipo Siniestro puro y como mínimo otro contará con un doble tipo y las consecuencias de esto. 

La IA se enfrentará a un equipo rival que a su vez constará de un mínimo de 2 pokemons y un máximo de 6 teniendo entre ellos uno con al menos uno de sus tipos debíl al tipo siniestro y otro contando con un tipo fuerte frente al tipo siniestro.

La IA tratará de ser capaz de plantar un combate complicado a su rival,de usar los ataque correctos en cada momento y deberá tener registrados tanto los ataques que ha usado su rival, cómo los que le quedan disponibles.

En este combaté se supondrá que no existen objetos curativos tales como pociones, revivir, mas PP o parecidos.

Además en un principio no se tendrán en cuenta ataques que puedan alterar las stats ni el estado del pokemon, aunque esto puede variar.

Se intentará hacer una base de datos relacional (SQL) que contendrá los datos de los pokemons, los movimientos, etc...

## Introducción

Pokémon es una franquicia que comenzó con la salida de dos juegos en 1996 *Pokémon Verde y Pokémon Rojo* tras su éxito se expandió a la creación de un anime, juegos de cartas, ropa, ...
Tanta ha sido la fama que ha conseguido Pokémon que incluso a día de hoy se usa para promover el turismo como es nombrar a ciertos pokémons embajadores de una perfectura, o cambiar las tapas de alcantarilla por unas decoradas con pokémons.

Lapras nombrado embajador de Miyagi   |  Tapas de alcantarilla
:-------------------------:|:-------------------------:
![Screenshot](AssetsREADME/LaprasMiyagi.jpg)  |  ![Screenshoot](AssetsREADME/UmbreonAlcantarilla.png)
[Información acerca de pokemon embajadores](https://local.pokemon.jp)| [Información acerca de tapas de alcantarillas](https://alfabetajuega.com/pokemon/alcantarillas-pokefuta)

Si deseas saber como empezó toda la franquicia de Pokémon te recomiendo que veas la [1º parte del monográfico de Pokémon de BaityBait](https://www.youtube.com/watch?v=1K_wJlkZ-YA), aunque lo hace de una forma sátirica y quizás poco profesional, explica muy bien como empezó toda esta franquicia y como se empezó a desarrollar.

La mecánica de los combates pokémon casi no ha variado desde sus inicios, en ellos se enfrentarán dos entrenadores(en ocasiones 4 entrenadores en combates de 2 vs 2) pokémon que contarán como mucho con 6 pokémons y que normalmente se enfrentan 1vs1 aunque hay variaciones en las que pueden luchar 2vs2 o incluso 3vs3 con una mecánica de rotación sin embargo en este proyecto nos centraremos en los combates 1vs1.

## Datos

Para almacenar los datos se pensó usar una base de datos relacional (SQL) con el siguiente esquema:
![Screenshot](AssetsREADME/BDDiagrama.png)

Para ello se usuarían los archivos que se pueden encontrar en [DBFiles](DBFiles/), se ejecutarían en el siguiente orden:

1. [CreateTables.sql](DBFiles/CreateTables.sql)
2. [Inserts.sql](DBFiles/Inserts.sql)

Sin embargo debido a la falta de conocimientos y la dificultad que suponia conectar la base de datos con el proyecto Unity se descartó y se pasó hacer una carga de datos mediante archivos JSON, para ellos se tendrán varios archivos JSON.

