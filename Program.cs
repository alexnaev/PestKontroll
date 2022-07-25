using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using PestKontroll.Data;
using PestKontroll.Models;
using PestKontroll.Services;
using PestKontroll.Services.Factories;
using PestKontroll.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(DataUtility.GetConnectionString(builder.Configuration),
                                                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<PKUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddClaimsPrincipalFactory<PKUserClaimsPrincipalFactory>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

//Custom Services
builder.Services.AddScoped<IPKRoleService, PKRoleService>();
builder.Services.AddScoped<IPKCompanyInfoService, PKCompanyInfoService>();
builder.Services.AddScoped<IPKProjectService, PKProjectService>();
builder.Services.AddScoped<IPKTicketService, PKTicketService>();
builder.Services.AddScoped<IPKTicketHistoryService, PKTicketHistoryService>();
builder.Services.AddScoped<IPKNotificationService, PKNotificationService>();
builder.Services.AddScoped<IPKInviteService, PKInviteService>();
builder.Services.AddScoped<IPKFileService, PKFileService>();

builder.Services.AddScoped<IEmailSender, PKEmailService>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

await DataUtility.ManageDataAsync(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
