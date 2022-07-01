using System.Threading.Tasks;

namespace PracticalBlazor.Services;

public interface ISourceCodeProvider
{
    Task<string> GetSourceCodeStringAsync(string fileName);
}