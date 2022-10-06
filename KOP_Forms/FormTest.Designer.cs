namespace KOP_Forms
{
    partial class FormTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxModified = new ComponentsCustom.ListBoxModified();
            this.textBoxModified = new ComponentsCustom.TextBoxModified();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonAddText = new System.Windows.Forms.Button();
            this.textBoxInputItems = new System.Windows.Forms.TextBox();
            this.labelCurrent1 = new System.Windows.Forms.Label();
            this.labelCurrent2 = new System.Windows.Forms.Label();
            this.dataGridViewModified = new ComponentsCustom.DataGridViewModified();
            this.SuspendLayout();
            // 
            // listBoxModified
            // 
            this.listBoxModified.Location = new System.Drawing.Point(10, 21);
            this.listBoxModified.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxModified.Name = "listBoxModified";
            this.listBoxModified.Size = new System.Drawing.Size(104, 112);
            this.listBoxModified.TabIndex = 1;
            this.listBoxModified.ValueList = "";
            this.listBoxModified.SpecEvent += new System.EventHandler(this.listBoxModified_SelectedChangedEvent);
            // 
            // textBoxModified
            // 
            this.textBoxModified.Location = new System.Drawing.Point(142, 25);
            this.textBoxModified.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxModified.Name = "textBoxModified";
            this.textBoxModified.Size = new System.Drawing.Size(117, 112);
            this.textBoxModified.TabIndex = 2;
            this.textBoxModified.SpecEvent += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 91);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(102, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 120);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(102, 23);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonAddText
            // 
            this.buttonAddText.Location = new System.Drawing.Point(144, 114);
            this.buttonAddText.Name = "buttonAddText";
            this.buttonAddText.Size = new System.Drawing.Size(115, 23);
            this.buttonAddText.TabIndex = 5;
            this.buttonAddText.Text = "Добавить";
            this.buttonAddText.UseVisualStyleBackColor = true;
            this.buttonAddText.Click += new System.EventHandler(this.buttonAddText_Click);
            // 
            // textBoxInputItems
            // 
            this.textBoxInputItems.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxInputItems.Location = new System.Drawing.Point(12, 62);
            this.textBoxInputItems.Name = "textBoxInputItems";
            this.textBoxInputItems.Size = new System.Drawing.Size(102, 23);
            this.textBoxInputItems.TabIndex = 6;
            // 
            // labelCurrent1
            // 
            this.labelCurrent1.AutoSize = true;
            this.labelCurrent1.Location = new System.Drawing.Point(146, 145);
            this.labelCurrent1.Name = "labelCurrent1";
            this.labelCurrent1.Size = new System.Drawing.Size(50, 15);
            this.labelCurrent1.TabIndex = 8;
            this.labelCurrent1.Text = "Current:";
            // 
            // labelCurrent2
            // 
            this.labelCurrent2.AutoSize = true;
            this.labelCurrent2.Location = new System.Drawing.Point(12, 148);
            this.labelCurrent2.Name = "labelCurrent2";
            this.labelCurrent2.Size = new System.Drawing.Size(50, 15);
            this.labelCurrent2.TabIndex = 9;
            this.labelCurrent2.Text = "Current:";
            // 
            // dataGridViewModified
            // 
            this.dataGridViewModified.Location = new System.Drawing.Point(283, 21);
            this.dataGridViewModified.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewModified.Name = "dataGridViewModified";
            this.dataGridViewModified.Size = new System.Drawing.Size(222, 139);
            this.dataGridViewModified.TabIndex = 10;
            this.dataGridViewModified.Load += new System.EventHandler(this.dataGridViewModified_Load);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 172);
            this.Controls.Add(this.dataGridViewModified);
            this.Controls.Add(this.labelCurrent2);
            this.Controls.Add(this.labelCurrent1);
            this.Controls.Add(this.textBoxInputItems);
            this.Controls.Add(this.buttonAddText);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxModified);
            this.Controls.Add(this.listBoxModified);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentsCustom.ListBoxModified listBoxModified;
        private ComponentsCustom.TextBoxModified textBoxModified;
        private Button buttonAdd;
        private Button buttonClear;
        private Button buttonAddText;
        private TextBox textBoxInputItems;
        private Label labelCurrent1;
        private Label labelCurrent2;
        private ComponentsCustom.DataGridViewModified dataGridViewModified;
    }
}