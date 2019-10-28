using System;
using System.IO;
using Microsoft.Data.Sqlite; 

namespace ConsoleApplication1
{
    public class pruebaSqlite01
    {
        static SqliteConnection conexion;
        private static void CrearDB(String dbname)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./" + dbname;
            
                conexion =
                    new SqliteConnection(connectionStringBuilder.ConnectionString);

                conexion.Open();
        
        }
        private static void CrearTablas()
        {
            // Creamos la tabla Autor
            string sql = "CREATE TABLE IF NOT EXISTS autor (id INTEGER PRIMARY KEY, nombre VARCHAR(30));";

            SqliteCommand cmd = new SqliteCommand(sql, conexion);
            cmd.ExecuteNonQuery();

            // Creamos la tabla Libro

            sql = "CREATE TABLE  IF NOT EXISTS libro "
              + "(id INTEGER PRIMARY KEY, titulo VARCHAR(30));";
            cmd = new SqliteCommand(sql, conexion);

            cmd.ExecuteNonQuery();

            // Creamos la tabla Escribe

            sql = "CREATE TABLE IF NOT EXISTS escribe "
              + "(autor_id INTEGER REFERENCES autor, libro_id INTEGER REFERENCES libro ,"
              + " PRIMARY KEY(autor_id , libro_id));";
            cmd = new SqliteCommand(sql, conexion);

            cmd.ExecuteNonQuery();
        }
        private static void InsertarAutores()
        {

            string sql;             // Sentencia SQL
            SqliteCommand cmd;      // Comando de Sqlite
            int cantidad = 1;       // Resultado: cantidad de datos
            int i = 0;

            String[] rel = {"Juan Perez", "Juana", "Josefa" };

            try
            {
                while (i < 3 && cantidad > 0)
                {
                    sql = "INSERT INTO autor (nombre) VALUES ('" + rel[i] + "') ;";
                    cmd = new SqliteCommand(sql, conexion);

                    cantidad = cmd.ExecuteNonQuery();
                    if (cantidad < 1)
                        Console.WriteLine("No se han podido insertar los registros en la tabla autor");
                    ++i;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se ha podido insertar");
                Console.WriteLine("Posiblemente un código está repetido");
                Console.WriteLine("Error encontrado: {0} ", e.Message);

            }
        }
        private static void InsertarLibros()
        {

            string sql;             // Sentencia SQL
            SqliteCommand cmd;      // Comando de Sqlite
            int cantidad = 1;       // Resultado: cantidad de datos
            int i = 0;

            String[] rel = { "Las mil y una noches", "El arte de la guerra", "Cien años de soledad" };

            try
            {
                while (i < 3 && cantidad > 0)
                {
                    sql = "INSERT INTO libro (titulo) VALUES (' " + rel[i] + "');";

                    cmd = new SqliteCommand(sql, conexion);
                    cantidad = cmd.ExecuteNonQuery();

                    if (cantidad < 1)
                        Console.WriteLine("No se ha podido insertar en la tabla libro");
                    ++i;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No se ha podido insertar");
                Console.WriteLine("Posiblemente un código está repetido");
                Console.WriteLine("Error encontrado: {0} ", e.Message);

            }
        }
        private static void InsertarRelaciones()
        {

            string sql;             // Sentencia SQL SQL
            SqliteCommand cmd;      // Comando de Sqlite
            int cantidad = 1;       // Resultado: cantidad de datos
            int i = 0;

            String[] rel = { "(1,1)", "(1,2)", "(2,3)", "(3, 2)" };
            try
            {
                while (i < 4 && cantidad > 0)
                {
                    sql = "INSERT INTO escribe " +
                       "VALUES " + rel[i] + " ;";
                    cmd = new SqliteCommand(sql, conexion);

                    cantidad = cmd.ExecuteNonQuery();
                    if (cantidad < 1)
                        Console.WriteLine("No se ha podido insertar en la tabla escribe");
                    ++i;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se ha podido insertar");
                Console.WriteLine("Posiblemente un código está repetido");
                Console.WriteLine("Error encontrado: {0} ", e.Message);

            }
        }
        private static void MostrarAutores()
        {
            // Consulta para seleccionar autores
            string sql = "select id, nombre from autor";
            SqliteCommand cmd = new SqliteCommand(sql, conexion);

            SqliteDataReader datos = cmd.ExecuteReader();
            
            // Iteramos sobre el cursor
            while (datos.Read())
            {
                int id = Convert.ToInt32(datos[0]);

                string nombre = Convert.ToString(datos[1]);

                Console.WriteLine("ID: {0}, Nombre: {1}", id, nombre);
            }

        }
        private static void MostrarLibros()
        {
            // Consulta para seleccionar libros
            string sql = "select id, titulo from libro";
            SqliteCommand cmd = new SqliteCommand(sql, conexion);

            SqliteDataReader datos = cmd.ExecuteReader();
            
            // Iteramos sobre el cursor
            while (datos.Read())
            {
                int id = Convert.ToInt32(datos[0]);

                string titulo = Convert.ToString(datos[1]);

                Console.WriteLine("ID: {0}, Título: {1}", id, titulo);
            }

        }
        private static void MostrarRelaciones()
        {

            // Consulta JOIN
            string sql =
                "select autor.nombre, libro.titulo " +
                "from escribe INNER JOIN autor ON escribe.autor_id = autor.id " +
                "INNER JOIN libro ON escribe.libro_id = libro.id; "; 

            SqliteCommand cmd = new SqliteCommand(sql, conexion);
            SqliteDataReader datos = cmd.ExecuteReader();

            // Iteramos sobre el cursor
            while (datos.Read())
            {
                string autor = Convert.ToString(datos[0]);

                string libro = Convert.ToString(datos[1]);

                Console.WriteLine("{0} escribió  '{1}'", autor, libro);
            }

        }

        private static void CerrarDB()
        {
            conexion.Close();
        }

        public static void Main()
        {
            Console.WriteLine("Creando base de datos");
            CrearDB("libros.db");
            CrearTablas();

            Console.WriteLine("Cargando datos...");
            InsertarAutores();
            InsertarLibros();
            InsertarRelaciones();
            
            Console.WriteLine("Listado de Autores:");
            MostrarAutores();

            Console.WriteLine("Listado de Libros:");
            MostrarLibros();

            Console.WriteLine("Listado de autores y los libros que ha escrito:");
            MostrarRelaciones();

            CerrarDB();
        }

    }

}