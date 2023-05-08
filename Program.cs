
global using safezonesoftware_restapi.Models;
using MongoDB.Driver;
using MongoDB.Bson;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ...

string connectionString = "mongodb+srv://safezonesoftware:Admin1234@cluster0.7mhrix9.mongodb.net/";


//var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
if (connectionString == null)
{
    Console.WriteLine("Error can't connect to database");
    Environment.Exit(0);
}
else
{
    Console.WriteLine("Connected");
   //Environment.Exit(0);
}
//var client = new MongoClient(connectionString);
//var collection = client.GetDatabase("db_safezonesoftware").GetCollection<BsonDocument>("users");

//find specific
//var filter = Builders<BsonDocument>.Filter.Eq("firstname", "Emmanuel");
//var document = collection.Find(filter).First();

//get all
//var filter = Builders<BsonDocument>.Filter.Eq("password", "Admin1234");
//var document = collection.Find(filter).First;
//Console.WriteLine(document);


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
