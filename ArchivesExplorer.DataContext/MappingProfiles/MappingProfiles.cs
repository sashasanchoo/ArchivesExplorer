using ArchivesExplorer.DataContext.Entities;
using ArchivexExplorer.Domain.Models;
using AutoMapper;

namespace ArchivesExplorer.DataContext.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Role, RoleModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ImagePath, ImagePathModel>().ReverseMap();
            CreateMap<Comment, CommentModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
        }
    }
}
