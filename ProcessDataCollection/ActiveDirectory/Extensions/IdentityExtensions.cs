using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProcessDataCollection.Context;

namespace KittingApplication.ActiveDirectory.Extensions
{
    public static class IdentityExtensions
    {
        public static IQueryable<UserPrincipal> FilterUsers(this IQueryable<UserPrincipal> principals) =>
            principals.Where(x => x.Guid.HasValue);

        public static IQueryable<AdUser> SelectAdUsers(this IQueryable<UserPrincipal> principals) =>
            principals.Select(x => AdUser.CastToAdUser(x));


        public static async Task<List<ApplicationUser>> GetUsers(this ApplicationContext db, bool isDeleted = false)
        {
            var users = await db
                .ApplicationUsers
                .Where(x => x.IsDeleted == isDeleted)
                .OrderBy(x => x.LastName)
                .ToListAsync();

            return users;
        }

        public static async Task<List<ApplicationUser>> SearchUsers(this ApplicationContext db, string search, bool isDeleted = false)
        {
            search = search.ToLower();

            var users = await db
                .ApplicationUsers
                .Where(x => x.IsDeleted == isDeleted)
                .Where(x =>
                    x.Email.ToLower().Contains(search) ||
                    x.FirstName.ToLower().Contains(search) ||
                    x.LastName.ToLower().Contains(search) ||
                    x.Username.ToLower().Contains(search)
                )
                .OrderBy(x => x.LastName)
                .ToListAsync();

            return users;
        }

        public static async Task<ApplicationUser> GetUser(this ApplicationContext db, int id)
        {
            var user = await db.ApplicationUsers.FindAsync(id);
            return user;
        }

        public static async Task<ApplicationUser> SyncUser(this AdUser adUser, ApplicationContext db)
        {
            var user = await db
                .ApplicationUsers
                .FirstOrDefaultAsync(x => x.Guid == adUser.Guid);

            user = user == null ?
                await db.AddUser(adUser) :
                await db.UpdateUser(adUser);

            return user;
        }

        public static async Task<ApplicationUser> AddUser(this ApplicationContext db, AdUser adUser)
        {
            ApplicationUser user = null;

            if (await adUser.Validate(db))
            {
                user = new ApplicationUser()
                {
                    Email = adUser.UserPrincipalName,
                    FirstName = adUser.GivenName,
                    Guid = adUser.Guid.Value,
                    IsDeleted = false,
                    LastName = adUser.Surname,
                    SocketName = $@"{adUser.GetDomainPrefix()}\{adUser.SamAccountName}",
                    Theme = "default",
                    Username = adUser.SamAccountName
                };


                await db.ApplicationUsers.AddAsync(user);
                await db.SaveChangesAsync();
            }

            return user;
        }

        public static async Task UpdateUser(this ApplicationContext db, ApplicationUser user)
        {
            db.ApplicationUsers.Update(user);
            await db.SaveChangesAsync();
        }

        private static async Task<ApplicationUser> UpdateUser(this ApplicationContext db, AdUser adUser)
        {
            var user = await db.ApplicationUsers.FirstOrDefaultAsync(x => x.Guid == adUser.Guid);

            user.Email = adUser.UserPrincipalName;
            user.FirstName = adUser.GivenName;
            user.LastName = adUser.Surname;
            user.SocketName = $@"{adUser.GetDomainPrefix()}\{adUser.SamAccountName}";
            user.Username = adUser.SamAccountName;

            await db.SaveChangesAsync();

            return user;
        }

        public static async Task ToggleUserDeleted(this ApplicationContext db, ApplicationUser user)
        {
            db.ApplicationUsers.Attach(user);
            user.IsDeleted = !user.IsDeleted;
            await db.SaveChangesAsync();
        }

        public static async Task ToggleAdminUser(this ApplicationContext db, ApplicationUser user)
        {
            db.ApplicationUsers.Attach(user);
            user.IsAdmin = !user.IsAdmin;
            await db.SaveChangesAsync();
        }

        public static async Task RemoveUser(this ApplicationContext db, ApplicationUser user)
        {
            db.ApplicationUsers.Remove(user);
            await db.SaveChangesAsync();
        }

        public static async Task<bool> Validate(this AdUser user, ApplicationContext db)
        {
            var check = await db
                .ApplicationUsers
                .FirstOrDefaultAsync(x => x.Guid == user.Guid.Value);

            if (check != null)
            {
                throw new Exception("The provided user already has an account");
            }

            return true;
        }

    }
}
