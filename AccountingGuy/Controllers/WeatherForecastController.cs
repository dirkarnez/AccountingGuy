using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLedger;
using NLedger.Accounts;
using NLedger.Amounts;
using NLedger.Extensibility.Net;
using NLedger.Values;

namespace AccountingGuy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet]
        public long Get()
        {
            return ABC();
        }

        private long ABC()
        {
            using (var session = NetSession.CreateStandaloneSession())
            {
                //var eur = CommodityPool.Current.FindOrCreate("EUR");
                //var totalEur = new Amount("0.00 EUR");

                Account account = new Account();
                account.XData.Visited = true;

                Post post1 = new Post();
                post1.XData.Visited = true;
                post1.Amount = new Amount(20); ;

                Post post2 = new Post();
                post2.XData.Visited = true;
                post2.Amount = new Amount(20);

                account.Posts.Add(post1);
                account.Posts.Add(post2);

                Value value = account.Amount();

                return value.AsLong;
            }


            //Assert.False(Value.IsNullOrEmpty(value));
            //Assert.Equal(30, value.AsLong);
            //Assert.Equal(30, account.XData.SelfDetails.Total.AsLong);

            //Assert.True(post1.XData.Considered);
            //Assert.True(post2.XData.Considered);
        }
    }
}
