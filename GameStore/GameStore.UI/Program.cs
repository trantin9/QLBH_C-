using GameStore.BLL;
using GameStore.DAL;
using GameStore.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GameStore.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // ─────────────────────────────────────────────
            // Dependency Injection container
            // ─────────────────────────────────────────────
            var services = new ServiceCollection();

            // Connection string – chỉnh lại Server name nếu cần
            // Ví dụ: "Server=DESKTOP-ABC\\SQLEXPRESS;Database=GameStoreDB;Trusted_Connection=True;TrustServerCertificate=True;"
            const string connStr =
                "Server=.;Database=GameStoreDB;Trusted_Connection=True;TrustServerCertificate=True;";

            // Logging: Console + Debug
            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Debug);
                builder.AddConsole();
                builder.AddDebug();
            });

            // DAL (singleton – chia sẻ connection string)
            services.AddSingleton<IProductDAL>(sp =>
                new ProductDAL(connStr, sp.GetRequiredService<ILogger<ProductDAL>>()));

            // BLL (singleton)
            services.AddSingleton<ProductBLL>(sp =>
                new ProductBLL(
                    sp.GetRequiredService<IProductDAL>(),
                    sp.GetRequiredService<ILogger<ProductBLL>>()));

            // Main Form
            services.AddTransient<frmMain>();

            var provider = services.BuildServiceProvider();

            // Launch
            var mainForm = provider.GetRequiredService<frmMain>();
            Application.Run(mainForm);
        }
    }
}
