using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false; //Normalde Https ile çalışıyorsak buranın true olması lazım.Localden çalıştığımız için burasu false.
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = "http://localhost:7263", //Issuer bu tokenı oluşturan sunucunun veya hizmetin kök url'ini yani bu tokenın kim tarafından oluşturulduğunu belirtir.
        ValidAudience = "http://localhost:7263",//Audience bu tokenı hangi kaynak veya hizmetler için geçerli olduğunu belirtir.Kimlerin kullanabileceğini tanımlar
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("pl2107980LPyavuzselimemrem.")),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
    };
});


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
