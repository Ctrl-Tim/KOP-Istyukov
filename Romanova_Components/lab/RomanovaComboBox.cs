using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab
{
    public partial class RomanovaComboBox : UserControl
    {
        public event EventHandler IndexChanged;

        public RomanovaComboBox()
        {
            InitializeComponent();
            comboBox.SelectedIndexChanged += (sender, e) => IndexChanged?.Invoke(sender, e);
        }

        public void FillList(string item)
        {
            comboBox.Items.Add(item);
        }

        public void ClearList()
        {
            comboBox.Items.Clear();
            comboBox.Text = "";
        }

        public string SelectElement
        {
            get
            {
                if (comboBox.SelectedItem == null)
                {
                    return string.Empty;
                }
                return comboBox.SelectedItem.ToString();
            }
            set
            {
                comboBox.SelectedItem = value;
            }
        }

        public event EventHandler SelectIndexChanged
        {

            add
            {
                IndexChanged += value;
            }
            remove
            {
                IndexChanged -= value;
            }
        }
    }
}
