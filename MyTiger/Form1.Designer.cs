namespace MyTiger
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
            petImage = new PictureBox();
            lblHunger = new Label();
            lblHappiness = new Label();
            lblEnergy = new Label();
            btnFeed = new Button();
            btnPlay = new Button();
            Sleep = new Button();
            btnHighFive = new Button();
            btnDelete = new Button();
            btnParty = new Button();
            lblStage = new Label();
            ((System.ComponentModel.ISupportInitialize)petImage).BeginInit();
            SuspendLayout();
            // 
            // petImage
            // 
            petImage.Location = new Point(12, 12);
            petImage.Name = "petImage";
            petImage.Size = new Size(569, 411);
            petImage.TabIndex = 0;
            petImage.TabStop = false;
            // 
            // lblHunger
            // 
            lblHunger.Location = new Point(602, 22);
            lblHunger.Name = "lblHunger";
            lblHunger.Size = new Size(180, 20);
            lblHunger.TabIndex = 1;
            lblHunger.Text = "Hunger:";
            // 
            // lblHappiness
            // 
            lblHappiness.Location = new Point(602, 77);
            lblHappiness.Name = "lblHappiness";
            lblHappiness.Size = new Size(180, 20);
            lblHappiness.TabIndex = 2;
            lblHappiness.Text = "Happiness:";
            // 
            // lblEnergy
            // 
            lblEnergy.Location = new Point(602, 135);
            lblEnergy.Name = "lblEnergy";
            lblEnergy.Size = new Size(180, 20);
            lblEnergy.TabIndex = 3;
            lblEnergy.Text = "Energy:";
            // 
            // btnFeed
            // 
            btnFeed.Location = new Point(684, 45);
            btnFeed.Name = "btnFeed";
            btnFeed.Size = new Size(94, 29);
            btnFeed.TabIndex = 4;
            btnFeed.Text = "Feed";
            btnFeed.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(684, 100);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(94, 29);
            btnPlay.TabIndex = 5;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            // 
            // Sleep
            // 
            Sleep.Location = new Point(684, 156);
            Sleep.Name = "Sleep";
            Sleep.Size = new Size(94, 29);
            Sleep.TabIndex = 6;
            Sleep.Text = "Sleep";
            Sleep.UseVisualStyleBackColor = true;
            //
            // btnHighFive
            //
            btnHighFive.Location = new Point(684, 200);
            btnHighFive.Name = "btnHighFive";
            btnHighFive.Size = new Size(94, 29);
            btnHighFive.TabIndex = 8;
            btnHighFive.Text = "High Five!";
            btnHighFive.UseVisualStyleBackColor = true;
            //
            // btnDelete
            //
            btnDelete.Location = new Point(684, 310);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Release Pet";
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.ForeColor = Color.White;
            btnDelete.UseVisualStyleBackColor = false;
            //
            // btnParty
            //
            btnParty.Location = new Point(684, 355);
            btnParty.Name = "btnParty";
            btnParty.Size = new Size(94, 29);
            btnParty.TabIndex = 10;
            btnParty.Text = "Pet Party!";
            btnParty.UseVisualStyleBackColor = true;
            //
            // lblStage
            //
            lblStage.Location = new Point(602, 255);
            lblStage.Name = "lblStage";
            lblStage.Size = new Size(180, 20);
            lblStage.TabIndex = 7;
            lblStage.Text = "Age Stage:";
            lblStage.TextAlign = ContentAlignment.TopCenter;
            lblStage.Click += lblStage_Click;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStage);
            Controls.Add(btnHighFive);
            Controls.Add(btnDelete);
            Controls.Add(btnParty);
            Controls.Add(Sleep);
            Controls.Add(btnPlay);
            Controls.Add(btnFeed);
            Controls.Add(lblEnergy);
            Controls.Add(lblHappiness);
            Controls.Add(lblHunger);
            Controls.Add(petImage);
            Name = "Form1";
            Text = "My Pet Tiger";
            ((System.ComponentModel.ISupportInitialize)petImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox petImage;
        private Label lblHunger;
        private Label lblHappiness;
        private Label lblEnergy;
        private Button btnFeed;
        private Button btnPlay;
        private Button Sleep;
        private Button btnHighFive;
        private Button btnDelete;
        private Button btnParty;
        private Label lblStage;
    }
}
