using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EntityFrameworkonMac
{
    public class Human
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String FirstName { get; set; }
        public String SirName { get; set; }
        public DateTime BirthDay { get; set; }
    }

    public class DatabaseContext : DbContext
    {
        public DbSet<Human> Humans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=HumanRegister.db");
        }
    }

}
