using Autos.Data;
using Autos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Autos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutosController : ControllerBase
    {

        private readonly AutosAPIDbContext db;
        public AutosController(AutosAPIDbContext dbContext)
        {
            this.db = dbContext;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rep = await db.Reparaciones.ToListAsync();

            AutoCliente auCl;

            List<Dictionary<string, string>> response = new List<Dictionary<string, string>>();

            for (int i = 0; i < rep.Count; i++)
            {

                Dictionary<string, string> obj = new Dictionary<string, string>();
                auCl = await db.AutoClientes.FindAsync(rep[i].AutoClienteID);

                Console.WriteLine(auCl);

                var auto = await db.Autos.FindAsync(auCl.AutoID);
                var cl = await db.Clientes.FindAsync(auCl.ClienteID);

                obj.Add("auto", auto.Modelo);
                obj.Add("cliente", cl.Name +" " + cl.LastName);
                obj.Add("km", rep[i].Km.ToString());
                obj.Add("patente", auCl.Patente);
                obj.Add("fecha", rep[i].Fecha.ToString());
                obj.Add("trabajo", rep[i].Trabajo);

                response.Add(obj);
            }
            return Ok(response);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
