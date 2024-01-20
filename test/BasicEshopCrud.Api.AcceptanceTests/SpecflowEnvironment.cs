namespace BasicEshopCrud.Api.AcceptanceTests;

public static class SpecflowEnvironment
{
    private const string E2EEnvironmentVariableName = "SPECFLOW_ENVIRONMENT";
    private const string Local = "local";
    private const string LocalDocker = "localdocker";

    private static readonly string[] AllowedEnvironments = new[] { Local, LocalDocker };

    static SpecflowEnvironment()
    {
        Name = GetEnvironment();
    }

    public static string Name { get; }

    private static bool IsValidEnvironment(string environment)
    {
        return !String.IsNullOrEmpty(environment) && AllowedEnvironments.Contains(environment);
    }

    private static string GetEnvironment()
    {
        var environment = Environment.GetEnvironmentVariable(E2EEnvironmentVariableName) ?? "localstack";

        if (!IsValidEnvironment(environment))
        {
            return Local;
        }

        return environment;
    }
}