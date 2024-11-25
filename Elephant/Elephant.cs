using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elephant
{
    internal class Elephant
    {
        public string? Name = "";
        public int EarSize;

        public void WhoAmI() 
        {
            Console.WriteLine($"My name is {Name}.");
            Console.WriteLine($"My ears are {EarSize} inches tall.");
        }

        public void HearMessage( string message, Elephant whoSaidIt )
        {
            Console.WriteLine($"{Name} hear a message");
            Console.WriteLine($"{whoSaidIt.Name} said this: {message}");
        }
        public void SpeakTo(Elephant whoTalkto, string message)
        {
            whoTalkto.HearMessage(message, this);
        }
    }
}
