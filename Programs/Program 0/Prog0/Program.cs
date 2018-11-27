// D5965
// CIS 200-01
// 1/30/2017
// Program 0
// Starting Point

// File: Program.cs
// This file creates a simple test application class that creates
// an array of LibraryBook objects and tests them.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Program
{
    // Precondition:  None
    // Postcondition: The LibraryBook class has been tested
    public static void Main(string[] args)
    {
        LibraryPatron patron1 = new LibraryPatron("Aragorn", "00001");
        LibraryPatron patron2 = new LibraryPatron("Legolas", "00002");
        LibraryPatron patron3 = new LibraryPatron("Gimli", "00003");
        LibraryPatron patron4 = new LibraryPatron("Boromir", "00004");
        LibraryPatron patron5 = new LibraryPatron("Gandalf", "00005");
        LibraryPatron patron6 = new LibraryPatron("Julie Dang", "00006");

        LibraryBook book1 = new LibraryBook("The Wright Guide to C#", "Andrew Wright", "UofL Press",
            2010, "ZZ25 3G");  // 1st test book
        LibraryBook book2 = new LibraryBook("Harriet Pooter", "IP Thief", "Stealer Books",
            2000, "AG773 ZF"); // 2nd test book
        LibraryBook book3 = new LibraryBook("The Color Mauve", "Mary Smith", "Beautiful Books Ltd.",
            1985, "JJ438 4T"); // 3rd test book
        LibraryBook book4 = new LibraryBook("The Guan Guide to SQL", "Jeff Guan", "UofL Press",
            1, "ZZ24 4F");    // 4th test book
        LibraryBook book5 = new LibraryBook("The Big Book of Doughnuts", "Homer Simpson", "Doh Books",
            2001, "AE842 7A"); // 5th test book
    LibraryBook book6 = new LibraryBook("The Cat in the Hat", "Dr. Seuss", "Rhyme Tyme", 1900, "AFH123");

        List<LibraryBook> theBooks = new List<LibraryBook> { book1, book2, book3, book4, book5, book6 }; // Test list of books

        Console.WriteLine("Original list of books");
        PrintBooks(theBooks);

        //// Make changes
        book1.CheckOut(patron1);
        book2.Publisher = "Borrowed Books";
        book3.CheckOut(patron3);
        book4.CallNumber = "AB123 4A";
        book5.CheckOut(patron5);
        book6.Publisher = "Random House";
        book6.CheckOut(patron6);

        Console.WriteLine("After changes");
        PrintBooks(theBooks);

        // Return all the books
        for (int i = 0; i < theBooks.Count; ++i)
            theBooks[i].ReturnToShelf();

        Console.WriteLine("After returning the books");
        PrintBooks(theBooks);
    }

    // Precondition:  None
    // Postcondition: The books have been printed to the console
    public static void PrintBooks(List<LibraryBook> books)
    {
        foreach (LibraryBook b in books)
        {
            Console.WriteLine(b);
            Console.WriteLine();
        }
    }
}
