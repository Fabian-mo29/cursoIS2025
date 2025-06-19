using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    public class Selenium
    {
        IWebDriver _driver;


        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();
        }

        [Test]
        public void Enter_To_List_Of_Countries_Test()
        {
            // Arrange
            // Abre una ventana
            var URL = "http://localhost:8080/";

            // Maximiza la pantalla
            _driver.Manage().Window.Maximize();

            // Act
            // Navega a la pagina que necesita probar
            _driver.Navigate().GoToUrl(URL);

            // Assert
            Assert.IsNotNull(_driver);
        }

        [Test]
        public void Add_Country_To_List_Form()
        {
            var URL = "http://localhost:8080/pais";
            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl(URL);

            var inputName = _driver.FindElement(By.Id("name"));
            inputName.Clear();
            inputName.SendKeys("Uruguay");

            var selectContinente = new SelectElement(_driver.FindElement(By.Id("continente")));
            selectContinente.SelectByText("América");

            var inputIdioma = _driver.FindElement(By.Id("idioma"));
            inputIdioma.Clear();
            inputIdioma.SendKeys("Español");

            var submitButton = _driver.FindElement(By.Id("submit"));
            submitButton.Click();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url == "http://localhost:8080/");

            var listaPaises = wait.Until(d => d.FindElement(By.TagName("table")));
            var filas = listaPaises.FindElements(By.TagName("tr"));

            bool encontrado = false;

            foreach (var fila in filas)
            {
                if (fila.Text.Contains("Uruguay") &&
                    fila.Text.Contains("América") &&
                    fila.Text.Contains("Español"))
                {
                    encontrado = true;
                    break;
                }
            }

            Assert.IsTrue(encontrado);

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}