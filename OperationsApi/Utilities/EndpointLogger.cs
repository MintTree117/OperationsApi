namespace OperationsApi.Utilities;

internal sealed class EndpointLogger // Static Singleton
{
    const string Padding = "------------------";
    
    internal static ILogger<EndpointLogger> Logger { get; set; } = null!;
    internal static void LogInformation( string message ) =>
        Logger.LogInformation( $"{Padding} {message}" );
    internal static void LogError( string message ) =>
        Logger.LogError( $"{Padding} {message}" );
    internal static void LogException( Exception exception, string message ) =>
        Logger.LogError( $"{Padding} {exception} {message}" );

    internal static void EndpointHit( string endpoint, Dictionary<string, object>? vars = null ) =>
        Logger.LogInformation( $"{Padding} Endpoint Hit: {endpoint} {GetVars( vars )}" );
    internal static void EndpointSuccess( string endpoint, Dictionary<string, object>? vars = null ) =>
        Logger.LogInformation( $"{Padding} Endpoint Success: {endpoint} {GetVars( vars )}" );
    internal static void EndpointFail( string endpoint, Dictionary<string, object>? vars = null ) =>
        Logger.LogInformation( $"{Padding} Endpoint Fail: {endpoint} {GetVars( vars )}" );
    
    static string GetVars( Dictionary<string, object>? vars )
    {
        if (vars is null)
            return string.Empty;
        
        string str = string.Empty;
        foreach ( var kvp in vars )
            str = $"{str}, {kvp.Key} = {kvp.Value} ";
        
        return str;
    }
}