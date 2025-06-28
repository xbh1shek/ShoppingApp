var builder = WebApplication.CreateBuilder(args);
// Add ShoppingAPIUrl-based HttpClient
builder.Services.AddHttpClient("ShoppingAPIClient", client =>
{
    var shoppingApiUrl = builder.Configuration["ShoppingAPIUrl"];
    Console.WriteLine($">>> CONFIG ShoppingAPIUrl = {shoppingApiUrl}");

    client.BaseAddress = new Uri(shoppingApiUrl ?? "http://fallback.local"); // fallback optional
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
