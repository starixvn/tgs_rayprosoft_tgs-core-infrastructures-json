using System;
using System.Text.Json;

namespace TGS.Core.Infrastructures.Json
{
	public sealed class JsonSerializationProvider : IJsonSerializationProvider
	{
		public T DeserializeFromString<T>(string value, JsonSerializerOptions options) =>
			JsonSerializer.Deserialize<T>(value, options);

		public string SerializeToString<T>(T obj, JsonSerializerOptions options) =>
			JsonSerializer.Serialize(obj, options);

		public string SerializeToString(object obj, Type inputType, JsonSerializerOptions options) =>
			JsonSerializer.Serialize(obj, inputType, options);
	}
}
