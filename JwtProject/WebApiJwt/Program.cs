using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.IdentityModel.Tokens;
using System.Buffers.Text;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt=>
{
    opt.RequireHttpsMetadata = false;//https bağlantısının zorunlu olup olmadığına bakar
    opt.TokenValidationParameters = new TokenValidationParameters()//Token'ların doğrulama ayarlarını içerir. 
    {
        ValidIssuer = "https://localhost",//Token'ı oluşturan tarafı (issuer) belirtir.
        ValidAudience = "https://localhost",//Token'ın hedef kitlesini (audience) belirtir
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiapiaspnetcoreapiapiaa")),
        //	Token'ın doğruluğunu kontrol etmek için kullanılan gizli anahtar.
        //Burada,aspnetcoreapiapi metni base64 formatında şifrelenmiş bir SymmetricSecurityKey olarak belirlenmiş.
        //Token'ı imzalamak ve doğrulamak için kullanılır.

        ValidateIssuerSigningKey = true,//IssuerSigningKey ile token'ın imzasını doğrulayıp doğrulamayacağını belirler.
        ValidateLifetime = true,
        //	Token'ın süresinin dolup dolmadığını kontrol eder.
        //true yapılmış,  yani token süresi dolmuşsa geçersiz kabul edilir.

        ClockSkew = TimeSpan.Zero // süre geçer ise tokenı oluşturma sıfırla zamanı

    };

});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
