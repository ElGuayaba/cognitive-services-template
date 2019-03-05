namespace Namespace.ProjectName.Domain.Implementation.Exception
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException(object id)
            : base($"Entity '{id}' was not found.")
        {
        }
    }
}