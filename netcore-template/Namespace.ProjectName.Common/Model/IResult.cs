using System.Collections.Generic;

namespace Namespace.ProjectName.Common.Model
{
    public interface IResult
    {
        RequestError Error { get; }
        IDictionary<string, string[]> ValidationFailures { get; }
        string Message { get; }
    }
}