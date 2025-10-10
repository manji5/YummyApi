using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using YummyApi.Context;
using YummyApi.Dtos.CategoryDtos;
using YummyApi.Entities;

namespace YummyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IValidator<Category> _validator;
        private readonly ApiContext _context;

        public CategoriesController(IMapper mapper, ApiContext context, IValidator<Category> validator)
        {
            _mapper = mapper;
            _context = context;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _context.Categories.ToList();
            return Ok(_mapper.Map<List<ResultCategoryDto>>(value));
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _context.Categories.Find(id);
            return Ok(_mapper.Map<GetByIdCategoryDto>(value));
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            var valueValidate = _validator.Validate(value);

            if (!valueValidate.IsValid)
            {
                return BadRequest(valueValidate.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Categories.Add(value);
                _context.SaveChanges();
                return Ok("Category is added.");
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            var valueValidate = _validator.Validate(value);

            if (!valueValidate.IsValid)
            {
                return BadRequest(valueValidate.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Categories.Update(value);
                _context.SaveChanges();
                return Ok("Category name is changed.");
            }
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Category is deleted.");
        }
    }
}
