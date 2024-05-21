namespace CourseProvider.Infrastructure.Models;

public class CourseCreateRequest
{
    public string CourseTitle { get; set; } = null!;
    public string CourseIngress { get; set; } = null!;
    public string CourseDescription { get; set; } = null!;
    public string? CourseImageUrl { get; set; }
    public bool IsBestseller { get; set; }
    public string? Category { get; set; }
    public RatingRequest Rating { get; set; } = null!;
    public AuthorRequest Author { get; set; } = null!;
    public List<HighlightRequest> Highlights { get; set; } = null!;
    public List<ProgramDetailRequest> Content { get; set; } = null!;
    public PriceRequest Prices { get; set; } = null!;
    public IncludedRequest Included { get; set; } = null!;
}

public class RatingRequest
{
    public decimal InNumbers { get; set; }
    public decimal InProcent { get; set; }
}

public class AuthorRequest
{
    public string FullName { get; set; } = null!;
    public string Biography { get; set; } = null!;
    public string? ProfileImageUrl { get; set; }
    public SocialMediaRequest? SocialMedia { get; set; }
}

public class HighlightRequest
{
    public string Highlight { get; set; } = null!;
}


public class SocialMediaRequest
{
    public string? YouTubeUrl { get; set; }
    public string? Subscribers { get; set; }
    public string? FacebookUrl { get; set; }
    public string? Followers { get; set; }
}

public class ProgramDetailRequest
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}

public class PriceRequest
{
    public decimal OriginalPrice { get; set; }
    public decimal? DiscountPrice { get; set; }
}

public class IncludedRequest
{
    public int HoursOfVideo { get; set; }
    public int Articles { get; set; }
    public int Resources { get; set; }
    public bool LifetimeAccess { get; set; }
    public bool Certificate { get; set; }
}
