﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPersonCreate.Domain.Contracts.v1;
using APIPersonCreate.Domain.DTOs.v1;
using FluentValidation;
using FluentValidation.Results;
using MediatR;


namespace APIPersonCreate.Domain.Pipes.v1;
public class FailFastValidation<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators,
    IDomainNotificationService notificationsService)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Response

{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
       CancellationToken cancellationToken)
    {
        if (!validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);
        var results = await GetResultsAsync(context, cancellationToken);
        var failures = results.SelectMany(r => r.Errors).Where(f => f != null).ToList();

        return failures.Any() ? await NotifyAsync(failures) : await next();
    }

    private Task<ValidationResult[]> GetResultsAsync(IValidationContext context, CancellationToken cancellationToken)
    {
        return Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
    }

    private Task<TResponse> NotifyAsync(IEnumerable<ValidationFailure> failures)
    {
        notificationsService.AddRange(failures.Select(x => $"{x.ErrorMessage} - {x.PropertyName}"));

        return Task.FromResult(default(TResponse))!;
    }
}

