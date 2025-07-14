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

//Listen to port 8080(<1024) for K8s/AKS:
app.Urls.Add("http://0.0.0.0:8080");

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
