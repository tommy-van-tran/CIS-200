// Grading ID: D5965
// Program 1B
// Due: 2/22/17
// CIS 200-01

// Program that creates a simple class hierarchy including (limited) use of polymorphism and LINQ to produce simple reports.

// File: Program.cs
// This file creates a small application that tests the LibraryItem hierarchy

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryItems;


public class Program
{
    // Precondition:  None
    // Postcondition: The LibraryItem hierarchy has been tested using LINQ, demonstrating polymorphism
    public static void Main(string[] args)
    {
       // const int DAYSLATE = 28; // Number of days late to test each object's CalcLateFee method

        List<LibraryItem> items = new List<LibraryItem>();       // List of library items
        List<LibraryPatron> patrons = new List<LibraryPatron>(); // List of patrons

        // Test data - Magic numbers allowed here
        items.Add(new LibraryBook("The Wright Guide to C#", "UofL Press", 2010, 14,
            "ZZ25 3G", "Andrew Wright"));
        items.Add(new LibraryBook("Harriet Pooter", "Stealer Books", 2000, 21,
            "AB73 ZF", "IP Thief"));
        items.Add(new LibraryMovie("Andrew's Super-Duper Movie", "UofL Movies", 2011, 7,
            "MM33 2D", 92.5, "Andrew L. Wright", LibraryMediaItem.MediaType.BLURAY,
            LibraryMovie.MPAARatings.PG));
        items.Add(new LibraryMovie("Pirates of the Carribean: The Curse of C#", "Disney Programming", 2012, 10,
            "MO93 4S", 122.5, "Steven Stealberg", LibraryMediaItem.MediaType.DVD, LibraryMovie.MPAARatings.G));
        items.Add(new LibraryMusic("C# - The Album", "UofL Music", 2014, 14,
            "CD44 4Z", 84.3, "Dr. A", LibraryMediaItem.MediaType.CD, 10));
        items.Add(new LibraryMusic("The Sounds of Programming", "Soundproof Music", 1996, 21,
            "VI64 1Z", 65.0, "Cee Sharpe", LibraryMediaItem.MediaType.VINYL, 12));
        items.Add(new LibraryJournal("Journal of C# Goodness", "UofL Journals", 2000, 14,
            "JJ12 7M", 1, 2, "Information Systems", "Andrew Wright"));
        items.Add(new LibraryJournal("Journal of VB Goodness", "UofL Journals", 2008, 14,
            "JJ34 3F", 8, 4, "Information Systems", "Alexander Williams"));
        items.Add(new LibraryMagazine("C# Monthly", "UofL Mags", 2016, 14,
            "MA53 9A", 16, 7));
        items.Add(new LibraryMagazine("C# Monthly", "UofL Mags", 2016, 14,
            "MA53 9B", 16, 8));
        items.Add(new LibraryMagazine("C# Monthly", "UofL Mags", 2016, 14,
            "MA53 9C", 16, 9));
        items.Add(new LibraryMagazine("VB Magazine", "UofL Mags", 2017, 14,
            "MA21 5V", 1, 1));

        // Add patrons
        patrons.Add(new LibraryPatron("Ima Reader", "12345"));
        patrons.Add(new LibraryPatron("Jane Doe", "11223"));
        patrons.Add(new LibraryPatron("John Smith", "54321"));
        patrons.Add(new LibraryPatron("James T. Kirk", "98765"));
        patrons.Add(new LibraryPatron("Jean-Luc Picard", "33456"));

        Console.WriteLine("List of items at start:\n");
        foreach (LibraryItem item in items)
            Console.WriteLine("{0}\n", item);
        Pause();

        // Check out some items
        items[0].CheckOut(patrons[0]);
        items[2].CheckOut(patrons[2]);
        items[5].CheckOut(patrons[1]);
        items[7].CheckOut(patrons[3]);
        items[10].CheckOut(patrons[4]);

        // Displays items after some of them have been checked out
        Console.WriteLine("List of items after checking some out:\n");
        foreach (LibraryItem item in items)
            Console.WriteLine("{0}\n", item);
        Pause();

        // Displays only items that have been checked out, then the count of checked out items
        var checkedOutLibraryItems =
            from element in items
            where element.IsCheckedOut() == true
            select element;

        Console.WriteLine("List of items that are checked out:\n");
        foreach (var item in checkedOutLibraryItems)
        {
            Console.WriteLine("{0}\n", item);
        }
        Console.WriteLine("Count of checked out items: " + checkedOutLibraryItems.Count() + "\n");
        Pause();

        // Displays only library media items that are checked out
        var checkedOutLibraryMedia =
            from element in checkedOutLibraryItems
            where element is LibraryMediaItem
            select element;

        Console.WriteLine("List of library media items that are checked out:\n");
        foreach (var item in checkedOutLibraryMedia)
        {
            Console.WriteLine("{0}\n", item);
        }
        Pause();

        // Displays only unique titles of Library Magazines
        var uniqueLibraryMagazines =
            from element in items
            where element is LibraryMagazine
            select element.Title;

        Console.WriteLine("List of library magazine titles that are unique:\n");
        foreach (var item in uniqueLibraryMagazines.Distinct())
        {
            Console.WriteLine("{0}\n", item);
        }
        Pause();

        // List of each library item's title, call number and late fee if they were 14 days late
        Console.WriteLine("List of each library item's title, call number and late fee if they were 14 days late:\n");
        foreach (var item in items)
        {
            Console.WriteLine($"Title: {item.Title}\nCall Number: {item.CallNumber}\nLate Fee: {item.CalcLateFee(14):c}\n");
        }
        Pause();

        // Returns all checked out items, and returns the count of checked out items from an earlier LINQ result
        Console.WriteLine("Returns all checked out items, and returns the count of checked out items from an earlier LINQ result:\n");
        foreach (var item in items)
        {
            item.ReturnToShelf();
        }
        Console.WriteLine("Using 'checkedOutLibraryItems.Count()' result, count of checked out items: " + checkedOutLibraryItems.Count() + "\n");
        Pause();

        // Displays each LibraryBook's loan period, adds 7 days to the period, and display the new loan period
        Console.WriteLine("Display each Library Book's loan period, adds 7 days, and displays the new loan period:\n");
        for (int b = 0; b <= items.Count() - 1; b++)
        {
            if (items[b] is LibraryBook)
            {
                Console.WriteLine($"Title: {items[b].Title} \nLoan Period: {items[b].LoanPeriod}");
                items[b].LoanPeriod = items[b].LoanPeriod + 7;
                Console.WriteLine($"Loan Period after adding 7 days: { items[b].LoanPeriod}\n");
            }
        }
        Pause();

        // Displays the entire list of items again
        Console.WriteLine("List of items:\n");
        foreach (LibraryItem item in items)
            Console.WriteLine("{0}\n", item);
        Pause();

        //Console.WriteLine("Calculated late fees after {0} days late:\n", DAYSLATE);
        //Console.WriteLine("{0,42} {1,11} {2,8}", "Title", "Call Number", "Late Fee");
        //Console.WriteLine("------------------------------------------ ----------- --------");

        //    // Caluclate and display late fees for each item
        //    foreach (LibraryItem item in items)
        //        Console.WriteLine("{0,42} {1,11} {2,8:C}", item.Title, item.CallNumber,
        //            item.CalcLateFee(DAYSLATE));
        //    Pause();

        //    // Return each item that is checked out
        //    foreach (LibraryItem item in items)
        //    {
        //        if (item.IsCheckedOut())
        //            item.ReturnToShelf();
        //    }

        //    Console.WriteLine("After returning all items:\n");
        //    foreach (LibraryItem item in items)
        //        Console.WriteLine("{0}\n", item);
        //    Pause();
    }

    // Precondition:  None
    // Postcondition: Pauses program execution until user presses Enter and
    //                then clears the screen
    public static void Pause()
    {
        Console.WriteLine("Press Enter to Continue...");
        Console.ReadLine();

        Console.Clear(); // Clear screen
    }
}