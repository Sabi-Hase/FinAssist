
using System;
using Microsoft.Data.Sqlite;
using FinAssist.Data;
using FinAssist.Models;

namespace FinAssist.Services
{
    public static class UsuarioService
    {
        public static void CadastrarUsuario()
        {
            Console.Write("Nome do usuário: ");
            string nome = Console.ReadLine();
            Console.Write("Gastos (estimativa): ");
            double.TryParse(Console.ReadLine(), out double gastos);

            using(var conn = SQLiteContext.GetConnection())
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Usuarios (Nome, Gastos) VALUES (@nome, @gastos)";
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@gastos", gastos);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Usuário cadastrado!");
        }

        public static void ListarUsuarios()
        {
            using(var conn = SQLiteContext.GetConnection())
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Nome, Gastos FROM Usuarios";
                using(var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Console.WriteLine($"Id:{reader.GetInt32(0)} Nome:{reader.GetString(1)} Gastos:{reader.GetDouble(2)}");
                    }
                }
            }
        }
    }
}
