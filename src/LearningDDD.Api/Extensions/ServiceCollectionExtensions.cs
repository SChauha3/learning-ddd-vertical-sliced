using FluentValidation;
using FluentValidation.AspNetCore;
using LearningDDD.Api.Application.Commands.Groups;
using LearningDDD.Api.Dtos.ChargeStation;
using LearningDDD.Api.Dtos.Connector;
using LearningDDD.Api.Dtos.Group;
using LearningDDD.Api.Services.ChargeStations;
using LearningDDD.Api.Services.Connectors;
using LearningDDD.Api.Services.Groups;
using LearningDDD.Api.Validators;
using LearningDDD.Domain.Interfaces;
using LearningDDD.Domain.Models;
using LearningDDD.Domain.SeedWork;
using LearningDDD.Infrastructure.Data;
using MediatR;

namespace LearningDDD.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services
                .AddScoped<IValidator<CreateGroup>, CreateGroupValidator>()
                .AddScoped<IValidator<CreateChargeStation>, CreateChargeStationValidator>()
                .AddScoped<IValidator<CreateConnector>, CreateConnectorValidator>()
                .AddScoped<IValidator<UpdateGroup>, UpdateGroupValidator>()
                .AddScoped<IValidator<UpdateChargeStation>, UpdateChargeStationValidator>()
                .AddScoped<IValidator<UpdateConnector>, UpdateConnectorValidator>()
                .AddFluentValidationAutoValidation();

            return services;
        }

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services
                .AddScoped<IGroupService, GroupService>()
                .AddScoped<IChargeStationService, ChargeStationService>()
                .AddScoped<IConnectorService, ConnectorService>();

            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddGroupHandler(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateGroupCommand, Result<Group>>, CreateGroupCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateGroupCommand, Result<bool>>, UpdateGroupCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteGroupCommand, Result<bool>>, DeleteGroupCommandHandler>();
            return services;
        }
    }
}
