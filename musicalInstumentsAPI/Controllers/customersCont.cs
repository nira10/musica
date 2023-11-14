using Microsoft.AspNetCore.Mvc;
using musicalInstumentsAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace musicalInstumentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class customersCont : ControllerBase
    {
        private static List<Customers> _customers = new List<Customers>();
        public static int index = 0;


        // GET: api/<customers>
        [HttpGet]
        public List<Customers> Get()
        {
            return _customers;
        }

        // GET api/<customers>/5
        [HttpGet("{id}")]
        public Customers Get(int id)
        {
            for (int i = 0; i < index; i++)
            {
                if (_customers[i].id == id)
                    return _customers[i];
            }
            return null;
        }

        // POST api/<customers>
        [HttpPost]
        public void Post([FromBody] Customers c)
        {
            _customers.Add(new Customers { id = index++, name = c.name, phone = c.phone, address = c.address, lastPurchaseDate = c.lastPurchaseDate });
        }

        // PUT api/<customers>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customers c)
        {
            for (int i = 0; i < index; i++)
            {
                if (_customers[i].id == id)
                {
                    _customers[i].name = c.name;
                    _customers[i].address = c.address;
                    _customers[i].lastPurchaseDate = c.lastPurchaseDate;
                    _customers[i].phone = c.phone;

                }
            }
        }

        // DELETE api/<customers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach (Customers item in _customers)
            {
                if (item.id == id)
                {
                    _customers.Remove(item);
                    break;
                }
            }
        }
    }
}
