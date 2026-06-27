// 1. THE CABINET: Order the master server chassis
var builder = WebApplication.CreateBuilder(args);


// 2. WIRING THE SERVICES: Adding capabilities to the cabinet before powering it on
// "Install the network card so it can read our UsersController"
builder.Services.AddControllers();

// "Install the automated testing screen (Swagger)"
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// 3. THROW THE BREAKER: Lock the cabinet and power it up
var app = builder.Build();


// 4. THE PIPELINE: Directing the flow of electricity (HTTP Traffic)
// "If we are in the testing lab (Development), turn on the Swagger testing screen"
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// "Route all incoming network traffic to our Controllers"
app.MapControllers();


// 5. RUN: Start the motor
app.Run();