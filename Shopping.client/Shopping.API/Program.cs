using Shopping.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your MongoDB ProductContext as singleton
builder.Services.AddSingleton<ProductContext>();

var app = builder.Build();

//Listen to port 8080(<1024) for K8s/AKS:
app.Urls.Add("http://0.0.0.0:8080");


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//Always enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();