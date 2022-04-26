using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Authentication.Cookies;
using Proyecto.Data;
using Proyecto.Interfaces;
using Proyecto.Servicios;
using  Microsoft.AspNetCore.Authorization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddSweetAlert2();
builder.Services.AddScoped<IDoctorServicio, DoctorServicio>();

builder.Services.AddScoped<IExpedientesServicio, ExpedientesServicio>()
    ;
builder.Services.AddScoped<IPacienteServicio, PacienteServicio>();


MySQLConfiguration cadenaConexion = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySQL"));
builder.Services.AddSingleton(cadenaConexion);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddHttpContextAccessor();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapControllers();

app.MapFallbackToPage("/_Host");

app.Run();
