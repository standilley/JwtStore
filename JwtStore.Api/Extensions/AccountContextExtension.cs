﻿using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace JwtStore.Api.Extensions
{
    public static class AccountContextExtension
    {
        public static void AddAccountContext(this WebApplicationBuilder builder)
        {
            #region Create

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contracts.IRepository,
                JwtStore.Infra.Contexts.AccountContext.UseCases.Create.Repository>();

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contracts.IService,
                JwtStore.Infra.Contexts.AccountContext.UseCases.Create.Service>();

            #endregion

            #region Authenticate

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.Authentication.Contracts.IRepository,
                JwtStore.Infra.Contexts.AccountContext.UseCases.Authentication.Repository>();

            #endregion
        }
        public static void MapAccountEndpoints(this WebApplication app)
        {
            #region Create

            app.MapPost("api/v1/users", async (
                JwtStore.Core.Contexts.AccountContext.UseCases.Create.Request request,
                IRequestHandler<
                    JwtStore.Core.Contexts.AccountContext.UseCases.Create.Request,
                    JwtStore.Core.Contexts.AccountContext.UseCases.Create.Response> handler) => 
            {
                var result = await handler.Handle(request, new CancellationToken());
                return result.IsSucess
                ? Results.Created($"api/v1/users/{result.Data?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
            });

            #endregion

            #region Authenticate

            app.MapPost("api/v1/authenticate", async (
                JwtStore.Core.Contexts.AccountContext.UseCases.Authentication.Request request,
                IRequestHandler<
                    JwtStore.Core.Contexts.AccountContext.UseCases.Authentication.Request,
                    JwtStore.Core.Contexts.AccountContext.UseCases.Authentication.Response> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                if (!result.IsSucess)
                    return Results.Json(result, statusCode: result.Status);

                if (result.Data is null)
                    return Results.Json(result, statusCode: 500);

                result.Data.Token = JwtExtension.Generate(result.Data);
                return Results.Ok(result);
            });

            #endregion
        }
    }
}


