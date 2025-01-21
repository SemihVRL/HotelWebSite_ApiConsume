using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace WebApiJwt.Models
{
    public class CreateToken
    {
        public string TokenCreate()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapiaspnetcoreapiapiaa");

            //Token'ın imzalanması için kullanılan bir anahtar (key) metni UTF-8 baytlara dönüştürülür.
            //"aspnetcoreapiapi" gizli bir anahtardır ve güvenli bir yerde saklanmalıdır.

            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);

            // Bu anahtar, hem token'ı imzalamak hem de doğrulamak için kullanılır.

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Token'ı dijital olarak imzalamak için kullanılan bilgiler oluşturulur.
            //HMAC SHA256 algoritması kullanılmıştır.



            JwtSecurityToken token = new JwtSecurityToken(issuer: "https://localhost",
                audience: "https://localhost", notBefore: DateTime.Now,
                expires: DateTime.Now.AddSeconds(50), signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);

            //issuer: Token'ı oluşturan tarafın adresi Burada https://localhost olarak ayarlanmış.

            //audience: Token'ın hedef kitlesi Burada https://localhost olarak ayarlanmış.

            //notBefore: Token'ın geçerli olmaya başlayacağı tarih/zaman Burada DateTime.Now(şu anki zaman) kullanılmış.

            //expires: Token'ın geçerlilik süresinin dolacağı tarih/zaman Burada DateTime.Now.AddMinutes(3) kullanılmış, yani token 3 dakika geçerli olacak.

            //signingCredentials: Token'ı imzalamak için kullanılan bilgiler.

            // JwtSecurityTokenHandler=Bu nesne, JWT'ler üzerinde işlemler yapmak için kullanılır (oluşturma, okuma, yazma, doğrulama).


        }

        public string TokenCreateAdmin()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapiaspnetcoreapiapiaa");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Role,"Visiter")

            };
            JwtSecurityToken token = new JwtSecurityToken(issuer: "https://localhost", audience: "https://localhost",
                notBefore: DateTime.Now, expires: DateTime.Now.AddSeconds(50), signingCredentials: credentials, claims: claims);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);


        }
    }
}
