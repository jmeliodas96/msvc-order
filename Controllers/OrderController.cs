using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using msvc_order.Controllers;
using msvc_order.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;


namespace msvc_order.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly BakeryContext db;  
        public OrderController(BakeryContext db) => this.db = db; 
        
        public Product Product { get; set; }

        //api/order/create
        [HttpPost]
        [EnableCors("AnotherPolicy")]
        [ActionName("create")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<Order>> Create([FromBody] Order order)
        {
     
            //insert Order
            db.Orders.Add(order);
            await db.SaveChangesAsync();

            return CreatedAtAction("create", new {
                OrderEmail = order.OrderEmail,
                OrderShipping = order.OrderShipping,
                OrderQuantity = order.OrderQuantity
                }, order);

        }


    }

    


}