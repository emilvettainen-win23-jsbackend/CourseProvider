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
            Author = request.Author != null ? new AuthorEntity
            {
                FullName = request.Author.FullName,
                Biography = request.Author.Biography,
                ProfileImageUrl = request.Author.ProfileImageUrl,
                SocialMedia = request.Author.SocialMedia != null ? new SocialMediaEntity
                {
                    YouTubeUrl = request.Author.SocialMedia.YouTubeUrl,
                    Subscribers = request.Author.SocialMedia.Subscribers,
                    FacebookUrl = request.Author.SocialMedia.FacebookUrl,
                    Followers = request.Author.SocialMedia.Followers
                } : null
            } : null!,
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
            Author = request.Author != null ? new AuthorEntity
            {
                FullName = request.Author.FullName,
                Biography = request.Author.Biography,
                ProfileImageUrl = request.Author.ProfileImageUrl,
                SocialMedia = request.Author.SocialMedia != null ? new SocialMediaEntity
                {
                    YouTubeUrl = request.Author.SocialMedia.YouTubeUrl,
                    Subscribers = request.Author.SocialMedia.Subscribers,
                    FacebookUrl = request.Author.SocialMedia.FacebookUrl,
                    Followers = request.Author.SocialMedia.Followers
                } : null
            } : null!,
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
            Author = entity.Author != null ? new Author
            {
                FullName = entity.Author.FullName,
                Biography = entity.Author.Biography,
                ProfileImageUrl = entity.Author.ProfileImageUrl,
                SocialMedia = entity.Author.SocialMedia != null ? new SocialMedia
                {
                    YouTubeUrl = entity.Author.SocialMedia.YouTubeUrl,
                    Subscribers = entity.Author.SocialMedia.Subscribers,
                    FacebookUrl = entity.Author.SocialMedia.FacebookUrl,
                    Followers = entity.Author.SocialMedia.Followers
                } : null
            } : null!,
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
    

