using Microsoft.EntityFrameworkCore;
using partsearch.Domain.Repositories.EntityFramework;
using partsearch.Domain.Repositories.Abstract;
using partsearch.Domain;
using partsearch.Service;
using Microsoft.AspNetCore.Identity;

var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json").Build().Bind("Project", new Config());
var Configuration = configurationBuilder.Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
builder.Services.AddTransient<IPartsRepository, EFPartsRepository>();
builder.Services.AddTransient<DataManager>();

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//����������� authentication cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "myCompanyAuth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});

//����������� �������� ����������� ��� Admin area
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
});

//��������� ������ ������������ � �������������
builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
}
);

var app = builder.Build();

//����������� ������ �� ������ � �������� ����������
if (builder.Environment.IsDevelopment()) 
    app.UseDeveloperExceptionPage();

//���������� ������������ ����������� �����
app.UseStaticFiles();

//�������������
app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

//����������� ���������
app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
