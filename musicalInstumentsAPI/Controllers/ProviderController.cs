using Microsoft.AspNetCore.Mvc;
using The_piano_house.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace The_piano_house.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly DataContext _conect;
        public ProviderController(DataContext conect)
        {
            _conect = conect;
        }

        // GET: api/<ProviderController>
        [HttpGet]
        public List<Provider> Get()
        {
            return _conect.ProviderList ;
        }

        // GET api/<ProviderController>/5
        [HttpGet("{id}")]
        public ActionResult< Provider> Get(int id)
        {
            var ev = _conect.ProviderList.Find(e => e.id == id);

            if (ev == null)
                return NotFound();

            return ev;
        }
        // POST api/<ProviderController>
        [HttpPost]
        public ActionResult Post([FromBody] Provider p)
        {
            if (p.id.ToString().Length != 9)
                return BadRequest();

            _conect.ProviderList.Add(new Provider { id =p.id, name = p.name, phone = p.phone, address = p.address });
            return Ok();
        }

        // PUT api/<ProviderController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Provider p)
        {

            var ev = _conect.ProviderList.Find(e => e.id == id);

            if (ev == null)
                return NotFound();
                  ev.name = p.name;
                  ev.address = p.address;
                  ev.phone = p.phone;
                  
            return Ok();
                
            
        }

        // DELETE api/<ProviderController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var ev = _conect.ProviderList.Find(e => e.id == id);

            if (ev == null)
                return NotFound();
            _conect.ProviderList.Remove(ev);
            return Ok();

        }
    }
}
