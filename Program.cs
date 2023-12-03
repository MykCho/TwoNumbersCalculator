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

        static string CleanupString( string stringToClean )
        {
            char[] allowedCharacters = ['+', '-', '*', '/', '^', '!', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'];
                       
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
            string[] splitStringArray, splitStringArrayResult = {"", ""};
            char[] allowedOperations = ['+', '-', '*', '/', '^', '!'];
            int minusCount = 0;
            int operationIndex = 0;

            for (int i = 0;i < stringToSplit.Length; i++)
            {
                if (i == 0 && stringToSplit[i] == '-') { //don't count it as a detected operation
                    minusCount++;
                    continue;
                }
                
                if (stringToSplit[i] == '-') minusCount++;

                if (allowedOperations.Contains(stringToSplit[i])) {
                    operationIndex = i;
                    break;
                }

            }
            operationSymbol = stringToSplit[operationIndex];
            splitStringArray = stringToSplit.Split(stringToSplit[operationIndex]);
            if (splitStringArray[0] == "" && splitStringArray.Length > 2) {//required for first string not to be empty
                splitStringArray[0] = splitStringArray[1];
                splitStringArray[1] = splitStringArray[2];
            }
            //if (stringToSplit[operationIndex]=='-' && splitStringArray[])
            Console.WriteLine($"minusCount: {minusCount}");
            
            if (minusCount == 2) //corner case of multiple minuses, f.e. -2-5, -2--5
            {
                if (splitStringArray[1]== "" && splitStringArray[2] == "")
                {
                    splitStringArray[1] = splitStringArray[3];
                }
                splitStringArray[1] = "-" + splitStringArray[1];
                splitStringArray[0] = "-" + splitStringArray[0];


            }

            splitStringArrayResult[0]= splitStringArray[0];
            splitStringArrayResult[1] = splitStringArray[1];
            return splitStringArrayResult;
        }

        static void Main(string[] args)
        {
       
            string inputString = "";
            string[] stringsArray;
            
            
            ShowInitialMenu();
            inputString = Console.ReadLine();
            inputString = CleanupString(inputString);
            
            if (inputString != "") {
                
                stringsArray = SplitString(inputString, out char operationSymbol);
                Console.WriteLine($"ArrayLength: {stringsArray.Length}");
                for (int i = 0; i<stringsArray.Length /*&& i<2*/; i++)
                {
                    Console.WriteLine($"string[{i}]{stringsArray[i]}");
                    
                }
                Console.WriteLine($"Operation: {operationSymbol}");
                //now check if each string is a number and call calculate functions
                

            } else { Console.WriteLine("You entered an empty string"); }
        }   
    }
}
