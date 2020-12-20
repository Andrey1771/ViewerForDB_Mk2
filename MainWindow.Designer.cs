namespace Lab7
{
    partial class MainWindow
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.consoleLogTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.loginButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.namesTablesComboBox = new System.Windows.Forms.ComboBox();
            this.insertRowButton = new System.Windows.Forms.Button();
            this.updateTableButton = new System.Windows.Forms.Button();
            this.deleteSelectedRowButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 561);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(887, 0);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // changeRoleUserButton
            // 
            this.changeRoleUserButton.AutoSize = true;
            this.changeRoleUserButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.changeRoleUserButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changeRoleUserButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.changeRoleUserButton.Location = new System.Drawing.Point(179, 3);
            this.changeRoleUserButton.Name = "changeRoleUserButton";
            this.changeRoleUserButton.Size = new System.Drawing.Size(158, 43);
            this.changeRoleUserButton.TabIndex = 0;
            this.changeRoleUserButton.Text = "Пользователи";
            this.changeRoleUserButton.UseVisualStyleBackColor = false;
            this.changeRoleUserButton.Click += new System.EventHandler(this.changeRoleUser_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel7);
            this.splitContainer1.Size = new System.Drawing.Size(887, 561);
            this.splitContainer1.SplitterDistance = 340;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Size = new System.Drawing.Size(340, 561);
            this.splitContainer2.SplitterDistance = 508;
            this.splitContainer2.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.consoleLogTextBox, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.771654F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 98.22835F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(340, 508);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // consoleLogTextBox
            // 
            this.consoleLogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleLogTextBox.Location = new System.Drawing.Point(3, 12);
            this.consoleLogTextBox.Multiline = true;
            this.consoleLogTextBox.Name = "consoleLogTextBox";
            this.consoleLogTextBox.ReadOnly = true;
            this.consoleLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleLogTextBox.Size = new System.Drawing.Size(334, 493);
            this.consoleLogTextBox.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.05882F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.94118F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel2.Controls.Add(this.loginButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.changeRoleUserButton, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(340, 49);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.AutoSize = true;
            this.loginButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.loginButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loginButton.Location = new System.Drawing.Point(3, 3);
            this.loginButton.Name = "loginButton";
            this.loginButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loginButton.Size = new System.Drawing.Size(170, 43);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Вход";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 464F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(543, 561);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.namesTablesComboBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.insertRowButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.updateTableButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.deleteSelectedRowButton, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(537, 91);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // namesTablesComboBox
            // 
            this.namesTablesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.namesTablesComboBox.FormattingEnabled = true;
            this.namesTablesComboBox.Location = new System.Drawing.Point(3, 12);
            this.namesTablesComboBox.Name = "namesTablesComboBox";
            this.namesTablesComboBox.Size = new System.Drawing.Size(262, 21);
            this.namesTablesComboBox.TabIndex = 1;
            this.namesTablesComboBox.SelectedIndexChanged += new System.EventHandler(this.namesTablesComboBox_SelectedIndexChanged);
            // 
            // insertRowButton
            // 
            this.insertRowButton.AutoSize = true;
            this.insertRowButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.insertRowButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insertRowButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.insertRowButton.Location = new System.Drawing.Point(271, 3);
            this.insertRowButton.Name = "insertRowButton";
            this.insertRowButton.Size = new System.Drawing.Size(263, 39);
            this.insertRowButton.TabIndex = 1;
            this.insertRowButton.Text = "Вставить строку";
            this.insertRowButton.UseVisualStyleBackColor = false;
            this.insertRowButton.Click += new System.EventHandler(this.insertRowButton_Click);
            // 
            // updateTableButton
            // 
            this.updateTableButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.updateTableButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateTableButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.updateTableButton.Location = new System.Drawing.Point(3, 48);
            this.updateTableButton.Name = "updateTableButton";
            this.updateTableButton.Size = new System.Drawing.Size(262, 40);
            this.updateTableButton.TabIndex = 0;
            this.updateTableButton.Text = "Обновить таблицу";
            this.updateTableButton.UseVisualStyleBackColor = false;
            this.updateTableButton.Click += new System.EventHandler(this.updateTableButton_Click);
            // 
            // deleteSelectedRowButton
            // 
            this.deleteSelectedRowButton.AutoSize = true;
            this.deleteSelectedRowButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.deleteSelectedRowButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteSelectedRowButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.deleteSelectedRowButton.Location = new System.Drawing.Point(271, 48);
            this.deleteSelectedRowButton.Name = "deleteSelectedRowButton";
            this.deleteSelectedRowButton.Size = new System.Drawing.Size(263, 40);
            this.deleteSelectedRowButton.TabIndex = 0;
            this.deleteSelectedRowButton.Text = "Удалить строку";
            this.deleteSelectedRowButton.UseVisualStyleBackColor = false;
            this.deleteSelectedRowButton.Click += new System.EventHandler(this.deleteSelectedRowButton_Click_1);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 100);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(537, 458);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(531, 452);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(887, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainWindow";
            this.Text = "DatabaseViewer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button changeRoleUserButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button deleteSelectedRowButton;
        private System.Windows.Forms.Button insertRowButton;
        private System.Windows.Forms.TextBox consoleLogTextBox;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button updateTableButton;
        private System.Windows.Forms.ComboBox namesTablesComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    }
}

