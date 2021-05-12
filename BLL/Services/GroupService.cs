using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Domain;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Serilog;
namespace BLL.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateGroup(GroupDto group)
        {
            var groupEntity = mapper.Map<Group>(group);
            await unitOfWork.Repository<Group>().AddAsync(groupEntity);
            await unitOfWork.SaveAsync();
        }

        public async Task AddStudent(GroupDto group, string studentEmail)
        {
            var groupEntity = unitOfWork.Repository<Group>().Get(group.Id);

            if (group.CreatorId != groupEntity.CreatorId)
            {
                Log.Logger.Warning("User with id: {id} don't have permission for add student to group: {@group}", group.CreatorId,group);
                throw new NoPermissionException("This user don't have permission");
            }
            var student = await unitOfWork.UserManager.FindByEmailAsync(studentEmail);

            if (student is null)
            {
                Log.Logger.Warning("Not found user with email: {email} to add student ", studentEmail);
                throw new ArgumentException("No user exists with email " + studentEmail);
            }

            groupEntity.Users.Append(student);
            Log.Logger.Verbose("User id: {id} add student: {@student} to group: {@group} ", group.CreatorId, student,group);
            unitOfWork.Repository<Group>().Update(groupEntity);
            await unitOfWork.SaveAsync();
        }

        public async Task RemoveStudent(GroupDto group, string studentEmail)
        {
            var groupEntity = unitOfWork.Repository<Group>().Get(group.Id);

            if (group.CreatorId != groupEntity.CreatorId)
            {
                Log.Logger.Warning("User with id: {id} don't have permission to remove student email:{email} from group: {@group}", group.CreatorId, studentEmail, group);
                throw new NoPermissionException("This user don't have permission");
            }
            var student = await unitOfWork.UserManager.FindByEmailAsync(studentEmail);

            if (student is null)
            {
                Log.Logger.Warning("Not found user with email: {email} to remove student from group: {@group}", studentEmail, group);
                throw new ArgumentException("No user exists with email " + studentEmail);
            }
            Log.Logger.Verbose("User id: {id} remove student: {@student} from group: {@group} ", group.CreatorId, student, group);
            groupEntity.Users.ToList().Remove(student);
            unitOfWork.Repository<Group>().Update(groupEntity);
            await unitOfWork.SaveAsync();
        }

        public async Task RenameGroup(GroupDto group)
        {
            var groupEntity = unitOfWork.Repository<Group>().Get(group.Id);

            if (group.CreatorId != groupEntity.CreatorId)
            {
                Log.Logger.Warning("User with id: {id} don't have permission to rename group: {@group}", group.CreatorId, group);
                throw new NoPermissionException("This user don't have permission");
            }
            Log.Logger.Verbose("User id: {id} rename group: {@group} ", group.CreatorId, group);
            groupEntity.Name = group.Name;
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteGroup(GroupDto group)
        {
            var groupEntity = unitOfWork.Repository<Group>().Get(group.Id);

            if (group.CreatorId != groupEntity.CreatorId)
            {
                Log.Logger.Warning("User with id: {id} don't have permission to remove group: {@group}", group.CreatorId, group);
                throw new NoPermissionException("This user don't have permission");
            }
            Log.Logger.Verbose("User id: {id} delete student: {@student} to group: {@group} ", group.CreatorId, group);
            unitOfWork.Repository<Group>().Delete(groupEntity);
            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<UserDto>> GetGroupStudents(GroupDto group)
        {
            var groupEntity = unitOfWork.Repository<Group>().Get(group.Id);

            return mapper.Map<IEnumerable<UserDto>>(groupEntity.Users);
        }
    }
}