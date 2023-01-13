using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedHost | ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();

app.UseForwardedHeaders();
app.UseRouting();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("<h1 style='font-family: sans-serif; padding-left: 50px;'>Headers</h1>");
        foreach (var header in context.Request.Headers)
        {
            await context.Response.WriteAsync($"<p style='font-family: sans-serif; padding-left: 50px;'><b>{header.Key}</b>: {header.Value}</p>{Environment.NewLine}");
        }
    });
});

//app.UseHttpsRedirection();
//app.UseStaticFiles();


//app.UseAuthorization();

//app.MapRazorPages();

app.Run();
