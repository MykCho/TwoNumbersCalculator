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
            Console.WriteLine("note: factorial is a one-number operation, f.e. !12)");
            Console.WriteLine($"{borderLine}");
        }

        static void Main(string[] args)
        {
            string inputString = "";
            ShowInitialMenu();
            inputString = Console.ReadLine();

        }
    }
}
