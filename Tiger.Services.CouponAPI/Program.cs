using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tiger.Services.CouponAPI;
using Tiger.Services.CouponAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//Automapper to services
// Register AutoMapper singleton
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
// AutoMapper auto scan for profiles
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
ApplyMigration();

app.Run();

void ApplyMigration()
{
    //Create scope
    using (var scope = app.Services.CreateScope())
    {
        //Get service AppDbContext from ServiceProvider
        //If not found any db => throw exception
        var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        //Ki?m tra xem có migration nào ch?a ???c áp d?ng hay không.
        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}
