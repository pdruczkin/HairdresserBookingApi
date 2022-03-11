﻿using System.Xml;
using AutoMapper;
using HairdresserBookingApi.Models.Db;
using HairdresserBookingApi.Models.Dto.WorkerActivity;
using HairdresserBookingApi.Models.Entities.Api;
using HairdresserBookingApi.Models.Exceptions;
using HairdresserBookingApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HairdresserBookingApi.Services.Implementations;

public class WorkerActivityService : IWorkerActivityService
{

    private readonly BookingDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IUserContextService _userContextService;

    public WorkerActivityService(BookingDbContext dbContext, IMapper mapper, IUserContextService userContextService)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _userContextService = userContextService;
    }


    public List<WorkerActivityDto> GetAllActivitiesOfWorker(int workerId)
    {
        var worker = _dbContext
            .Workers
            .Include(w => w.WorkerActivity)
            .SingleOrDefault(w => w.Id == workerId);

        if (worker == null) throw new NotFoundException($"Worker of Id: {workerId} is not found");

        var workerActivities = worker.WorkerActivity;

        var workerActivitiesDto = _mapper.Map<List<WorkerActivityDto>>(workerActivities);

        return workerActivitiesDto;
    }

    public List<WorkerActivityDto> GetAllWorkersOfActivity(int activityId)
    {
        var activity = _dbContext
            .Activities
            .Include(a => a.WorkerActivity)
            .SingleOrDefault(a => a.Id == activityId);

        if (activity == null) throw new NotFoundException($"Activity of Id: {activityId} is not found");

        var workerActivities = activity.WorkerActivity;

        var workerActivitiesDto = _mapper.Map<List<WorkerActivityDto>>(workerActivities);

        return workerActivitiesDto;
    }


    public WorkerActivityDto GetWorkerActivity(int id)
    {
        var workerActivity = _dbContext.WorkerActivities.SingleOrDefault(wa => wa.Id == id);

        if (workerActivity == null) throw new NotFoundException($"WorkerActivity of Id: {id} is not found");

        var workerActivityDto = _mapper.Map<WorkerActivityDto>(workerActivity);

        return workerActivityDto;
    }

    public int CreateWorkerActivity(CreateWorkerActivityDto dto)
    {
        var activity = _dbContext.Activities.SingleOrDefault(a => a.Id == dto.ActivityId);
        if (activity == null) throw new NotFoundException($"Activity of Id: {dto.ActivityId} is not found");

        var worker = _dbContext.Workers.SingleOrDefault(w => w.Id == dto.WorkerId);
        if (worker == null) throw new NotFoundException($"Worker of Id: {dto.WorkerId} is not found");


        var workerActivity = _mapper.Map<WorkerActivity>(dto);

        //check if same entity exist
        var foundEntity = _dbContext.WorkerActivities.FirstOrDefault
        (wa => wa.Price == dto.Price && wa.RequiredMinutes == dto.RequiredMinutes && wa.ActivityId == dto.ActivityId && wa.WorkerId == dto.WorkerId);

        if (foundEntity != null) throw new EntityExistsException($"Entity of this values already exists");


        _dbContext.WorkerActivities.Add(workerActivity);
        _dbContext.SaveChanges();

        return workerActivity.Id;
    }
}