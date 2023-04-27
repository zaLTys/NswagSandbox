using NswagSandbox.sandbox;
using Xunit.Abstractions;

namespace AcceptanceTest;

public class ApiTests
{
    private readonly HttpClient _httpClient;
    private readonly ITestOutputHelper _output;

    public ApiTests(ITestOutputHelper output)
    {
        _httpClient = new HttpClient();
        _output = output;
    }

    [Fact]
    public async Task TestGetEndpoint()
    {
        // Arrange
        var apiClient = new Client(_httpClient);

        // Act
        try
        {
            var result = await apiClient.WeatherForecastAsync();

            // Assert
            Assert.NotNull(result);
            _output.WriteLine(result.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw; 
        }

    }
}