namespace YummyApi.Dtos.FeatureDtos
{
    public class CreateFeatureDto
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Describtion { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}
