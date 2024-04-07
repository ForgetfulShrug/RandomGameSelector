namespace RandomGameSelector
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
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Gasha_Nut_Blue_Backed;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.MaximumSize = new Size(384, 640);
            pictureBox1.MinimumSize = new Size(384, 640);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(384, 640);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox3.Image = Properties.Resources.Gasha_Nut_Green_Backed;
            pictureBox3.Location = new Point(768, 0);
            pictureBox3.MaximumSize = new Size(384, 640);
            pictureBox3.MinimumSize = new Size(384, 640);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(384, 640);
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = Properties.Resources.Gasha_Nut_Red_Backed;
            pictureBox2.Location = new Point(384, 128);
            pictureBox2.MaximumSize = new Size(384, 640);
            pictureBox2.MinimumSize = new Size(384, 640);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(384, 640);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button1.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(528, 469);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Reroll";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Georgia", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(87, 0);
            label1.Name = "label1";
            label1.Size = new Size(978, 640);
            label1.TabIndex = 3;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Georgia", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.MaximumSize = new Size(330, 0);
            label2.Name = "label2";
            label2.Size = new Size(87, 31);
            label2.TabIndex = 1;
            label2.Text = "label2";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Dock = DockStyle.Right;
            label3.Font = new Font("Georgia", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(1065, 0);
            label3.MaximumSize = new Size(330, 0);
            label3.Name = "label3";
            label3.Size = new Size(87, 31);
            label3.TabIndex = 1;
            label3.Text = "label3";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = Properties.Resources.Back_Layer_Complete_Signs1;
            pictureBox4.Location = new Point(0, 0);
            pictureBox4.MaximumSize = new Size(1152, 640);
            pictureBox4.MinimumSize = new Size(1152, 640);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(1152, 640);
            pictureBox4.TabIndex = 12;
            pictureBox4.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = Properties.Resources.Back_Layer_Complete_Signs1;
            ClientSize = new Size(1152, 640);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(pictureBox4);
            Name = "Form1";
            Text = "Game Randomizer";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox4;
    }
}