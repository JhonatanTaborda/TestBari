using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransferObjects;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace SendMessageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly IMessageAppService _messageAppService;
        public SendMessageController(IMessageAppService messageAppService)
        {
            _messageAppService = messageAppService;
        }


        [HttpGet]
        public ActionResult Get(string queue = "")
        {

            var obj = _messageAppService.CreateMessage(ControllerContext.RouteData.Values["controller"].ToString());

            using (IConnection connection = new ConnectionFactory().CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    channel.BasicPublish(string.Empty, queue, null,  _messageAppService.EncodeMessage(obj));
                }
            }

            return Ok(true);

        }
    }
}