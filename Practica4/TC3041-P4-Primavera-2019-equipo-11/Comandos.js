#Alexandro Marcelo
#Andres Campos

#Crear repositorio

docker run --name influxdb -d -p 8086:8086 -v $PWD:/var/lib/influxdb influxdb

# Copiar el dataset al contenedor

docker cp DatosInvernadero.txt influxdb:/

# Conectarse al bash del contenedor

docker exec -it influxdb bash

# Importar el dataset en InfluxDB

influx -import -path=DatosInvernadero.txt -precision=s

#Conectarse a Grafana en otra terminal

docker run --name grafana -d -p 3000:3000 grafana/grafana
