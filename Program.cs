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
    Console.WriteLine("You must set your 'MONGODB_URI' environmental variable. See\n\t https://www.mongodb.com/docs/drivers/go/current/usage-examples/#environment-variable");
    Environment.Exit(0);
}
else
{
    Console.WriteLine("Connected");
   //Environment.Exit(0);
}
var client = new MongoClient(connectionString);
var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");
var filter = Builders<BsonDocument>.Filter.Eq("title", "Back to the Future");
var document = collection.Find(filter).First();
Console.WriteLine(document);


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
