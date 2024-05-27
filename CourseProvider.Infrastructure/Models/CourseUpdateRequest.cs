namespace CourseProvider.Infrastructure.Models;

public class CourseUpdateRequest
{
    public string Id { get; set; } = null!;
    public string CourseTitle { get; set; } = null!;
    public string CourseIngress { get; set; } = null!;
    public string CourseDescription { get; set; } = null!;
    public string? CourseImageUrl { get; set; }
    public bool IsBestseller { get; set; }
    public string? Category { get; set; }
    public RatingUpdateRequest Rating { get; set; } = null!;
    public AuthorUpdateRequest Author { get; set; } = null!;
    public List<HighlightUpdateRequest> Highlights { get; set; } = null!;
    public List<ProgramDetailUpdateRequest> Content { get; set; } = null!;
    public PriceUpdateRequest Prices { get; set; } = null!;
    public IncludedUpdateRequest Included { get; set; } = null!;
}

public class RatingUpdateRequest
{
    public decimal InNumbers { get; set; }
    public decimal InProcent { get; set; }
}

public class AuthorUpdateRequest
{
    public string FullName { get; set; } = null!;
    public string Biography { get; set; } = null!;
    public string? ProfileImageUrl { get; set; }
    public SocialMediaUpdateRequest? SocialMedia { get; set; }
}

public class HighlightUpdateRequest
{
    public string Highlight { get; set; } = null!;
}

public class SocialMediaUpdateRequest
{
    public string? YouTubeUrl { get; set; }
    public string? Subscribers { get; set; }
    public string? FacebookUrl { get; set; }
    public string? Followers { get; set; }
}

public class ProgramDetailUpdateRequest
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}

public class PriceUpdateRequest
{
    public decimal OriginalPrice { get; set; }
    public decimal? DiscountPrice { get; set; }
}

public class IncludedUpdateRequest
{
    public int HoursOfVideo { get; set; }
    public int Articles { get; set; }
    public int Resources { get; set; }
    public bool LifetimeAccess { get; set; }
    public bool Certificate { get; set; }
}