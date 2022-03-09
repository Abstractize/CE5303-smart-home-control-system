using System.Security.Claims;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;

namespace Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userService;
        private readonly SignInManager<User> _signInService;

        public AuthService(UserManager<User> userService, SignInManager<User> signInService)
        {
            _userService = userService;
            _signInService = signInService;
        }

        public Task<IdentityResult> AccessFailedAsync(User user)
            => _userService.AccessFailedAsync(user);

        public Task<IdentityResult> AddClaimAsync(User user, Claim claim)
            => _userService.AddClaimAsync(user, claim);

        public Task<IdentityResult> AddClaimsAsync(User user, IEnumerable<Claim> claims)
            => _userService.AddClaimsAsync(user, claims);

        public Task<IdentityResult> AddLoginAsync(User user, UserLoginInfo login)
            => _userService.AddLoginAsync(user, login);

        public Task<IdentityResult> AddPasswordAsync(User user, string password)
            => _userService.AddPasswordAsync(user, password);

        public Task<IdentityResult> AddToRoleAsync(User user, string role)
            => _userService.AddToRoleAsync(user, role);

        public Task<IdentityResult> AddToRolesAsync(User user, IEnumerable<string> roles)
            => _userService.AddToRolesAsync(user, roles);

        public Task<IdentityResult> ChangeEmailAsync(User user, string newEmail, string token)
            => _userService.ChangeEmailAsync(user, newEmail, token);

        public Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
            => _userService.ChangePasswordAsync(user, currentPassword, newPassword);

        public Task<IdentityResult> ChangePhoneNumberAsync(User user, string phoneNumber, string token)
            => _userService.ChangePhoneNumberAsync(user, phoneNumber, token);

        public Task<bool> CheckPasswordAsync(User user, string password)
            => _userService.CheckPasswordAsync(user, password);

        public Task<IdentityResult> ConfirmEmailAsync(User user, string token)
            => _userService.ConfirmEmailAsync(user, token);

        public Task<int> CountRecoveryCodesAsync(User user)
            => _userService.CountRecoveryCodesAsync(user);

        public Task<IdentityResult> CreateAsync(User user)
            => _userService.CreateAsync(user);

        public Task<IdentityResult> CreateAsync(User user, string password)
            => _userService.CreateAsync(user, password);

        public Task<byte[]> CreateSecurityTokenAsync(User user)
            => _userService.CreateSecurityTokenAsync(user);

        public Task<IdentityResult> DeleteAsync(User user)
            => _userService.DeleteAsync(user);

        public void Dispose()
            => _userService?.Dispose();

        public Task<User> FindByEmailAsync(string email)
            => _userService.FindByEmailAsync(email);

        public Task<User> FindByIdAsync(string userId)
            => _userService.FindByIdAsync(userId);

        public Task<User> FindByLoginAsync(string loginProvider, string providerKey)
            => _userService.FindByLoginAsync(loginProvider, providerKey);

        public Task<User> FindByNameAsync(string userName)
            => _userService.FindByNameAsync(userName);

        public Task<string> GenerateChangeEmailTokenAsync(User user, string newEmail)
            => _userService.GenerateChangeEmailTokenAsync(user, newEmail);

        public Task<string> GenerateChangePhoneNumberTokenAsync(User user, string phoneNumber)
            => _userService.GenerateChangePhoneNumberTokenAsync(user, phoneNumber);

        public Task<string> GenerateConcurrencyStampAsync(User user)
            => _userService.GenerateConcurrencyStampAsync(user);

        public Task<string> GenerateEmailConfirmationTokenAsync(User user)
            => _userService.GenerateEmailConfirmationTokenAsync(user);

        public string GenerateNewAuthenticatorKey() 
            => _userService.GenerateNewAuthenticatorKey();

        public Task<IEnumerable<string>> GenerateNewTwoFactorRecoveryCodesAsync(User user, int number)
            => _userService.GenerateNewTwoFactorRecoveryCodesAsync(user, number);

        public Task<string> GeneratePasswordResetTokenAsync(User user)
            => _userService.GeneratePasswordResetTokenAsync(user);

        public Task<string> GenerateTwoFactorTokenAsync(User user, string tokenProvider)
            => _userService.GenerateTwoFactorTokenAsync(user, tokenProvider);

        public Task<string> GenerateUserTokenAsync(User user, string tokenProvider, string purpose)
            => _userService.GenerateUserTokenAsync(user, tokenProvider, purpose);

        public Task<int> GetAccessFailedCountAsync(User user)
            => _userService.GetAccessFailedCountAsync(user);

        public Task<string> GetAuthenticationTokenAsync(User user, string loginProvider, string tokenName)
            => _userService.GetAuthenticationTokenAsync(user, loginProvider, tokenName);

        public Task<string> GetAuthenticatorKeyAsync(User user)
            => _userService.GetAuthenticatorKeyAsync(user);

        public Task<IList<Claim>> GetClaimsAsync(User user)
            => _userService.GetClaimsAsync(user);

        public Task<string> GetEmailAsync(User user)
            => _userService.GetEmailAsync(user);

        public Task<bool> GetLockoutEnabledAsync(User user)
            => _userService.GetLockoutEnabledAsync(user);

        public Task<DateTimeOffset?> GetLockoutEndDateAsync(User user)
            => _userService.GetLockoutEndDateAsync(user);

        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
            => _userService.GetLoginsAsync(user);

        public Task<string> GetPhoneNumberAsync(User user)
            => _userService.GetPhoneNumberAsync(user);

        public Task<IList<string>> GetRolesAsync(User user)
            => _userService.GetRolesAsync(user);

        public Task<string> GetSecurityStampAsync(User user)
            => _userService.GetSecurityStampAsync(user);

        public Task<bool> GetTwoFactorEnabledAsync(User user)
            => _userService.GetTwoFactorEnabledAsync(user);

        public Task<User> GetUserAsync(ClaimsPrincipal principal)
            => _userService.GetUserAsync(principal);

        public string GetUserId(ClaimsPrincipal principal)
            => _userService.GetUserId(principal);

        public Task<string> GetUserIdAsync(User user)
            => _userService.GetUserIdAsync(user);

        public string GetUserName(ClaimsPrincipal principal)
            => _userService.GetUserName(principal);

        public Task<string> GetUserNameAsync(User user)
            => _userService.GetUserNameAsync(user);

        public Task<IList<User>> GetUsersForClaimAsync(Claim claim)
            => _userService.GetUsersForClaimAsync(claim);

        public Task<IList<User>> GetUsersInRoleAsync(string roleName)
            => _userService.GetUsersInRoleAsync(roleName);

        public Task<IList<string>> GetValidTwoFactorProvidersAsync(User user)
            => _userService.GetValidTwoFactorProvidersAsync(user);

        public Task<bool> HasPasswordAsync(User user)
            => _userService.HasPasswordAsync(user);

        public Task<bool> IsEmailConfirmedAsync(User user)
            => _userService.IsEmailConfirmedAsync(user);

        public Task<bool> IsInRoleAsync(User user, string role)
            => _userService.IsInRoleAsync(user, role);

        public Task<bool> IsLockedOutAsync(User user)
            => _userService.IsLockedOutAsync(user);

        public Task<bool> IsPhoneNumberConfirmedAsync(User user)
            => _userService.IsPhoneNumberConfirmedAsync(user);

        public string NormalizeEmail(string email)
            => _userService.NormalizeEmail(email);

        public string NormalizeName(string name)
            => _userService.NormalizeName(name);

        public Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(User user, string code)
            => _userService.RedeemTwoFactorRecoveryCodeAsync(user, code);

        public void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<User> provider) 
            => _userService.RegisterTokenProvider(providerName, provider);

        public Task<IdentityResult> RemoveAuthenticationTokenAsync(User user, string loginProvider, string tokenName)
            => _userService.RemoveAuthenticationTokenAsync(user, loginProvider, tokenName);

        public Task<IdentityResult> RemoveClaimAsync(User user, Claim claim)
            => _userService.RemoveClaimAsync(user, claim);

        public Task<IdentityResult> RemoveClaimsAsync(User user, IEnumerable<Claim> claims)
            => _userService.RemoveClaimsAsync(user, claims);

        public Task<IdentityResult> RemoveFromRoleAsync(User user, string role)
            => _userService.RemoveFromRoleAsync(user, role);

        public Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> roles)
            => _userService.RemoveFromRolesAsync(user, roles);

        public Task<IdentityResult> RemoveLoginAsync(User user, string loginProvider, string providerKey)
            => _userService.RemoveLoginAsync(user, loginProvider, providerKey);

        public Task<IdentityResult> RemovePasswordAsync(User user)
            => _userService.RemovePasswordAsync(user);

        public Task<IdentityResult> ReplaceClaimAsync(User user, Claim claim, Claim newClaim)
            => _userService.ReplaceClaimAsync(user, claim, newClaim);

        public Task<IdentityResult> ResetAccessFailedCountAsync(User user)
            => _userService.ResetAccessFailedCountAsync(user);

        public Task<IdentityResult> ResetAuthenticatorKeyAsync(User user)
            => _userService.ResetAuthenticatorKeyAsync(user);

        public Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword)
            => _userService.ResetPasswordAsync(user, token, newPassword);

        public Task<IdentityResult> SetAuthenticationTokenAsync(User user, string loginProvider, string tokenName, string tokenValue)
            => _userService.SetAuthenticationTokenAsync(user, loginProvider, tokenName, tokenValue);

        public Task<IdentityResult> SetEmailAsync(User user, string email)
            => _userService.SetEmailAsync(user, email);

        public Task<IdentityResult> SetLockoutEnabledAsync(User user, bool enabled)
            => _userService.SetLockoutEnabledAsync(user, enabled);

        public Task<IdentityResult> SetLockoutEndDateAsync(User user, DateTimeOffset? lockoutEnd)
            => _userService.SetLockoutEndDateAsync(user, lockoutEnd);

        public Task<IdentityResult> SetPhoneNumberAsync(User user, string phoneNumber)
            => _userService.SetPhoneNumberAsync(user, phoneNumber);

        public Task<IdentityResult> SetTwoFactorEnabledAsync(User user, bool enabled)
            => _userService.SetTwoFactorEnabledAsync(user, enabled);

        public Task<IdentityResult> SetUserNameAsync(User user, string userName)
            => _userService.SetUserNameAsync(user, userName);

        public Task<IdentityResult> UpdateAsync(User user)
            => _userService.UpdateAsync(user);

        public Task UpdateNormalizedEmailAsync(User user)
            => _userService.UpdateNormalizedEmailAsync(user);

        public Task UpdateNormalizedUserNameAsync(User user) 
            => _userService.UpdateNormalizedUserNameAsync(user);

        public Task<IdentityResult> UpdateSecurityStampAsync(User user) 
            => _userService.UpdateSecurityStampAsync(user);

        public Task<bool> VerifyChangePhoneNumberTokenAsync(User user, string token, string phoneNumber)
            => _userService.VerifyChangePhoneNumberTokenAsync(user, token, phoneNumber);

        public Task<bool> VerifyTwoFactorTokenAsync(User user, string tokenProvider, string token)
            => _userService.VerifyTwoFactorTokenAsync(user, tokenProvider, token);

        public Task<bool> VerifyUserTokenAsync(User user, string tokenProvider, string purpose, string token) 
            => _userService.VerifyUserTokenAsync(user, tokenProvider, purpose, token);

        public Task<SignInResult> CheckPasswordSignInAsync(User user, string password, bool lockoutOnFailure = false)
            => _signInService.CheckPasswordSignInAsync(user, password, lockoutOnFailure);
        public Task SignOutAsync()
            => _signInService.SignOutAsync();

    }
}
