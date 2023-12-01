namespace Bekerites
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
            menuStrip1 = new MenuStrip();
            újJátékToolStripMenuItem = new ToolStripMenuItem();
            újJátékToolStripMenuItem1 = new ToolStripMenuItem();
            játékBetöltéseToolStripMenuItem = new ToolStripMenuItem();
            játékMentéseToolStripMenuItem = new ToolStripMenuItem();
            kilépésToolStripMenuItem = new ToolStripMenuItem();
            játékIndításaToolStripMenuItem = new ToolStripMenuItem();
            kisPálya6X6ToolStripMenuItem = new ToolStripMenuItem();
            közepesPálya8X8ToolStripMenuItem = new ToolStripMenuItem();
            nagyPálya10X10ToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { újJátékToolStripMenuItem, játékIndításaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(835, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // újJátékToolStripMenuItem
            // 
            újJátékToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { újJátékToolStripMenuItem1, játékBetöltéseToolStripMenuItem, játékMentéseToolStripMenuItem, kilépésToolStripMenuItem });
            újJátékToolStripMenuItem.Name = "újJátékToolStripMenuItem";
            újJátékToolStripMenuItem.Size = new Size(37, 20);
            újJátékToolStripMenuItem.Text = "File";
            újJátékToolStripMenuItem.Click += újJátékToolStripMenuItem_Click;
            // 
            // újJátékToolStripMenuItem1
            // 
            újJátékToolStripMenuItem1.Name = "újJátékToolStripMenuItem1";
            újJátékToolStripMenuItem1.Size = new Size(151, 22);
            újJátékToolStripMenuItem1.Text = "Új játék";
            újJátékToolStripMenuItem1.Click += újJátékToolStripMenuItem1_Click;
            // 
            // játékBetöltéseToolStripMenuItem
            // 
            játékBetöltéseToolStripMenuItem.Name = "játékBetöltéseToolStripMenuItem";
            játékBetöltéseToolStripMenuItem.Size = new Size(151, 22);
            játékBetöltéseToolStripMenuItem.Text = "Játék betöltése";
            játékBetöltéseToolStripMenuItem.Click += játékBetöltéseToolStripMenuItem_Click_1;
            // 
            // játékMentéseToolStripMenuItem
            // 
            játékMentéseToolStripMenuItem.Name = "játékMentéseToolStripMenuItem";
            játékMentéseToolStripMenuItem.Size = new Size(151, 22);
            játékMentéseToolStripMenuItem.Text = "Játék mentése";
            játékMentéseToolStripMenuItem.Click += játékMentéseToolStripMenuItem_Click_1;
            // 
            // kilépésToolStripMenuItem
            // 
            kilépésToolStripMenuItem.Name = "kilépésToolStripMenuItem";
            kilépésToolStripMenuItem.Size = new Size(151, 22);
            kilépésToolStripMenuItem.Text = "Kilépés";
            kilépésToolStripMenuItem.Click += kilépésToolStripMenuItem_Click_1;
            // 
            // játékIndításaToolStripMenuItem
            // 
            játékIndításaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kisPálya6X6ToolStripMenuItem, közepesPálya8X8ToolStripMenuItem, nagyPálya10X10ToolStripMenuItem });
            játékIndításaToolStripMenuItem.Name = "játékIndításaToolStripMenuItem";
            játékIndításaToolStripMenuItem.Size = new Size(89, 20);
            játékIndításaToolStripMenuItem.Text = "Játék indítása";
            játékIndításaToolStripMenuItem.Click += játékIndításaToolStripMenuItem_Click;
            // 
            // kisPálya6X6ToolStripMenuItem
            // 
            kisPálya6X6ToolStripMenuItem.Name = "kisPálya6X6ToolStripMenuItem";
            kisPálya6X6ToolStripMenuItem.Size = new Size(183, 22);
            kisPálya6X6ToolStripMenuItem.Text = "Kis pálya (6 x 6)";
            kisPálya6X6ToolStripMenuItem.Click += kisPálya6X6ToolStripMenuItem_Click;
            // 
            // közepesPálya8X8ToolStripMenuItem
            // 
            közepesPálya8X8ToolStripMenuItem.Name = "közepesPálya8X8ToolStripMenuItem";
            közepesPálya8X8ToolStripMenuItem.Size = new Size(183, 22);
            közepesPálya8X8ToolStripMenuItem.Text = "Közepes pálya (8 x 8)";
            közepesPálya8X8ToolStripMenuItem.Click += közepesPálya8X8ToolStripMenuItem_Click_1;
            // 
            // nagyPálya10X10ToolStripMenuItem
            // 
            nagyPálya10X10ToolStripMenuItem.Name = "nagyPálya10X10ToolStripMenuItem";
            nagyPálya10X10ToolStripMenuItem.Size = new Size(183, 22);
            nagyPálya10X10ToolStripMenuItem.Text = "Nagy pálya (10 x 10)";
            nagyPálya10X10ToolStripMenuItem.Click += nagyPálya10X10ToolStripMenuItem_Click_1;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(650, 336);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(650, 369);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(669, 41);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(669, 82);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(669, 132);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(835, 566);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Bekerites";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem újJátékToolStripMenuItem;
        private ToolStripMenuItem játékIndításaToolStripMenuItem;
        private ToolStripMenuItem újJátékToolStripMenuItem1;
        private ToolStripMenuItem játékBetöltéseToolStripMenuItem;
        private ToolStripMenuItem játékMentéseToolStripMenuItem;
        private ToolStripMenuItem kilépésToolStripMenuItem;
        private ToolStripMenuItem kisPálya6X6ToolStripMenuItem;
        private ToolStripMenuItem közepesPálya8X8ToolStripMenuItem;
        private ToolStripMenuItem nagyPálya10X10ToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}