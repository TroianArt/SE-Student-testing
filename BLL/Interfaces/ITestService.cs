using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ITestService
    {
        Task<bool> CreateTest(TestDto test); 
        Task<bool> EditTest(TestDto test); 
        Task<bool> DeleteTest(TestDto test);
    }
}