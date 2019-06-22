using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace iFalcao.WebCrawlerApp.Objetos
{
    public class Noticia
    {
        public Noticia(IWebElement webElement)
        {
            this.ConteudoNoticia = webElement.FindElement(By.ClassName("news-list__item__content"));
            this.AnchorTagNoticia = this.ConteudoNoticia.FindElement(By.TagName("a"));
            this.LinkNoticia = this.AnchorTagNoticia.GetAttribute("href");
            this.TextoNoticia = this.AnchorTagNoticia.Text;
        }

        public IWebElement ConteudoNoticia { get; private set; }
        public IWebElement AnchorTagNoticia { get; private set; }
        public string TextoNoticia { get; private set; }
        public string LinkNoticia { get; private set; }


        public void ExibirNoticia()
        {
            
        }
    }
}
