using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using VedaSystem.Domain.Enums;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Mappings;

namespace VedaSystem.Infra.Data.Context
{
    public class TradutorContext : DbContext
    {
        IWebDriver webDriver;
        public DbContextOptions<TradutorContext> _options;
        public TradutorContext(DbContextOptions<TradutorContext> options) : base(options) 
        {
            _options = options;
        }
        public DbSet<Tradutor> ConteudoPt { get; set; }

        public IWebDriver CreateWebDriver(Browser browser, string pathDriver)
        {
            try
            {
                switch (browser)
                {
                    case Browser.Firefox:
                        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(pathDriver);
                        webDriver = new FirefoxDriver(service);

                        break;
                    case Browser.Chrome:
                        ChromeOptions options = new ChromeOptions();
                        options.AddArguments("--headless");
                        webDriver = new ChromeDriver(pathDriver, options);
                        break;
                }
                return webDriver;
            }catch(Exception e)
            {
                throw e;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConteudoPtMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
