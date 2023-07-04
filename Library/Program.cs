using Library.Api;
using Library.Api.Middlewares;
using Library.Infrastructure.DataBaseHelper;
using Library.Service.Profiles;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Claims;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContext");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

DI.DependecyResolver(builder.Services);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

// add cors
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                                                                              .AllowAnyMethod()
                                                                              .AllowAnyHeader()));

//add autoMapper
builder.Services.AddAutoMapper(typeof(MappingProfiles));
// add OAuth
builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie")
    .AddOAuth("github", options =>
    {
        options.SignInScheme = "cookie";
        
        options.ClientId = "0b8893e097d133fe438c"; 
        options.ClientSecret = "9ca337ef462162f72a88451ff36a26f713bfe7bf";

        options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
        options.TokenEndpoint = "https://github.com/login/oauth/access_token";
        options.SaveTokens = true;
        options.UserInformationEndpoint = "https://api.github.com/user";

        options.CallbackPath = "/oauth/github-cb";

        options.ClaimActions.MapJsonKey("sub", "id");
        options.ClaimActions.MapJsonKey(ClaimTypes.Name, "login");

        options.Events.OnCreatingTicket = async ctx =>
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, ctx.Options.UserInformationEndpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", ctx.AccessToken);
            using var result = await ctx.Backchannel.SendAsync(request);
            var user = await result.Content.ReadFromJsonAsync<JsonElement>();
            ctx.RunClaimActions(user);
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();

app.UseCors("Default");

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dataContext.Database.Migrate();
}


// login minimal api
var y=  app.MapGet("/auth/login", () =>
{
    return Results.Challenge(
    new AuthenticationProperties()
    {
        RedirectUri = "https://localhost:7199/api/Book"  
    },
    authenticationSchemes: new List<string>() { "github" });

});


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
//  აპლიკაციას  რომ გაუშვებ, ჩაწერე url-ში https://localhost:7199/auth/login 

