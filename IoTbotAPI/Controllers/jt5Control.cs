using Microsoft.AspNetCore.Mvc;
using IoTbotAPI.Models;

namespace IoTbotAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class jt5Control : ControllerBase
    {
            private string intdirec = "no data";

            private readonly botContext _context;

        public jt5Control(botContext context)
        {
            _context = context;
        }

        [HttpGet("count5")]
        public  int GetJT5Controls()
        {
            return  _context.JT5Control.Count();
        }


        [HttpGet(Name = "GetJT5state")]
        public string GetJT5Control()
        {

            //var TDirec = await _context.TDirec.FindAsync(1);
            var JT5Control = _context.JT5Control.Last();


            if (JT5Control.data == null)
            {
                return "0";
            }
            else
            {
                if (JT5Control.data != null)
                {
                    intdirec=JT5Control.data; 
                }
            }

            return intdirec;
        }


    [HttpPost(Name = "SetJT5state")]
    public async Task<ActionResult<JT5Control>> PostJT5Control(JT5Control JT5Control) //string? Post([FromBody]TDirec TDirec)
    {
        //_context.Dispose();

        

        if (_context.JT5Control.Count() > 0)
        {
        var Item =  _context.JT5Control.Last();
        _context.JT5Control.Remove(Item);
        }
        

        _context.JT5Control.Add(JT5Control);

        await _context.SaveChangesAsync();
        
        if (JT5Control.data != null)
        {
        
           intdirec=JT5Control.data; 
        
        }
    


    return CreatedAtAction(nameof(GetJT5Control), 1, JT5Control.data);
   
    }

    }
