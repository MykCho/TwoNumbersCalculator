using System;

namespace TwoNumbersCalculator
{
    internal class Program
    {
        static void ShowInitialMenu() //function for showing initial menu, duh
        {
            string borderLine = new String('-', Console.WindowWidth); //string of repeating symbols, WindowWidth times
            Console.WriteLine($"{borderLine}");
            Console.WriteLine("This console app should (hopefully) calculate a simple mathematical expression");
            Console.WriteLine("Please input an expression in following format:");
            Console.WriteLine("<number1> <operation> <number2>");
            Console.WriteLine("Allowed operations: + - * / ^ !");
            Console.WriteLine("note: factorial is a one-number operation, f.e. 12!)");
            Console.WriteLine("press \"CTRL+C\" to exit");

            Console.WriteLine($"{borderLine}");
        }

        static string CleanupString(string stringToClean)
        {
            string initialString = stringToClean; //to not output unnecessary \n
            char[] allowedCharacters = ['+', '-', '*', '/', '^', '!', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ','];

            for (int i = 0; i < stringToClean.Length; i++) //removing garbage
            {

                if (!allowedCharacters.Contains(stringToClean[i]))
                {
                    stringToClean = stringToClean.Remove(i--, 1); //removing symbol and rewinding back one symbol to compensate

                    Console.Write("\r" + stringToClean + " ");
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(0.1));

                }
            }
            if (initialString != stringToClean) {
                Console.WriteLine("\n");
            }
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

        static string Calculate(double a, double b, char operationSymbol) {
            string result = "";
            long fact;
            //Console.WriteLine("Right now I'm just a stub");
            //Console.WriteLine($"num1={a}, num2={b}, operation={operationSymbol}");
            
            switch (operationSymbol)
            {
                case '-':
                    result = (a-b).ToString();
                    break;

                case '+':
                    result = (a+b).ToString();
                    break;

                case '*':
                    result = (a*b).ToString();
                    break;
                
                case '/':
                    
                    if (b == 0) 
                    {
                        result = "[error]: division by zero";
                        break;                    
                    }
                    result = (a/b).ToString();
                    break;

                case '^':
                    result = (Math.Pow(a, b)).ToString();
                    break;
                    

                case '!':
                    if (a == 0)
                    {
                        result = 1.ToString();
                        break;
                    }

                    if (a < 0 || a != ((long)a))
                    {
                        result = "[error]: factorial is possible only for non-negative integers";
                        break;
                    }

                    if (a > 20)
                    {
                        result = "[error]: out of range";
                        break;
                    }

                    fact = 1;
                    for (int i = ((int)a); i >0; i--) 
                    {
                        fact = fact * i;
                    }
                    result = fact.ToString();
                    break;

                default:
                    result = "default result";
                    break;  
            }

            return result;
        }
        
        //here goes main stuff-------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
       
            string inputString = "";
            string[] stringsArray;
            double num1, num2;
            
           ShowInitialMenu();
                
            do {
                inputString = Console.ReadLine();
                inputString = CleanupString(inputString);

                if (inputString != "")
                {

                    stringsArray = SplitString(inputString, out char operationSymbol);

                    //for (int i = 0; i<stringsArray.Length; i++) //diagnostic output
                    //{
                    //    Console.WriteLine($"string[{i}]: {stringsArray[i]}");

                    //}
                    //Console.WriteLine($"Operation: {operationSymbol}");

                    //now check if each string is a number and call calculate functions
                    if (!Double.TryParse(stringsArray[0], out num1) || !(Double.TryParse(stringsArray[1], out num2)))
                    {
                        Console.WriteLine("You did not enter the one of the numbers properly, or, god forbid, even both");
                    }
                    else
                    {
                        //Console.WriteLine($"number1={num1}");
                        //Console.WriteLine($"number2={num2}");
                        Console.WriteLine($"Result is: {Calculate(num1, num2, operationSymbol)}");
                    }
                } else { Console.WriteLine("You entered an empty string"); }
            } while (true);
        }   
    }
}
