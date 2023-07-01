using Library.Api;
using Library.Api.Middlewares;
using Library.Infrastructure.DataBaseHelper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Security.Claims;
using Newtonsoft.Json.Linq;

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


builder.Services.AddAuthentication(options =>
{
    // If an authentication cookie is present, use it to get authentication information
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

    // If authentication is required, and no cookie is present, use Okta (configured below) to sign in
    options.DefaultChallengeScheme = "Okta";
})
.AddCookie() // cookie authentication middleware first
.AddOAuth("Okta", options =>
{
    // Oauth authentication middleware is second
    var oktaDomain = builder.Configuration.GetValue<string>("Okta:OktaDomain");

    // When a user needs to sign in, they will be redirected to the authorize endpoint
    options.AuthorizationEndpoint = $"{oktaDomain}/oauth2/default/v1/authorize";

    // Okta's OAuth server is OpenID compliant, so request the standard openid
    // scopes when redirecting to the authorization endpoint
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.Scope.Add("email");

    // After the user signs in, an authorization code will be sent to a callback
    // in this app. The OAuth middleware will intercept it
    options.CallbackPath = new PathString("/authorization-code/callback");

    // The OAuth middleware will send the ClientId, ClientSecret, and the
    // authorization code to the token endpoint, and get an access token in return
    options.ClientId = builder.Configuration.GetValue<string>("Okta:ClientId");
    options.ClientSecret = builder.Configuration.GetValue<string>("Okta:ClientSecret");
    options.TokenEndpoint = $"{oktaDomain}/oauth2/default/v1/token";

    // Below we call the userinfo endpoint to get information about the user
    options.UserInformationEndpoint = $"{oktaDomain}/oauth2/default/v1/userinfo";

    // Describe how to map the user info we receive to user claims
    options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "sub");
    options.ClaimActions.MapJsonKey(ClaimTypes.Name, "given_name");
    options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");

    options.Events = new OAuthEvents
    {
        OnCreatingTicket = async context =>
        {
            // Get user info from the userinfo endpoint and use it to populate user claims
            var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

            var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
            response.EnsureSuccessStatusCode();

            var user  = JObject.Parse(await response.Content.ReadAsStringAsync());
            var element = JsonSerializer.SerializeToElement(user);
            
            context.RunClaimActions(element);
        }
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


app.UseCors("Default");

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dataContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthentication(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
