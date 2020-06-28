using System;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ReceiveMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiveMessageController : ControllerBase
    {
        private readonly IMessageAppService _messageAppService;

        public ReceiveMessageController(IMessageAppService messageAppService)
        {
            _messageAppService = messageAppService;
        }    

        [HttpGet]
        public ActionResult Get(string queue = "")
        {
            var result = string.Empty;

            using (IConnection connection = new ConnectionFactory().CreateConnection())
            {

                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    BasicGetResult resultChannel = channel.BasicGet(queue, true);
                    if (resultChannel != null)
                    {
                        result = _messageAppService.DecodeMessage(resultChannel.Body);
                    }
                }
            }

            return Ok(result);  
        } 

        [HttpGet]
        [Route("[Action]")]
        public ActionResult GetMessage()
        {
            var obj = _messageAppService.CreateMessage(ControllerContext.RouteData.Values["controller"].ToString());

            return Ok(_messageAppService.ReturnMessage(obj));
        }
    }
}