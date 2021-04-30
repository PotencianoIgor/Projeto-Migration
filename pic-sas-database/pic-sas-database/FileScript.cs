using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace pic_sas_database
{
    public class FileScript
    {
        public static void ExecFileScript(string scriptName, MigrationBuilder migrationBuilder, EnumDirectory[] enumDirectories)
        {
            string directoryFile = string.Concat(System.IO.Directory.GetCurrentDirectory(), "\\", EnumDirectory.SQL, "\\");

            foreach (var item in enumDirectories)
            {
                directoryFile += item.ToString() + "\\";
            }

            directoryFile = string.Concat(directoryFile, scriptName);

            if (!File.Exists(directoryFile))
            {
                throw new System.Exception($"O arquivo {scriptName} não foi encontrado.");
            }

            migrationBuilder.Sql(File.ReadAllText(directoryFile));
        }

        public static void ExecFileScript(string scriptName, MigrationBuilder migrationBuilder, EnumDirectory enumDirectory)
        {
            string directoryFile = string.Concat(System.IO.Directory.GetCurrentDirectory(), "\\", EnumDirectory.SQL, "\\", enumDirectory, "\\");

            directoryFile = string.Concat(directoryFile, scriptName);

            if (!File.Exists(directoryFile))
            {
                throw new System.Exception($"O arquivo {scriptName} não foi encontrado.");
            }

            migrationBuilder.Sql(File.ReadAllText(directoryFile));
        }

        public static void ExecFileScript(string scriptName, MigrationBuilder migrationBuilder)
        {
            string directoryFile = string.Concat(System.IO.Directory.GetCurrentDirectory(), "\\", EnumDirectory.SQL, "\\");

            directoryFile = string.Concat(directoryFile, scriptName);

            if (!File.Exists(directoryFile))
            {
                throw new System.Exception($"O arquivo {scriptName} não foi encontrado.");
            }

            migrationBuilder.Sql(File.ReadAllText(directoryFile));
        }
    }
}
