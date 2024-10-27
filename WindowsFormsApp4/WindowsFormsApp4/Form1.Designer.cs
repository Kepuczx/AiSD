namespace WindowsFormsApp4
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxElements = new System.Windows.Forms.ListBox();
            this.buttonAddFirst = new System.Windows.Forms.Button();
            this.buttonAddLast = new System.Windows.Forms.Button();
            this.buttonRemoveFirst = new System.Windows.Forms.Button();
            this.buttonRemoveLast = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxElements
            // 
            this.listBoxElements.FormattingEnabled = true;
            this.listBoxElements.Location = new System.Drawing.Point(29, 89);
            this.listBoxElements.Name = "listBoxElements";
            this.listBoxElements.Size = new System.Drawing.Size(526, 342);
            this.listBoxElements.TabIndex = 0;
            // 
            // buttonAddFirst
            // 
            this.buttonAddFirst.Location = new System.Drawing.Point(634, 89);
            this.buttonAddFirst.Name = "buttonAddFirst";
            this.buttonAddFirst.Size = new System.Drawing.Size(87, 23);
            this.buttonAddFirst.TabIndex = 1;
            this.buttonAddFirst.Text = "Add first";
            this.buttonAddFirst.UseVisualStyleBackColor = true;
            this.buttonAddFirst.Click += new System.EventHandler(this.buttonAddFirst_Click);
            // 
            // buttonAddLast
            // 
            this.buttonAddLast.Location = new System.Drawing.Point(634, 130);
            this.buttonAddLast.Name = "buttonAddLast";
            this.buttonAddLast.Size = new System.Drawing.Size(87, 23);
            this.buttonAddLast.TabIndex = 2;
            this.buttonAddLast.Text = "Add last";
            this.buttonAddLast.UseVisualStyleBackColor = true;
            this.buttonAddLast.Click += new System.EventHandler(this.buttonAddLast_Click);
            // 
            // buttonRemoveFirst
            // 
            this.buttonRemoveFirst.Location = new System.Drawing.Point(634, 369);
            this.buttonRemoveFirst.Name = "buttonRemoveFirst";
            this.buttonRemoveFirst.Size = new System.Drawing.Size(87, 23);
            this.buttonRemoveFirst.TabIndex = 3;
            this.buttonRemoveFirst.Text = "Remove First";
            this.buttonRemoveFirst.UseVisualStyleBackColor = true;
            this.buttonRemoveFirst.Click += new System.EventHandler(this.buttonRemoveFirst_Click);
            // 
            // buttonRemoveLast
            // 
            this.buttonRemoveLast.Location = new System.Drawing.Point(634, 408);
            this.buttonRemoveLast.Name = "buttonRemoveLast";
            this.buttonRemoveLast.Size = new System.Drawing.Size(87, 23);
            this.buttonRemoveLast.TabIndex = 4;
            this.buttonRemoveLast.Text = "Remove Last";
            this.buttonRemoveLast.UseVisualStyleBackColor = true;
            this.buttonRemoveLast.Click += new System.EventHandler(this.buttonRemoveLast_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRemoveLast);
            this.Controls.Add(this.buttonRemoveFirst);
            this.Controls.Add(this.buttonAddLast);
            this.Controls.Add(this.buttonAddFirst);
            this.Controls.Add(this.listBoxElements);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxElements;
        private System.Windows.Forms.Button buttonAddFirst;
        private System.Windows.Forms.Button buttonAddLast;
        private System.Windows.Forms.Button buttonRemoveFirst;
        private System.Windows.Forms.Button buttonRemoveLast;
        private System.Windows.Forms.Label label1;
    }
}

