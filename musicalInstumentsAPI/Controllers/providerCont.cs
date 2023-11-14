using Microsoft.AspNetCore.Mvc;
using musicalInstumentsAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace musicalInstumentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class providerCont : ControllerBase
    {
        private static List<Provider> _providers = new List<Provider>();
        public static int index = 0;
        // GET: api/<provider>
        [HttpGet]
        public List<Provider> Get()
        {
            return _providers;
        }

        // GET api/<provider>/5
        [HttpGet("{id}")]
        public Provider Get(int id)
        {
            for (int i = 0; i < index; i++)
            {
                if (_providers[i].id == id)
                    return _providers[i];
            }
            return null;
        }

        // POST api/<provider>
        [HttpPost]
        public void Post([FromBody] Provider c)
        {
            _providers.Add(new Provider { id = index++, name = c.name, phone = c.phone, address = c.address});
        }

        // PUT api/<provider>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Provider c)
        {
            for (int i = 0; i < index; i++)
            {
                if (_providers[i].id == id)
                {
                    _providers[i].name = c.name;
                    _providers[i].address = c.address;
                    _providers[i].phone = c.phone;

                }
            }
        }

        // DELETE api/<provider>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach (Provider item in _providers)
            {
                if (item.id == id)
                {
                    _providers.Remove(item);
                    break;
                }
            }
        }
    }
}
