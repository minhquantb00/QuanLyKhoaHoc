﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebCourseManagement_Business.Implements;
using WebCourseManagement_Business.Interfaces;
using WebCourseManagement_Commons.DefaultConstants;
using WebCourseManagement_Models.ConfigModels.MomoPayment.Config;
using WebCourseManagement_Models.ConfigModels.VnPayPayment;
using WebCourseManagement_Models.ConfigModels.VnPayPayment.Config;
using WebCourseManagement_Models.ConfigModels.ZaloPayment.Config;
using WebCourseManagement_Models.Converters;
using WebCourseManagement_Models.DataContexts;
using WebCourseManagement_Models.ResponseModels.DataBaiHoc;
using WebCourseManagement_Models.ResponseModels.DataBaiViet;
using WebCourseManagement_Models.ResponseModels.DataBanner;
using WebCourseManagement_Models.ResponseModels.DataBaoCao;
using WebCourseManagement_Models.ResponseModels.DataBinhLuanBaiHoc;
using WebCourseManagement_Models.ResponseModels.DataChuongHoc;
using WebCourseManagement_Models.ResponseModels.DataHoaDon;
using WebCourseManagement_Models.ResponseModels.DataKhoaHoc;
using WebCourseManagement_Models.ResponseModels.DataKhoaHocCuaNguoiDung;
using WebCourseManagement_Models.ResponseModels.DataLoaiKhoaHoc;
using WebCourseManagement_Models.ResponseModels.DataNguoiDung;
using WebCourseManagement_Models.ResponseModels.DataNguoiDungHoanThanhBaiHoc;
using WebCourseManagement_Models.ResponseModels.DataTestCase;
using WebCourseManagement_Models.ResponseModels.DataThucHanh;
using WebCourseManagement_Models.Responses;
using WebCourseManagement_Repositories.HandleVNPayPayment;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString(Constants.AppSettingKeys.DEFAULT_CONNECTION)));
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "StampCard.API", Version = "v1" });
    option.CustomSchemaIds(type => type.ToString());
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Vui lòng nhập chuỗi token hợp lệ",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"

                }
            },
            new string[]{}
        }
    });
});
//builder.Services.Configure<CookiePolicyOptions>(options =>
//{
//    options.CheckConsentNeeded = context => true;
//    options.MinimumSameSitePolicy = SameSiteMode.None;
//});
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
}).AddCookie().AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
{
    options.ClientId = builder.Configuration.GetSection("Authentication:Google:ClientId").Value;
    options.ClientSecret = builder.Configuration.GetSection("Authentication:Google:ClientSecret").Value;
    options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
});
//builder.Services.AddScoped<IOAuthService, OAuthService>();
var Vnpay = builder.Configuration.GetSection("VnPay").Get<DataVnpay>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ResponseObject<DataResponseNguoiDung>>();
builder.Services.AddScoped<ResponseObject<DataResponseToken>>();
builder.Services.AddScoped<NguoiDungConverter>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILoaiKhoaHocService, LoaiKhoaHocService>();
builder.Services.AddScoped<ResponseObject<DataResponseLoaiKhoaHoc>>();
builder.Services.AddScoped<LoaiKhoaHocConverter>();
builder.Services.AddScoped<KhoaHocConverter>();
builder.Services.AddScoped<ResponseObject<DataResponseKhoaHoc>>();
builder.Services.AddScoped<BaiHocConverter>();
builder.Services.AddScoped<ResponseObject<DataResponseBaiHoc>>();
builder.Services.AddScoped<BinhLuanBaiHocConverter>();
builder.Services.AddScoped<CauTraLoiConverter>();
builder.Services.AddScoped<DatCauHoiConverter>();
builder.Services.AddScoped<NguoiDungThichBinhLuanBaihocConverter>();
builder.Services.AddScoped<ThucHanhConverter>();
builder.Services.AddScoped<DataVnpay>();
builder.Services.AddScoped<ResponseObject<DataResponseBinhLuanBaiHoc>>();
builder.Services.AddScoped<ResponseObject<DataResponseChuongHoc>>();
builder.Services.AddScoped<ChuongHocConverter>();
builder.Services.AddScoped<KhoaHocNguoiDungConverter>();
builder.Services.AddScoped<DanhGiaConverter>();
builder.Services.AddScoped<IKhoaHocService, KhoaHocService>();
builder.Services.AddScoped<IChuongHocService, ChuongHocService>();
builder.Services.AddScoped<HoaDonConverter>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ResponseObject<DataResponseHoaDon>>();
builder.Services.AddScoped<IBaiHocService, BaiHocService>();
builder.Services.AddScoped<IVNPayService, VNPayService>();
builder.Services.AddScoped<IMomoService, MomoService>();
builder.Services.AddScoped<VNPayLibrary>();
builder.Services.AddScoped<IThichBinhLuanBaiHocService, ThichBinhLuanBaiHocService>();
builder.Services.AddScoped<IBinhLuanBaiHocService, BinhLuanBaiHocService>();
builder.Services.AddScoped<IBaiVietService, BaiVietService>();
builder.Services.AddScoped<ResponseObject<DataResponseBaiViet>>();
builder.Services.AddScoped<NguoiDungThichBaiVietConverter>();
builder.Services.AddScoped<BaiVietConverter>();
builder.Services.AddScoped<BinhLuanBaiVietConverter>();
builder.Services.AddScoped<NguoiDungThichBinhLuanBaiVietConverter>();
builder.Services.AddScoped<NguoiDungThichBinhLuanBaiVietConverter>();
builder.Services.AddScoped<KhoaHocNguoiDungConverter>();
builder.Services.AddScoped<BinhLuanBaiVietConverter>();
builder.Services.AddScoped<IThichBinhLuanBaiVietService, ThichBinhLuanBaiVietService>();
builder.Services.AddScoped<ResponseObject<DataResponseBinhLuanBaiViet>>();
builder.Services.AddScoped<INguoiDungThichBaiVietService, NguoiDungThichBaiVietService>();
builder.Services.AddScoped<ResponseObject<DataResponseKhoaHocCuaNguoiDung>>();
builder.Services.AddScoped<IKhoaHocNguoiDungService, KhoaHocNguoiDungService>();
builder.Services.AddScoped<ResponseObject<DataResponseThucHanh>>();
builder.Services.AddScoped<ThucHanhConverter>();
builder.Services.AddScoped<ResponseObject<DataResponseTestCaseResult>>();
builder.Services.AddScoped<ITestCaseService, TestCaseService>();
builder.Services.AddScoped<IBannerService, BannerService>();
builder.Services.AddScoped<ResponseObject<DataResponseBanner>>();
builder.Services.AddScoped<ResponseObject<DataResponseLoaiBaiViet>>();
builder.Services.AddScoped<LoaiBaiVietConverter>();
builder.Services.AddScoped<BannerConverter>();
builder.Services.AddScoped<IBaoCaoService, BaoCaoService>();
builder.Services.AddScoped<ResponseObject<DataResponseBaoCao>>();
builder.Services.AddScoped<BaoCaoConverter>();
builder.Services.AddScoped<NguoiDungHoanThanhBaiHocConverter>();
builder.Services.AddScoped<ResponseObject<DataResponseNguoiDungHoanThanhBaiHoc>>();
builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            builder.Configuration.GetSection(Constants.AppSettingKeys.AUTH_SECRET).Value!))
    };
});
builder.Services.Configure<MomoConfig>(builder.Configuration.GetSection(MomoConfig.ConfigName));
builder.Services.Configure<VnPayConfig>(builder.Configuration.GetSection(VnPayConfig.ConfigName));
builder.Services.Configure<ZaloPayConfig>(builder.Configuration.GetSection(ZaloPayConfig.ConfigName));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();

app.Run();
