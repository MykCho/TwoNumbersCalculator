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
            Console.WriteLine("Allowed operations: + - * / ^ !");
            Console.WriteLine("note: factorial is a one-number operation, f.e. 123!)");
            Console.WriteLine($"{borderLine}");
        }

        static string CleanupString( string stringToClean )
        {
            char[] allowedCharacters = ['+', '-', '*', '/', '^', '!', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ','];
                       
            for (int i = 0; i < stringToClean.Length; i++) //removing garbage
            {
                
                if (!allowedCharacters.Contains(stringToClean[i]))
                {
                    stringToClean = stringToClean.Remove(i--, 1); //removing symbol and rewinding back one symbol to compensate

                    Console.Write("\r" + stringToClean + " ");
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(0.2));

                }
            }
            Console.WriteLine("\n");
            return stringToClean;
        }

        static string[] SplitString(string stringToSplit, out char operationSymbol)
        {
            string[] splitStringArray;
            char[] allowedOperations = ['+', '-', '*', '/', '^', '!'];
            bool startsWithMinus = false;
            int operationIndex = 0;

            if (stringToSplit.StartsWith("-")) { //in case if first symbol is -
                startsWithMinus = true;
                stringToSplit = stringToSplit.Substring(1);
            }
            
            for (int i = 0; i < stringToSplit.Length; i++)
            {
                if (allowedOperations.Contains(stringToSplit[i]))
                {
                    operationIndex = i;
                    break;
                }

            }

            operationSymbol = stringToSplit[operationIndex];
            splitStringArray = stringToSplit.Split(stringToSplit[operationIndex],2);

            if ( startsWithMinus ) { splitStringArray[0] = "-" + splitStringArray[0]; } // if starts with minus
            if (operationSymbol == '!' && splitStringArray[1] == "") { splitStringArray[1] = splitStringArray[0]; } // if factorial

            return splitStringArray;
        }

        //here goes main stuff-------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
       
            string inputString = "";
            string[] stringsArray;
            double num1, num2;
            
            
            ShowInitialMenu();
            inputString = Console.ReadLine();
            inputString = CleanupString(inputString);
            
            if (inputString != "") {
                
                stringsArray = SplitString(inputString, out char operationSymbol);

                for (int i = 0; i<stringsArray.Length; i++)
                {
                    Console.WriteLine($"string[{i}]: {stringsArray[i]}");
                    
                }
                Console.WriteLine($"Operation: {operationSymbol}");
                
                //now check if each string is a number and call calculate functions
                if (Double.TryParse(stringsArray[0], out num1) ) { Console.WriteLine($"number1={num1}"); }
                if (Double.TryParse(stringsArray[1], out num2)) { Console.WriteLine($"number2={num2}"); }


            } else { Console.WriteLine("You entered an empty string"); }
        }   
    }
}
