
// Amir Moeini Rad
// September 2025


// Main Concept: Events in C#


/*

The Process of Defining and Using Events in C#:

1- Declare the event delegate: 'CharEventHandler'.
2- Create the event argument class: 'CharEventArgs'.
3- Create the event publisher class: 'CharChecker'.
4- Define the event in the publisher class: 'TestChar'.
5- Raise the event in the publisher class using the 'CurrentCharacter' property.
6- Create the event publisher object: 'tester'.
7- Install/Subscribe to the event handler in the main class: 'Drop_A'.

*/


using System;


// Declaring the event delegate 
// 'CharEventHandler' is the name of the delegate
// The first parameter is the source of the event.
// The second parameter is the custom event argument class.
// This delegate will be used to refer to the event handler method with this signature.
delegate void CharEventHandler(object source, CharEventArgs e);



// Declaring the event argument class 
// 'EventArgs' is the base class for classes containing event data.
public class CharEventArgs : EventArgs
{
    public char CurrentCharacter { get; set; }

    public CharEventArgs(char charArgument)
    {
        CurrentCharacter = charArgument;
    }
}



// Class that raises the event.
// This class is the event publisher.
class CharChecker
{
    private char currChar;

    // Defining the event.
    // 'CharEventHandler' is the delegate type of the event defined above.
    // 'TestChar' is the name of the event.
    public event CharEventHandler TestChar;

    // Property that raises the event when a new value is assigned to it.
    public char CurrentCharacter
    {
        get { return currChar; }

        set
        {
            if (TestChar != null )
            {
                // Creating the event argument class object.
                CharEventArgs args = new CharEventArgs(value);

                // Calling/Raising the event manually.
                TestChar(this, args);
                currChar = args.CurrentCharacter;
            }
        }
    }
}



// The main class
class Events
{
    public static void Main()
    {
        Console.WriteLine("-----------------");
        Console.WriteLine("Events in C#.NET.");
        Console.WriteLine("-----------------\n");


        // Creating the event publisher object
        CharChecker tester = new CharChecker();

        // Installing the event
        // The event handler 'Drop_A' is added/subscribed to the event 'TestChar'.
        tester.TestChar += new CharEventHandler(Drop_A);


        // The following assignments via the 'CurrentCharacter' property cause the event to be called.
        tester.CurrentCharacter = 'B';
        Console.WriteLine("Back to Main(). Current Character: {0}\n", tester.CurrentCharacter);

        tester.CurrentCharacter = 'r';
        Console.WriteLine("Back to Main(). Current Character: {0}\n", tester.CurrentCharacter);

        tester.CurrentCharacter = 'a';
        Console.WriteLine("Back to Main(). Current Character: {0}\n", tester.CurrentCharacter);

        tester.CurrentCharacter = 'd';
        Console.WriteLine("Back to Main(). Current Character: {0}\n", tester.CurrentCharacter);


        Console.WriteLine("Done.");
    }


    // Defining the event handler
    static void Drop_A(object source, CharEventArgs e)
    {
        Console.WriteLine("In the event handler. Current Character: {0}", e.CurrentCharacter);

        if(e.CurrentCharacter == 'a' || e.CurrentCharacter == 'A' )
        {
            Console.WriteLine("Don't like 'a/A'!");
            e.CurrentCharacter = 'X';
        }
    }
}