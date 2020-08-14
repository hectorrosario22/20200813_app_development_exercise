using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException() : base("Han ocurrido uno o más errores de validación")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(List<ValidationFailure> failures) : this()
        {
            var propertyNames = failures
                .Select(d => d.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(d => d.PropertyName == propertyName)
                    .Select(d => d.ErrorMessage)
                    .ToArray();

                Errors.Add(propertyName, propertyFailures);
            }
        }
    }
}
