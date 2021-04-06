using System;
using System.Text.Json;

namespace TGS.Core.Infrastructures.Json
{
	public interface IJsonSerializationProvider
	{
		T DeserializeFromString<T>(string value, JsonSerializerOptions options = null);

		string SerializeToString<T>(T obj, JsonSerializerOptions options = null);

		string SerializeToString(object obj, Type inputType, JsonSerializerOptions options = null);
	}
}
