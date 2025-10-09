using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using YummyApi.Context;
using YummyApi.Dtos.ProductDtos;
using YummyApi.Entities;

namespace YummyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> validator, ApiContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _context.Products.ToList();
            return Ok(_mapper.Map<List<ResultProductDto>>(values));
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _context.Products.Find(id);
            return Ok(_mapper.Map<GetByIdProductDto>(value));
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            var valueValidate = _validator.Validate(value);

            if (!valueValidate.IsValid)
            {
                return BadRequest(valueValidate.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Add(value);
                _context.SaveChanges();
                return Ok("Product is added.");
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            var valueValidate = _validator.Validate(value);

            if (!valueValidate.IsValid)
            {
                return BadRequest(valueValidate.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Update(value);
                _context.SaveChanges();
                return Ok("Product is updated.");
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return Ok("Product is deleted.");
        }
    }
}
