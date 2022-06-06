
namespace KaFruit
{
    partial class main
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
            this.questionBox = new System.Windows.Forms.TextBox();
            this.nextBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.A1Checkbox = new System.Windows.Forms.CheckBox();
            this.A2Checkbox = new System.Windows.Forms.CheckBox();
            this.A3Checkbox = new System.Windows.Forms.CheckBox();
            this.A4Checkbox = new System.Windows.Forms.CheckBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.counterText = new System.Windows.Forms.Label();
            this.a1 = new System.Windows.Forms.TextBox();
            this.a2 = new System.Windows.Forms.TextBox();
            this.a3 = new System.Windows.Forms.TextBox();
            this.a4 = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.roomLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // questionBox
            // 
            this.questionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionBox.Location = new System.Drawing.Point(325, 25);
            this.questionBox.Multiline = true;
            this.questionBox.Name = "questionBox";
            this.questionBox.Size = new System.Drawing.Size(413, 53);
            this.questionBox.TabIndex = 0;
            this.questionBox.TextChanged += new System.EventHandler(this.questionBox_TextChanged);
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(986, 546);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 23);
            this.nextBtn.TabIndex = 6;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(44, 546);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 7;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // A1Checkbox
            // 
            this.A1Checkbox.AutoSize = true;
            this.A1Checkbox.Location = new System.Drawing.Point(325, 228);
            this.A1Checkbox.Name = "A1Checkbox";
            this.A1Checkbox.Size = new System.Drawing.Size(15, 14);
            this.A1Checkbox.TabIndex = 8;
            this.A1Checkbox.UseVisualStyleBackColor = true;
            // 
            // A2Checkbox
            // 
            this.A2Checkbox.AutoSize = true;
            this.A2Checkbox.Location = new System.Drawing.Point(311, 385);
            this.A2Checkbox.Name = "A2Checkbox";
            this.A2Checkbox.Size = new System.Drawing.Size(15, 14);
            this.A2Checkbox.TabIndex = 9;
            this.A2Checkbox.UseVisualStyleBackColor = true;
            // 
            // A3Checkbox
            // 
            this.A3Checkbox.AutoSize = true;
            this.A3Checkbox.Location = new System.Drawing.Point(1077, 228);
            this.A3Checkbox.Name = "A3Checkbox";
            this.A3Checkbox.Size = new System.Drawing.Size(15, 14);
            this.A3Checkbox.TabIndex = 10;
            this.A3Checkbox.UseVisualStyleBackColor = true;
            // 
            // A4Checkbox
            // 
            this.A4Checkbox.AutoSize = true;
            this.A4Checkbox.Location = new System.Drawing.Point(1077, 385);
            this.A4Checkbox.Name = "A4Checkbox";
            this.A4Checkbox.Size = new System.Drawing.Size(15, 14);
            this.A4Checkbox.TabIndex = 11;
            this.A4Checkbox.UseVisualStyleBackColor = true;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(498, 548);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(123, 42);
            this.SaveBtn.TabIndex = 12;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // counterText
            // 
            this.counterText.AutoSize = true;
            this.counterText.Location = new System.Drawing.Point(13, 13);
            this.counterText.Name = "counterText";
            this.counterText.Size = new System.Drawing.Size(24, 13);
            this.counterText.TabIndex = 13;
            this.counterText.Text = "1/1";
            this.counterText.Click += new System.EventHandler(this.counterText_Click);
            // 
            // a1
            // 
            this.a1.Location = new System.Drawing.Point(16, 203);
            this.a1.Multiline = true;
            this.a1.Name = "a1";
            this.a1.Size = new System.Drawing.Size(252, 39);
            this.a1.TabIndex = 14;
            // 
            // a2
            // 
            this.a2.Location = new System.Drawing.Point(12, 360);
            this.a2.Multiline = true;
            this.a2.Name = "a2";
            this.a2.Size = new System.Drawing.Size(252, 39);
            this.a2.TabIndex = 15;
            // 
            // a3
            // 
            this.a3.Location = new System.Drawing.Point(744, 203);
            this.a3.Multiline = true;
            this.a3.Name = "a3";
            this.a3.Size = new System.Drawing.Size(252, 39);
            this.a3.TabIndex = 16;
            // 
            // a4
            // 
            this.a4.Location = new System.Drawing.Point(744, 360);
            this.a4.Multiline = true;
            this.a4.Name = "a4";
            this.a4.Size = new System.Drawing.Size(253, 39);
            this.a4.TabIndex = 17;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(498, 498);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(123, 44);
            this.startBtn.TabIndex = 18;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // roomLbl
            // 
            this.roomLbl.AutoSize = true;
            this.roomLbl.Location = new System.Drawing.Point(871, 25);
            this.roomLbl.Name = "roomLbl";
            this.roomLbl.Size = new System.Drawing.Size(35, 13);
            this.roomLbl.TabIndex = 19;
            this.roomLbl.Text = "label1";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 602);
            this.Controls.Add(this.roomLbl);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.a4);
            this.Controls.Add(this.a3);
            this.Controls.Add(this.a2);
            this.Controls.Add(this.a1);
            this.Controls.Add(this.counterText);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.A4Checkbox);
            this.Controls.Add(this.A3Checkbox);
            this.Controls.Add(this.A2Checkbox);
            this.Controls.Add(this.A1Checkbox);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.questionBox);
            this.Name = "main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox questionBox;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.CheckBox A1Checkbox;
        private System.Windows.Forms.CheckBox A2Checkbox;
        private System.Windows.Forms.CheckBox A3Checkbox;
        private System.Windows.Forms.CheckBox A4Checkbox;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label counterText;
        private System.Windows.Forms.TextBox a1;
        private System.Windows.Forms.TextBox a2;
        private System.Windows.Forms.TextBox a3;
        private System.Windows.Forms.TextBox a4;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Label roomLbl;
    }
}

