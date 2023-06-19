namespace RealEstate.API.FitnessTests; 

internal static class GlobalSettings
{
    public static string LocalhostUrl = "localhost";
    public static string Scheme = "http"; // or https
    public static string Port = "8000"; // when using docker on local system
    public static string BaseUrl = $"{Scheme}://{LocalhostUrl}:{Port}/{{0}}";
}
