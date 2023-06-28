namespace RSKDockerDemo.IntegrationTests.Helpers;
/// <summary>
/// A set of helpers allowing us to detect information about Docker.
/// </summary>
public static class DockerHelpers
{
    /// <summary>
    /// ARe we currently running in Docker.
    /// </summary>
    /// <returns><c>True</c> if the code is currently running in a Docker container, <c>False</c> otherwise.</returns>
    public static bool InDocker() => Convert.ToBoolean(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"));
}