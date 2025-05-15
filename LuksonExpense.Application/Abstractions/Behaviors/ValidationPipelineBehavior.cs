using FluentValidation;
using FluentValidation.Results;
using LuksonExpense.Domain.Shared;
using MediatR;
using System.Net;

namespace LuksonExpense.Application.Abstractions.Behaviors
{
    public class ValidationPipelineBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) 
        : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                IEnumerable<ValidationFailure>? failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null);

                if (failures.Any())
                {
                    var responseType = typeof(TResponse);

                    if (responseType.IsGenericType &&
                        responseType.GetGenericTypeDefinition() == typeof(Response<>))
                    {
                        var errorResponse = Activator.CreateInstance(responseType);
                        var statusCodeProp = responseType.GetProperty(nameof(Response<object>.StatusCode));
                        var errorProp = responseType.GetProperty(nameof(Response<object>.Error));
                        
                        statusCodeProp?.SetValue(errorResponse, HttpStatusCode.BadRequest);
                        errorProp?.SetValue(errorResponse, new ErrorResponse
                        {
                            ErrorMessages = failures.Select(f => f.ErrorMessage).ToList()
                        });

                        return (TResponse)errorResponse!;
                    }

                    throw new InvalidOperationException($"TResponse debe ser del tipo Response<T> para que la validación pueda construir un error.");
                }
            }

            return await next();
        }
    }
}
