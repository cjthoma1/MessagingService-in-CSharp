using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingSystem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 1;
            string[] newMessages = new string[index];       //Holds string of messages
            string[] prevMessages;                          //Temporary holds string of previous messages before we put them back into our new message array 
            newMessages[index - 1] = TakingUserInput();
            ShowUserIndexNum(index);
            bool decision = true;
            while (decision)
            {
                string users_Options = InputUserChoice();
                switch (users_Options)
                {
                    case "a":
                        prevMessages = new string[index];
                        for (int i = 0; i < index; ++i)
                        {
                            prevMessages[i] = newMessages[i];          //Here is where we add all of our current messages to "prevMessages"
                                                                       //That way we can can always change the size of our "newMessages" array
                        }
                        newMessages = new string[index + 1];
                        for (int i = 0; i < index; ++i)
                        {
                            newMessages[i] = prevMessages[i];  //Then we put all of our messages back in the same order that they were in
                        }
                        ++index;
                        newMessages[index - 1] = TakingUserInput();  //Add the useres new messgae to the end of our array
                        ShowUserIndexNum(index);                    //Give them their new index number
                        break;

                    case "r":
                        string validOrError = GiveUserMessage(newMessages, index);
                        Console.WriteLine(validOrError);               //shows error if user inputs a index number thats not avaiable
                        Console.WriteLine();             
                        break;
                    case "s":
                        decision = false;
                        break;
                    case "v":
                        PrintAllMessagesScrambled(newMessages, index);
                        Console.WriteLine();
                        PrintAllMessagesUnscrambled(newMessages, index);
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Please choice a valid option");
                        Console.WriteLine();
                        break;
                }
            }
            
            Console.WriteLine("Messaging Service Terminated");           
            Console.ReadLine();
        }
        static string TakingUserInput()         //input users new message
        {
            Console.WriteLine("What is the message you would like to input"); 
            string output = Console.ReadLine();
           output= Cypher(output);
           
            return output;      //Return string for user input

        }
        static void ShowUserIndexNum(int index)                 //display users index number 
        {
            Console.WriteLine("Your message has been stored");

            Console.WriteLine("Your index number is: " + index);
            Console.WriteLine();
        }
        static string InputUserChoice()
        {
            Console.WriteLine("To add another message type 'A'");               //users options
            Console.WriteLine("To receive your message type 'R'");
            Console.WriteLine("To view all messages type 'V'");
            Console.WriteLine("If you would like terminatet the messaging service type 'S'");
            Console.WriteLine();
            return Console.ReadLine().ToLower();
        }
        static string GiveUserMessage(string[] stored_Messages, int index) 
        {
            Console.WriteLine("Ok, what is your index number?");        //request their index number
            string input = Console.ReadLine();
            int track= -1;                                          
            if (input.All(char.IsDigit)) {
                track = Convert.ToInt32(input);
            }

            Console.WriteLine();

            if (track <= index && track >= 0)
            {  
                return ("Here is your message: " + Decypher(stored_Messages[track - 1]));       //Display the user their message
            }

            return "INVALID INPUT";   //returns an error if the user inputs a number thats not avaiable

        }
        static void PrintAllMessagesScrambled(string[] messages, int index)
        {
            Console.WriteLine("Here are all of your messages Scrambled ");      //Print all of the users messages exactly how they are
            Console.WriteLine();
            for(int count = 0; count < index; count++)
            {
                Console.WriteLine(messages[count]);
            }
        }
        static void PrintAllMessagesUnscrambled(string[] messages, int index)
        {
            Console.WriteLine("Here are all of your messages unscrambled "); //Print all of the users messages decyphered
            Console.WriteLine();

            for (int count = 0; count < index; count++)
            {
                Console.WriteLine(Decypher(messages[count]));
            }
        }

        static string Cypher (string message)
        {
            char[] cyph = message.ToCharArray();
            int [] change = new int[cyph.Length];               //SCRAMBLE THAT STRING MANE!!!!!
            for(int i = 0; i< cyph.Length; ++i)
            {
                change[i] = cyph[i]+5;
                cyph[i] = (char)change[i];
            }
            string new_message = new string(cyph);
            return new_message;
        }
        static string Decypher(string message)
        {
            char[] cyph = message.ToCharArray();           //UNSCRAMBLE THAT STRING MANE!!!!!!
            int[] change = new int[cyph.Length];
            for (int i = 0; i < cyph.Length; ++i)
            {
                change[i] = cyph[i] - 5;
                cyph[i] = (char)change[i];
            }
            string new_message = new string(cyph);
            return new_message;

            
        }
    }
}
