using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //we don't want this high level class relying on Person, a low level class
            //new Person, new Chore, new etc are tightly coupled dependencies that we want to break (invert?)
            //we instead want to work off interfaces
            //Person owner = new Person
            //{
            //    FirstName = "Tim",
            //    LastName = "Corey",
            //    EmailAddress = "tim@iamtimcorey.com",
            //    PhoneNumber = "555-1212"
            //};

            //Now use IPerson interface instead of Person implementation
            IPerson owner = Factory.CreatePerson(); //Use the factory to create the person (DIP complaint)
            owner.FirstName = "Tim";
            owner.LastName = "Corey";
            owner.EmailAddress = "tim@iamtimcorey.com";
            owner.PhoneNumber = "555-1212";

            //Now use IChore interface instead of Chore implementation
            //IChore chore = new Chore();
            IChore chore = Factory.CreateChore(); //Use the factory to create the chore (DIP complaint)
            chore.ChoreName = "Take out the trash";
            chore.Owner = owner;


            chore.PerformedWork(3);
            chore.PerformedWork(1.5);
            chore.CompleteChore();

            Console.ReadLine();
        }
    }
}
