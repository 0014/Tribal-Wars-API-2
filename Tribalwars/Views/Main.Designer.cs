namespace Tribalwars.Views
{
    partial class Main
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
            this.gridAttacks = new System.Windows.Forms.DataGridView();
            this.tmrAttackCheck = new System.Windows.Forms.Timer(this.components);
            this.txtX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chckAutomation = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttacks)).BeginInit();
            this.SuspendLayout();
            // 
            // gridAttacks
            // 
            this.gridAttacks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAttacks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridAttacks.Location = new System.Drawing.Point(0, 91);
            this.gridAttacks.Name = "gridAttacks";
            this.gridAttacks.Size = new System.Drawing.Size(784, 670);
            this.gridAttacks.TabIndex = 0;
            // 
            // tmrAttackCheck
            // 
            this.tmrAttackCheck.Enabled = true;
            this.tmrAttackCheck.Interval = 20000;
            this.tmrAttackCheck.Tick += new System.EventHandler(this.tmrAttackCheck_Tick);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(77, 39);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(100, 20);
            this.txtX.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add New Village:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(201, 37);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "X";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(77, 65);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(100, 20);
            this.txtY.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y";
            // 
            // chckAutomation
            // 
            this.chckAutomation.AutoSize = true;
            this.chckAutomation.Checked = true;
            this.chckAutomation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckAutomation.Location = new System.Drawing.Point(201, 67);
            this.chckAutomation.Name = "chckAutomation";
            this.chckAutomation.Size = new System.Drawing.Size(96, 17);
            this.chckAutomation.TabIndex = 7;
            this.chckAutomation.Text = "Automation On";
            this.chckAutomation.UseVisualStyleBackColor = true;
            this.chckAutomation.CheckedChanged += new System.EventHandler(this.chckAutomation_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.chckAutomation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.gridAttacks);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.gridAttacks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridAttacks;
        private System.Windows.Forms.Timer tmrAttackCheck;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chckAutomation;
    }
}

