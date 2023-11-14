using Microsoft.AspNetCore.Mvc;
using musicalInstumentsAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace musicalInstumentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class musicalInstrumenCont : ControllerBase
    {
        private static List<MusicalInstrumen> _musicalInstrumens = new List<MusicalInstrumen>();
        public static int index = 0;

        // GET: api/<musicalInstrumen>
        [HttpGet]
        public List<MusicalInstrumen> Get()
        {
            return _musicalInstrumens;
        }

        // GET api/<musicalInstrumen>/5
        [HttpGet("{id}")]
        public MusicalInstrumen Get(int id)
        {
            for (int i = 0; i < index; i++)
            {
                if (_musicalInstrumens[i].code == id)
                    return _musicalInstrumens[i];
            }
            return null;
        }

        // POST api/<musicalInstrumen>
        [HttpPost]
        public void Post([FromBody] MusicalInstrumen c)
        {
            _musicalInstrumens.Add(new MusicalInstrumen { code = index++, name = c.name, manufacturer = c.manufacturer, costPrice = c.costPrice, purchasePrice = c.purchasePrice, stockpile = c.stockpile, providerCode = c.providerCode });
        }

        // PUT api/<musicalInstrumen>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MusicalInstrumen c)
        {
            for (int i = 0; i < index; i++)
            {
                if (_musicalInstrumens[i].code == id)
                {
                    _musicalInstrumens[i].name = c.name;
                    _musicalInstrumens[i].manufacturer = c.manufacturer;
                    _musicalInstrumens[i].costPrice = c.costPrice;
                    _musicalInstrumens[i].purchasePrice = c.purchasePrice;
                    _musicalInstrumens[i].stockpile = c.stockpile;
                    _musicalInstrumens[i].providerCode = c.providerCode;

                }
            }
        }

        // DELETE api/<musicalInstrumen>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach (MusicalInstrumen item in _musicalInstrumens)
            {
                if (item.code == id)
                {
                    _musicalInstrumens.Remove(item);
                    break;
                }
            }
        }
    }
}