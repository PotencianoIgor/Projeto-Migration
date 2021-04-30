using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace pic_sas_database.Migrations._2021
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20210409112315")]
    internal class Migration20210409112315 : Migration
    {
        protected override void Up([NotNullAttribute] MigrationBuilder migrationBuilder)
        {
            FileScript.ExecFileScript("CREATE_TABLE_STATUS_PENDENCIA.sql", migrationBuilder);
        }
    }
}
