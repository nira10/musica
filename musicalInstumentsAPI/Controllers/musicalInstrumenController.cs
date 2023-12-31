﻿using Microsoft.AspNetCore.Mvc;
using musicalInstumentsAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace musicalInstumentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaLInstrumentController : ControllerBase
    {
        private readonly DataContext _conect;
        public MusicaLInstrumentController(DataContext conect)
        {
            _conect = conect;
        }
        // GET: api/<MusicaLInstrumentController>
        [HttpGet]
        public List<MusicalInstrumen> Get()
        {
            return _conect.MusicaLInstrumentList;
        }

        // GET api/<MusicaLInstrumentController>/5
        [HttpGet("{id}")]
        public ActionResult<MusicalInstrumen> Get(int id)
        {
            var ev = _conect.MusicaLInstrumentList.Find(e => e.code == id);

            if (ev == null)
                return NotFound();

            return ev;
        }

        // POST api/<MusicaLInstrumentController>
        [HttpPost]
        public void Post([FromBody] MusicalInstrumen m)
        {

            _conect.MusicaLInstrumentList.Add(new MusicalInstrumen { code = _conect.index++, name = m.name, manufacturer = m.manufacturer, costPrice = m.costPrice, purchasePrice = m.purchasePrice, stockpile = m.stockpile, providerCode = m.providerCode });
        }

        // PUT api/<MusicaLInstrumentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MusicalInstrumen m)
        {
            var ev = _conect.MusicaLInstrumentList.Find(e => e.code == id);

            if (ev == null)
                return NotFound();
            ev.name = m.name;
            ev.manufacturer = m.manufacturer;
            ev.costPrice = m.costPrice;
            ev.purchasePrice = m.purchasePrice;
            ev.stockpile = m.stockpile;
            ev.providerCode = m.providerCode;
            return Ok();

        }

        // DELETE api/<MusicaLInstrumentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var ev = _conect.MusicaLInstrumentList.Find(e => e.code == id);

            if (ev == null)
                return NotFound();
            _conect.MusicaLInstrumentList.Remove(ev);
            return Ok();
        }
    }
}
