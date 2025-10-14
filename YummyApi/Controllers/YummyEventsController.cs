using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyApi.Context;
using YummyApi.Dtos.EventDtos;
using YummyApi.Entities;

namespace YummyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummyEventsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public YummyEventsController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult YummyEventList()
        {
            var values = _context.YummyEvents.ToList();
            return Ok(_mapper.Map<List<ResultEventDto>>(values));
        }

        [HttpGet("GetEvent")]
        public IActionResult YummyGetEvent(int id)
        {
            var value = _context.YummyEvents.Find(id);
            return Ok(_mapper.Map<GetByIdEventDto>(value));
        }

        [HttpPost]
        public IActionResult CreateYummyEvent(CreateEventDto createEventDto)
        {
            var value = _mapper.Map<YummyEvent>(createEventDto);
            _context.YummyEvents.Add(value);
            _context.SaveChanges();
            return Ok("Event is added.");
        }

        [HttpPut]
        public IActionResult UpdateYummyEvent(UpdateEventDto updateEventDto)
        {
            var value = _mapper.Map<YummyEvent>(updateEventDto);
            _context.YummyEvents.Update(value);
            _context.SaveChanges();
            return Ok("Event is updated.");
        }

        [HttpDelete]
        public IActionResult DeleteYummyEvent(int id)
        {
            var value = _context.YummyEvents.Find(id);
            _context.YummyEvents.Remove(value);
            _context.SaveChanges();
            return Ok("Event is deleted.");
        }
    }
}
