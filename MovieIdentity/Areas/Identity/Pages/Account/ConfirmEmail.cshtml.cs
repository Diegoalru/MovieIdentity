// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable

using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using MovieIdentity.Areas.Identity.Data;

namespace MovieIdentity.Areas.Identity.Pages.Account;

public class ConfirmEmailModel(UserManager<MovieUser> userManager, IConfiguration configuration)
    : PageModel
{
    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [TempData]
    public string StatusMessage { get; set; }

    /// <summary>
    ///     Handles the GET request to confirm the user's email.
    /// </summary>
    /// <param name="userId">The ID of the user whose email is to be confirmed.</param>
    /// <param name="code">The confirmation code sent to the user's email.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the IActionResult.</returns>
    public async Task<IActionResult> OnGetAsync(string userId, string code)
    {
        if (userId == null || code == null) return RedirectToPage("/Index");

        var user = await userManager.FindByIdAsync(userId);
        if (user == null) return NotFound($"Unable to load user with ID '{userId}'.");

        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        var result = await userManager.ConfirmEmailAsync(user, code);
        StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";

        var adminEmail = configuration["AdminEmail"] ?? throw new InvalidOperationException("Admin email not found.");
        if (!result.Succeeded) return Page();
        var isAdmin = string.Compare(user.Email, adminEmail, StringComparison.OrdinalIgnoreCase) == 0;
        await userManager.AddClaimAsync(user,
            new Claim("IsAdmin", isAdmin.ToString()));

        return Page();
    }
}