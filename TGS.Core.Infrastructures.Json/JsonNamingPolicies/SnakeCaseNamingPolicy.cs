using System.Text.Json;

namespace TGS.Core.Infrastructures.Json.JsonNamingPolicies
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToSnakeCase();
    }
}