using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace Automacao
{
    public class UnitTest1
    {
        public object ExpectedConditions { get; private set; }

        [Fact]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            
            driver.Navigate().GoToUrl("https://localhost:44329/");
            driver.Manage().Window.Maximize();

            var titulo = driver.FindElement(By.XPath("/html/body/div[3]/h2"));
            Assert.True(titulo.Displayed);
            Assert.Equal(titulo.Text.ToLower(), "Teste Desenvolvedor W12".ToLower());

            var botao = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/p[2]/a"));
            Assert.True(botao.Displayed);
            Assert.Equal(botao.Text.ToLower(), "Visite a documentação".ToLower());
            
            driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/table/tbody/tr[2]/td[5]/a")).Click();

            var cabecalho2 = driver.FindElement(By.XPath("/html/body/div[3]/h2"));
            Assert.True(cabecalho2.Displayed);
            Assert.Equal(cabecalho2.Text.ToLower(), "Detalhe".ToLower());

            var coluna1 = driver.FindElement(By.XPath("/html/body/div[3]/table/tbody/tr/th"));
            Assert.True(coluna1.Displayed);
            Assert.Equal(coluna1.Text.ToLower(), "Repositório".ToLower());

            var atualizacao = driver.FindElement(By.XPath("/html/body/div[3]/table/thead/tr/th[5]"));
            Assert.True(atualizacao.Displayed);
            Assert.Equal(atualizacao.Text.ToLower(), "Ultima Atualização".ToLower());
           
            var nome = driver.FindElement(By.XPath("/html/body/div[3]/table/tbody/tr/td[1]"));
            Assert.True(nome.Displayed);
            Assert.Equal(nome.Text.ToLower(), "AcessibilidadeWeb".ToLower());

            var linguagem = driver.FindElement(By.XPath("/html/body/div[3]/table/tbody/tr/td[3]"));
            Assert.True(linguagem.Displayed);
            Assert.Equal(linguagem.Text.ToLower(), "HTML".ToLower());

            var horario = driver.FindElement(By.XPath("/html/body/div[3]/table/tbody/tr/td[4]"));
            Assert.True(horario.Displayed);
            Assert.Equal(horario.Text.ToLower(), "23/08/2020 21:04:06 +00:00".ToLower());

            driver.Quit();

        }
    }
}
