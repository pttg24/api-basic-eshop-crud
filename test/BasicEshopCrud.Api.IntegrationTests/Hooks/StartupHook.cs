namespace BasicEshopCrud.Api.IntegrationTests.Hooks;

[Binding]
public class StartupHook
{
    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        Startup.BuildAndStartHost();
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        Startup.StopHost();
    }
}
