using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Blog.Models;
using Blog.Repositories;
using Dapper;
using Blog.Screens;

namespace Blog
{
    class Program
    {
        static private string connectionString = "Server=localhost,1433;Database=Blog;User ID=sa;Password=password;Trusted_Connection=False; TrustServerCertificate=True;";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Bem Vindo ao Blog!");
                using (var connection = new SqlConnection(connectionString))
                {
                    CScreens screens = new CScreens(connection);
                    screens.HomeScreen();
                }
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
            