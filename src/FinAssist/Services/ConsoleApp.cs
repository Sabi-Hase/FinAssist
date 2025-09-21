
using System;
using FinAssist.Services;

namespace FinAssist
{
    public class ConsoleApp
    {
        public void Run()
        {
            int opcao = -1;
            while(opcao != 0)
            {
                Console.WriteLine("\n=== FinAssist Menu ===");
                Console.WriteLine("1 - Cadastrar Usuário");
                Console.WriteLine("2 - Listar Usuários");
                Console.WriteLine("3 - Gerar Relatório");
                Console.WriteLine("4 - Sugestões de Atividades");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha: ");
                int.TryParse(Console.ReadLine(), out opcao);

                switch(opcao)
                {
                    case 1:
                        UsuarioService.CadastrarUsuario();
                        break;
                    case 2:
                        UsuarioService.ListarUsuarios();
                        break;
                    case 3:
                        RelatorioService.GerarRelatorio();
                        break;
                    case 4:
                        AtividadesAlternativasService.MostrarSugestoes();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}
