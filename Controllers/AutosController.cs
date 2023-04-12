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
            List<Dictionary<string, string>> response = new List<Dictionary<string, string>>();
            foreach (var re in rep)
            {
                Dictionary<string, string> obj = new Dictionary<string, string>();
                //var auCl = await db.AutoClientes.FindAsync(re.Id);
                //Console.WriteLine(auCl.AutoID.ToString());
                //Console.WriteLine(auCl.ClienteID.ToString());

                
                var auto = await db.Autos.FindAsync(1);
                var cl = await db.Clientes.FindAsync(1);


                obj.Add("auto", auto.Modelo);
                obj.Add("cliente", cl.Name + cl.LastName);
                obj.Add("km", re.Km.ToString());
                //response.Add("patente", auCl.Patente);
                obj.Add("fecha", re.Fecha.ToString());
                obj.Add("trabajo", re.Trabajo);

                //foreach (KeyValuePair<string, string> kvp in obj)
                //{
                //    Console.WriteLine(kvp);
                //}

                response.Add(obj);

                obj.Clear();
            }
            foreach (var item in response)
            {
                foreach (KeyValuePair<string, string> kvp in item)
                {
                    Console.WriteLine(kvp);
                }
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
