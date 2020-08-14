using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }

        public ValidationException() : base("Han ocurrido uno o más errores de validación")
        {
            Errors = new List<string>();
        }

        public ValidationException(List<ValidationFailure> failures) : this()
        {
            var errorMessages = failures
                .Select(d => d.ErrorMessage)
                .Distinct()
                .ToArray();

            Errors.AddRange(errorMessages);
        }
    }
}
