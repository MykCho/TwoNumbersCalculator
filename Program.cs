using System;

namespace TwoNumbersCalculator
{
    internal class Program
    {
        static void ShowInitialMenu() //function for showing initial menu, duh
        {
            string borderLine = new String('-', Console.WindowWidth); //string of repeating symbols, WindowWidth times
            Console.WriteLine($"{borderLine}");
            Console.WriteLine("This console app should (hopefully) calculate an expression on two numbers");
            Console.WriteLine("Please input an expression in following format:");
            Console.WriteLine("<number1> <operation> <number2>");
            Console.WriteLine("(spaces are not necessary, but preferable for the sake of beauty and Universal balance).");
            Console.WriteLine("Allowed operations: + - * / ^ !");
            Console.WriteLine("note: factorial is a one-number operation, f.e. 123!)");
            Console.WriteLine($"{borderLine}");
        }

        static void Main(string[] args)
        {
            char[] allowedCharacters = ['+', '-', '*', '/', '^', '!', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9']; //not sure if needed
            char[] allowedOperations = ['+', '-', '*', '/', '^', '!'];
            string inputString = "";
            
            
            ShowInitialMenu();
            inputString = Console.ReadLine();

            if (inputString != "") {

                for (int i = 0; i < inputString.Length; i++) //removing garbage
                {
                    if (!allowedCharacters.Contains(inputString[i])) {
                        inputString = inputString.Remove(i--,1);
                        
                        Console.Write("\r"+inputString+" ");
                        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(0.2));

                    }
                }
                Console.WriteLine("\n");
            } else { Console.WriteLine("You entered an empty string"); }
        }   
    }
}
