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
                throw new NoPermissionException("This user don't have permission");
            }
            var student = await unitOfWork.UserManager.FindByEmailAsync(studentEmail);

            if (student is null)
            {
                throw new ArgumentException("No user exists with email " + studentEmail);
            }

            groupEntity.Users.Append(student);
            unitOfWork.Repository<Group>().Update(groupEntity);
            await unitOfWork.SaveAsync();
        }

        public async Task RemoveStudent(GroupDto group, string studentEmail)
        {
            var groupEntity = unitOfWork.Repository<Group>().Get(group.Id);

            if (group.CreatorId != groupEntity.CreatorId)
            {
                throw new NoPermissionException("This user don't have permission");
            }
            var student = await unitOfWork.UserManager.FindByEmailAsync(studentEmail);

            if (student is null)
            {
                throw new ArgumentException("No user exists with email " + studentEmail);
            }

            groupEntity.Users.ToList().Remove(student);
            unitOfWork.Repository<Group>().Update(groupEntity);
            await unitOfWork.SaveAsync();
        }

        public async Task RenameGroup(GroupDto group)
        {
            var groupEntity = unitOfWork.Repository<Group>().Get(group.Id);

            if (group.CreatorId != groupEntity.CreatorId)
            {
                throw new NoPermissionException("This user don't have permission");
            }

            groupEntity.Name = group.Name;
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteGroup(GroupDto group)
        {
            var groupEntity = unitOfWork.Repository<Group>().Get(group.Id);

            if (group.CreatorId != groupEntity.CreatorId)
            {
                throw new NoPermissionException("This user don't have permission");
            }

            unitOfWork.Repository<Group>().Delete(groupEntity);
            await unitOfWork.SaveAsync();
        }
    }
}