using System.Diagnostics;

Stopwatch sw = new Stopwatch();

Console.WriteLine($"Welcome to osu! stream speedtest!\n\nThis tool will calculate your streaming speed by counting the time it takes you to stream a given number of hits.\nStart by entering the two keys you would like to test with.");

Console.Write("\nKey 1: ");
string key1 = Console.ReadKey().Key.ToString();
Console.Write("\nKey 2: ");
string key2 = Console.ReadKey().Key.ToString();

Boolean test = true;

while (test)
{
    Console.Write("\n\nNumber of hits: ");
    int hits = 50;
    bool numberIsValid = false;
    while (!numberIsValid)
    {
        try
        {
            hits = Int32.Parse(Console.ReadLine());
            numberIsValid = true;
        }
        catch (Exception)
        {
            Console.Write("\nIncorrect number. Please type a valid number: ");
        }
    }
    
    Console.WriteLine("\nReady to test!\nThe test will start once you press one of your set keys.\nOther keys pressed will not be counted.\n");

    for (int i = 0; i < hits; i++)
    {
        bool correctKeyPressed = false;
        while (!correctKeyPressed)
        {
            string keyPressed = Console.ReadKey(true).Key.ToString();
            if (keyPressed.Equals(key1) || keyPressed.Equals(key2))
            {
                correctKeyPressed = true;
                sw.Start();
                Console.Write($"\rTesting ({i + 1}/{hits})");
            }
        }
    }

    sw.Stop();

    TimeSpan ts = sw.Elapsed;
    double elapsedMilliseconds = ts.Milliseconds;
    double elapsedSeconds = ts.Seconds + elapsedMilliseconds / 1000;
    double bpm = hits / elapsedSeconds * 60 / 4;
    
    Console.WriteLine($"\n\nTest completed in {elapsedSeconds} seconds.\nThat is about {Math.Round(bpm)}BPM.\n");

    Console.Write("Confirm your result by pressing enter: ");
    while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }

    Console.Write("\n\nWould you like to test again? (Y=yes/N=no): ");
    if (Console.ReadKey(true).Key == ConsoleKey.N) test = false;
    Console.WriteLine();
}

Console.WriteLine("\nThank you for testing!");