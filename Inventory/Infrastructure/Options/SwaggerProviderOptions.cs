using static Inventory.Infrastructure.Options.SwaggerProviderOptions;

namespace Inventory.Infrastructure.Options
{
    public interface ISwaggerProviderOptions
    {
        /// <summary>
        /// Title
        /// </summary>
        string? Title { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        string? Version { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        string? Description { get; set; }
        /// <summary>
        /// JsonRoute
        /// </summary>
        string? JsonRoute { get; set; }
        /// <summary>
        /// UIEndpoint
        /// </summary>
        string? UIEndpoint { get; set; }
    }
    public sealed class SwaggerProviderOptions : ISwaggerProviderOptions
    {
        /// <summary>
        /// Title
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        public string? Version { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// JsonRoute
        /// </summary>
        public string? JsonRoute { get; set; }
        /// <summary>
        /// UIEndpoint
        /// </summary>
        public string? UIEndpoint { get; set; }
    }
}
