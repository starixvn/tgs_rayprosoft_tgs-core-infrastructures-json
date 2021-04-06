using System.Globalization;
using System;
using NUnit.Framework;
using System.Text.Json;
using TGS.Core.Infrastructures.Json.JsonConverters;
using FluentAssertions;

namespace TGS.Core.Infrastructures.Json.Tests
{
	public class Tests
	{
		[Test]
		public void Can_Deserialize_Number_Value_To_String()
		{
			var expected = new
			{
				Odds = 4.5f,
				Hdp = 4.6m,
				Amount = 10m
			};

			var value = JsonSerializer.Serialize(expected);

			Func<Data> func = () =>
				JsonSerializer.Deserialize<Data>(value, new() { Converters = { new NumberToStringConverter() } });

			var data = func();

			func.Should().NotThrow();

			var culture = CultureInfo.InvariantCulture;
			expected.Odds.ToString(culture).Should().Be(data.Odds);
			expected.Hdp.ToString(culture).Should().Be(data.Hdp);
			expected.Amount.ToString(culture).Should().Be(data.Amount.ToString(culture));
		}

		[Test]
		public void Can_Serialize_Number_Value_To_String()
		{
			var expected = new
			{
				Odds = 4.5f,
				Hdp = 4.6m,
				Amount = 10m
			};

			Func<string> func = () =>
				JsonSerializer.Serialize(expected, expected.GetType(),
					new() { Converters = { new NumberToStringConverter() } });

			var value = func();

			func.Should().NotThrow();
			value.Should().NotBeNullOrEmpty();
		}

		[Test]
		public void Can_Deserialize_String_Value_To_String()
		{
			var expected = new
			{
				Odds = 4.5f,
				Hdp = "4.6",
				Amount = 10m
			};

			var value = JsonSerializer.Serialize(expected);

			Func<Data> func = () =>
				JsonSerializer.Deserialize<Data>(value, new() { Converters = { new NumberToStringConverter() } });

			var data = func();

			func.Should().NotThrow();

			var culture = CultureInfo.InvariantCulture;
			expected.Odds.ToString(culture).Should().Be(data.Odds);
			expected.Hdp.ToString(culture).Should().Be(data.Hdp);
			expected.Amount.ToString(culture).Should().Be(data.Amount.ToString(culture));
		}

		[Test]
		public void Can_Serialize_String_Value_To_String()
		{
			var expected = new
			{
				Odds = 4.5f,
				Hdp = "4.6",
				Amount = 10m
			};

			Func<string> func = () =>
				JsonSerializer.Serialize(expected, expected.GetType(),
					new() { Converters = { new NumberToStringConverter() } });

			var value = func();

			func.Should().NotThrow();
			value.Should().NotBeNullOrEmpty();
		}

		private record Data(string Hdp, string Odds, decimal Amount);
	}
}