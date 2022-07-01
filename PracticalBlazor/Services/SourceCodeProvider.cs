using System.Net.Http;
using System.Threading.Tasks;

namespace PracticalBlazor.Services;

public class SourceCodeProvider : ISourceCodeProvider
{
    private readonly HttpClient httpClient;

    public SourceCodeProvider(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }


    public async Task<string> GetSourceCodeStringAsync(string fileName) =>
        await this.httpClient.GetStringAsync($"/source-code-data/{fileName}.txt");
}
