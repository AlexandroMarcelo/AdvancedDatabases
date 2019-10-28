#include <stdio.h>
#include <sqlite3.h>

int main(int argc, char **argv){
    
	sqlite3 *conexion;
	sqlite3_stmt *sql;
	
	int error = 0;
	int count = 0;
	
	const char * res;
	
	error = sqlite3_open("./libros.db", &conexion);
	
	if (error != SQLITE_OK) {
		printf("No se puede establecer la conexión");
		return 1;
	}
	
	error = sqlite3_prepare_v2(conexion, "select * from libro", 100, &sql, &res);
	
	if (error != SQLITE_OK) {
		printf("Error en el prepare");
		return 1;
	}
	
	while (sqlite3_step(sql) == SQLITE_ROW) 
	{
		printf("%d | ", sqlite3_column_int(sql,0));
		printf("%s \n ", sqlite3_column_text(sql,1));
	}
	
	sqlite3_finalize(sql);
	sqlite3_close(conexion);
  }
  

       