using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace pic_sas_database
{
    public class DefaultDbContext : DbContext
    {
        public static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder => { builder.AddConsole(); });
        private string _connectionString = ConfigurationManager.ConnectionStrings["sasDatabase"].ConnectionString;
        private readonly StreamWriter _logStream = new StreamWriter(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "databaseLog.txt"), append: false);
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString)
            .UseLoggerFactory(LoggerFactory);

            optionsBuilder.ConfigureWarnings(
            b => b.Log(
                (RelationalEventId.ConnectionOpened, LogLevel.Trace),
                (RelationalEventId.ConnectionClosed, LogLevel.Trace),
                (RelationalEventId.MigrationApplying, LogLevel.Information),
                 (RelationalEventId.MigrationsNotApplied, LogLevel.Warning),
                 (RelationalEventId.MigrationsNotFound, LogLevel.Error),
                   (RelationalEventId.TransactionCommitted, LogLevel.Information),
                (RelationalEventId.CommandExecuted, LogLevel.Trace)))
                .LogTo(_logStream.WriteLine);
        }

        public override void Dispose()
        {
            base.Dispose();
            _logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await _logStream.DisposeAsync();
        }
    }
}