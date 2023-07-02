using Library.Api;
using Library.Api.Middlewares;
using Library.Infrastructure.DataBaseHelper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
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
builder.Services.AddSwaggerGen();

// add cors
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                                                                              .AllowAnyMethod()
                                                                              .AllowAnyHeader()));
//add Oauth Configuration
// სანამ ამას დაწერ, პირველი ნაბიჯი ისაა, რომ ხსნი გითჰაბს, შედიხარ სეთინგებში, სულ ბოლოში ირჩევ - <developer settings>, 
// შემდეგ ირჩევ OAuthApps-ს და ქმნი მანდ ახალ აპლიკაციას. Homepage URL -ში ჩაწერე აპლიკაცია რა ორტზეც ეშვება, ეგ მისამართი,
// მაგალითად - https://localhost:7199;
// Authorization callback URL - საწყის ეტაპზე https://localhost:7199 - მერე შეცვლი. 
// 
//გითჰაპს რომ მორჩები და აპლიკაციას რომ დაარეგისტრირებ, შემდეგ დაიწყე ამ კონფიგურაციის წერა. 
builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie")
    .AddOAuth("github", options =>
    {
        options.SignInScheme = "cookie";

        // ეს ქვედა ორი თუ გინდა ჯეისონში გაიტანე და იქიდან წამოიღე, უკეთესია. თუ გინდა დატოვე.
        options.ClientId = "0b8893e097d133fe438c";  //ამას წამოიღებ გითჰაბიდან, კლიენტ აიდის აიღებ მანდედან.
        options.ClientSecret = "9ca337ef462162f72a88451ff36a26f713bfe7bf"; //სექრეთ ქისაც მანდვე დააგენერირებ.

        options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
        options.TokenEndpoint = "https://github.com/login/oauth/access_token";
        options.SaveTokens = true;
        options.UserInformationEndpoint = "https://api.github.com/user";

        options.CallbackPath = "/oauth/github-cb"; //აქ შეგიძლია ნებისმიერი რამ ჩაწერო, Path-რაც გინდა რომ გქონდეს, უბრალოდ
                                                   //როცა ამას დაწერე, იგივე უნდა აიღო და Authorization callback URL - სადაც ჩაწერე გითჰაბზე, იქ მიამატებ -
                                                   // ანუ Authorization callback URL-ში  https://localhost:7199 ნაცვლად გექნება https://localhost:7199/oauth/github-cb 
                                                   //ანუ რასაც მანდ დაწერ, იმას მიამატებ. შეგიძლია დატოვო ისე, როგორც არის. 

        //"Sub" stands for "subject"
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

//ამას რომ დაწერ, შემდეგ გადადი აპლიკაციაში - properties ფოლდერში, და launchSettings.json გახსენი.

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

// ეს პირველი get - მეთოდი აუცილებელი არაა, უბრალოდ იმიტომ დავწერე რომ სადმე გადავემისამართებინე და ქლეიმები გამოეტანა.
app.MapGet("/auth/homepage", (HttpContext ctx) =>
{
    ctx.GetTokenAsync("access_token");
    return ctx.User.Claims.Select(x => new { x.Type, x.Value }).ToList();
});

//ამ ენდფოინთზე ("/auth/login") კონტროლერი არ კეთდება(ვცადე მარა არ გამოვიდა), რადგან IActionResult-ს არ აბრუნებს, ამიტომ Minimal Api-ით კეთდება, ასე რომ პირდაპირ აქ დაამპლემენტირე.
// აუცილებლად app.UseAuthentication(); ქვემოთ.


app.MapGet("/auth/login", () =>
{
    return Results.Challenge(
    new AuthenticationProperties()
    {
        RedirectUri = "https://localhost:7199/auth/homepage"  // აქ შეგიძლია მიუთითო ნებისმიერი url- სადაც გინდა რომ გადამისამართდეს
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
// რომ მორჩები, და აპლიკაციას გაუშვებ, ჩაწერე url-ში https://localhost:7199/auth/login და სასწაული მოხდება :D მანამდე გითჰაბიდან დალოგაუთდი