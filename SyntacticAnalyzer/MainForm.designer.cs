namespace SyntacticAnalyzer
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxContent1 = new System.Windows.Forms.TextBox();
            this.buttonSplitWords = new System.Windows.Forms.Button();
            this.textBoxContent2 = new System.Windows.Forms.TextBox();
            this.dataGridViewWords = new System.Windows.Forms.DataGridView();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWords)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxContent1
            // 
            this.textBoxContent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxContent1.Location = new System.Drawing.Point(15, 14);
            this.textBoxContent1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxContent1.Multiline = true;
            this.textBoxContent1.Name = "textBoxContent1";
            this.textBoxContent1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxContent1.Size = new System.Drawing.Size(433, 586);
            this.textBoxContent1.TabIndex = 0;
            // 
            // buttonSplitWords
            // 
            this.buttonSplitWords.Location = new System.Drawing.Point(836, 57);
            this.buttonSplitWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSplitWords.Name = "buttonSplitWords";
            this.buttonSplitWords.Size = new System.Drawing.Size(97, 28);
            this.buttonSplitWords.TabIndex = 1;
            this.buttonSplitWords.Text = "Analyzer";
            this.buttonSplitWords.UseVisualStyleBackColor = true;
            this.buttonSplitWords.Click += new System.EventHandler(this.buttonSplitWords_Click);
            // 
            // textBoxContent2
            // 
            this.textBoxContent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxContent2.Location = new System.Drawing.Point(472, 11);
            this.textBoxContent2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxContent2.Multiline = true;
            this.textBoxContent2.Name = "textBoxContent2";
            this.textBoxContent2.Size = new System.Drawing.Size(357, 589);
            this.textBoxContent2.TabIndex = 2;
            // 
            // dataGridViewWords
            // 
            this.dataGridViewWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lexema,
            this.Tipo,
            this.Id});
            this.dataGridViewWords.Location = new System.Drawing.Point(16, 622);
            this.dataGridViewWords.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewWords.Name = "dataGridViewWords";
            this.dataGridViewWords.Size = new System.Drawing.Size(815, 271);
            this.dataGridViewWords.TabIndex = 3;
            // 
            // Lexema
            // 
            this.Lexema.HeaderText = "Lexema";
            this.Lexema.Name = "Lexema";
            this.Lexema.Width = 200;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Width = 200;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 200;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(836, 11);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(97, 28);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Clear all";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 907);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.dataGridViewWords);
            this.Controls.Add(this.textBoxContent2);
            this.Controls.Add(this.buttonSplitWords);
            this.Controls.Add(this.textBoxContent1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Syntactic Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxContent1;
        private System.Windows.Forms.Button buttonSplitWords;
        private System.Windows.Forms.TextBox textBoxContent2;
        private System.Windows.Forms.DataGridView dataGridViewWords;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}

