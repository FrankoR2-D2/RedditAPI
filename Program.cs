var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();



//using System.Security.Cryptography;
//using System.Text;

//string password = "myPassword123";
//byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

//using (SHA256 sha256 = SHA256.Create())
//{
//    byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
//    string hashedPassword = Convert.ToBase64String(hashedBytes);

//    // Store the hashed password securely
//}
//string enteredPassword = "myPassword123";
//byte[] enteredPasswordBytes = Encoding.UTF8.GetBytes(enteredPassword);

//using (SHA256 sha256 = SHA256.Create())
//{
//    byte[] enteredHashedBytes = sha256.ComputeHash(enteredPasswordBytes);
//    string enteredHashedPassword = Convert.ToBase64String(enteredHashedBytes);

//    // Compare the entered hashed password with the stored hashed password
//    if (enteredHashedPassword == storedHashedPassword)
//    {
//        // Password is valid
//    }
//    else
//    {
//        // Password is invalid
//    }
//}
