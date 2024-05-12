using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using MovieIdentity.Areas.Identity.Data;
using MovieIdentity.Services;
using QRCoder;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MovieAuthConnection") ??
                       throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<MovieAuth>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MovieUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MovieAuth>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddSingleton(new QrCodeService(new QRCodeGenerator()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();