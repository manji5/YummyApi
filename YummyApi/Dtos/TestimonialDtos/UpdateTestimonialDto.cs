using YummyApi.Entities;

namespace YummyApi.Dtos.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Commant { get; set; }
        public string ImageUrl { get; set; }
    }
}
