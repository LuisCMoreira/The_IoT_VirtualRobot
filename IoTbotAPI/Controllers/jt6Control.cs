using Microsoft.AspNetCore.Mvc;
using IoTbotAPI.Models;

namespace IoTbotAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class jt6Control : ControllerBase
    {
            private string intdirec = "no data";

            private readonly botContext _context;

        public jt6Control(botContext context)
        {
            _context = context;
        }

        [HttpGet("count6")]
        public  int GetJTnControls()
        {
            return  _context.JT6Control.Count();
        }


        [HttpGet(Name = "GetJT6state")]
        public string GetJT6Control()
        {

            //var TDirec = await _context.TDirec.FindAsync(1);
            var JT6Control = _context.JT6Control.Last();


            if (JT6Control.data == null)
            {
                return "0";
            }
            else
            {
                if (JT6Control.data != null)
                {
                    intdirec=JT6Control.data; 
                }
            }

            return intdirec;
        }


    [HttpPost(Name = "SetJT6state")]
    public async Task<ActionResult<JT6Control>> PostJT6Control(JT6Control JT6Control) //string? Post([FromBody]TDirec TDirec)
    {
        //_context.Dispose();

        

        if (_context.JT6Control.Count() > 0)
        {
        var Item =  _context.JT6Control.Last();
        _context.JT6Control.Remove(Item);
        }
        

        _context.JT6Control.Add(JT6Control);

        await _context.SaveChangesAsync();
        
        if (JT6Control.data != null)
        {
        
           intdirec=JT6Control.data; 
        
        }
    


    return CreatedAtAction(nameof(GetJT6Control), 1, JT6Control.data);
   
    }

    }
