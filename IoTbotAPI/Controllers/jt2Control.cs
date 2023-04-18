using Microsoft.AspNetCore.Mvc;
using IoTbotAPI.Models;

namespace IoTbotAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class jt2Control : ControllerBase
    {
            private string intdirec = "no data";

            private readonly botContext _context;

        public jt2Control(botContext context)
        {
            _context = context;
        }

        [HttpGet("count2")]
        public  int GetJT2Controls()
        {
            return  _context.JT2Control.Count();
        }


        [HttpGet(Name = "GetJT2state")]
        public string GetJT2Control()
        {

            //var TDirec = await _context.TDirec.FindAsync(1);
            var JT2Control = _context.JT2Control.Last();


            if (JT2Control.data == null)
            {
                return "0";
            }
            else
            {
                if (JT2Control.data != null)
                {
                    intdirec=JT2Control.data; 
                }
            }

            return intdirec;
        }


    [HttpPost(Name = "SetJT2state")]
    public async Task<ActionResult<JT2Control>> PostJT2Control(JT2Control JT2Control) //string? Post([FromBody]TDirec TDirec)
    {
        //_context.Dispose();

        

        if (_context.JT2Control.Count() > 0)
        {
        var Item =  _context.JT2Control.Last();
        _context.JT2Control.Remove(Item);
        }
        

        _context.JT2Control.Add(JT2Control);

        await _context.SaveChangesAsync();
        
        if (JT2Control.data != null)
        {
        
           intdirec=JT2Control.data; 
        
        }
    


    return CreatedAtAction(nameof(GetJT2Control), 1, JT2Control.data);
   
    }

    }
