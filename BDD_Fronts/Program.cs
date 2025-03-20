using BDD_Fronts.Middlewares;

namespace BDD_Fronts;
/// <summary>
/// �G���g���[�|�C���g
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        /*** �ˑ�����` ***/
        Configs.SetupAppDependency.SettingDependencyInjection(
            builder.Configuration, builder.Services);
        /*** Http Sessio�Ɋւ���ݒ� ***/
        builder.Services.AddControllersWithViews();
        // �Z�b�V�����̐ݒ�
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30); // �Z�b�V�����̗L�����Ԃ�ݒ�
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true; // GDPR�ɏ������邽�߂ɕK�v�ȏꍇ
        });



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        // �J�X�^���~�h���E�F�A��o�^����
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseSession(); // Session�̗��p

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Index}/{action=Index}");

        app.Run();
    }
}
