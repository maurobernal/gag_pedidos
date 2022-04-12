﻿using FrontEnd.Interfaces;
using FrontEnd.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
                 .AddRazorRuntimeCompilation()
                // Maintain property names during serialization. See:
                // https://github.com/aspnet/Announcements/issues/194
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());
// Add Kendo UI services to the services container"
builder.Services.AddKendo();

builder.Services.AddHttpClient("Backend", c => c.BaseAddress = new Uri("https://localhost:7244/"));
builder.Services.AddTransient<IOriginService, OriginService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductTypeService, ProductTypeService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderDetailService, OrderDetailService>();

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
    pattern: "{controller=api}/{action=order}/{id?}");

app.Run();