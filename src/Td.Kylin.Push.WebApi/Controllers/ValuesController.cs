using JPush.Api;
using JPush.Api.common;
using JPush.Api.common.resp;
using JPush.Api.push.mode;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;

namespace Td.Kylin.Push.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("push")]
        public IActionResult Push()
        {
            JPushClient client = new JPushClient("", "");

            PushPayload payload = PushObject_All_All_Alert();

            try
            {
                var result = client.SendPush(payload);
            }
            catch (APIRequestException e)
            {
                Console.WriteLine("Error response from JPush server. Should review and fix it. ");
                Console.WriteLine("HTTP Status: " + e.Status);
                Console.WriteLine("Error Code: " + e.ErrorCode);
                Console.WriteLine("Error Message: " + e.ErrorCode);
            }
            catch (APIConnectionException e)
            {
                Console.WriteLine(e.Message);
            }

            return Ok("");
        }

        public static PushPayload PushObject_All_All_Alert()
        {
            PushPayload pushPayload = new PushPayload();
            pushPayload.platform = Platform.all();
            pushPayload.audience = Audience.all();
            pushPayload.notification = new Notification().setAlert("曹鑫");
            return pushPayload;
        }
    }
}
