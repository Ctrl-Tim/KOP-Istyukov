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
            this.components = new System.ComponentModel.Container();
            this.listBoxModified = new ComponentsCustom.ListBoxModified();
            this.textBoxModified = new ComponentsCustom.TextBoxModified();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonAddText = new System.Windows.Forms.Button();
            this.textBoxInputItems = new System.Windows.Forms.TextBox();
            this.labelCurrent1 = new System.Windows.Forms.Label();
            this.labelCurrent2 = new System.Windows.Forms.Label();
            this.dataGridViewModified = new ComponentsCustom.DataGridViewModified();
            this.wordTablesContext = new ComponentsCustomUnvisual.WordTablesContext(this.components);
            this.wordTableCustom = new ComponentsCustomUnvisual.WordTableCustom(this.components);
            this.buttonSaveDataChangebleWord = new System.Windows.Forms.Button();
            this.buttonGistogram = new System.Windows.Forms.Button();
            this.buttonSaveStorage = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.groupBoxVisual = new System.Windows.Forms.GroupBox();
            this.wordGistagram = new ComponentsCustomUnvisual.WordGistagram(this.components);
            this.groupBox.SuspendLayout();
            this.groupBoxVisual.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxModified
            // 
            this.listBoxModified.Location = new System.Drawing.Point(22, 21);
            this.listBoxModified.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxModified.Name = "listBoxModified";
            this.listBoxModified.Size = new System.Drawing.Size(104, 112);
            this.listBoxModified.TabIndex = 1;
            this.listBoxModified.ValueList = "";
            this.listBoxModified.SpecEvent += new System.EventHandler(this.listBoxModified_SelectedChangedEvent);
            // 
            // textBoxModified
            // 
            this.textBoxModified.Location = new System.Drawing.Point(154, 25);
            this.textBoxModified.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxModified.Name = "textBoxModified";
            this.textBoxModified.Size = new System.Drawing.Size(117, 112);
            this.textBoxModified.TabIndex = 2;
            this.textBoxModified.SpecEvent += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.SystemColors.Info;
            this.buttonAdd.Location = new System.Drawing.Point(24, 91);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(102, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.SystemColors.Info;
            this.buttonClear.Location = new System.Drawing.Point(24, 120);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(102, 23);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonAddText
            // 
            this.buttonAddText.Location = new System.Drawing.Point(156, 114);
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
            this.textBoxInputItems.Location = new System.Drawing.Point(24, 62);
            this.textBoxInputItems.Name = "textBoxInputItems";
            this.textBoxInputItems.Size = new System.Drawing.Size(102, 23);
            this.textBoxInputItems.TabIndex = 6;
            // 
            // labelCurrent1
            // 
            this.labelCurrent1.AutoSize = true;
            this.labelCurrent1.Location = new System.Drawing.Point(158, 145);
            this.labelCurrent1.Name = "labelCurrent1";
            this.labelCurrent1.Size = new System.Drawing.Size(50, 15);
            this.labelCurrent1.TabIndex = 8;
            this.labelCurrent1.Text = "Current:";
            // 
            // labelCurrent2
            // 
            this.labelCurrent2.AutoSize = true;
            this.labelCurrent2.Location = new System.Drawing.Point(24, 148);
            this.labelCurrent2.Name = "labelCurrent2";
            this.labelCurrent2.Size = new System.Drawing.Size(50, 15);
            this.labelCurrent2.TabIndex = 9;
            this.labelCurrent2.Text = "Current:";
            // 
            // dataGridViewModified
            // 
            this.dataGridViewModified.Location = new System.Drawing.Point(277, 21);
            this.dataGridViewModified.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewModified.Name = "dataGridViewModified";
            this.dataGridViewModified.Size = new System.Drawing.Size(222, 139);
            this.dataGridViewModified.TabIndex = 10;
            this.dataGridViewModified.Load += new System.EventHandler(this.dataGridViewModified_Load);
            // 
            // buttonSaveDataChangebleWord
            // 
            this.buttonSaveDataChangebleWord.BackColor = System.Drawing.SystemColors.Info;
            this.buttonSaveDataChangebleWord.Location = new System.Drawing.Point(145, 22);
            this.buttonSaveDataChangebleWord.Name = "buttonSaveDataChangebleWord";
            this.buttonSaveDataChangebleWord.Size = new System.Drawing.Size(245, 28);
            this.buttonSaveDataChangebleWord.TabIndex = 11;
            this.buttonSaveDataChangebleWord.Text = "Сохранить в настраиваемой таблице";
            this.buttonSaveDataChangebleWord.UseVisualStyleBackColor = false;
            this.buttonSaveDataChangebleWord.Click += new System.EventHandler(this.buttonSaveDataChangebleWord_Click);
            // 
            // buttonGistogram
            // 
            this.buttonGistogram.BackColor = System.Drawing.SystemColors.Info;
            this.buttonGistogram.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonGistogram.Location = new System.Drawing.Point(396, 22);
            this.buttonGistogram.Name = "buttonGistogram";
            this.buttonGistogram.Size = new System.Drawing.Size(103, 28);
            this.buttonGistogram.TabIndex = 12;
            this.buttonGistogram.Text = "Гистограмма";
            this.buttonGistogram.UseVisualStyleBackColor = false;
            this.buttonGistogram.Click += new System.EventHandler(this.buttonGistogram_Click);
            // 
            // buttonSaveStorage
            // 
            this.buttonSaveStorage.BackColor = System.Drawing.SystemColors.Info;
            this.buttonSaveStorage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSaveStorage.Location = new System.Drawing.Point(6, 22);
            this.buttonSaveStorage.Name = "buttonSaveStorage";
            this.buttonSaveStorage.Size = new System.Drawing.Size(133, 28);
            this.buttonSaveStorage.TabIndex = 13;
            this.buttonSaveStorage.Text = "Сохранить данные";
            this.buttonSaveStorage.UseVisualStyleBackColor = false;
            this.buttonSaveStorage.Click += new System.EventHandler(this.buttonSaveStorage_Click_1);
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox.Controls.Add(this.buttonSaveStorage);
            this.groupBox.Controls.Add(this.buttonGistogram);
            this.groupBox.Controls.Add(this.buttonSaveDataChangebleWord);
            this.groupBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox.Location = new System.Drawing.Point(7, 188);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(508, 56);
            this.groupBox.TabIndex = 14;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Невизуальные компоненты";
            // 
            // groupBoxVisual
            // 
            this.groupBoxVisual.BackColor = System.Drawing.SystemColors.Window;
            this.groupBoxVisual.Controls.Add(this.dataGridViewModified);
            this.groupBoxVisual.Controls.Add(this.textBoxModified);
            this.groupBoxVisual.Controls.Add(this.labelCurrent2);
            this.groupBoxVisual.Controls.Add(this.buttonAdd);
            this.groupBoxVisual.Controls.Add(this.labelCurrent1);
            this.groupBoxVisual.Controls.Add(this.buttonClear);
            this.groupBoxVisual.Controls.Add(this.textBoxInputItems);
            this.groupBoxVisual.Controls.Add(this.buttonAddText);
            this.groupBoxVisual.Controls.Add(this.listBoxModified);
            this.groupBoxVisual.Location = new System.Drawing.Point(7, 6);
            this.groupBoxVisual.Name = "groupBoxVisual";
            this.groupBoxVisual.Size = new System.Drawing.Size(508, 176);
            this.groupBoxVisual.TabIndex = 15;
            this.groupBoxVisual.TabStop = false;
            this.groupBoxVisual.Text = "Визуальные компоненты";
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(520, 249);
            this.Controls.Add(this.groupBoxVisual);
            this.Controls.Add(this.groupBox);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.groupBox.ResumeLayout(false);
            this.groupBoxVisual.ResumeLayout(false);
            this.groupBoxVisual.PerformLayout();
            this.ResumeLayout(false);

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
        private ComponentsCustomUnvisual.WordTablesContext wordTablesContext;
        private ComponentsCustomUnvisual.WordTableCustom wordTableCustom;
        private Button buttonSaveDataChangebleWord;
        private Button buttonGistogram;
        private Button buttonSaveStorage;
        private GroupBox groupBox;
        private GroupBox groupBoxVisual;
        private ComponentsCustomUnvisual.WordGistagram wordGistagram;
    }
}