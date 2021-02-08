using System;
using DemoLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    //this static class will "new" up the 4 different types of instances when I need them
    //We have access to this at the very top level (Program.cs)
    public static class Factory
    {
        public static IPerson CreatePerson()
        {
            return new Person();
        }

        public static IChore CreateChore()
        {
            //add the parameters from the things in this Factor Class
            //passing in a new logger instance and a new Emailer instance into the Chore Class
            return new Chore(CreateLogger(), CreateMessageSender());
        }

        public static ILogger CreateLogger()
        {
            return new Logger();
        }

        public static IMessageSender CreateMessageSender()
        {
            //return new Emailer();
            //with the inclusion of the Texter class we can create this message sender
            return new Texter(); //no direct dependencies means this new return won't break anything
        }
    }
}
