using System;

namespace Namespace.ProjectName.Domain.Contract.Model
{
    public class CommandResult
    {
        public Guid Identifier { get; set; }
        public bool Successful { get; set; }

        public bool IsSuccessful()
        {
            return Successful;
        }
    }
}