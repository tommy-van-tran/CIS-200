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
    public partial class BookInputForm : Form
    {

        // Precondition:  None
        // Postcondition: The BookInputForm GUI is initialized, and test data is added
        public BookInputForm()
        {
            InitializeComponent();
        }


        // Internal Inputs


        internal string TitleInput 
        {
            // Precondition:  None
            // Postcondition: Text in titleText is returned
            get { return titleText.Text; }

            // Precondition:  Not null or empty
            // Postcondition: Text in titleText is set to specified value
            set { titleText.Text = value; }
        }

        internal string publisherInput
        {
            // Precondition:  None
            // Postcondition: Text in publisherText is returned
            get { return publisherText.Text; }

            // Precondition:  Not null or empty
            // Postcondition: Text in publisherText is set to specified value
            set { publisherText.Text = value; }
        }

        internal string CopyrightInput
        {
            // Precondition:  None
            // Postcondition: Text in copyrightText is returned
            get { return copyrightText.Text; }

            // Precondition:  Value >= 0
            // Postcondition: Text in copyrightText is set to specified value
            set { copyrightText.Text = value; }
        }

        internal string LoanPeriodInput
        {
            // Precondition:  None
            // Postcondition: Text in loanPeriodText is returned
            get { return loanPeriodText.Text; }

            // Precondition:  Value >= 0
            // Postcondition: Text in loanPeriodText is set to specified value
            set { loanPeriodText.Text = value; }
        }

        internal string CallNumberInput
        {
            // Precondition:  None
            // Postcondition: Text in callNumberText is returned
            get { return callNumberText.Text; }

            // Precondition:  Not null or empty
            // Postcondition: Text in callNumberText is set to specified value
            set { callNumberText.Text = value; }
        }

        internal string AuthorInput
        {
            // Precondition:  None
            // Postcondition: Text in authorText is returned
            get { return authorText.Text; }

            // Precondition:  None
            // Postcondition: Text in authorText is set to specified value, and empty if null
            set { authorText.Text = (value == null ? string.Empty : value.Trim()); }
        }


        // Title Validation


        // Precondition:  Attempting to change focus from titleText
        // Postcondition: If entered value is valid string, focus will change,
        //                else focus will remain and error provider message set
        private void titleText_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleText.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(titleText, "Title must not be null or void!");
            }
        }

        // Precondition:  titleText_Validating succeeded
        // Postcondition: Any error message set for titleText is cleared
        //                Focus is allowed to change
        private void titleText_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(titleText, "");
        }


        // Publisher Validation


        // Precondition:  Attempting to change focus from publisherText
        // Postcondition: If entered value is valid string, focus will change,
        //                else focus will remain and error provider message set
        private void publisherText_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(publisherText.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(publisherText, "Publisher must not be null or void!");
            }
        }

        // Precondition:  publisherText_Validating succeeded
        // Postcondition: Any error message set for publisherText is cleared
        //                Focus is allowed to change
        private void publisherText_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(publisherText, "");
        }


        // Copyright Year Validation


        // Precondition:  Attempting to change focus from copyrightText
        // Postcondition: If entered value is valid int, focus will change,
        //                else focus will remain and error provider message set
        private void copyrightText_Validating(object sender, CancelEventArgs e)
        {
            int number; // Value entered into copyrightText

            // Will try to parse text as int
            // If fails, TryParse returns false
            // If succeeds, TryParse returns true and number stores parsed value
            if (!int.TryParse(copyrightText.Text, out number))
            {
                e.Cancel = true; // Stops focus changing process
                                 // Will NOT proceed to Validated event

                errorProvider.SetError(copyrightText, "Copyright must be an integer!"); // Set error message

                copyrightText.SelectAll(); // Select all text in copyrightText to ease correction
            }
            else
            {
                if (number < 0)
                {
                    e.Cancel = true; // Stops focus changing process
                    // Will NOT proceed to Validated event

                    errorProvider.SetError(copyrightText, "Copyright must be a non-negative integer!"); // Set error message

                    copyrightText.SelectAll(); // Select all text in inputTxt to ease correction
                }
            }
        }

        // Precondition:  copyrightText_Validating succeeded
        // Postcondition: Any error message set for copyrightText is cleared
        //                Focus is allowed to change
        private void copyrightText_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(copyrightText, "");
        }


        // Loan Period Validation


        // Precondition:  Attempting to change focus from loanPeriodText
        // Postcondition: If entered value is valid int, focus will change,
        //                else focus will remain and error provider message set
        private void loanPeriodText_Validating(object sender, CancelEventArgs e)
        {
            int number; // Value entered into loanPeriodText

            if (!int.TryParse(loanPeriodText.Text, out number))
            {
                e.Cancel = true; 

                errorProvider.SetError(loanPeriodText, "Enter an integer!");

                loanPeriodText.SelectAll();
            }
            else
            {
                if (number < 0)
                {
                    e.Cancel = true; 

                    errorProvider.SetError(loanPeriodText, "Enter a non-negative integer!");

                    loanPeriodText.SelectAll(); 
                }
            }
        }

        // Precondition:  loanPeriodText_Validating succeeded
        // Postcondition: Any error message set for loanPeriodText is cleared
        //                Focus is allowed to change
        private void loanPeriodText_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(loanPeriodText, "");
        }


        // Call Number Validation


        // Precondition:  Attempting to change focus from callNumberText
        // Postcondition: If entered value is valid string, focus will change,
        //                else focus will remain and error provider message set
        private void callNumberText_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(callNumberText.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(callNumberText, "Call Number must not be null or void!");
            }
        }

        // Precondition:  callNumberText_Validating succeeded
        // Postcondition: Any error message set for callNumberText is cleared
        //                Focus is allowed to change
        private void callNumberText_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(callNumberText, "");
        }


        // OK and Cancel Buttons


        // Precondition:  User has initiated click on OkButton
        // Postcondition: If all controls on form validate, BookInputBox is dismissed with OK result
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }

        // Precondition:  User has initiated click on cancelButton
        // Postcondition: If left-click, BookInputForm is dismissed with Cancel result
        private void cancelButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Was it a left-click?
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
