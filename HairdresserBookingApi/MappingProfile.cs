﻿using AutoMapper;
using HairdresserBookingApi.Models.Dto;
using HairdresserBookingApi.Models.Dto.Activity;
using HairdresserBookingApi.Models.Dto.Availability;
using HairdresserBookingApi.Models.Dto.Reservation;
using HairdresserBookingApi.Models.Dto.User;
using HairdresserBookingApi.Models.Dto.Worker;
using HairdresserBookingApi.Models.Dto.WorkerActivity;
using HairdresserBookingApi.Models.Entities.Api;
using HairdresserBookingApi.Models.Entities.Users;

namespace HairdresserBookingApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<Activity, ActivityDto>();
        CreateMap<CreateActivityDto, Activity>();

        CreateMap<Activity, ActivityDetailsDto>();

        CreateMap<WorkerActivity, WorkerActivityDto>();

        CreateMap<WorkerActivity, AvailableActivityDto>()
            .ForMember(m => m.Name, c => c.MapFrom(s => s.Activity.Name))
            .ForMember(m => m.Description, c => c.MapFrom(s => s.Activity.Description))
            .ForMember(m => m.Id, c => c.MapFrom(s => s.Activity.Id))
            .ForMember(m => m.IsForMan, c => c.MapFrom(s => s.Activity.IsForMan))
            .ForMember(m => m.MinPrice, c => c.MapFrom(s => s.Price));


        CreateMap<Worker, WorkerDto>();
        CreateMap<Worker, WorkerDetailsDto>();
        CreateMap<CreateWorkerDto, Worker>();


        CreateMap<CreateUserDto, User>();

        CreateMap<Availability, AvailabilityDto>();
        CreateMap<AddAvailabilityDto, Availability>();

        CreateMap<ReservationRequestDto, Reservation>();

    }
}