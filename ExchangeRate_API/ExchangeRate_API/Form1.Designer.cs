namespace ExchangeRate_API
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
            comboBoxFrom = new ComboBox();
            comboBoxTo = new ComboBox();
            textBoxAmount = new TextBox();
            buttonConvert = new Button();
            labelResult = new Label();
            SuspendLayout();
            // 
            // comboBoxFrom
            // 
            comboBoxFrom.FormattingEnabled = true;
            comboBoxFrom.Location = new Point(344, 165);
            comboBoxFrom.Name = "comboBoxFrom";
            comboBoxFrom.Size = new Size(121, 23);
            comboBoxFrom.TabIndex = 0;
            // 
            // comboBoxTo
            // 
            comboBoxTo.FormattingEnabled = true;
            comboBoxTo.Location = new Point(503, 165);
            comboBoxTo.Name = "comboBoxTo";
            comboBoxTo.Size = new Size(121, 23);
            comboBoxTo.TabIndex = 1;
            // 
            // textBoxAmount
            // 
            textBoxAmount.Location = new Point(535, 246);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(100, 23);
            textBoxAmount.TabIndex = 2;
            // 
            // buttonConvert
            // 
            buttonConvert.Location = new Point(344, 246);
            buttonConvert.Name = "buttonConvert";
            buttonConvert.Size = new Size(75, 23);
            buttonConvert.TabIndex = 3;
            buttonConvert.Text = "button1";
            buttonConvert.UseVisualStyleBackColor = true;
            buttonConvert.Click += buttonConvert_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(684, 173);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(38, 15);
            labelResult.TabIndex = 4;
            labelResult.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelResult);
            Controls.Add(buttonConvert);
            Controls.Add(textBoxAmount);
            Controls.Add(comboBoxTo);
            Controls.Add(comboBoxFrom);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxFrom;
        private ComboBox comboBoxTo;
        private TextBox textBoxAmount;
        private Button buttonConvert;
        private Label labelResult;
    }
}
