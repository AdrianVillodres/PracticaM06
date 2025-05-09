using System;
using Npgsql;

namespace cat.itb.store_VillodresAdrian.connections
{
    public class SQLConnection
    {
        private String HOST = "postgresql-adrianvillodres.alwaysdata.net"; // Ubicació de la BD.
        private String DB = "adrianvillodres_practica"; // Nom de la BD.
        private String USER = "adrianvillodres";
        private String PASSWORD = "pyraforsmash";

        // Specify connection options and open an connection
        public NpgsqlConnection conn = null;

        public NpgsqlConnection GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(
                "Host=" + HOST + ";" + "Username=" + USER + ";" +
                "Password=" + PASSWORD + ";" + "Database=" + DB + ";"
            );
            conn.Open();
            return conn;
        }
    }
}