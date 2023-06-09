using backend.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//add cors policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost/");
                      });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//List all Favorite table: {Email, IdPlayer}
app.MapGet("/Favorite", () =>
{
    var aux = new List<Favorite>();
    using (var db = new DataBaseContext())
    {
        aux = db.Favorites.ToList();
    }
    return aux;

});
//Add a new Favorite {Email, IdPlayer}
app.MapPost("/Favorite", (Favorite favorite) =>
{
    using (var db = new DataBaseContext())
    {
        db.Favorites.Add(favorite);
        db.SaveChanges();
    }

    return favorite;

});
app.MapGet("/ApplicationPlayer", (int page) =>
{
    var aux = new ApplicationPlayer();
    var lista = aux.GetListDataPlayer(page);

    return lista;

});

app.Run();
