// Program 3
// CIS 200-01
// Due: 4/5/2017
// By: D5965

// File: EditPatronForm.cs
// This class creates the GUI for users to edit Patron information.
// Users will select a Patron from a list, enter in a new name and ID, and the info will be edited.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryItems
{
    public partial class EditPatronForm : Form
    {
        private List<LibraryPatron> _patrons; // List of patrons

        // Precondition:  Lists patronList are populated with the available
        //                LibraryPatrons, respectively, to choose from
        // Postcondition: The form's GUI is prepared for display.
        public EditPatronForm(List<LibraryPatron> patronList)
        {
            InitializeComponent();
            _patrons = patronList;
        }

        // Precondition:  None
        // Postcondition: The lists of patrons are used to populate the
        //                patron combo boxes
        private void EditPatronForm_Load(object sender, EventArgs e)
        {
            foreach (LibraryPatron patron in _patrons)
                patronListComboBox.Items.Add(patron.PatronName + ", " + patron.PatronID);
        }

        internal int PatronIndex
        {
            // Precondition:  None
            // Postcondition: The index of form's selected patron combo box has been returned
            get
            {
                return patronListComboBox.SelectedIndex;
            }
        }

        internal String NewPatronName
        {
            // Precondition:  None
            // Postcondition: The text of form's name field has been returned
            get
            {
                return newPatronNameTextBox.Text;
            }

            // Precondition:  None
            // Postcondition: The text of form's name field has been set to the specified value
            set
            {
                newPatronNameTextBox.Text = value;
            }
        }

        internal String NewPatronID
        {
            // Precondition:  None
            // Postcondition: The text of form's name field has been returned
            get
            {
                return newPatronIdTextBox.Text;
            }

            // Precondition:  None
            // Postcondition: The text of form's name field has been set to the specified value
            set
            {
                newPatronIdTextBox.Text = value;
            }
        }


        // Precondition:  Focus is shifting from patronListComboBox
        // Postcondition: If selection is invalid, focus remains and error provider
        //                highlights the field
        private void patronListComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (patronListComboBox.SelectedIndex == -1) // Nothing selected
            {
                e.Cancel = true;
                errorProvider.SetError(patronListComboBox, "Must select Patron");
            }
        }


        // Precondition:  Validating of patronListComboBox not cancelled, so data OK
        // Postcondition: Error provider cleared and focus allowed to change
        private void patronListComboBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(patronListComboBox, "");
        }


        // Precondition:  User clicked on OKButton
        // Postcondition: If invalid field on dialog, keep form open and give first invalid
        //                field the focus. Else return OK and close form.
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren()) // If all controls validate
                this.DialogResult = DialogResult.OK; // Causes form to close and return OK result
        }


        // Precondition:  User pressed on cancelButton
        // Postcondition: Form closes and sends Cancel result
        private void cancelButton_MouseDown(object sender, MouseEventArgs e)
        {
            // This handler uses MouseDown instead of Click event because
            // Click won't be allowed if other field's validation fails

            if (e.Button == MouseButtons.Left) // Was it a left-click?
                this.DialogResult = DialogResult.Cancel;
        }

        // Precondition:  Focus is shifting from newPatronNameTextBox
        // Postcondition: If text is invalid, focus remains and error provider
        //                highlights the field
        private void newPatronNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newPatronNameTextBox.Text)) // Empty/whitespace field
            {
                e.Cancel = true;
                newPatronNameTextBox.SelectAll();
                errorProvider.SetError(newPatronNameTextBox, "Must provide new name");
            }
        }

        // Precondition:  Validating of newPatronNameTextBox not cancelled, so data OK
        // Postcondition: Error provider cleared and focus allowed to change
        private void newPatronNameTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(newPatronNameTextBox, "");
        }


        // Precondition:  Focus is shifting from newPatronIdTextBox
        // Postcondition: If text is invalid, focus remains and error provider
        //                highlights the field
        private void newPatronIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newPatronIdTextBox.Text)) // Empty/whitespace field
            {
                e.Cancel = true;
                newPatronIdTextBox.SelectAll();
                errorProvider.SetError(newPatronIdTextBox, "Must provide new name");
            }
        }


        // Precondition:  Validating of newPatronIdTextBox not cancelled, so data OK
        // Postcondition: Error provider cleared and focus allowed to change
        private void newPatronIdTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(newPatronIdTextBox, "");
        }
    }
}
