using System.Text;
using AutoMapper;
using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Fiap.Web.Alunos.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// DATABASE
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);

// Repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IRepresentativeRepository, RepresentativeRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Services
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IRepresentativeService, RepresentativeService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// AutoMapper
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AllowNullCollections = true;
    cfg.AllowNullDestinationValues = true;

    cfg.CreateMap<CustomerModel, CustomerViewModel>();
    cfg.CreateMap<SupplierModel, SupplierViewModel>();
    cfg.CreateMap<StoreModel, StoreViewModel>();
    cfg.CreateMap<OrderModel, OrderViewModel>();
    cfg.CreateMap<OrderProductModel, OrderProductViewModel>();
    cfg.CreateMap<ProductModel, ProductViewModel>();
    cfg.CreateMap<RepresentativeModel, RepresentativeViewModel>();

    cfg.CreateMap<CustomerViewModel, CustomerModel>();
    cfg.CreateMap<SupplierViewModel, SupplierModel>();
    cfg.CreateMap<StoreViewModel, StoreModel>();
    cfg.CreateMap<OrderViewModel, OrderModel>();
    cfg.CreateMap<OrderProductViewModel, OrderProductModel>();
    cfg.CreateMap<ProductViewModel, ProductModel>();
    cfg.CreateMap<RepresentativeViewModel, RepresentativeModel>();

    cfg.CreateMap<CreateOrderViewModel, OrderModel>()
        .ForMember(dest => dest.OrderProducts, opt => opt.MapFrom(src =>
            src.ProductIds.Select(id => new OrderProductModel { ProductId = id }).ToList()));
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
