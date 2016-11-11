using Calculator.Api.Result;
using Calculator.Service;
using Calculator.Service.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Calculator.Api.Controllers
{
    [RoutePrefix("api/calculator")]
    [EnableCors("*", "*", "*")]
    public class CalculatorController : ApiController
    {
        private ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }
        public CalculatorController()
        {

        }

        // GET api/Calculator
        [HttpGet, Route("GetKeys"), EnableCors("*", "*", "*")]
        public char[][] Get()
        {
            return _calculatorService.GetCalculatorLayoutKeys();
        }

        // POST: api/Calculator
        [HttpPost,Route("EvaluateExpression"), EnableCors("*","*","*")]
        public IHttpActionResult EvaluateExpression([FromBody]MathExpression expression)
        {
            var expressionResult = _calculatorService.EvaluateExpression(expression);

            if (expressionResult == null) return new InvalidExpressionResult("Invalid Expression");

           return Ok(expressionResult);
        }

    }
}
