// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityModels.cs" company="">
//   
// </copyright>
// <summary>
//   The application user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht.Models
{
    #region

    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    #endregion

    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    /// <summary>The application user.</summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>The generate user identity.</summary>
        /// <param name="manager">The manager.</param>
        /// <returns>The <see cref="ClaimsIdentity"/>.</returns>
        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }

        /// <summary>The generate user identity async.</summary>
        /// <param name="manager">The manager.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }

    /// <summary>The application db context.</summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>Initializes a new instance of the <see cref="ApplicationDbContext"/> class.</summary>
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        /// <summary>The create.</summary>
        /// <returns>The <see cref="ApplicationDbContext"/>.</returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}

#region Helpers
namespace IndividueleOpdracht
{
    #region

    using System;
    using System.Web;

    #endregion

    /// <summary>The identity helper.</summary>
    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        /// <summary>The xsrf key.</summary>
        public const string XsrfKey = "XsrfId";

        /// <summary>The provider name key.</summary>
        public const string ProviderNameKey = "providerName";

        /// <summary>The code key.</summary>
        public const string CodeKey = "code";

        /// <summary>The user id key.</summary>
        public const string UserIdKey = "userId";

        /// <summary>The get provider name from request.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }

        /// <summary>The get code from request.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetCodeFromRequest(HttpRequest request)
        {
            return request.QueryString[CodeKey];
        }

        /// <summary>The get user id from request.</summary>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetUserIdFromRequest(HttpRequest request)
        {
            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        }

        /// <summary>The get reset password redirect url.</summary>
        /// <param name="code">The code.</param>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
        {
            var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        /// <summary>The get user confirmation redirect url.</summary>
        /// <param name="code">The code.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="request">The request.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
        {
            var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        /// <summary>The is local url.</summary>
        /// <param name="url">The url.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        /// <summary>The redirect to return url.</summary>
        /// <param name="returnUrl">The return url.</param>
        /// <param name="response">The response.</param>
        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!string.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
}
#endregion
