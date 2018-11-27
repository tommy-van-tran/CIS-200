// Program 2
// CIS 200-01
// Spring 2017
// By: Andrew L. Wright

// File: Library.cs
// This file creates a basic Library class that stores a list
// of LibraryItems and a list of LibraryPatrons. It allows items
// to be checked out by patrons. The lists are accessible to other
// classes in the same namespace (LibraryItems).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    public class Library
    {
        // Namespace Accessible Data - Use with care
        internal List<LibraryItem> _items;     // List of items stored in Library
        internal List<LibraryPatron> _patrons; // List of patrons of Library

        // Precondition:  None
        // Postcondition: The library has been created and is empty (no books, no patrons)
        public Library()
        {
            _items = new List<LibraryItem>();
            _patrons = new List<LibraryPatron>();
        }

        // Precondition:  None
        // Postcondition: A patron has been created with the specified values for name and ID.
        //                The patron has been added to the Library.
        public void AddPatron(String name, String id)
        {
            _patrons.Add(new LibraryPatron(name, id));
        }

        // Precondition:  theCopyrightYear >= 0 and theLoanPeriod >= 0
        // Postcondition: A library book has been created with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, and author. The item is not checked out.
        //                The book has been added to the Library.
        public void AddLibraryBook(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, String theAuthor)
        {
            _items.Add(new LibraryBook(theTitle, thePublisher, theCopyrightYear, theLoanPeriod,
                theCallNumber, theAuthor));
        }

        // Precondition:  theCopyrightYear >= 0 and theLoanPeriod >= 0 and 
        //                theMedium from { DVD, BLURAY, VHS } and theDuration >= 0
        // Postcondition: A library movie has been created with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, duration, director, medium, and rating. The
        //                item is not checked out.
        //                The movie has been added to the Library.
        public void AddLibraryMovie(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, double theDuration, String theDirector,
            LibraryMediaItem.MediaType theMedium, LibraryMovie.MPAARatings theRating)
        {
            _items.Add(new LibraryMovie(theTitle, thePublisher, theCopyrightYear, theLoanPeriod,
                theCallNumber, theDuration, theDirector, theMedium, theRating));
        }

        // Precondition:  theCopyrightYear >= 0 and theLoanPeriod >= 0 and 
        //                theMedium from { CD, SACD, VINYL } and theDuration >= 0 and
        //                theNumTracks >= 0
        // Postcondition: A library music item has been created with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, duration, director, medium, and rating. The
        //                item is not checked out.
        //                The music item has been added to the Library.
        public void AddLibraryMusic(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, double theDuration, String theArtist,
            LibraryMediaItem.MediaType theMedium, int theNumTracks)
        {
            _items.Add(new LibraryMusic(theTitle, thePublisher, theCopyrightYear,
            theLoanPeriod, theCallNumber, theDuration, theArtist,
            theMedium, theNumTracks));
        }

        // Precondition:  theCopyrightYear >= 0 and theLoanPeriod >= 0 and
        //                theVolume >= 0 and theNumber >= 0
        // Postcondition: A library journal has been created with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, volume, number, discipline, and editor. The
        //                item is not checked out.
        //                The journal has been added to the Library.
        public void AddLibraryJournal(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, int theVolume, int theNumber,
            String theDiscipline, String theEditor)
        {
            _items.Add(new LibraryJournal(theTitle, thePublisher, theCopyrightYear,
            theLoanPeriod, theCallNumber, theVolume, theNumber,
            theDiscipline, theEditor));
        }

        // Precondition:  theCopyrightYear >= 0 and theLoanPeriod >= 0 and
        //                theVolume >= 0 and theNumber >= 0
        // Postcondition: A library magazine has been created with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, volume, and number. The item is not checked out.
        //                The magazine has been added to the Library.
        public void AddLibraryMagazine(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, int theVolume, int theNumber)
        {
            _items.Add(new LibraryMagazine(theTitle, thePublisher, theCopyrightYear,
            theLoanPeriod, theCallNumber, theVolume, theNumber));
        }

        // Precondition:  None
        // Postcondition: The number of patrons in the library is returned
        public int GetPatronCount()
        {
            return _patrons.Count;
        }

        // Precondition:  None
        // Postcondition: The number of items in the library is returned
        public int GetItemCount()
        {
            return _items.Count;
        }

        // Precondition:  0 <= itemIndex < GetItemCount()
        //                0 <= patronIndex < GetPatronCount()
        // Postcondition: The specified item will be checked out by
        //                the specifed patron
        public void CheckOut(int itemIndex, int patronIndex)
        {
            if ((itemIndex >= 0) && (itemIndex < GetItemCount()))
            {
                if ((patronIndex >= 0) && (patronIndex < GetPatronCount()))
                    _items[itemIndex].CheckOut(_patrons[patronIndex]);
                else
                    throw new ArgumentOutOfRangeException($"{nameof(patronIndex)}", patronIndex,
                        $"0 <= {nameof(patronIndex)} < GetPatronCount()");
            }
            else
                throw new ArgumentOutOfRangeException($"{nameof(itemIndex)}", itemIndex,
                    $"0 <= {nameof(itemIndex)} < GetItemCount()");
        }

        // Precondition:  0 <= bookIndex < GetItemCount()
        // Postcondition: The specified book will be returned to shelf
        public void ReturnToShelf(int itemIndex)
        {
            if ((itemIndex >= 0) && (itemIndex < GetItemCount()))
                _items[itemIndex].ReturnToShelf();
            else
                throw new ArgumentOutOfRangeException($"{nameof(itemIndex)}", itemIndex,
                    $"0 <= {nameof(itemIndex)} < GetItemCount()");
        }

        // Precondition:  None
        // Postcondition: The number of items checked out from the library is returned
        public int GetCheckedOutCount()
        {
            int checkedOutCount = 0; // Running count of checked out books

            foreach (LibraryItem item in _items)
                if (item.IsCheckedOut())
                    ++checkedOutCount;

            return checkedOutCount;
        }

        // Namespace Helper Method - Use with care
        // Precondition:  None
        // Postcondition: The list of items stored in the library is returned
        internal List<LibraryItem> GetItemsList()
        {
            return _items;
        }

        // Namespace Helper Method - Use with care
        // Precondition:  None
        // Postcondition: The list of patrons stored in the library is returned
        internal List<LibraryPatron> GetPatronsList()
        {
            return _patrons;
        }
        
        // Precondition:  None
        // Postcondition: A string is returned presenting the libary in a formatted report
        public override string ToString()
        {
            // Using StringBuilder to show use of a more efficient way than String concatenation
            StringBuilder report = new StringBuilder(); // Will hold report as being built
            string NL = Environment.NewLine; // NewLine shortcut

            report.Append("Library Report\n");
            report.Append($"Number of items stored:      {GetItemCount(),4:d}{NL}");
            report.Append($"Number of items checked out: {GetCheckedOutCount(),4:d}{NL}");
            report.Append($"Number of patrons stored:    {GetPatronCount(),4:d}");

            return report.ToString();
        }
    }
}
