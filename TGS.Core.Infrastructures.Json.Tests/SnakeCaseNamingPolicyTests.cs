using System;
using System.Text.Json;
using NUnit.Framework;
using TGS.Core.Infrastructures.Json.JsonNamingPolicies;

namespace TGS.Core.Infrastructures.Json.Tests
{
    [TestFixture]
    public class SnakeCaseNamingPolicyTests
    {
        [SetUp]
        public void _Setup()
        {
            _sut = new SnakeCaseNamingPolicy();
        }

        private SnakeCaseNamingPolicy _sut;

        [Test]
        public void Null_String_Does_Not_Cause_An_Exception()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _sut.ConvertName(null);
            });
        }

        [Test]
        public void Empty_String_Does_Not_Cause_An_Exception()
        {
            Assert.DoesNotThrow(() =>
            {
                _sut.ConvertName(string.Empty);
            });
        }

        [TestCase("Id", "id")]
        [TestCase("Forename", "forename")]
        [TestCase("PeopleCarrier", "people_carrier")]
        [TestCase("MultiWordString", "multi_word_string")]
        public void Input_String_Is_Returned_In_Snake_Case(string input, string expectedOutput)
        {
            var result = _sut.ConvertName(input);

            Assert.That(
                result,
                Is.EqualTo(expectedOutput)
            );
        }

        private record Data(string TestData);

        [Test]
        public void Can_Serialize_In_Snake_Case()
        {
            var expected = new
            {
                TestData = "test"
            };

            var value = JsonSerializer.Serialize(expected,
                new JsonSerializerOptions { PropertyNamingPolicy = new SnakeCaseNamingPolicy() });

            Assert.IsTrue(value.IndexOf("test_data", StringComparison.Ordinal) > -1);
        }
    }
}