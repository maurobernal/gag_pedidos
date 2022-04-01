using Front.Interfaces;
using Front.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                // Maintain property names during serialization. See:
                // https://github.com/aspnet/Announcements/issues/194
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());
// Add Kendo UI services to the services container"
builder.Services.AddKendo();
builder.Services.AddHttpClient("PokeAPI", c => {
    c.BaseAddress= new Uri ("https://pokeapi.co/api/v2/pokemon/");
    //c.DefaultRequestHeaders.Add("content-type","application-json");
    //c.DefaultRequestHeaders.Add("Authentication", "Bearer 6434534545");
});

builder.Services.AddHttpClient("Backend", c => {c.BaseAddress = new Uri("https://localhost:7244/");});

builder.Services.AddTransient<IPokemonService, PokemonService>();
builder.Services.AddTransient<IOrigenService, OrigenService>();
builder.Services.AddTransient<IProductoService, ProductoService>();
builder.Services.AddTransient<ITipoDeProductoService, TipoDeProductoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();