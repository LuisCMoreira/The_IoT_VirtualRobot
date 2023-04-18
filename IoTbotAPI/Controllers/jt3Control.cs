using Microsoft.AspNetCore.Mvc;
using IoTbotAPI.Models;

namespace IoTbotAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class jt3Control : ControllerBase
    {
            private string intdirec = "no data";

            private readonly botContext _context;

        public jt3Control(botContext context)
        {
            _context = context;
        }

        [HttpGet("count3")]
        public  int GetJT3Controls()
        {
            return  _context.JT3Control.Count();
        }


        [HttpGet(Name = "GetJT3state")]
        public string GetJT3Control()
        {

            //var TDirec = await _context.TDirec.FindAsync(1);
            var JT3Control = _context.JT3Control.Last();


            if (JT3Control.data == null)
            {
                return "0";
            }
            else
            {
                if (JT3Control.data != null)
                {
                    intdirec=JT3Control.data; 
                }
            }

            return intdirec;
        }


    [HttpPost(Name = "SetJT3state")]
    public async Task<ActionResult<JT3Control>> PostJT3Control(JT3Control JT3Control) //string? Post([FromBody]TDirec TDirec)
    {
        //_context.Dispose();

        

        if (_context.JT3Control.Count() > 0)
        {
        var Item =  _context.JT3Control.Last();
        _context.JT3Control.Remove(Item);
        }
        

        _context.JT3Control.Add(JT3Control);

        await _context.SaveChangesAsync();
        
        if (JT3Control.data != null)
        {
        
           intdirec=JT3Control.data; 
        
        }
    


    return CreatedAtAction(nameof(GetJT3Control), 1, JT3Control.data);
   
    }

    }
