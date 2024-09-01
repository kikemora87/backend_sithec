using Microsoft.AspNetCore.Mvc;

namespace Backend_sithec.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperacionesController : ControllerBase
    {
        private readonly ILogger<OperacionesController> _logger;

        public OperacionesController(ILogger<OperacionesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetOperacion")]
        public String GetOperacion()
        {
            string Operador = Request.Headers.FirstOrDefault(x => x.Key == "Operador").Value;
            double val1 = Convert.ToDouble(Request.Headers.FirstOrDefault(x => x.Key == "Valor1").Value);
            double val2 = Convert.ToDouble(Request.Headers.FirstOrDefault(x => x.Key == "Valor2").Value);

            return Operation(val1, val2, Operador);
        }

        [HttpPost(Name = "PostOperacion")]
        public String PostOperacion(Double Valor1, Double Valor2, String Operador)
        {
            return Operation(Valor1, Valor2, Operador);
        }

        private String Operation(Double Valor1, Double Valor2, String Operador) {
            double result = 0;

            switch (Operador)
            {
                case "+":
                    result = Valor1 + Valor2;
                    break;
                case "-":
                    result = Valor1 - Valor2;
                    break;
                case "/":
                    result = Valor1 / Valor2;
                    break;
                case "*":
                    result = Valor1 * Valor2;
                    break;
                default:
                    return "El Operador no es Valido";
            }

            /*return Operador switch
            {
                "+" => Valor1 + Valor2,
                "-" => Valor1 - Valor2,
                _ => throw new System.NotImplementedException()
            };*/

            return "Resultado es: " + result;
        }
    }
}
