using iFalcao.WebCrawlerApp.Objetos;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;

namespace iFalcao.WebCrawlerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Portal ##The Enemy## - Crawler";
            using (var driver = new ChromeDriver(Helper.ChromeOptions))
            {
                driver.Navigate().GoToUrl("https://www.theenemy.com.br/");
                var noticias = driver.FindElementByClassName("news-list--big")
                    .FindElements(By.ClassName("news-list__item"));

                WrapperLeituraNoticias(() =>
                {
                    foreach (var elementoNoticia in noticias)
                    {
                        ExibirNoticia(new Noticia(elementoNoticia));
                    }
                });
            }
        }

        private static void WrapperLeituraNoticias(Action acaoLeitura)
        {
            Console.Clear();
            Console.WriteLine("INICIANDO LEITURA DAS NOTÍCIAS");
            Console.WriteLine("------------------------------");
            acaoLeitura.Invoke();
            Console.WriteLine("---------FIM DA LISTA DE NOTÍCIAS-----------");
            Console.WriteLine("APERTE QUALQUER TECLA PARA FINALIZAR O PROGRAMA");
            Console.ReadKey();
        }

        private static void ExibirNoticia(Noticia noticia)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(noticia.TextoNoticia);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(noticia.LinkNoticia);
            Console.ResetColor();
            MostrarOpcoes(noticia);
        }

        private static void MostrarOpcoes(Noticia noticia)
        {
            Console.WriteLine("[v]      - Ver Notícia no Chrome");
            Console.WriteLine("[outras] - Próxima Notícia");
            var teclaPressionada = Console.ReadKey();
            if (teclaPressionada.Key == ConsoleKey.V)
                AbrirNoticiaNavegador(noticia.LinkNoticia);
            Console.WriteLine("----------------------------------");
        }

        static void AbrirNoticiaNavegador(string link)
        {
            using (Process process = new Process())
            {
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = "chrome";
                process.StartInfo.Arguments = link;
                process.Start();
            }
        }
    }
}
