using Microsoft.EntityFrameworkCore;
using WebApplication1.Singleton.WebApplication1.Data;
using WebApplication1.Config;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllers();
// Utiliza el método de extensión para agregar tus servicios personalizados
builder.Services.AddApplicationServices();

// Llama al método ConfigureServices de tu clase ConfigServices
WebApplication1.Config.ConfigServices.ConfigureServices(builder.Services);

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
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");

   
});

app.Run();
