using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrelimCoop.Entities;

namespace PrelimCoop.Controllers
{
  
    public class ClientApiController : ControllerBase
    {
        public readonly NotadocoopContext _context;

        public ClientApiController(NotadocoopContext context)
        {
            _context = context;
        }
          [HttpGet]
        public IActionResult GetClients()
        {
            try
            {
                var clients = _context.ClientsInfoTbs.ToList();

                if (clients.Any())
                {
                    return Ok(clients);
                }

                else
                {
                    return Ok("No records found");
                }
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

    }
}