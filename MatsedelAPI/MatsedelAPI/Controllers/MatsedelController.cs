using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.Diagnostics.Eventing.Reader;
using HtmlAgilityPack;

namespace MatsedelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatsedelController : Controller
    {
        MySqlConnection connection =
            new MySqlConnection("server=localhost;uid=root;pwd=;database=teknikum - matsedel");

        [HttpGet]
        public ActionResult<List<Matsedel>> GetMatsedel()
        {
            List<Matsedel> matsedlar = new List<Matsedel>();
            try
            {
                connection.Open();
                MySqlCommand query = connection.CreateCommand();
                query.Prepare();
                query.CommandText = "SELECT * FROM maträtt";
                MySqlDataReader data = query.ExecuteReader();
                
                while (data.Read())
                {
                    Matsedel maträtt = new Matsedel();
                    maträtt.Id = data.GetInt32("Id");
                    maträtt.namn = data.GetString("namn");
                    maträtt.datum = data.GetString("datum");
                    matsedlar.Add(maträtt);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Något gick snett med databsen ¯\\_(ツ)_/¯");
            }
            
            return Ok(matsedlar);
        }        
    }    
}
