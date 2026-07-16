using Microsoft.AspNetCore.Mvc;

namespace ValuesWebAPI.Controllers;

// Inherits from ControllerBase (equivalent of ApiController in .NET Core)
// [ApiController] enables automatic model validation, binding source inference
// [Route] defines the URL pattern: api/values
[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    // In-memory data store to simulate a database
    private static readonly List<string> _values = new() { "value1", "value2" };

    // GET api/values
    // Returns all values - 200 OK
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        return Ok(_values);
    }

    // GET api/values/0
    // Returns a single value by index - 200 OK or 404 NotFound
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        if (id < 0 || id >= _values.Count)
            return NotFound();

        return Ok(_values[id]);
    }

    // POST api/values
    // Creates a new value - 201 Created or 400 BadRequest
    [HttpPost]
    public ActionResult Post([FromBody] string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return BadRequest("Value cannot be empty.");

        _values.Add(value);
        return CreatedAtAction(nameof(Get), new { id = _values.Count - 1 }, value);
    }

    // PUT api/values/0
    // Updates an existing value - 204 NoContent, 400 BadRequest, or 404 NotFound
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] string value)
    {
        if (id < 0 || id >= _values.Count)
            return NotFound();

        if (string.IsNullOrWhiteSpace(value))
            return BadRequest("Value cannot be empty.");

        _values[id] = value;
        return NoContent();
    }

    // DELETE api/values/0
    // Deletes a value - 204 NoContent or 404 NotFound
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        if (id < 0 || id >= _values.Count)
            return NotFound();

        _values.RemoveAt(id);
        return NoContent();
    }
}
