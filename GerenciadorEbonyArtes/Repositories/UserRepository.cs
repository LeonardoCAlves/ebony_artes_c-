using Avalonia.Controls.Documents;
using GerenciadorEbonyArtes.Services;
using Npgsql;


namespace GerenciadorEbonyArtes.Repositories
{
    public class userRepository
    {
        public bool ValidateLogin(string username, string password)
        {
            using var conn = Database.GetConnection();

            string sql = @"
            SELECT COUNT(*)
            FROM usuarios
            WHERE username = @u
                AND senha = crypt(@p, senha)";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);

            long count = (long)cmd.ExecuteScalar();
            return count > 0;

        }
    }
}