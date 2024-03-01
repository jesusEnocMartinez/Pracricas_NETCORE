using WebApplication1.Service.ServiceInterface;
using WebApplication1.Service;
using WebApplication1.Repository.RepositoryInterface;
using WebApplication1.Repository;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Singleton.WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddScoped<IMensajeService, MensajeService>();
builder.Services.AddScoped<IMensajeRepository, MensajeRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

// Configura aquí tu DbContext para usar una base de datos en memoria
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("NombreBaseDatosEnMemoria"));

var app = builder.Build();

// La configuración del pipeline HTTP y cualquier otro ajuste debe hacerse después de Build()
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
