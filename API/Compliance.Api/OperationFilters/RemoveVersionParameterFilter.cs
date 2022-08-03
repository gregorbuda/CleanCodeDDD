using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Compliance.Api.OperationFilters
{
    /// <summary>
    /// RemoveVersionParameter Filter
    /// </summary>
    /// <seealso cref="Swashbuckle.AspNetCore.SwaggerGen.IOperationFilter" />
    public class RemoveVersionParameterFilter : IOperationFilter
    {
        /// <summary>
        /// Applies the specified operation.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="context">The context.</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var versionParameter = operation.Parameters.FirstOrDefault(p => p.Name == "version");
            if (versionParameter != null)
                operation.Parameters.Remove(versionParameter);

            var versionParameter2 = operation.Parameters.FirstOrDefault(p => p.Name == "api-version");
            if (versionParameter2 != null)
                operation.Parameters.Remove(versionParameter2);
        }
    }
}
