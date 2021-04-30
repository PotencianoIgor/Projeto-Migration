using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace pic_sas_database
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var context = new DefaultDbContext())
                {
                    context.Database.Migrate();
                }
            }
            catch (System.Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            Console.ReadKey();
        }
    }
}
