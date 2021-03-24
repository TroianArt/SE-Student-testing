using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Domain;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DAL.Repositories
{
    /// <summary>
    /// Unit of work class
    /// Implement IUnitOfWork interface
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationContext context;

        private bool disposed;
        private Dictionary<string, object> repositories;

        /// <summary>
        /// Constructor by default
        /// </summary>
        public UnitOfWork()
        {
            this.context = new ApplicationContext();
        }

        /// <summary>
        /// Constructor with paramethr
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="signInManager"></param>
        public UnitOfWork(
            ApplicationContext context,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            SignInManager<User> signInManager)
        {
            this.context = context;
            this.UserManager = userManager;
            this.RoleManager = roleManager;
            this.SignInManager = signInManager;
        }

        /// <summary>
        /// Implementation of IUnitOfWork
        /// </summary>
        /// <typeparam name="T">type param of repository</typeparam>
        /// <returns>repository by type</returns>
        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            repositories ??= new Dictionary<string, object>();

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<T>);
                var repositoryInstance = Activator.CreateInstance(repositoryType, context);
                repositories.Add(type, repositoryInstance);
            }
            return (Repository<T>)repositories[type];
        }

        public UserManager<User> UserManager { get; }

        public RoleManager<Role> RoleManager { get; }

        public SignInManager<User> SignInManager { get; }

        /// <summary>
        /// Defining the destructor
        /// </summary>
        /// <param name="disposing">disposing</param>
        public virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                context.Dispose();
            }

            disposed = true;
        }

        /// <summary>
        /// Defining the destructor
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Save changes
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }
        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns>saved changes</returns>
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}