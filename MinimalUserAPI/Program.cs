using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinimalUserAPI.Data;
using MinimalUserAPI.DTOs;
using MinimalUserAPI.Entities;
using MinimalUserAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("users"));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region APIs
app.MapGet("api/v1/users", async (IUserService service, IMapper mapper) => {
    var users = await service.GetAllUsers();
    return Results.Ok(mapper.Map<IEnumerable<UserReadDto>>(users));
});

app.MapGet("api/v1/user/{id}", async (IUserService service, IMapper mapper, int id) => {
    var user = await service.GetUserById(id);

    if(user is null) return Results.NotFound("Sorry, this user doesn't exist.");

    return Results.Ok(mapper.Map<UserReadDto>(user));
}).WithName("GetUserById");

app.MapPost("api/v1/user", async (IUserService service, IMapper mapper, UserCreateDto userCreateDto) =>
{
    var user = mapper.Map<User>(userCreateDto);

    await service.CreateUser(user);
    await service.SaveChanges();

    var userReadDto = mapper.Map<UserReadDto>(user);

    return Results.CreatedAtRoute("GetUserById", new { id = user.Id }, userReadDto);
});

app.MapPut("api/user/{id}", async (IUserService service, IMapper mapper, int id, UserUpdateDto userUpdateDto) =>
{
    var user = await service.GetUserById(id);

    if(user is null) return Results.NotFound("Sorry, this user doesn't exist.");
    
    mapper.Map(userUpdateDto, user);
    await service.SaveChanges();

    return Results.NoContent();
});

app.MapDelete("api/user/{id}", async (IUserService service, IMapper mapper, int id) =>
{
    var user = await service.GetUserById(id);

    if(user is null) return Results.NotFound("Sorry, this user doesn't exist.");

    service.DeleteUser(user);
    await service.SaveChanges();

    return Results.Accepted();
});
#endregion

app.Run();