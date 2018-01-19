using System;
using System.Linq;


namespace EntityFrameworkonMac
{
    class Program
    {   
        const String CloseApp = "close";
        const String AddPerson = "add";
        const String ShowDatabase = "list";

        static void Main(string[] args)
        {
            
            using ( var dbContext = new DatabaseContext())
            {
                dbContext.Database.EnsureCreated();

                while(true)
                {
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine(CloseApp + " - Exit program.");
                    Console.WriteLine(AddPerson + " - Add new human.");
                    Console.WriteLine(ShowDatabase + " - Show human register!");

                    String input = Console.ReadLine();

                    switch(input)
                    {
                        case CloseApp:
                            return;
                        case AddPerson:
                            AddPeronFunc(dbContext);
                            break;
                        case ShowDatabase:
                            ShowDBContent(dbContext);
                            break;
                        default:
                            break;
                    }
                }
                
            }
        }


        public  static void AddPeronFunc(DatabaseContext ctxt)
        {
            Console.Write("Enter humans first name : ");
            String firstName = Console.ReadLine();
            Console.Write("Enter humans sir name :");
            String sirName = Console.ReadLine();
            Console.Write("Eanter humans birt year (int) :");
            int year = Int32.Parse(Console.ReadLine());
            Console.Write("Eanter humans birt month (int) :");

            int month = Int32.Parse(Console.ReadLine());
            Console.Write("Eanter humans birt day (int) :");
            int day = Int32.Parse(Console.ReadLine());

            Human newHuman = new Human()
            {
                FirstName = firstName,
                SirName = sirName,
                BirthDay = new DateTime(year, month, day)
            };

            ctxt.Humans.Add(newHuman);

            ctxt.SaveChanges();
        }
    
        public static void ShowDBContent(DatabaseContext ctxt)
        {
            var humans = from h in ctxt.Humans orderby h.SirName select h;
 
            foreach(Human h in ctxt.Humans)
            {
                Console.WriteLine($"{h.SirName} {h.FirstName}, {h.BirthDay}.");
            }
        }
    }
}
