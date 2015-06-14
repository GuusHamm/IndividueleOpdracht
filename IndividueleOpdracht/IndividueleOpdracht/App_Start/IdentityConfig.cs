// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityConfig.cs" company="">
//   
// </copyright>
// <summary>
//   The email service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IndividueleOpdracht
{
    #region

    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using IndividueleOpdracht.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;

    #endregion

    /// <summary>The email service.</summary>
    public class EmailService : IIdentityMessageService
    {
        /// <summary>The send async.</summary>
        /// <param name="message">The message.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    /// <summary>The sms service.</summary>
    public class SmsService : IIdentityMessageService
    {
        /// <summary>The send async.</summary>
        /// <param name="message">The message.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    /// <summary>The application user manager.</summary>
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        /// <summary>Initializes a new instance of the <see cref="ApplicationUserManager"/> class.</summary>
        /// <param name="store">The store.</param>
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        /// <summary>The create.</summary>
        /// <param name="options">The options.</param>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="ApplicationUserManager"/>.</returns>
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(
                new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
                                        {
                                            AllowOnlyAlphanumericUserNames = false, 
                                            RequireUniqueEmail = true
                                        };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
                                            {
                                                RequiredLength = 6, 
                                                RequireNonLetterOrDigit = true, 
                                                RequireDigit = true, 
                                                RequireLowercase = true, 
                                                RequireUppercase = true, 
                                            };

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider(
                "Phone Code", 
                new PhoneNumberTokenProvider<ApplicationUser> { MessageFormat = "Your security code is {0}" });
            manager.RegisterTwoFactorProvider(
                "Email Code", 
                new EmailTokenProvider<ApplicationUser>
                    {
                        Subject = "Security Code", 
                        BodyFormat = "Your security code is {0}"
                    });

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }
    }

    /// <summary>The application sign in manager.</summary>
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        /// <summary>Initializes a new instance of the <see cref="ApplicationSignInManager"/> class.</summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="authenticationManager">The authentication manager.</param>
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) :
            base(userManager, authenticationManager) { }

        /// <summary>The create user identity async.</summary>
        /// <param name="user">The user.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        /// <summary>The create.</summary>
        /// <param name="options">The options.</param>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="ApplicationSignInManager"/>.</returns>
        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
