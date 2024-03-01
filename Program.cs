using WebApplication1.Service.ServiceInterface;
using WebApplication1.Service;
using WebApplication1.Repository.RepositoryInterface;
using WebApplication1.Repository;

var builder = WebApplication.CreateBuilder(args);

// Registra servicios aqu�
builder.Services.AddRazorPages();
builder.Services.AddControllers();
// Aseg�rate de registrar tus servicios personalizados antes de llamar a Build()
builder.Services.AddScoped<IMensajeService, MensajeService>();
builder.Services.AddScoped<IMensajeRepository, MensajeRepository>();

var app = builder.Build();

// La configuraci�n del pipeline HTTP y cualquier otro ajuste debe hacerse despu�s de Build()
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
