using System.Threading.Tasks;
using BLL.DTO;
using DAL.Domain;

namespace BLL.Interfaces
{
    public interface IGroupService
    {
        Task CreateGroup(GroupDto group);
        Task AddStudent(GroupDto group, string studentEmail);
        Task RemoveStudent(GroupDto group, string studentEmail);
        Task RenameGroup(GroupDto group);
        Task DeleteGroup(GroupDto group);
    }
}