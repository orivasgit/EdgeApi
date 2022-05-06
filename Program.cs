using EdgeApi.Interface;
using EdgeApi.Service;

var builder = WebApplication.CreateBuilder(args);




//static IHostBuilder CreateHostBuilder(string[] args) =>
//    Host.CreateDefaultBuilder(args)
//        .ConfigureServices((_, services) =>
//            services.AddHostedService<Worker>()
//                    .AddScoped<IPostsModelService, PostsModelService>());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add a service to DI
builder.Services.AddSingleton<IPostsModelService, PostsModelService>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
