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
    public partial class PatronInputForm : Form
    {

        // Precondition:  None
        // Postcondition: The PatronInputForm GUI is initialized, and test data is added
        public PatronInputForm()
        {
            InitializeComponent();
            
        }

        internal string NameInput // Can be accessed by other classes in same namespace
        {
            // Precondition:  None
            // Postcondition: Text in nameText is returned
            get { return nameText.Text; }

            // Precondition:  None
            // Postcondition: Text in nameText is set to specified value
            set { nameText.Text = value; }
        }

        internal string IdInput // Can be accessed by other classes in same namespace
        {
            // Precondition:  None
            // Postcondition: Text in IdText is returned
            get { return IdText.Text; }

            // Precondition:  None
            // Postcondition: Text in IdText is set to specified value
            set { IdText.Text = value; }
        }


        // Name Validation


        // Precondition:  Attempting to change focus from nameText
        // Postcondition: If entered value is valid string, focus will change,
        //                else focus will remain and error provider message set
        private void nameText_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameText.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(nameText, "Name must not be null or void!");
            }
        }

        // Precondition:  nameText_Validating succeeded
        // Postcondition: Any error message set for nameText is cleared
        //                Focus is allowed to change
        private void nameText_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(nameText, "");
        }


        // ID Validation


        // Precondition:  Attempting to change focus from IdText
        // Postcondition: If entered value is valid string, focus will change,
        //                else focus will remain and error provider message set
        private void IdText_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IdText.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(IdText, "Name must not be null or void!");
            }
        }

        // Precondition:  IdText_Validating succeeded
        // Postcondition: Any error message set for IdText is cleared
        //                Focus is allowed to change
        private void IdText_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(IdText, "");
        }


        // OK and Cancel Buttons

        // Precondition:  User has initiated click on OkButton
        // Postcondition: If all controls on form validate, PatronInputBox is dismissed with OK result
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }

        // Precondition:  User has initiated click on cancelButton
        // Postcondition: If left-click, PatronInputForm is dismissed with Cancel result
        private void cancelButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Was it a left-click?
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
