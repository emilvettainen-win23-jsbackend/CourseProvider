using Azure.Core;
using CourseProvider.Infrastructure.Data.Entities;
using CourseProvider.Infrastructure.Models;

namespace CourseProvider.Infrastructure.Factories;

public static class CourseFactory
{
    public static CourseEntity Create(CourseCreateRequest request)
    {
        return new CourseEntity
        {
            CourseTitle = request.CourseTitle,
            CourseIngress = request.CourseIngress,
            CourseDescription = request.CourseDescription,
            CourseImageUrl = request.CourseImageUrl,
            IsBestseller = request.IsBestseller,
            Category = request.Category ?? "",
            Authors = request.Authors?.Select(a => new AuthorEntity
            {
                FullName = a.FullName,
                Biography = a.Biography,
                ProfileImageUrl = a.ProfileImageUrl,
                SocialMedia = a.SocialMedia != null ? new SocialMediaEntity
                {
                    YouTubeUrl = a.SocialMedia.YouTubeUrl,
                    Subscribers = a.SocialMedia.Subscribers,
                    FacebookUrl = a.SocialMedia.FacebookUrl,
                    Followers = a.SocialMedia.Followers,
                } : null!
            }).ToList() ?? [],
            Rating = request.Rating != null ? new RatingEntity
            {
                InNumbers = request.Rating.InNumbers,
                InProcent = request.Rating.InProcent,
            } : null!,
            Highlights = request.Highlights?.Select(h => new HighlightsEntity { Highlight = h.Highlight }).ToList() ?? [],
            Content = request.Content?.Select(p => new ProgramDetailsEntity
            {
                Title = p.Title,
                Description = p.Description
            }).ToList() ?? [],
            Prices = request.Prices != null ? new PriceEntity
            {
                OriginalPrice = request.Prices.OriginalPrice,
                DiscountPrice = request.Prices.DiscountPrice
            } : null!,
            Included = request.Included != null ? new IncludedEntity
            {
                HoursOfVideo = request.Included.HoursOfVideo,
                Articles = request.Included.Articles,
                Resourses = request.Included.Resources,
                LifetimeAccess = request.Included.LifetimeAccess,
                Certificate = request.Included.Certificate
            } : null!,
            Created = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow
        };
    }


    public static CourseEntity Update(CourseUpdateRequest request)
    {
        return new CourseEntity
        {
            Id = request.Id,
            CourseTitle = request.CourseTitle,
            CourseIngress = request.CourseIngress,
            CourseDescription = request.CourseDescription,
            CourseImageUrl = request.CourseImageUrl,
            IsBestseller = request.IsBestseller,
            Category = request.Category ?? "",
            Authors = request.Authors?.Select(a => new AuthorEntity
            {
                FullName = a.FullName,
                Biography = a.Biography,
                ProfileImageUrl = a.ProfileImageUrl,
                SocialMedia = a.SocialMedia != null ? new SocialMediaEntity
                {
                    YouTubeUrl = a.SocialMedia.YouTubeUrl,
                    Subscribers = a.SocialMedia.Subscribers,
                    FacebookUrl = a.SocialMedia.FacebookUrl,
                    Followers = a.SocialMedia.Followers,
                } : null!
            }).ToList() ?? [],
            Rating = request.Rating != null ? new RatingEntity
            {
                InNumbers = request.Rating.InNumbers,
                InProcent = request.Rating.InProcent,
            } : null!,
            Highlights = request.Highlights?.Select(h => new HighlightsEntity { Highlight = h.Highlight }).ToList() ?? [],
            Content = request.Content?.Select(p => new ProgramDetailsEntity
            {
                Title = p.Title,
                Description = p.Description
            }).ToList() ?? [],
            Prices = request.Price != null ? new PriceEntity
            {
                OriginalPrice = request.Price.OriginalPrice,
                DiscountPrice = request.Price.DiscountPrice
            } : null!,
            Included = request.Included != null ? new IncludedEntity
            {
                HoursOfVideo = request.Included.HoursOfVideo,
                Articles = request.Included.Articles,
                Resourses = request.Included.Resources,
                LifetimeAccess = request.Included.LifetimeAccess,
                Certificate = request.Included.Certificate
            } : null!,
            LastUpdated = DateTime.UtcNow
        };
    }

    public static Course Read(CourseEntity entity)
    {
        return new Course
        {
            Id = entity.Id,
            Created = entity.Created,
            LastUpdated = entity.LastUpdated,
            CourseTitle = entity.CourseTitle,
            CourseIngress = entity.CourseIngress,
            CourseDescription = entity.CourseDescription,
            CourseImageUrl = entity.CourseImageUrl,
            IsBestseller = entity.IsBestseller,
            Category = entity.Category ?? "",
            Authors = entity.Authors?.Select(a => new Author
            {
                FullName = a.FullName,
                Biography = a.Biography,
                ProfileImageUrl = a.ProfileImageUrl,
                SocialMedia = a.SocialMedia != null ? new SocialMedia
                {
                    YouTubeUrl = a.SocialMedia.YouTubeUrl,
                    Subscribers = a.SocialMedia.Subscribers,
                    FacebookUrl = a.SocialMedia.FacebookUrl,
                    Followers = a.SocialMedia.Followers,
                } : null
            }).ToList() ?? new List<Author>(),
            Rating = entity.Rating != null ? new Rating
            {
                InNumbers = entity.Rating.InNumbers,
                InProcent = entity.Rating.InProcent,
            }: null!,
            Highlights = entity.Highlights?.Select(h => new Highlights { Highlight = h.Highlight}).ToList() ?? new List<Highlights>(),
            Content = entity.Content?.Select(p => new ProgramDetail
            {
                Title = p.Title,
                Description = p.Description
            }).ToList() ?? new List<ProgramDetail>(),
            Prices = entity.Prices != null ? new Price
            {
                OriginalPrice = entity.Prices.OriginalPrice,
                DiscountPrice = entity.Prices.DiscountPrice
            } : new Price(),
            Included = entity.Included != null ? new Included
            {
                HoursOfVideo = entity.Included.HoursOfVideo,
                Articles = entity.Included.Articles,
                Resources = entity.Included.Resourses,
                LifetimeAccess = entity.Included.LifetimeAccess,
                Certificate = entity.Included.Certificate
            } : new Included(),

        };
    }
}
    

