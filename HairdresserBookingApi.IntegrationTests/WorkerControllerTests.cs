﻿using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using HairdresserBookingApi.IntegrationTests.Helpers;
using HairdresserBookingApi.Models.Db;
using HairdresserBookingApi.Models.Dto.Worker;
using HairdresserBookingApi.Models.Entities.Api;
using Microsoft.Extensions.DependencyInjection;
using NLog.Targets.Wrappers;
using Xunit;

namespace HairdresserBookingApi.IntegrationTests;

public class WorkerControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public WorkerControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    private void SeedWorker(Worker worker)
    {
        var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();

        using var scope = scopeFactory?.CreateScope();
        var dbContext = scope?.ServiceProvider.GetService<BookingDbContext>();

        dbContext?.Workers.Add(worker);
        dbContext?.SaveChanges();
    }

    [Fact]
    public async Task GetAll_ReturnsOk()
    {
        var response = await _client.GetAsync("api/worker");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetById_ForExistingWorker_ReturnsOk()
    {
        var model = new Worker()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test@test.com",
            PhoneNumber = "111222333"
        };

        SeedWorker(model);

        var response = await _client.GetAsync($"api/worker/{model.Id}");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetById_ForNonExistingWorker_ReturnsNotFound()
    {
        var response = await _client.GetAsync($"api/worker/{-1}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task Create_ForValidModel_ReturnsCreated()
    {
        var model = new Worker()
        {
            FirstName = "Test2",
            LastName = "Test2",
            Email = "test2@test.com",
            PhoneNumber = "123123123"
        };

        var httpContent = model.ToJsonHttpContent();


        var response = await _client.PostAsync("api/worker", httpContent);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task Create_ForInValidModel_ReturnsBadRequest()
    {
        var model = new Worker()
        {
            FirstName = "Test",
            Email = "WrongEmail"
        };

        var httpContent = model.ToJsonHttpContent();


        var response = await _client.PostAsync("api/worker", httpContent);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Update_ForValidModelAndExistingWorker_ReturnsCreated()
    {
        var workerToUpdate = new Worker()
        {
            FirstName = "Test3",
            LastName = "Test3",
            Email = "test3@test.com",
            PhoneNumber = "123456712"
        };

        SeedWorker(workerToUpdate);

        var updateDto = new UpdateWorkerDto()
        {
            FirstName = "Test4",
            LastName = "Test4",
            Email = "test4@test.com",
            PhoneNumber = "111222344"
        };

        var httpContent = updateDto.ToJsonHttpContent();

        var response = await _client.PutAsync($"api/worker/{workerToUpdate.Id}", httpContent);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

    }

    [Fact]
    public async Task Update_ForValidModelAndNonExistingWorker_ReturnsNotFound()
    {
        var updateDto = new UpdateWorkerDto()
        {
            FirstName = "Test5",
            LastName = "Test5",
            Email = "test5@test.com",
            PhoneNumber = "111222355"
        };

        var httpContent = updateDto.ToJsonHttpContent();

        var response = await _client.PutAsync($"api/worker/{-1}", httpContent);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task Update_ForInValidModel_ReturnsBadRequest()
    {
        //no need to seed, cause validation is before finding worker entity


        //same email and phoneNumber, lack of LastName
        var updateDto = new UpdateWorkerDto()
        {
            FirstName = "Test",
            Email = "test@test.com",
            PhoneNumber = "123123123"
        };

        var httpContent = updateDto.ToJsonHttpContent();

        var response = await _client.PutAsync($"api/worker/{-1}", httpContent);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Delete_ForExistingWorker_ReturnsNoContent()
    {
        var workerToDelete = new Worker()
        {
            FirstName = "TestToDelete",
            LastName = "TestToDelete",
            Email = "testToDelete@test.com",
            PhoneNumber = "888777444"
        };

        SeedWorker(workerToDelete);

        var response = await _client.DeleteAsync($"api/worker/{workerToDelete.Id}");

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task Delete_ForNonExistingWorker_ReturnsNotFound()
    {
        var response = await _client.DeleteAsync($"api/worker/{-1}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }


}