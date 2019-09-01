using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;
using System.Collections.Generic;

namespace CustomerAccountServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            Log.Debug("testing Serilog Debug level logging....");
            Log.Information("testing Serilog Information level logging....");
            Log.Warning("testing Serilog Warning level logging....");
            Log.Error("testing Serilog Error level logging....");
            Log.Fatal("testing Serilog Fatal level logging....");
            Log.Verbose("testing Serilog Verbose level logging....");
            Log.Write(LogEventLevel.Warning, "Am writing a warning log to the console");

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            Log.Debug("testing Serilog Debug level logging....");
            Log.Information("testing Serilog Information level logging....");
            Log.Warning("testing Serilog Warning level logging....");
            Log.Error("testing Serilog Error level logging....");
            Log.Fatal("testing Serilog Fatal level logging....");
            Log.Verbose("testing Serilog Verbose level logging....");
            Log.Write(LogEventLevel.Warning, "Am writing a warning log to the console");

            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
