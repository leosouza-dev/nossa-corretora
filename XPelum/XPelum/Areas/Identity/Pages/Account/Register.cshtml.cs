using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using XPelum.Areas.Identity.Services;
using XPelum.CustomDataAnnotation;
using XPelum.Models;
using XPelum.Resources;

namespace XPelum.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Cliente> _signInManager;
        private readonly UserManager<Cliente> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ValidaCpfService _validaCpfService;
        private readonly IStringLocalizer _identityLocalizer;

        public RegisterModel(
            UserManager<Cliente> userManager,
            SignInManager<Cliente> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ValidaCpfService validaCpfService,
            IStringLocalizerFactory factory
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _validaCpfService = validaCpfService;

            var type = typeof(IdentityResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _identityLocalizer = factory.Create("IdentityResource", assemblyName.Name);

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "IsRequiredMsg")]
            [Display(Name = "Name")]
            public string NomeCompleto { get; set; }

            [Required(ErrorMessage = "IsRequiredMsg")]
            [EmailAddress(ErrorMessage = "EmailMsg")]
            [Display(Name = "Email*")]
            public string Email { get; set; }

            //criar validação de cpf
            [CpfIsValid(ErrorMessage = "CpfMsg")]
            [Required(ErrorMessage = "IsRequiredMsg")]
            [StringLength(11, ErrorMessage = "StringLengthCpfMsg", MinimumLength = 11)]
            [Display(Name = "ID")]
            public string CPF { get; set; }

            [Required(ErrorMessage = "IsRequiredMsg")]
            [DataType(DataType.DateTime)]
            [Display(Name = "DateOfBirth")]
            public DateTime DataNascimento { get; set; }

            [Required(ErrorMessage = "IsRequiredMsg")]
            [Display(Name = "CellPhone")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "IsRequiredMsg")]
            [StringLength(100, ErrorMessage = "StringLengthMsg", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required(ErrorMessage = "IsRequiredMsg")]
            [DataType(DataType.Password)]
            [Display(Name = "ConfirmPassword")]
            [Compare("Password", ErrorMessage = "ConfirmPasswordMsg")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            var user = new Cliente { NomeCompleto = Input.NomeCompleto, UserName = Input.Email, Email = Input.Email, CPF = Input.CPF, DataNascimento = Input.DataNascimento };

            if (ModelState.IsValid && _validaCpfService.ValidarCpf(user.CPF))
            {
                var result = await _userManager.CreateAsync(user, Input.Password);
                
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            //mensagems de erro de validação de cpf  
            //foreach (var error in _validaCpfService.ListaDeErros)
            //{
            //    ModelState.AddModelError(string.Empty, error);
            //}

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
