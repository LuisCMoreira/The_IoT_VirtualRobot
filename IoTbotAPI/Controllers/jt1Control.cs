using Microsoft.AspNetCore.Mvc;
using IoTbotAPI.Models;

namespace IoTbotAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class jt1Control : ControllerBase
    {
            private string intdirec = "no data";

            private readonly botContext _context;

        public jt1Control(botContext context)
        {
            _context = context;
        }

        [HttpGet("count1")]
        public  int GetJT1Controls()
        {
            return  _context.JT1Control.Count();
        }


        [HttpGet(Name = "Getjt1Control")]
        public string GetJT1Control()
        {

            //var TDirec = await _context.TDirec.FindAsync(1);
            var JT1Control = _context.JT1Control.Last();


            if (JT1Control.data == null)
            {
                return "0";
            }
            else
            {
                if (JT1Control.data != null)
                {
                    intdirec=JT1Control.data; 
                }
            }

            return intdirec;
        }


    [HttpPost(Name = "Setjt1Control")]
    public async Task<ActionResult<JT1Control>> PostJT1Control(JT1Control JT1Control) //string? Post([FromBody]TDirec TDirec)
    {
        //_context.Dispose();

        

        if (_context.JT1Control.Count() > 0)
        {
        var Item =  _context.JT1Control.Last();
        _context.JT1Control.Remove(Item);
        }
        

        _context.JT1Control.Add(JT1Control);

        await _context.SaveChangesAsync();
        
        if (JT1Control.data != null)
        {
        
           intdirec=JT1Control.data; 
        
        }
    


    return CreatedAtAction(nameof(GetJT1Control), 1, JT1Control.data);
   
    }

    }
