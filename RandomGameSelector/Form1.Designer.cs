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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Gasha_Nut_Blue_Backed;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
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
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
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
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
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
            button1.Location = new Point(532, 579);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(83, 29);
            button1.TabIndex = 1;
            button1.Text = "Reroll";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Georgia", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(317, 295);
            label1.Name = "label1";
            label1.Size = new Size(518, 48);
            label1.TabIndex = 3;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Georgia", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(24, 9);
            label2.Name = "label2";
            label2.Size = new Size(296, 168);
            label2.TabIndex = 1;
            label2.Text = "label2";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Georgia", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(832, 9);
            label3.Name = "label3";
            label3.Size = new Size(296, 168);
            label3.TabIndex = 1;
            label3.Text = "label3";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = Properties.Resources.Back_Layer_Complete_Signs1;
            ClientSize = new Size(1152, 639);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Game Randomizer";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}