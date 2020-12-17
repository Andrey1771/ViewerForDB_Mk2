namespace Lab7_Bd_Mk2_Entity
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.changeRoleUserButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.consoleLogTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.loginButton = new System.Windows.Forms.Button();
            this.nameUserTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.insertRowButton = new System.Windows.Forms.Button();
            this.deleteSelectedRowButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.updateTableButton = new System.Windows.Forms.Button();
            this.namesTablesComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 690);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1183, 0);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // changeRoleUserButton
            // 
            this.changeRoleUserButton.AutoSize = true;
            this.changeRoleUserButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.changeRoleUserButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.changeRoleUserButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.changeRoleUserButton.Location = new System.Drawing.Point(4, 4);
            this.changeRoleUserButton.Margin = new System.Windows.Forms.Padding(4);
            this.changeRoleUserButton.Name = "changeRoleUserButton";
            this.changeRoleUserButton.Size = new System.Drawing.Size(134, 47);
            this.changeRoleUserButton.TabIndex = 0;
            this.changeRoleUserButton.Text = "Пользователи";
            this.changeRoleUserButton.UseVisualStyleBackColor = false;
            this.changeRoleUserButton.Click += new System.EventHandler(this.changeRoleUser_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(1183, 690);
            this.splitContainer1.SplitterDistance = 1028;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 44);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel6);
            this.splitContainer2.Size = new System.Drawing.Size(1028, 646);
            this.splitContainer2.SplitterDistance = 513;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1028, 513);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.consoleLogTextBox, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1028, 128);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // consoleLogTextBox
            // 
            this.consoleLogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleLogTextBox.Location = new System.Drawing.Point(4, 4);
            this.consoleLogTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.consoleLogTextBox.Multiline = true;
            this.consoleLogTextBox.Name = "consoleLogTextBox";
            this.consoleLogTextBox.ReadOnly = true;
            this.consoleLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleLogTextBox.Size = new System.Drawing.Size(1020, 120);
            this.consoleLogTextBox.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.17509F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.824903F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1028, 44);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.62745F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.37255F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 212F));
            this.tableLayoutPanel2.Controls.Add(this.loginButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.nameUserTextBox, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(203, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(719, 36);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginButton.AutoSize = true;
            this.loginButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.loginButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loginButton.Location = new System.Drawing.Point(4, 4);
            this.loginButton.Margin = new System.Windows.Forms.Padding(4);
            this.loginButton.Name = "loginButton";
            this.loginButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loginButton.Size = new System.Drawing.Size(137, 28);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Вход/Регистрация";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // nameUserTextBox
            // 
            this.nameUserTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nameUserTextBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.nameUserTextBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.nameUserTextBox.Location = new System.Drawing.Point(520, 7);
            this.nameUserTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameUserTextBox.Name = "nameUserTextBox";
            this.nameUserTextBox.ReadOnly = true;
            this.nameUserTextBox.Size = new System.Drawing.Size(185, 22);
            this.nameUserTextBox.TabIndex = 2;
            this.nameUserTextBox.Text = "Имя пользователя";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(221, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Подключенный пользователь:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1024, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 36);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.tableLayoutPanel4);
            this.flowLayoutPanel2.Controls.Add(this.tableLayoutPanel5);
            this.flowLayoutPanel2.Controls.Add(this.updateTableButton);
            this.flowLayoutPanel2.Controls.Add(this.namesTablesComboBox);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(150, 690);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.insertRowButton, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.deleteSelectedRowButton, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(141, 98);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // insertRowButton
            // 
            this.insertRowButton.AutoSize = true;
            this.insertRowButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.insertRowButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.insertRowButton.Location = new System.Drawing.Point(4, 53);
            this.insertRowButton.Margin = new System.Windows.Forms.Padding(4);
            this.insertRowButton.Name = "insertRowButton";
            this.insertRowButton.Size = new System.Drawing.Size(133, 41);
            this.insertRowButton.TabIndex = 1;
            this.insertRowButton.Text = "Вставить строку";
            this.insertRowButton.UseVisualStyleBackColor = false;
            this.insertRowButton.Click += new System.EventHandler(this.insertRowButton_Click);
            // 
            // deleteSelectedRowButton
            // 
            this.deleteSelectedRowButton.AutoSize = true;
            this.deleteSelectedRowButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.deleteSelectedRowButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.deleteSelectedRowButton.Location = new System.Drawing.Point(4, 4);
            this.deleteSelectedRowButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteSelectedRowButton.Name = "deleteSelectedRowButton";
            this.deleteSelectedRowButton.Size = new System.Drawing.Size(133, 39);
            this.deleteSelectedRowButton.TabIndex = 0;
            this.deleteSelectedRowButton.Text = "Удалить строку";
            this.deleteSelectedRowButton.UseVisualStyleBackColor = false;
            this.deleteSelectedRowButton.Click += new System.EventHandler(this.deleteSelectedRowButton_Click_1);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.39046F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.60954F));
            this.tableLayoutPanel5.Controls.Add(this.changeRoleUserButton, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 110);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(142, 55);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // updateTableButton
            // 
            this.updateTableButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.updateTableButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.updateTableButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.updateTableButton.Location = new System.Drawing.Point(4, 173);
            this.updateTableButton.Margin = new System.Windows.Forms.Padding(4);
            this.updateTableButton.Name = "updateTableButton";
            this.updateTableButton.Size = new System.Drawing.Size(137, 32);
            this.updateTableButton.TabIndex = 0;
            this.updateTableButton.Text = "Обновить таблицу";
            this.updateTableButton.UseVisualStyleBackColor = false;
            this.updateTableButton.Click += new System.EventHandler(this.updateTableButton_Click);
            // 
            // namesTablesComboBox
            // 
            this.namesTablesComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.namesTablesComboBox.FormattingEnabled = true;
            this.namesTablesComboBox.Location = new System.Drawing.Point(4, 213);
            this.namesTablesComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.namesTablesComboBox.Name = "namesTablesComboBox";
            this.namesTablesComboBox.Size = new System.Drawing.Size(133, 24);
            this.namesTablesComboBox.TabIndex = 1;
            this.namesTablesComboBox.SelectedIndexChanged += new System.EventHandler(this.namesTablesComboBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1183, 690);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "DatabaseViewer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button changeRoleUserButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button deleteSelectedRowButton;
        private System.Windows.Forms.Button insertRowButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox consoleLogTextBox;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox nameUserTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button updateTableButton;
        private System.Windows.Forms.ComboBox namesTablesComboBox;
    }
}

