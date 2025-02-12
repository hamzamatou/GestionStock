using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Services.UserService
{
    public class userService : IUser
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public userService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Create(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                // Supprimer les rôles associés à l'utilisateur
                var userRoles = await _userManager.GetRolesAsync(user);
                if (userRoles.Count > 0)
                {
                    var resultRemoveRoles = await _userManager.RemoveFromRolesAsync(user, userRoles);
                    if (!resultRemoveRoles.Succeeded)
                    {
                        throw new System.Exception("Unable to remove user roles");
                    }
                }

                // Supprimer l'utilisateur
                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    throw new System.Exception("Unable to delete user");
                }
            }
            else
            {
                throw new System.Exception("User not found");
            }
        }


        public async Task<User> GetUserAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public List<User> GetUsers()
        {
            return _userManager.Users.ToList();
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var existingUser = await _userManager.FindByIdAsync(user.Id);
            if (existingUser != null)
            {
                existingUser.nom = user.nom;
                existingUser.prenom = user.prenom;
                existingUser.Address = user.Address;
                existingUser.datecreation = user.datecreation;
                await _userManager.UpdateAsync(existingUser);
                return existingUser;
            }
            return null;
        }
        public async Task UpdateUserRolesAsync(User user, string newRole)
        {
            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.AddToRoleAsync(user, newRole);
            // Supprimer tous les rôles existants
            if (currentRoles.Any())
             {
                 await _userManager.RemoveFromRolesAsync(user, currentRoles);
             }

             // Ajouter le nouveau rôle
             if (!string.IsNullOrEmpty(newRole))
             {
                 await _userManager.AddToRoleAsync(user, newRole);
             }
        }
    }
}
