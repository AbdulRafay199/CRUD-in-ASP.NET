using Microsoft.AspNetCore.Mvc;
using testApp.Data;
using testApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly TestDbContext _transactionContext;

        public TransactionController(TestDbContext TestDbContext)
        {
            _transactionContext = TestDbContext;
        }

        // GET: api/<TransactionController>
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return _transactionContext.Transactions;
        }

        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            string message;
            var item = _transactionContext.Transactions.FirstOrDefault(x => x.id == id);
            if (item != null)
            {
                message = "User Found";
                return Ok(new {message, item});
            }
            else
            {
                message = "Oops no data found!";
                return BadRequest(new { message });
            }
                
        }

        // POST api/<TransactionController>
        [HttpPost]
        public void Post([FromBody] Transaction req)
        {
            _transactionContext.Transactions.Add(req);
            _transactionContext.SaveChanges();
        }

        // PUT api/<TransactionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Transaction req)
        {
            req.id = id;
            _transactionContext.Transactions.Update(req);
            _transactionContext.SaveChanges();
            //var item = _transactionContext.Transactions.FirstOrDefault(x => x.id == id);
            //if(item != null)
            //{
                
            //}
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _transactionContext.Transactions.FirstOrDefault(x=>x.id == id);
            if (item != null)
            {
                _transactionContext.Transactions.Remove(item);
                _transactionContext.SaveChanges();
            }
        }
    }
}
