using Microsoft.EntityFrameworkCore;
using DevicesAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DevicesDb>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

#region HTTP CRUD API TEST using Map<HTTP>
//var devices = app.MapGroup("/devices");
////Gets
//devices.MapGet("/", async (DevicesDb db) =>
//    await db.Devices.ToListAsync());

//devices.MapGet("/{id}", async (int id, DevicesDb db) =>
//    await db.Devices.FindAsync(id)
//    is Devices device
//    ? Results.Ok(device)
//    : Results.NotFound());

////Posts
//devices.MapPost("/", async (Devices device, DevicesDb db) =>
//{
//    db.Devices.Add(device);
//    await db.SaveChangesAsync();

//    return Results.Created($"/devices/{device.id}", device);
//});

////Put - Update
//devices.MapPut("/{id}", async (int id, Devices input_device, DevicesDb db) =>
//{
//    var device = await db.Devices.FindAsync(id);

//    if (device is null) return Results.NotFound();

//    if (!String.IsNullOrEmpty(input_device.description))
//        device.description = input_device.description;

//    if (!String.IsNullOrEmpty(input_device.adress))
//        device.adress = input_device.adress;

//    if (input_device.kWh_energy_consumption > 0)
//        device.kWh_energy_consumption = input_device.kWh_energy_consumption;
//    else device.kWh_energy_consumption = null;

//    await db.SaveChangesAsync();

//    return Results.NoContent();
//});

////Delete
//devices.MapDelete("/{id}", async (int id, DevicesDb db) =>
//{
//    if(await db.Devices.FindAsync(id) is Devices device)
//    {
//        db.Devices.Remove(device);
//        await db.SaveChangesAsync();
//        Console.WriteLine($"deleted 1 item with id = {id}");
//        return Results.NoContent();
//    }
//    Console.WriteLine("tried to delete a ghost itm");
//    return Results.NotFound();
//});
#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
