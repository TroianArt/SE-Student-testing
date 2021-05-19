using System;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Domain;
using DAL.Interfaces;
using Serilog;

namespace BLL.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> CreateTest(TestDto test)
        {
            try
            {
                var testEntity = mapper.Map<Test>(test);
                await unitOfWork.Repository<Test>().AddAsync(testEntity);
                await unitOfWork.Repository<Test>().SaveAsync();
                Log.Logger.Verbose("Create test: {@test}  ", test);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> EditTest(TestDto test)
        {
            try
            {
                var testEntity = mapper.Map<Test>(test);
                unitOfWork.Repository<Test>().Update(testEntity);
                await unitOfWork.Repository<Test>().SaveAsync();
                Log.Logger.Verbose("Edit test: {@test}  ", test);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTest(TestDto test)
        {
            try
            {

                var testEntity = mapper.Map<Test>(test);
                unitOfWork.Repository<Test>().Delete(testEntity);
                await unitOfWork.Repository<Test>().SaveAsync();
                Log.Logger.Verbose("Delete test: {@test}  ", test);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}