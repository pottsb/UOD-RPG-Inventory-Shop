using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    public partial class CreateShopItemPopup : Form
    {
        readonly string[] ItemCode = {"C","S","H1L","H1R","H2"};
        private List<Item> _masterItemList = new List<Item>();

        // Type of item
        private string _typeCode;
        // Name of item
        private string _name;
        // Description of item
        private string _description;
        // Weight of item
        private int _weight;
        // Cost of item
        private int _cost;
        // Cleaning magic of item
        private int _cleaningMagic;
        // Protective magic of item
        private int _protectiveMagic;
        // Item Object
        private Item _item;

        public Item Item { get { return _item; } }

        public CreateShopItemPopup(List<Item> itemList)
        {
            InitializeComponent();

            //Populates the combo box
            cbItemType.DataSource = Enum.GetValues(typeof(ItemType));

            //Sets the default selected item
            cbItemType.SelectedItem = ItemType.Clothing; 

            //Removes minimise and maximise buttons
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            _masterItemList = itemList;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateData())
            {
                _item = Tasks.CreateItem(_typeCode,_name,_cost,_weight,_cleaningMagic,_protectiveMagic,_description);
                DialogResult = DialogResult.OK;
            }
        }

        private bool validateData()
        {

            bool _validationSuccess = true;
            string validationErrorMessage = "";

            _typeCode = ItemCode[cbItemType.SelectedIndex];

            //Validate Name
            if (tbName.Text.Length > 3 && ItemNameUnique(tbName.Text))
            {
                lblName.ForeColor = Color.Black;
                _name = tbName.Text;
            }
            else
            {
                lblName.ForeColor = Color.Red;
                validationErrorMessage += "Name needs must unique and more than 3 characters long.\n";
                _validationSuccess = false;
            }

            //Validate Description
            if(tbDescription.Text.Length > 3)
            {
                lblDescription.ForeColor = Color.Black;
                _description = tbDescription.Text;
            }
            else
            {
                lblDescription.ForeColor = Color.Red;
                validationErrorMessage += "Description must be more than 3 characters long.\n";
                _validationSuccess = false;
            }

            //Validate Cost
            if(int.TryParse(tbCost.Text, out _cost))
            {
                lblCost.ForeColor = Color.Black;
            }
            else
            {
                lblCost.ForeColor = Color.Red;
                validationErrorMessage += "Cost must be a 3 digit number.\n";
                _validationSuccess = false;
            }

            //Validate Weight
            if (int.TryParse(tbWeight.Text, out _weight))
            {
                lblWeight.ForeColor = Color.Black;
            }
            else
            {
                lblWeight.ForeColor = Color.Red;
                validationErrorMessage += "Weight must be a 3 digit number.\n";
                _validationSuccess = false;
            }

            //Validate Cleaning Magic
            if (int.TryParse(tbCleaningMagic.Text, out _cleaningMagic))
            {
                lblCleaningMagic.ForeColor = Color.Black;
            }
            else
            {
                lblCleaningMagic.ForeColor = Color.Red;
                validationErrorMessage += "Cleaning magic must be a 3 digit number.\n";
                _validationSuccess = false;
            }

            //Validate Protective Magic
            if (int.TryParse(tbProtectiveMagic.Text, out _protectiveMagic))
            {
                lblProtectiveMagic.ForeColor = Color.Black;
            }
            else
            {
                lblProtectiveMagic.ForeColor = Color.Red;
                validationErrorMessage += "Protective magic must be a 3 digit number.\n";
                _validationSuccess = false;
            }

            if (!_validationSuccess)
            {
                MessageBox.Show(validationErrorMessage, "Game Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return _validationSuccess;
        }

        private bool ItemNameUnique(string name)
        {
            bool nameUnique = true;

            foreach(Item item in _masterItemList)
            {
                if(item.Name == name)
                {
                    nameUnique = false;
                    break;
                }
            }

            return nameUnique;
        }

        private void ValidateNumericInput(KeyPressEventArgs e)
        {
            if (e.KeyChar != (Char)Keys.Back && !Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericInput(e);
        }

        private void tbWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericInput(e);
        }

        private void tbCleaningMagic_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericInput(e);
        }

        private void tbProtectiveMagic_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericInput(e);
        }
    }
}
