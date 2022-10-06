using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentsCustom
{
    public partial class ListBoxModified : UserControl
    {
        /// <summary>
        /// User Control, содержащий ListBox и методы работы с ним
        /// </summary>
        public ListBoxModified()
        {
            InitializeComponent();
        }

        public string ValueList
        {
            set
            {
                int index = listBox.FindString(value);
                if (index != -1)
                {
                    listBox.SetSelected(index, true);
                }
            }
            get { return listBox.Text; }
        }

        private void ListBox_SelectedChanged(object sender, System.EventArgs e)
        {
            eventHandler?.Invoke(sender, e);
        }

        public event EventHandler eventHandler;

        /// <summary>
        /// Событие, которое вызывается при изменении элемента
        /// </summary>
        public event EventHandler SpecEvent
        {
            add { eventHandler += value; }
            remove { eventHandler -= value; }
        }

        /// <summary>
        /// Добавляет элемент в ListBox
        /// </summary>
        public void AddItem(string item)
        {
            listBox.Items.Add(item);
        }

        /// <summary>
        /// Очищает список элементов ListBox
        /// </summary>
        public void ClearList()
        {
            listBox.Items.Clear();
            listBox.ResetText();
        }

        private void ListBoxModified_Load(object sender, EventArgs e)
        {

        }
    }
}
