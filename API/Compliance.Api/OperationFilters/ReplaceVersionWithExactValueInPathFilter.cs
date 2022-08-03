using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Compliance.Api.OperationFilters
{
    /// <summary>
    /// ReplaceVersionWithExactValueInPath Filter
    /// </summary>
    /// <seealso cref="Swashbuckle.AspNetCore.SwaggerGen.IDocumentFilter" />
    public class ReplaceVersionWithExactValueInPathFilter : IDocumentFilter
    {
        /// <summary>
        /// Applies the specified swagger document.
        /// </summary>
        /// <param name="swaggerDoc">The swagger document.</param>
        /// <param name="context">The context.</param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = new OpenApiPaths();
            foreach (var path in swaggerDoc.Paths)
            {
                paths.Add(path.Key.Replace("v{version}", $"v{swaggerDoc.Info.Version}"), path.Value);
            }
            swaggerDoc.Paths = paths;
        }
    }
}
