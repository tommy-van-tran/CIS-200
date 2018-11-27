// Grading ID: D5965
// Program 2
// Due: 3/10/2017

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace LibraryItems
{
    public partial class MainForm : Form
    {
        string NL = Environment.NewLine; // String variable that inserts new line

        // Precondition:  None
        // Postcondition: The MainForm GUI is initialized, and test data is added
        public MainForm()
        {
            InitializeComponent();
            addTestData(); // Adds test data

        }

        // Precondition:  None
        // Postcondition: The library has been created and is empty (no books, no patrons)
        public Library TestLibrary = new Library();

        // Precondition:  None
        // Postcondition: The library has been filled with various Library Items
        private void addTestData()
        {
            // Library Test Patrons
            TestLibrary.AddPatron("John Smith", "00001"); 
            TestLibrary.AddPatron("Jane Doe", "00002");
            TestLibrary.AddPatron("Rob Johnson", "00003");

            // Library Test Items
            TestLibrary.AddLibraryBook("The Great Gatsby", "Charles Scribner's Sons", 1925, 30, "BK001", "F. Scott Fitzgerald");
            TestLibrary.AddLibraryBook("Of Mice and Men", "Covici Friede", 1937, 30, "BK002", "John Steinbeck");
            TestLibrary.AddLibraryBook("Nineteen Eighty-Four", "	Secker & Warburg", 1949, 30, "BK003", "George Orwell");
            TestLibrary.AddLibraryBook("Winesburg, Ohio", "B.W. Huebsch", 1919, 30, "BK004", "Sherwood Anderson");
            TestLibrary.AddLibraryBook("The Lord of the Rings", "George Allen & Unwin (UK)", 1955, 30, "BK005", "J. R. R. Tolkien");

        }

        // Precondition:  None
        // Postcondition: The menu item has been created and gives program information when clicked
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Grading ID: D5965 {NL}Program 2 {NL}Due Date: March 10th, 2017", "About",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Precondition:  None
        // Postcondition: The menu item has been created and exits program application when clicked
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Precondition:  None
        // Postcondition: The menu item has been created and prompts user to add a new patron
        private void patronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatronInputForm patronInput = new PatronInputForm();
            DialogResult result;

            result = patronInput.ShowDialog();

            if (result == DialogResult.OK) // Creates patron based on validated user inputs
            {
                TestLibrary.AddPatron(patronInput.NameInput, patronInput.IdInput);
                MessageBox.Show("A new Library Patron has been added!");
            }
        }

        // Precondition:  None
        // Postcondition: The menu item has been created and prompts user to add a new book
        private void bookMenuItem_Click(object sender, EventArgs e)
        {
            BookInputForm bookInput = new BookInputForm();
            DialogResult result;

            result = bookInput.ShowDialog();
            int copyrightToInt;  // User's copyright input to be gathered from dialog box
            int loanPeriodToInt; // User's loan period input to be gathered from dialog box

            if (result == DialogResult.OK) // Creates book based on validated user inputs
            {
                copyrightToInt = int.Parse(bookInput.CopyrightInput);   // Retrieve values from dialog box
                loanPeriodToInt = int.Parse(bookInput.LoanPeriodInput);

                TestLibrary.AddLibraryBook(bookInput.TitleInput, bookInput.publisherInput, copyrightToInt,
                                           loanPeriodToInt, bookInput.CallNumberInput, bookInput.AuthorInput);
                MessageBox.Show("A new Library Book has been added!");
            }
        }

        // Precondition:  None
        // Postcondition: The menu item has been created and prompts user to select an item and patron to check out
        private void checkoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckOutForm checkOut = new CheckOutForm(TestLibrary.GetItemsList(), TestLibrary.GetPatronsList());
            DialogResult result;

            result = checkOut.ShowDialog();

            if (result == DialogResult.OK) // Checks out item based on validated user selection
            {
                TestLibrary.CheckOut(checkOut.itemCheckOutIndex, checkOut.patronCheckOutIndex);
                MessageBox.Show("You have checked out this library item!");
            }
            
        }

        // Precondition:  None
        // Postcondition: The menu item has been created and prompts user to select an item and patron to return
        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnForm returns = new ReturnForm(TestLibrary.GetItemsList());
            DialogResult result;

            result = returns.ShowDialog();

            if (result == DialogResult.OK) // Checks out item based on validated user selection
            {
                TestLibrary.ReturnToShelf(returns.itemReturnIndex);
                MessageBox.Show("You have returned this library item!");
            }
        }

        // Precondition:  None
        // Postcondition: The listbox clear itself and will add the list and count of patrons
        private void patronListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportListBox.Items.Clear();

            foreach (LibraryPatron patrons in TestLibrary.GetPatronsList())
            {
                reportListBox.Items.Add(patrons);
            }

            reportListBox.Items.Add("\nNumber of patrons: " + TestLibrary.GetPatronCount());
        }

        // Precondition:  None
        // Postcondition: The listbox clear itself and will add the list and count of items
        private void itemListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportListBox.Items.Clear();

            foreach (LibraryItem items in TestLibrary.GetItemsList())
            {
                reportListBox.Items.Add(items);
            }

            reportListBox.Items.Add("\nNumber of items: " + TestLibrary.GetItemCount());
        }

        // Precondition:  None
        // Postcondition: The listbox clear itself and will add the list and count of checked out items
        private void checkedOutItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportListBox.Items.Clear();

            foreach (LibraryItem items in TestLibrary.GetItemsList())
            {
                if (items.IsCheckedOut())
                {
                    reportListBox.Items.Add(items);
                }
            }

            reportListBox.Items.Add("\nCheck out items: " + TestLibrary.GetCheckedOutCount());
        }
    }
}
