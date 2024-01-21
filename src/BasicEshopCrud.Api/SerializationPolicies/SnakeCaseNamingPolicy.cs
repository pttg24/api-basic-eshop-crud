using System.Text;
using System.Text.Json;

namespace BasicEshopCrud.Api.SerializationPolicies;

public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return name;

        var result = new StringBuilder();
        char previousChar = char.MinValue;

        foreach (char currentChar in name)
        {
            if (char.IsUpper(currentChar))
            {
                if (result.Length > 0 && previousChar != '_')
                    result.Append('_');

                result.Append(char.ToLowerInvariant(currentChar));
            }
            else if (currentChar == '-')
            {
                result.Append('_');
            }
            else
            {
                result.Append(currentChar);
            }

            previousChar = currentChar;
        }

        return result.ToString();
    }
}
