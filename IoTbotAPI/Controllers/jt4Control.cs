using Microsoft.AspNetCore.Mvc;
using IoTbotAPI.Models;

namespace IoTbotAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class jt4Control : ControllerBase
    {
            private string intdirec = "no data";

            private readonly botContext _context;

        public jt4Control(botContext context)
        {
            _context = context;
        }

        [HttpGet("count4")]
        public  int GetJT4Controls()
        {
            return  _context.JT4Control.Count();
        }


        [HttpGet(Name = "GetJT4Control")]
        public string GetJT4Control()
        {

            //var TDirec = await _context.TDirec.FindAsync(1);
            var JT4Control = _context.JT4Control.Last();


            if (JT4Control.data == null)
            {
                return "0";
            }
            else
            {
                if (JT4Control.data != null)
                {
                    intdirec=JT4Control.data; 
                }
            }

            return intdirec;
        }


    [HttpPost(Name = "SetJT4state")]
    public async Task<ActionResult<JT4Control>> PostJT4Control(JT4Control JT4Control) //string? Post([FromBody]TDirec TDirec)
    {
        //_context.Dispose();

        

        if (_context.JT4Control.Count() > 0)
        {
        var Item =  _context.JT4Control.Last();
        _context.JT4Control.Remove(Item);
        }
        

        _context.JT4Control.Add(JT4Control);

        await _context.SaveChangesAsync();
        
        if (JT4Control.data != null)
        {
        
           intdirec=JT4Control.data; 
        
        }
    


    return CreatedAtAction(nameof(GetJT4Control), 1, JT4Control.data);
   
    }

    }
