using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace iFalcao.WebCrawlerApp
{
    public class Helper
    {
        public static ChromeOptions ChromeOptions
        {
            get
            {
                var options = new ChromeOptions();
                options.AddArguments(new List<string>()
                {
                    "--silent-launch",
                    "--no-startup-window",
                    "--ignore-certificate-errors",
                    "no-sandbox",
                    "headless"
                });
                return options;
            }
        }
    }
}
