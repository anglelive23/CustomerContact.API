using AutoMapper;
using CustomerContacts.Data;
using CustomerContacts.Dtos;
using CustomerContacts.Interfaces;
using CustomerContacts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerContacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        IBaseRepository<Customer> _customersRepository;
        public CustomerController(IBaseRepository<Customer> CustomersRepository)
        {
            this._customersRepository = CustomersRepository;
        }

        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllContacts()
        {
            if (ModelState.IsValid)
            {
                var customers = _customersRepository.GetAll(new[] { "Contact" }).Select(Mapper.Map<Customer, CustomerDto>);
                return (customers == null || !customers.Any()) ? NotFound() : Ok(customers);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult SaveCustomer([FromBody] CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                var isAlreadyCustomer = _customersRepository.Find(c => c.Id == customerDto.Id, new[] { "Contact" });
                if (isAlreadyCustomer == null)
                {
                    var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                    _customersRepository.Post(customer);
                    // these 3 columns is generated from database so we copy it to new object before we send it
                    customerDto.Id = customer.Id;
                    customerDto.ContactId = customer.ContactId;
                    customerDto.Contact.Id = customer.Contact.Id;

                    return Ok(customerDto);
                }
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer([FromRoute] int id, [FromBody]ContactDto newContact)
        {
            if(ModelState.IsValid)
            {
                var customer = _customersRepository.Find(c => c.Id == id, new[] { "Contact" });
                if (customer != null)
                {
                    // Getting Id from acutal customer in database and assign it to Dto object
                    newContact.Id = customer.Contact.Id;
                    // Map the two objects
                    Mapper.Map<ContactDto, Contact>(newContact, customer.Contact);
                    // SaveChanges
                    _customersRepository.Update();
                    return Ok(Mapper.Map<Customer, CustomerDto>(customer));
                }
            }
            return NotFound();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            if (ModelState.IsValid)
            {
                var customer = _customersRepository.Find(c => c.Id == id, new[] { "Contact" });
                if (customer != null)
                {
                    _customersRepository.Delete(customer);
                    return Ok();
                }
                return NotFound();
            }
            return BadRequest();
        }
    }
}
