using TGS.Core.Infrastructures.Json;

namespace Microsoft.Extensions.DependencyInjection
{
	/// <summary>
	/// Dependency Injection of Infrastructures.Json
	/// </summary>
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddSystemJsonSerializer(this IServiceCollection services)
		{
			return services.AddSingleton<IJsonSerializationProvider, JsonSerializationProvider>();
		}
	}
}
