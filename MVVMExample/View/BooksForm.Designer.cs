namespace MVVMExample.View
{
    partial class BooksForm
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
            this.gvBooks = new System.Windows.Forms.DataGridView();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.bookViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gvBooks
            // 
            this.gvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBooks.Location = new System.Drawing.Point(9, 13);
            this.gvBooks.Name = "gvBooks";
            this.gvBooks.Size = new System.Drawing.Size(388, 208);
            this.gvBooks.TabIndex = 3;
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(322, 227);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(75, 23);
            this.btnAddBook.TabIndex = 2;
            this.btnAddBook.Text = "Add Book";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // bookViewModelBindingSource
            // 
            this.bookViewModelBindingSource.DataSource = typeof(MVVMExample.ViewModel.BookViewModel);
            // 
            // BooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 262);
            this.Controls.Add(this.gvBooks);
            this.Controls.Add(this.btnAddBook);
            this.Name = "BooksForm";
            this.Text = "Books";
            ((System.ComponentModel.ISupportInitialize)(this.gvBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvBooks;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.BindingSource bookViewModelBindingSource;
    }
}