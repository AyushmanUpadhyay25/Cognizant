using System;

class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.Instance;
        logger1.Log("Ayushman");

        Logger logger2 = Logger.Instance;
        logger2.Log("Upadhyay");

        Console.WriteLine("Is the logger instance same " + (logger1 == logger2));
    }
}
