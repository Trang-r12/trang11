using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

public class AuthenticationService
{
    private readonly string _connectionString = "Server=your_server;Database=your_db;User Id=your_user;Password=your_password;";

    public bool Login(string username, string password)
    {
        string hashedPassword = HashPassword(password);

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND PasswordHash = @Password";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }

    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
