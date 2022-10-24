﻿using AutoMapper;
using Northwind.Contracts.Dto.Authentication;
using Northwind.Contracts.Dto.Category;
using Northwind.Contracts.Dto.Product;
using Northwind.Contracts.Dto.Supplier;
using Northwind.Domain.Models;

namespace NorthwindWebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryForCreateDto>().ReverseMap();

            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<Supplier, SupplierForCreateDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductForCreateDto>().ReverseMap();

            CreateMap<ProductPhoto, ProductPhotoDto>().ReverseMap();
            CreateMap<ProductPhoto, ProductPhotoCreateDto>().ReverseMap();
            //tambahan edit
            CreateMap<ProductPhoto, ProductPhotoGroupDto>().ReverseMap();
            //selesai tambahan edit

            //tambahan untuk order
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderForCreateDto>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailForCreateDto>().ReverseMap();

            //register
            CreateMap<UserRegistrationDto, User>().ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

            //login
            CreateMap<UserLoginDto, User>().ReverseMap();
        }
    }
}