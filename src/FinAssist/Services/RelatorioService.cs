
using System.IO;
using System;
namespace FinAssist.Services
{
    public static class RelatorioService
    {
        public static void GerarRelatorio()
        {
            string relatorio = $"Relatório gerado em {DateTime.Now}";
            File.WriteAllText("relatorio.txt", relatorio);
            Console.WriteLine("Relatório salvo em relatorio.txt");
        }
    }
}
