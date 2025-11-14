using Npgsql;

namespace GerenciadorEbonyArtes.Services
{
    public static class Database
    {
        private static string _connectionString =
        "Host=localhost;Port=5432;Username=postgres;Password=?;Database=db_ebonyartes";

        public static NpgsqlConnection GetConnection()
        {
            var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            return conn;
        }
    }
}