using System;
using System.Threading.Tasks;
using DAL.Domain;
using Microsoft.AspNetCore.Identity;

namespace DAL.Interfaces
{
    /// <summary>
    /// Unit of Work interface
    /// Contains methods Save, Save async, Repository
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Implementation of IUnitOfWork
        /// </summary>
        /// <typeparam name="T">type param of repository</typeparam>
        /// <returns>repository by type</returns>
        public IRepository<T> Repository<T>() where T : BaseEntity;

        /// <summary>
        /// Get user manager
        /// </summary>
        public UserManager<User> UserManager { get; }

        /// <summary>
        /// Get role manager
        /// </summary>
        public RoleManager<Role> RoleManager { get; }

        /// <summary>
        /// Get role manager
        /// </summary>
        public SignInManager<User> SignInManager { get; }

        /// <summary>
        /// Save changes
        /// </summary>
        public void Save();

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns>saved changes</returns>
        public Task SaveAsync();
    }
}