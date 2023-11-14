using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private List<Customer> _customers = new List<Customer>(); // Simulating storage using a list (in real scenario, use a database)

    [HttpGet]
    public ActionResult<IEnumerable<Customer>> Get()
    {
        return _customers;
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> Get(int id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer == null)
        {
            return NotFound(); // Return 404 if customer with the given ID is not found
        }
        return customer;
    }

    [HttpPost]
    public ActionResult<Customer> Post(Customer customer)
    {
        customer.Id = _customers.Count + 1; // Assign an ID (in a real database, this would be auto-generated)
        _customers.Add(customer);
        return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
    }
}
