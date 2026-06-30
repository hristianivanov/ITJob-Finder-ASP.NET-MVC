namespace DevHunter.Common
{
    public static class GuidParser
    {
        public static Guid ParseRequired(string id, string entityName)
        {
            if (Guid.TryParse(id, out Guid parsed))
            {
                return parsed;
            }

            throw new InvalidOperationException($"A valid {entityName} id is required.");
        }

        public static bool TryParseTwo(string firstId, string secondId, out Guid parsedFirst, out Guid parsedSecond)
        {
            return Guid.TryParse(firstId, out parsedFirst) & Guid.TryParse(secondId, out parsedSecond);
        }

        public static (Guid First, Guid Second) ParseRequiredTwo(string firstId, string secondId)
        {
            if (!TryParseTwo(firstId, secondId, out Guid first, out Guid second))
            {
                throw new InvalidOperationException("Valid identifiers are required.");
            }

            return (first, second);
        }
    }
}
