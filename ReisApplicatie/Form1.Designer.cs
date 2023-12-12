namespace ReisApplicatie
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            listBoxLand = new ListBox();
            listBoxHotel = new ListBox();
            listBoxVlucht = new ListBox();
            buttonBereken = new Button();
            textBoxNacht = new TextBox();
            labelNacht = new Label();
            labelTotaal = new Label();
            SuspendLayout();
            // 
            // listBoxLand
            // 
            listBoxLand.FormattingEnabled = true;
            listBoxLand.ItemHeight = 20;
            listBoxLand.Location = new Point(60, 135);
            listBoxLand.Name = "listBoxLand";
            listBoxLand.Size = new Size(150, 124);
            listBoxLand.TabIndex = 1;
            listBoxLand.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // listBoxHotel
            // 
            listBoxHotel.FormattingEnabled = true;
            listBoxHotel.ItemHeight = 20;
            listBoxHotel.Location = new Point(404, 24);
            listBoxHotel.Name = "listBoxHotel";
            listBoxHotel.Size = new Size(384, 104);
            listBoxHotel.TabIndex = 2;
            // 
            // listBoxVlucht
            // 
            listBoxVlucht.FormattingEnabled = true;
            listBoxVlucht.ItemHeight = 20;
            listBoxVlucht.Location = new Point(404, 261);
            listBoxVlucht.Name = "listBoxVlucht";
            listBoxVlucht.Size = new Size(384, 104);
            listBoxVlucht.TabIndex = 4;
            // 
            // buttonBereken
            // 
            buttonBereken.Location = new Point(365, 403);
            buttonBereken.Name = "buttonBereken";
            buttonBereken.Size = new Size(94, 29);
            buttonBereken.TabIndex = 5;
            buttonBereken.Text = "Bereken";
            buttonBereken.UseVisualStyleBackColor = true;
            buttonBereken.Click += buttonBereken_Click;
            // 
            // textBoxNacht
            // 
            textBoxNacht.Location = new Point(202, 403);
            textBoxNacht.Name = "textBoxNacht";
            textBoxNacht.Size = new Size(125, 27);
            textBoxNacht.TabIndex = 6;
            // 
            // labelNacht
            // 
            labelNacht.AutoSize = true;
            labelNacht.Location = new Point(81, 406);
            labelNacht.Name = "labelNacht";
            labelNacht.Size = new Size(115, 20);
            labelNacht.TabIndex = 7;
            labelNacht.Text = "Aantal  nachten:";
            // 
            // labelTotaal
            // 
            labelTotaal.AutoSize = true;
            labelTotaal.Location = new Point(526, 407);
            labelTotaal.Name = "labelTotaal";
            labelTotaal.Size = new Size(81, 20);
            labelTotaal.TabIndex = 8;
            labelTotaal.Text = "Totale Prijs";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 450);
            Controls.Add(labelTotaal);
            Controls.Add(labelNacht);
            Controls.Add(textBoxNacht);
            Controls.Add(buttonBereken);
            Controls.Add(listBoxVlucht);
            Controls.Add(listBoxHotel);
            Controls.Add(listBoxLand);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "ReisApplicatie";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxLand;
        private ListBox listBoxHotel;
        private ListBox listBoxVlucht;
        private Button buttonBereken;
        private TextBox textBoxNacht;
        private Label labelNacht;
        private Label labelTotaal;
    }
}