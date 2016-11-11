using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Api.Controllers;
using Calculator.Service;
using Calculator.Service.Models;
using System.Web.Http.Results;
using Microsoft.Owin.Hosting;
using System.Net.Http;
using System.Threading.Tasks;

namespace Calculator.Api.Tests
{
    [TestClass]
    public class CalculatorApiTests
    {
        private static IDisposable _webApp;
        private const string baseUri = "http://localhost:65105";

        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            _webApp = WebApp.Start<Startup>(baseUri);
        }

        [AssemblyCleanup]
        public static void TearDown()
        {
            _webApp.Dispose();
        }


        [TestMethod]
        public void TestMathExpression_ShouldProvideCorrectSum()
        {
            // Arrange
            var calcService = new CalculatorService();
            var controller = new CalculatorController(calcService);

            // Act
            var expression = controller.EvaluateExpression(new MathExpression
            {
                Expression = "2+4"
            });

            var contentResult = expression as OkNegotiatedContentResult<MathExpression>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
          //  Assert.IsTrue(contentResult.Content.Key.HasValue);
            Assert.AreEqual(6, contentResult.Content.Key);

        }

        [TestMethod]
        public async Task TestMathExpression_ApiUriShouldWork()
        {

            string controller = "api/calculator/evaluateexpression";
            var mathExpression = new MathExpression() { Expression = "1+2" };

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUri);
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await httpClient.PostAsJsonAsync(controller, mathExpression);

                Assert.IsNotNull(response);
                Assert.IsTrue(response.IsSuccessStatusCode);

                var x = await response.Content.ReadAsAsync<MathExpression>();

                Assert.IsNotNull(x);
                Assert.IsNotNull(x.Key);
                Assert.AreEqual(3, x.Key);

            }
        }
    }
}
