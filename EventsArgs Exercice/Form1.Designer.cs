namespace EventsArgs_Exercice
{
    partial class Form1
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
            this.myOrder1 = new EventsArgs_Exercice.MyOrder();
            this.SuspendLayout();
            // 
            // myOrder1
            // 
            this.myOrder1.Location = new System.Drawing.Point(176, 106);
            this.myOrder1.Name = "myOrder1";
            this.myOrder1.Size = new System.Drawing.Size(467, 168);
            this.myOrder1.TabIndex = 0;
            this.myOrder1.OrderCompleted += new System.EventHandler<EventsArgs_Exercice.MyOrder.OrderEventArgs>(this.myOrder1_OrderCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 519);
            this.Controls.Add(this.myOrder1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MyOrder myOrder1;
    }
}

