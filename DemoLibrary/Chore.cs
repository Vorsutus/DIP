using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class Chore : IChore
    {
        ILogger _logger;
        IMessageSender _messageSender;

        public string ChoreName { get; set; }
        public IPerson Owner { get; set; }
        public double HoursWorked { get; private set; }
        public bool IsComplete { get; private set; }

        //creating a constructor for my chore class
        //pass in a Logger and an Emailer interfaces at the constructor level
        public Chore(ILogger logger, IMessageSender messageSender)
        {
            _logger = logger;
            _messageSender = messageSender;
        }

        public void PerformedWork(double hours)
        {
            HoursWorked += hours;
            //Logger log = new Logger(); //could have this call the Factory to make new, but thats not a dependency that I want
            //log.Log($"Performed work on { ChoreName }");
            _logger.Log($"Performed work on { ChoreName }"); //this uses the logger created here, not the lower level
        }

        //we use the two interfaces created above already to log a message and to send a message (no more "new ____")
        public void CompleteChore()
        {
            IsComplete = true;

            //Logger log = new Logger();
            //log.Log($"Completed { ChoreName }");
            _logger.Log($"Completed { ChoreName }");

            //Emailer emailer = new Emailer();
            _messageSender.SendMessage(Owner, $"The chore { ChoreName } is complete.");
            //emailer.SendMessage(Owner, $"The chore { ChoreName } is complete.");
        }
    }
}
