﻿using FluentValidation;
using MediatR;

namespace Currencies.Api
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var errors = validators
                    .Select(x => x.Validate(context))
                    .SelectMany(x => x.Errors)
                    .Where(x => x != null)
                    .ToArray();

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
            else
            {
                return await next();
            }
        }
    }
}