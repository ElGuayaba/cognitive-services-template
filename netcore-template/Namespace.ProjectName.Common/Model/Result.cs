using System;
using System.Collections.Generic;

namespace Namespace.ProjectName.Common.Model
{
    public class Result : IResult
    {
        public RequestError Error { get; }
        public IDictionary<string, string[]> ValidationFailures { get; }
        public string Message { get; }
        
        protected Result(RequestError error, IDictionary<string, string[]> validationFailures, string message = null)
        {
            Error = error;
            ValidationFailures = validationFailures;
            Message = message;
        }
        
        public static Result ValidationFail(IDictionary<string, string[]> validationFailures)
        {
            return new Result(RequestError.Validation, validationFailures);
        }

    }
    public class Result<T> : Result
    {
        public T Value { get; set; }
//        public RequestError Error { get; set; }
//        public IDictionary<string, string[]> ValidationFailures { get; set; }
//        public string Message { get; set; }
        
        protected Result(T value, RequestError error, IDictionary<string, string[]> validationFailures, string message = null) : base(error, validationFailures, message)
        {
            Value = value;
        }
        
        public static Result<T> Success(T value)
        {
            return new Result<T>(value, RequestError.None, null);
        }
        
        public static Result<T> NotFound(object identifier)
        {
            return new Result<T>(default(T), RequestError.NotFound, null, identifier.ToString());
        }

        public new static Result<T> ValidationFail(IDictionary<string, string[]> validationFailures)
        {
            return new Result<T>(default(T), RequestError.Validation, validationFailures);
        }

        public static Result<T> Forbidden(string message)
        {
            return new Result<T>(default(T), RequestError.Forbidden, null, message);
        }

        public static Result<T> UnknownError()
        {
            return new Result<T>(default(T), RequestError.Unknown, null);
        }

        public bool IsSuccessful()
        {
            return Error == RequestError.None;
        }

        public bool HasValidationErrors()
        {
            return Error == RequestError.Validation;
        }

        public bool HasNotBeenFound()
        {
            return Error == RequestError.NotFound;
        }

        public bool IsForbidden()
        {
            return Error == RequestError.Forbidden;
        }

        public bool IsUnknownError()
        {
            return Error == RequestError.Unknown;
        }
    }
}