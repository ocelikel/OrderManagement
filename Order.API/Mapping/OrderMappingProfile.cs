using AutoMapper;
using Order.API.Model;
using Order.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Mapping
{
    public class OrderMappingProfile:Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderDetailViewModel, Model.OrderDetail>();

            CreateMap<OrderViewModel, Model.Order>()
                .ForMember(dest => dest.OrderDetails, opts => opts.MapFrom(src => src.OrderDetailViewModels));

        }
    }
}
