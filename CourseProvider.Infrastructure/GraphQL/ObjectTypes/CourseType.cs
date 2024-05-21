using CourseProvider.Infrastructure.Data.Entities;

namespace CourseProvider.Infrastructure.GraphQL.ObjectTypes;

public class CourseType : ObjectType<CourseEntity>
{
    protected override void Configure(IObjectTypeDescriptor<CourseEntity> descriptor)
    {
        descriptor.Field(c => c.Id).Type<NonNullType<IdType>>();
        descriptor.Field(c => c.CourseTitle).Type<NonNullType<StringType>>();
        descriptor.Field(c => c.CourseIngress).Type<NonNullType<StringType>>();
        descriptor.Field(c => c.CourseDescription).Type<NonNullType<StringType>>();
        descriptor.Field(c => c.CourseImageUrl).Type<StringType>();
        descriptor.Field(c => c.IsBestseller).Type<NonNullType<BooleanType>>();
        descriptor.Field(c => c.Category).Type<StringType>();
        descriptor.Field(c => c.Created).Type<NonNullType<DateTimeType>>();
        descriptor.Field(c => c.LastUpdated).Type<NonNullType<DateTimeType>>();
        descriptor.Field(c => c.Rating).Type<RatingType>();
        descriptor.Field(c => c.Author).Type<AuthorType>();
        descriptor.Field(c => c.Included).Type<IncludedType>();
        descriptor.Field(c => c.Highlights).Type<ListType<HighlightType>>();
        descriptor.Field(c => c.Content).Type<ListType<ProgramDetailType>>();
        descriptor.Field(c => c.Prices).Type<PriceType>();
    }
}

public class RatingType : ObjectType<RatingEntity>
{
    protected override void Configure(IObjectTypeDescriptor<RatingEntity> descriptor)
    {
        descriptor.Field(r => r.InNumbers).Type<NonNullType<DecimalType>>();
        descriptor.Field(r => r.InProcent).Type<NonNullType<DecimalType>>();
    }
}

public class AuthorType : ObjectType<AuthorEntity>
{
    protected override void Configure(IObjectTypeDescriptor<AuthorEntity> descriptor)
    {
        descriptor.Field(a => a.FullName).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.Biography).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.ProfileImageUrl).Type<StringType>();
        descriptor.Field(a => a.SocialMedia).Type<SocialMediaType>();
    }
}

public class SocialMediaType : ObjectType<SocialMediaEntity>
{
    protected override void Configure(IObjectTypeDescriptor<SocialMediaEntity> descriptor)
    {
        descriptor.Field(s => s.YouTubeUrl).Type<StringType>();
        descriptor.Field(s => s.Subscribers).Type<StringType>();
        descriptor.Field(s => s.FacebookUrl).Type<StringType>();
        descriptor.Field(s => s.Followers).Type<StringType>();
    }
}

public class IncludedType : ObjectType<IncludedEntity>
{
    protected override void Configure(IObjectTypeDescriptor<IncludedEntity> descriptor)
    {
        descriptor.Field(i => i.HoursOfVideo).Type<NonNullType<IntType>>();
        descriptor.Field(i => i.Articles).Type<NonNullType<IntType>>();
        descriptor.Field(i => i.Resourses).Type<NonNullType<IntType>>();
        descriptor.Field(i => i.LifetimeAccess).Type<NonNullType<BooleanType>>();
        descriptor.Field(i => i.Certificate).Type<NonNullType<BooleanType>>();
    }
}

public class HighlightType : ObjectType<HighlightsEntity>
{
    protected override void Configure(IObjectTypeDescriptor<HighlightsEntity> descriptor)
    {
        descriptor.Field(h => h.Highlight).Type<NonNullType<StringType>>();
    }
}

public class ProgramDetailType : ObjectType<ProgramDetailsEntity>
{
    protected override void Configure(IObjectTypeDescriptor<ProgramDetailsEntity> descriptor)
    {
        descriptor.Field(p => p.Title).Type<NonNullType<StringType>>();
        descriptor.Field(p => p.Description).Type<NonNullType<StringType>>();
    }
}

public class PriceType : ObjectType<PriceEntity>
{
    protected override void Configure(IObjectTypeDescriptor<PriceEntity> descriptor)
    {
        descriptor.Field(p => p.OriginalPrice).Type<NonNullType<DecimalType>>();
        descriptor.Field(p => p.DiscountPrice).Type<DecimalType>();
    }
}