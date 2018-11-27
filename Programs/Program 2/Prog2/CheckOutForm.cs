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
    public partial class CheckOutForm : Form
    {

        private List<LibraryItem> _theLibraryItemList;
        private List<LibraryPatron> _theLibraryPatronList;

        internal int itemCheckOutIndex
        {
            // Precondition:  None
            // Postcondition: The index in itemComboBox is returned
            get { return itemComboBox.SelectedIndex; }
        }

        internal int patronCheckOutIndex
        {
            // Precondition:  None
            // Postcondition: The index in patronComboBox is returned
            get { return patronComboBox.SelectedIndex; }
        }

        // Precondition:  None
        // Postcondition: The CheckOutForm GUI is initialized, and test data is added
        public CheckOutForm(List<LibraryItem> aLibraryItemList, List<LibraryPatron> aLibraryPatronList)
        {
            InitializeComponent();
            _theLibraryItemList = aLibraryItemList;
            _theLibraryPatronList = aLibraryPatronList;
        }

        // Precondition:  Needs item to add to combo box
        // Postcondition: Adds item to combo box
        public void AddItems(LibraryItem item)
        {
            itemComboBox.Items.Add(item);
        }

        // Precondition:  Needs patron to add to combo box
        // Postcondition: Adds patron to combo box
        public void AddPatrons(LibraryPatron patron)
        {
            patronComboBox.Items.Add(patron);
        }

        //public void FormatItems()
        //{
        //    for (int i = 0; i < _theLibraryItemList.Count; i++)
        //    {
        //        string.Format($"{_theLibraryItemList[i].Title}, {_theLibraryItemList[i].CallNumber}");
        //    }
        //}

        //public void FormatPatrons()
        //{
        //    for (int i = 0; i < _theLibraryPatronList.Count; i++)
        //    {
        //        _theLibraryPatronList.ToString($"{_theLibraryPatronList[i].PatronName}, {_theLibraryPatronList[i].PatronName}");
        //    }
        //}

        // Precondition:  None
        // Postcondition: Loads list of items and patron into combo boxes
        private void CheckOutForm_Load(object sender, EventArgs e)
        {
            foreach (LibraryItem item in _theLibraryItemList)
            {
                AddItems(item);
                string.Format($"{item.Title}, {item.CallNumber}");
            }

            foreach (LibraryPatron patron in _theLibraryPatronList)
            {
                AddPatrons(patron);
            }
        }


        // itemComboBox Validation


        // Precondition:  Attempting to change focus from itemComboBox
        // Postcondition: If entered value is valid string, focus will change,
        //                else focus will remain and error provider message set
        private void itemComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (itemComboBox.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider.SetError(itemComboBox, "An item must be selected!");
            }
        }

        // Precondition:  itemComboBox_Validating succeeded
        // Postcondition: Any error message set for itemComboBox is cleared
        //                Focus is allowed to change
        private void itemComboBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(itemComboBox, "");
        }


        // patronComboBox Validation

        // Precondition:  Attempting to change focus from patronComboBox
        // Postcondition: If entered value is valid string, focus will change,
        //                else focus will remain and error provider message set
        private void patronComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (patronComboBox.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider.SetError(patronComboBox, "A patron must be selected!");
            }
        }

        // Precondition:  patronComboBox_Validating succeeded
        // Postcondition: Any error message set for patronComboBox is cleared
        //                Focus is allowed to change
        private void patronComboBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(patronComboBox, "");
        }


        // OK and Cancel Buttons

        // Precondition:  User has initiated click on OkButton
        // Postcondition: If all controls on form validate, CheckOutForm is dismissed with OK result
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }

        // Precondition:  User has initiated click on cancelButton
        // Postcondition: If left-click, CheckOutForm is dismissed with Cancel result
        private void cancelButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Was it a left-click?
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
