namespace Tester_lnuidnet
{
    partial class frmlnuidTester
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnGenerateId = new System.Windows.Forms.Button();
            this.btnPerformanceTest = new System.Windows.Forms.Button();
            this.btnMultiThreadTest = new System.Windows.Forms.Button();
            this.btnRunWithCheckDupes = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDecodeID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDecode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtResult.Location = new System.Drawing.Point(0, 196);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(792, 213);
            this.txtResult.TabIndex = 1;
            this.txtResult.TextChanged += new System.EventHandler(this.txtResult_TextChanged);
            // 
            // btnGenerateId
            // 
            this.btnGenerateId.Location = new System.Drawing.Point(6, 22);
            this.btnGenerateId.Name = "btnGenerateId";
            this.btnGenerateId.Size = new System.Drawing.Size(150, 23);
            this.btnGenerateId.TabIndex = 2;
            this.btnGenerateId.Text = "Generate LN UID";
            this.btnGenerateId.UseVisualStyleBackColor = true;
            this.btnGenerateId.Click += new System.EventHandler(this.btnGenerateId_Click);
            // 
            // btnPerformanceTest
            // 
            this.btnPerformanceTest.Location = new System.Drawing.Point(6, 51);
            this.btnPerformanceTest.Name = "btnPerformanceTest";
            this.btnPerformanceTest.Size = new System.Drawing.Size(150, 23);
            this.btnPerformanceTest.TabIndex = 3;
            this.btnPerformanceTest.Text = "Run Performance Test";
            this.btnPerformanceTest.UseVisualStyleBackColor = true;
            this.btnPerformanceTest.Click += new System.EventHandler(this.btnPerformanceTest_Click);
            // 
            // btnMultiThreadTest
            // 
            this.btnMultiThreadTest.Location = new System.Drawing.Point(6, 80);
            this.btnMultiThreadTest.Name = "btnMultiThreadTest";
            this.btnMultiThreadTest.Size = new System.Drawing.Size(150, 23);
            this.btnMultiThreadTest.TabIndex = 4;
            this.btnMultiThreadTest.Text = "Run Multi Thread Test";
            this.btnMultiThreadTest.UseVisualStyleBackColor = true;
            this.btnMultiThreadTest.Click += new System.EventHandler(this.btnMultiThreadTest_Click);
            // 
            // btnRunWithCheckDupes
            // 
            this.btnRunWithCheckDupes.Location = new System.Drawing.Point(6, 109);
            this.btnRunWithCheckDupes.Name = "btnRunWithCheckDupes";
            this.btnRunWithCheckDupes.Size = new System.Drawing.Size(150, 23);
            this.btnRunWithCheckDupes.TabIndex = 5;
            this.btnRunWithCheckDupes.Text = "Run with Check Dupes";
            this.btnRunWithCheckDupes.UseVisualStyleBackColor = true;
            this.btnRunWithCheckDupes.Click += new System.EventHandler(this.btnRunWithCheckDupes_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRunWithCheckDupes);
            this.groupBox1.Controls.Add(this.btnGenerateId);
            this.groupBox1.Controls.Add(this.btnMultiThreadTest);
            this.groupBox1.Controls.Add(this.btnPerformanceTest);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 150);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // txtDecodeID
            // 
            this.txtDecodeID.Location = new System.Drawing.Point(140, 32);
            this.txtDecodeID.Name = "txtDecodeID";
            this.txtDecodeID.Size = new System.Drawing.Size(222, 20);
            this.txtDecodeID.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnDecode);
            this.groupBox2.Controls.Add(this.txtDecodeID);
            this.groupBox2.Location = new System.Drawing.Point(303, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 88);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(368, 29);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(75, 23);
            this.btnDecode.TabIndex = 8;
            this.btnDecode.Text = "Decode";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Enter UID to Decode: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Result: ";
            // 
            // frmlnuidTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 409);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtResult);
            this.Name = "frmlnuidTester";
            this.Text = "Tester lnuid";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnGenerateId;
        private System.Windows.Forms.Button btnPerformanceTest;
        private System.Windows.Forms.Button btnMultiThreadTest;
        private System.Windows.Forms.Button btnRunWithCheckDupes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDecodeID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Label label2;
    }
}

