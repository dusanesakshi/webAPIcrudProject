using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPIcrudProject.Data;

namespace webAPIcrudProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly APIDbContext _context;

        public CustomerController(APIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomer()
        {
            return Ok(await _context.Customer.ToListAsync());
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var cust = _context.Customer.Find(id);
            if (cust==null)
            {
                return NotFound();
            }
            return cust;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Create(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();  
            return Ok(customer);
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> Update(int id, Customer customer)
        {
            if(id!=customer.Id)
            {
                return BadRequest();
            }
            _context.Entry(customer).State=EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]

        public async Task<ActionResult> Delete(int id)
        {
            var customer= await _context.Customer.FindAsync(id);
            if(customer==null)
            {
                return NotFound();
            }
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }
     
    }
}
