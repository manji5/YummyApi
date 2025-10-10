using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyApi.Context;
using YummyApi.Dtos.ChefDtos;
using YummyApi.Entities;

namespace YummyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IValidator<Chef> _validator;
        private readonly ApiContext _context;

        public ChefsController(IMapper mapper, ApiContext context, IValidator<Chef> validator)
        {
            _mapper = mapper;
            _context = context;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            var values = _context.Chefs.ToList();
            return Ok(_mapper.Map<List<ResultChefDto>>(values));
        }

        [HttpGet("GetChef")]
        public IActionResult GetChef(int id)
        {
            var value = _context.Chefs.Find(id);
            return Ok(_mapper.Map<GetByIdChefDto>(value));
        }

        [HttpPost]
        public IActionResult CreateChef(CreateChefDto createChefDto)
        {
            var value = _mapper.Map<Chef>(createChefDto);
            var valueValidator = _validator.Validate(value);

            if (!valueValidator.IsValid) 
            {
                return BadRequest(valueValidator.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Chefs.Add(value);
                _context.SaveChanges();
                return Ok("Chef is added.");
            }
        }

        [HttpPut]
        public IActionResult UpdateChef(UpdateChefDto updateChefDto)
        {
            var value = _mapper.Map<Chef>(updateChefDto);
            var valueValidate = _validator.Validate(value);

            if (!valueValidate.IsValid)
            {
                return BadRequest(valueValidate.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Chefs.Update(value);
                _context.SaveChanges();
                return Ok("Chef is updated.");
            }
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var value = _context.Chefs.Find(id);
            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Chef is deleted.");
        }
    }
}
