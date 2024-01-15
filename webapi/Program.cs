using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection(key: "JwtConfig"));

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserRepo, UserRepo>();
builder.Services.AddScoped<BankRepo, BankRepo>();
builder.Services.AddScoped<LotRepo, LotRepo>();

builder.Services.AddCors(
    options =>
        {
         options.AddPolicy("MyPolicy",builder=>
         builder.WithOrigins("https://localhost:4200")
               .AllowAnyHeader() 
               .AllowAnyMethod()
               
            );
        }
    );


//builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("MyDb"));
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var context = service.GetService<AppDbContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{   
    app.UseDefaultFiles();
    app.UseStaticFiles();

}


app.UseHttpsRedirection();

app.UseCors("MyPolicy").UseCors();
app.UseAuthorization();

app.MapControllers(
);   

app.Run();