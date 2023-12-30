var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHttpContextAccessor();

// Configure session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Example timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add authentication services
builder.Services.AddAuthentication(/* ... Configure your authentication ... */);

// Add and configure authorization services
builder.Services.AddAuthorization(options =>
{
    // Define your authorization policies here
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    // More policies can be added here
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

// Use authentication and authorization
app.UseAuthentication(); // This must be called before UseAuthorization
app.UseAuthorization();

// Session middleware
app.UseSession();

// Map Razor Pages
app.MapRazorPages();

app.Run();
