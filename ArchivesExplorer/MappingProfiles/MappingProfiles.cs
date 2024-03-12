using ArchivesExplorer.Requests;
using ArchivesExplorer.Responses;
using ArchivexExplorer.Domain.Aggregates;
using ArchivexExplorer.Domain.Models;
using AutoMapper;

namespace ArchivesExplorer.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RegisterRequest, UserModel>();
            CreateMap<ChangePasswordRequest, ChangePasswordAggregateModel>();
            CreateMap<CreateRoleRequest, RoleModel>();
            CreateMap<ProductCreatingRequest, ProductModel>();

            CreateMap<ProductUpdatingRequest, ProductModel>().ForMember(destination => destination.Id,
                options => options.MapFrom(source => Guid.Parse(source.Id)));

            CreateMap<CreateCategoryRequest, CategoryModel>();
            CreateMap<CreateCommentRequest, CommentModel>();

            CreateMap<CreateOrderRequest, OrderModel>().ForMember(destination => destination.ProductId,
                options => options.MapFrom(source => Guid.Parse(source.ProductId)));

            CreateMap<CommentModel, CommentResponse>();
            CreateMap<CategoryModel, CategoryResponse>();
            CreateMap<OrderModel, OrderResponse>();

            CreateMap<ProductModel, ShortProductResponse>().ForMember(destination => destination.Images,
                options => options.MapFrom(source => source.Images.Select(x => x.Path)));

            CreateMap<ProductModel, ProductResponseWithComments>().ForMember(destination => destination.Images,
                options => options.MapFrom(source => source.Images.Select(x => x.Path)));
        }
    }
}
