using Backend_sithec.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Backend_sithec.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MockHumanoController : ControllerBase
    {
        private static readonly string[] Nombres = new[]
        {
            "Jazz", "Jessie", "Joss", "Júpiter", "Aimar", "Andra", "Cruz", "Denis", "Farah", "Gaby"
        };
        private static readonly string[] Sexos = new[]
        {
            "Masculino", "Femenino", "Binario"
        };
        private readonly ILogger<MockHumanoController> _logger;

        public MockHumanoController(ILogger<MockHumanoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Humano> GetMockHumano()
        {
            return Enumerable.Range(1, 5).Select(index => new Humano
            {
                Id = index,
                Nombre = Nombres[Random.Shared.Next(Nombres.Length)],
                Sexo = Sexos[Random.Shared.Next(Sexos.Length)],
                Edad = Random.Shared.Next(1, 80),
                Altura = Random.Shared.Next(1, 2) + Math.Round(Random.Shared.NextDouble(), 2),
                Peso = Random.Shared.Next(20, 90) + Math.Round(Random.Shared.NextDouble(), 2),
            })
             .ToArray();
        }
    }
}
