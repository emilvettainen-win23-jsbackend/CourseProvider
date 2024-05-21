﻿using System.ComponentModel.DataAnnotations;

namespace CourseProvider.Infrastructure.Data.Entities;

public class CourseEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CourseTitle { get; set; } = null!;
    public string CourseIngress { get; set; } = null!;
    public string CourseDescription { get; set; } = null!;
    public string? CourseImageUrl { get; set; }
    public bool IsBestseller { get; set; }
    public string? Category { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }
    public virtual RatingEntity Rating { get; set; } = null!;
    public virtual List<AuthorEntity> Authors { get; set; } = [];
    public virtual IncludedEntity Included { get; set; } = null!;
    public virtual List<HighlightsEntity> Highlights { get; set; } = null!;
    public virtual List<ProgramDetailsEntity> Content { get; set; } = null!;
    public virtual PriceEntity Prices { get; set; } = null!;
}

public class RatingEntity
{
    public decimal InNumbers { get; set; }
    public decimal InProcent { get; set; }
}

public class AuthorEntity
{
    public string FullName { get; set; } = null!;
    public string Biography { get; set; } = null!;
    public string? ProfileImageUrl { get; set; }
    public SocialMediaEntity? SocialMedia { get; set; }

}

public class SocialMediaEntity
{
    public string? YouTubeUrl { get; set; }
    public string? Subscribers { get; set; }
    public string? FacebookUrl { get; set; }
    public string? Followers { get; set; }
}


public class IncludedEntity
{
    public int HoursOfVideo { get; set; }
    public int Articles { get; set; }
    public int Resourses { get; set; }
    public bool LifetimeAccess { get; set; } = false;
    public bool Certificate { get; set; } = false;
}

public class HighlightsEntity
{
    public string Highlight { get; set; } = null!;
}

public class ProgramDetailsEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}

public class PriceEntity
{
    public decimal OriginalPrice { get; set; }
    public decimal? DiscountPrice { get; set; }
}

