#Alexandro Francisco Marcelo Gonzalez A01021383

#en una terminal iniciamos el nodo

docker run --name=neo4j -m=4g --publish=7474:7474 --publish=7687:7687 --volume=$HOME/neo4j/data:/data --env=NEO4J_AUTH=none neo4j

#otra terminal

docker cp estudiantes.csv neo4j:/var/lib/neo4j/import/
docker cp conoce_a.csv neo4j:/var/lib/neo4j/import/
docker cp pareja_de.csv neo4j:/var/lib/neo4j/import/
docker cp amigo_de.csv neo4j:/var/lib/neo4j/import/

#conectarse a localhost:7474 e importar los nodos y sus relaciones

USING PERIODIC COMMIT
LOAD CSV WITH HEADERS FROM "file:/estudiantes.csv" AS row
CREATE (:Estudiante {estudianteNo: row.estudianteNo, nombre: row.nombreEstudiante, apellido: row.apellidoEstudiante, edad: toInteger(row.edadEstudiante), matricula: row.matriculaEstudiante}); 

CREATE INDEX ON :Estudiante(estudianteNo);

LOAD CSV WITH HEADERS FROM "file:/conoce_a.csv" AS row
MATCH (start:Estudiante {estudianteNo: row.StartId})   
MATCH (end:Estudiante {estudianteNo: row.EndId})
MERGE (start)-[:CONOCE_A]->(end);

LOAD CSV WITH HEADERS FROM "file:/amigo_de.csv" AS row
MATCH (start:Estudiante {estudianteNo: row.StartId})   
MATCH (end:Estudiante {estudianteNo: row.EndId})
MERGE (start)-[:AMIGO_DE]->(end);

LOAD CSV WITH HEADERS FROM "file:/pareja_de.csv" AS row
MATCH (start:Estudiante {estudianteNo: row.StartId})   
MATCH (end:Estudiante {estudianteNo: row.EndId})
MERGE (start)-[:PAREJA_DE {inicioRelacion: row.inicioRelacion, finRelacion: row.finRelacion}]->(end);
