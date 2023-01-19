using Microsoft.EntityFrameworkCore;
using ITCPBackend.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ITCPBackendContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ITCPBackendContext"), sqlServerOptionsAction:sqlOption =>
    {
        sqlOption.EnableRetryOnFailure(maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd:null);
    } ));
//?? throw new InvalidOperationException("Connection string 'ITCPBackendContext' not found.")
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//services cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


#region JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = "localhost",
           ValidAudience = "localhost",
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("salskmiddcmio32##8936@#"))
       };
   });
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyOrigin());


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
