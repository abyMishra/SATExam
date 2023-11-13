using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using JwtTokenAuthentication;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", false, false);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()  // WithOrigins("https://localhost:7108/","https://localhost:44465/")
                               .AllowAnyMethod()
                               .AllowAnyHeader(); 
                      });
});

builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddJwtAuthentication();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

await app.UseOcelot();

app.UseAuthentication();
app.UseAuthorization();

app.Run();

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services
//       .AddOcelot(builder.Configuration)
//       .AddConsul()
//       .AddPolly();

////TokenVerification tv = new TokenVerification();
////IdentityModelEventSource.ShowPII = true;

////var publicKey = builder.Configuration["JwtOptions:Secret"] ?? "G3VF4C6KFV43JH6GKCDFGJH45V36JHGV3H4C6F3GJC63HG45GH6V345GHHJ4623FJL3HCVMO1P23PZ07W8";

////builder.Services.AddAuthentication(options =>
////{
////    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
////    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
////}).AddJwtBearer(options =>
////{
////    //options.Authority = builder.Configuration["JwtOptions:Issuer"];
////    options.RequireHttpsMetadata = false;

////    byte[] bytes = Encoding.UTF8.GetBytes(publicKey);
////    string encodedString = Convert.ToBase64String(bytes);


////    options.TokenValidationParameters = new TokenValidationParameters
////    {
////        ValidateIssuer = true,
////        ValidateAudience = false,
////        ValidateLifetime = true,
////        ValidIssuer = builder.Configuration["JwtOptions:Issuer"],
////        //ValidAudience = builder.Configuration["JwtOptions:Audience"],
////        ValidateIssuerSigningKey = true,
////        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(encodedString)), // new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
////    };
////    //options.Validate();
////});



//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseCors(MyAllowSpecificOrigins);

//app.UseHttpsRedirection();

//app.UseRouting();

////app.UseAuthentication();
////app.UseRouting();
////app.UseAuthorization();

//app.MapControllers();

//app.UseOcelot()
//   .Wait();

//app.Run();

