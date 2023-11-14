using Microsoft.AspNetCore.Mvc;
using The_piano_house.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace The_piano_house.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _conect;
        public CustomersController(DataContext conect)
        {
            _conect = conect;
        }


        // GET: api/<CustomersController>
        [HttpGet]
        public List<Customers> Get()
        {
            return _conect.CustomersList;
        }


        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult< Customers> Get(int id)
        {
            var ev = _conect.CustomersList.Find(e => e.id == id);

            if (ev == null)
                return NotFound();

                return ev;
        }


        // POST api/<CustomersController>
        [HttpPost]
        public ActionResult Post([FromBody] Customers c)
        {
            if (c.id.ToString().Length != 9)
                return BadRequest();
            _conect.CustomersList.Add(new Customers { id =c.id,name=c.name,phone=c.phone,address=c.address,lastPurchaseDate=c.lastPurchaseDate  });
            return Ok();
        }


        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Customers c)
        {


            var ev = _conect.CustomersList.Find(e => e.id == id);

            if (ev == null)
                return NotFound();
            ev.name = c.name;
            ev.address = c.address;
            ev.lastPurchaseDate= c.lastPurchaseDate;
            ev.phone= c.phone;
         
            
             return Ok();
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var ev = _conect.CustomersList.Find(e => e.id == id);

            if (ev == null)
                return NotFound();             
          _conect.CustomersList.Remove(ev);
            return Ok();      
                
            
        }
    }
}
