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
    public partial class ReturnForm : Form
    {
        private List<LibraryItem> _theLibraryItemList;

        internal int itemReturnIndex
        {
            // Precondition:  None
            // Postcondition: The index in itemComboBox is returned
            get { return returnItemComboBox.SelectedIndex; }
        }

        public ReturnForm(List<LibraryItem> aLibraryItemList)
        {
                InitializeComponent();
                _theLibraryItemList = aLibraryItemList;
        }

        // Precondition:  Needs item to add to combo box
        // Postcondition: Adds item to combo box
        public void AddItems(LibraryItem item)
        {
            returnItemComboBox.Items.Add(item);
        }

        // Precondition:  None
        // Postcondition: Loads list of items into combo boxes
        private void ReturnForm_Load(object sender, EventArgs e)
        {
            foreach (LibraryItem item in _theLibraryItemList)
            {
                AddItems(item);
            }
        }

        // Precondition:  Attempting to change focus from returnItemComboBox
        // Postcondition: If entered value is valid string, focus will change,
        //                else focus will remain and error provider message set
        private void returnItemComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (returnItemComboBox.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider.SetError(returnItemComboBox, "An item must be selected!");
            }
        }

        // Precondition:  returnItemComboBox_Validating succeeded
        // Postcondition: Any error message set for returnItemComboBox is cleared
        //                Focus is allowed to change
        private void returnItemComboBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(returnItemComboBox, "");
        }

        // Precondition:  User has initiated click on OkButton
        // Postcondition: If all controls on form validate, ReturnForm is dismissed with OK result
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }

        // Precondition:  User has initiated click on cancelButton
        // Postcondition: If left-click, ReturnForm is dismissed with Cancel result
        private void cancelButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Was it a left-click?
                this.DialogResult = DialogResult.Cancel;
        }
    }

        
}
