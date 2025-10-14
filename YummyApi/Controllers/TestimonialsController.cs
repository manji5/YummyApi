using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyApi.Context;
using YummyApi.Dtos.TestimonialDtos;
using YummyApi.Entities;

namespace YummyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public TestimonialsController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _context.Testimonials.ToList();
            return Ok(_mapper.Map<List<ResultTestimonialDto>>(values));
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            return Ok(_mapper.Map<GetByIdTestimonialDto>(value));
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(createTestimonialDto);
            _context.Testimonials.Add(value);
            _context.SaveChanges();
            return Ok("Testimonial is added.");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _context.Testimonials.Update(value);
            _context.SaveChanges();
            return Ok("Testimonial is updated.");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Testimonial is deleted.");
        }
    }
}
