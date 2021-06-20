using AutoMapper;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Controllers;

namespace UI.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<List<ProductDetailDto>, ProductDetailViewModel>();
            CreateMap<ProductDetailViewModel, List<ProductDetailDto>>();
        }
    }
}
