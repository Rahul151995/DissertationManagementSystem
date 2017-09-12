using System;

namespace Faculty
{
    partial class Evaulation
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.werror = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Roll_comboBox = new System.Windows.Forms.ComboBox();
            this.Remarks_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.total_textview = new System.Windows.Forms.Label();
            this.class_textview = new System.Windows.Forms.Label();
            this.name_textview = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Presentation_textbox = new System.Windows.Forms.TextBox();
            this.Technical_textbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Report_textbox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.evaluated_list = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.werror)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Submit ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(516, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "View";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // werror
            // 
            this.werror.ContainerControl = this;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(298, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "MARKS EVALUATION";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(58, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(927, 297);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(179, 243);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.Roll_comboBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Remarks_textbox, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.total_textview, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.class_textview, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.name_textview, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Presentation_textbox, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.Technical_textbox, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.Report_textbox, 3, 1);
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 71);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.65854F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.34146F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(845, 149);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // Roll_comboBox
            // 
            this.Roll_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Roll_comboBox.FormattingEnabled = true;
            this.Roll_comboBox.Location = new System.Drawing.Point(5, 103);
            this.Roll_comboBox.Name = "Roll_comboBox";
            this.Roll_comboBox.Size = new System.Drawing.Size(131, 24);
            this.Roll_comboBox.TabIndex = 10;
            this.Roll_comboBox.Text = "Select Roll No.";
            this.Roll_comboBox.Leave += new System.EventHandler(this.Roll_textbox_Leave);
            // 
            // Remarks_textbox
            // 
            this.Remarks_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Remarks_textbox.Location = new System.Drawing.Point(684, 83);
            this.Remarks_textbox.Multiline = true;
            this.Remarks_textbox.Name = "Remarks_textbox";
            this.Remarks_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Remarks_textbox.Size = new System.Drawing.Size(156, 60);
            this.Remarks_textbox.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Remarks";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // total_textview
            // 
            this.total_textview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.total_textview.AutoSize = true;
            this.total_textview.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.total_textview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.total_textview.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.total_textview.Location = new System.Drawing.Point(624, 104);
            this.total_textview.Name = "total_textview";
            this.total_textview.Size = new System.Drawing.Size(52, 18);
            this.total_textview.TabIndex = 17;
            this.total_textview.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.total_textview.Leave += new System.EventHandler(this.total_textview_Leave);
            // 
            // class_textview
            // 
            this.class_textview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.class_textview.AutoSize = true;
            this.class_textview.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.class_textview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.class_textview.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.class_textview.Location = new System.Drawing.Point(255, 104);
            this.class_textview.Name = "class_textview";
            this.class_textview.Size = new System.Drawing.Size(93, 18);
            this.class_textview.TabIndex = 16;
            this.class_textview.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // name_textview
            // 
            this.name_textview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.name_textview.AutoSize = true;
            this.name_textview.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.name_textview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.name_textview.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.name_textview.Location = new System.Drawing.Point(144, 104);
            this.name_textview.Name = "name_textview";
            this.name_textview.Size = new System.Drawing.Size(103, 18);
            this.name_textview.TabIndex = 15;
            this.name_textview.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(255, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 32);
            this.label11.TabIndex = 3;
            this.label11.Text = "Class And Stream";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Presentation_textbox
            // 
            this.Presentation_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Presentation_textbox.Location = new System.Drawing.Point(520, 102);
            this.Presentation_textbox.Name = "Presentation_textbox";
            this.Presentation_textbox.Size = new System.Drawing.Size(96, 22);
            this.Presentation_textbox.TabIndex = 14;
            this.Presentation_textbox.Leave += new System.EventHandler(this.Presentation_textbox_Leave);
            // 
            // Technical_textbox
            // 
            this.Technical_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Technical_textbox.Location = new System.Drawing.Point(435, 102);
            this.Technical_textbox.Name = "Technical_textbox";
            this.Technical_textbox.Size = new System.Drawing.Size(77, 22);
            this.Technical_textbox.TabIndex = 13;
            this.Technical_textbox.Leave += new System.EventHandler(this.Technical_textbox_Leave);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(624, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 32);
            this.label7.TabIndex = 7;
            this.label7.Text = "Total (30)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(520, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 32);
            this.label8.TabIndex = 6;
            this.label8.Text = "Presentation(10)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(356, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 48);
            this.label10.TabIndex = 4;
            this.label10.Text = "Report Writing (10)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(144, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Name";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "Roll No.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(435, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 48);
            this.label9.TabIndex = 5;
            this.label9.Text = "Technical Content (10)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Report_textbox
            // 
            this.Report_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Report_textbox.Location = new System.Drawing.Point(356, 102);
            this.Report_textbox.Name = "Report_textbox";
            this.Report_textbox.Size = new System.Drawing.Size(71, 22);
            this.Report_textbox.TabIndex = 12;
            this.Report_textbox.Leave += new System.EventHandler(this.Report_textbox_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.evaluated_list);
            this.groupBox2.Location = new System.Drawing.Point(58, 328);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(927, 352);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(314, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "MARKS SHEET";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(381, 323);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Print Marks";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // evaluated_list
            // 
            this.evaluated_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.evaluated_list.Location = new System.Drawing.Point(36, 75);
            this.evaluated_list.Name = "evaluated_list";
            this.evaluated_list.Size = new System.Drawing.Size(751, 229);
            this.evaluated_list.TabIndex = 0;
            this.evaluated_list.UseCompatibleStateImageBehavior = false;
            this.evaluated_list.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "S.No";
            this.columnHeader1.Width = 61;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Roll Number";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 129;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Report Writing";
            this.columnHeader4.Width = 113;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Technical Content";
            this.columnHeader5.Width = 145;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Presentation ";
            this.columnHeader6.Width = 102;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Total";
            // 
            // Evaulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImage = global::Faculty.Properties.Resources._2016_09_05;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1069, 417);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Evaulation";
            this.Text = "Evaluation Sheet";
            ((System.ComponentModel.ISupportInitialize)(this.werror)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void Evaulation_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

      /*  private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }*/

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider  werror;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox Remarks_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label total_textview;
        private System.Windows.Forms.Label class_textview;
        private System.Windows.Forms.Label name_textview;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Presentation_textbox;
        private System.Windows.Forms.TextBox Technical_textbox;
        private System.Windows.Forms.TextBox Report_textbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListView evaluated_list;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Roll_comboBox;
        private System.Windows.Forms.Button button4;
    }
}