namespace BikeShop.Infrastructure.Http;

internal class BikeShopHttpClientConfig
{
    public PollyDecorators? Decorators { get; init; }
}

internal class PollyDecorators
{
    public bool Enabled { get; init; }
    public TimeoutDecoratorConfig Timeout { get; init; }
    public CircuitBreakerDecoratorConfig CircuitBreaker { get; init; }
    public RetryDecoratorConfig Retry { get; init; }
}

internal class TimeoutDecoratorConfig
{
    public bool Enabled { get; init; }
    public uint SecondsToTimeout { get; init; }
}

internal class CircuitBreakerDecoratorConfig
{
    public bool Enabled { get; init; }
    public int ExceptionsAllowedBeforeBreaking { get; init; }
    public uint DurationOfBreakInSeconds { get; init; }
}

internal class RetryDecoratorConfig
{
    public bool Enabled { get; init; }
    public int RetryCount { get; init; }
}