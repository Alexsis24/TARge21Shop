namespace TARge21Shop.Core.Dto.WeatherDtos
{
    public class WeatherRootDto
    {
        public HeadlineDto Headline { get; set; }
        public List<HeadlineDto> DailyForecasts { get; set; }
        
    }
}
