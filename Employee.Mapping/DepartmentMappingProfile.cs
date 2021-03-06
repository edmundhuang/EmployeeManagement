﻿using AutoMapper;

using Employee.Mapping.Abstraction;
using Employee.Service.Contracts.DataContracts;

namespace Employee.Mapping
{
    internal class DepartmentMappingProfile : Profile,
                                            IMapper<Model.Department, DepartmentDto>,
                                            IMapper<DepartmentDto, Model.Department>
    {
        public DepartmentMappingProfile()
        {
        }

        public DepartmentDto Map(Model.Department src)
        {
            return Mapper.Map<DepartmentDto>(src);
        }

        public Model.Department Map(DepartmentDto src)
        {
            return Mapper.Map<Model.Department>(src);
        }

        protected override void Configure()
        {
            this.CreateMap<Model.Department, DepartmentDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                //.ForMember(dest => dest.Leader, opt => opt.MapFrom(src => Mapper.Map<Model.Employee, EmployeeDto>(src.Leader)))
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));

            this.CreateMap<DepartmentDto, Model.Department>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                //.ForMember(dest => dest.LeaderId, opt => opt.MapFrom(src => Mapper.Map<EmployeeDto, Model.Employee>(src.Leader).Id))
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));
        }
    }
}