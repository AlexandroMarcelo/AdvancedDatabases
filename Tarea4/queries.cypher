#Alexandro Francisco Marcelo Gonzalez A01021383

#1
match(n:Estudiante) 
return n.nombre as Nombre, n.apellido as Apellido, n.matricula as Matricula 
order by n.apellido;

#2
match(n:Estudiante) 
where n.edad > 20
return n.nombre as Nombre, n.apellido as Apellido, n.edad as edad;

#3
Match (n)-[r:PAREJA_DE]->()
return n.nombre as Nombre, n.apellido as Apellido, n.edad as Edad, count(n.nombre) as Relaciones_totales;

#4
Match (n {nombre: 'Emerson'})-[r:PAREJA_DE]->(m)
unwind[
duration.between(date(r.inicioRelacion), date(r.finRelacion))
]as Duracion_Relacion
return m.nombre as Nombre, m.apellido as Apellido, m.edad as Edad, m.matricula as Matricula, Duracion_Relacion;

#5
Match (n)-[r:AMIGO_DE]->()
return n.nombre as Nombre, n.apellido as Apellido, count(n.matricula) as total_amigos
order by(total_amigos) desc limit 1;

#6
match(n)
where not (n)-[:PAREJA_DE]->()
return n.nombre as Nombre, n.apellido as Apellido, n.matricula as Matricula;

#7
Match (n)-[r:PAREJA_DE]->()
with n, count(n.nombre) as Total_parejas
where Total_parejas > 3
return n.nombre as Nombre, n.apellido as Apellido, n.matricula as Matricula, Total_parejas;

#8
Match (n {nombre: 'Lucy'})-[r:CONOCE_A]->()
return n.nombre as Nombre, n.apellido as Apellido, n.matricula as Matricula, count(n) as Conoce_personas;

#9
Match (n:Estudiante)-[r:CONOCE_A]->(m:Estudiante {nombre: 'Moana'})
return n.nombre as Nombre, n.apellido as Apellido, n.matricula as Matricula;
