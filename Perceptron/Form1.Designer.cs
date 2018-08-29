namespace Perceptron
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUcz = new System.Windows.Forms.Button();
            this.btnDalej = new System.Windows.Forms.Button();
            this.btnRysuj = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "x1      x2         w1     w2       bies     e       d          y";
            // 
            // btnUcz
            // 
            this.btnUcz.Location = new System.Drawing.Point(13, 218);
            this.btnUcz.Name = "btnUcz";
            this.btnUcz.Size = new System.Drawing.Size(83, 31);
            this.btnUcz.TabIndex = 1;
            this.btnUcz.Text = "Ucz";
            this.btnUcz.UseVisualStyleBackColor = true;
            this.btnUcz.Click += new System.EventHandler(this.btnUcz_Click);
            // 
            // btnDalej
            // 
            this.btnDalej.Location = new System.Drawing.Point(102, 218);
            this.btnDalej.Name = "btnDalej";
            this.btnDalej.Size = new System.Drawing.Size(105, 31);
            this.btnDalej.TabIndex = 2;
            this.btnDalej.Text = "Dalej";
            this.btnDalej.UseVisualStyleBackColor = true;
            this.btnDalej.Click += new System.EventHandler(this.btnDalej_Click);
            // 
            // btnRysuj
            // 
            this.btnRysuj.Location = new System.Drawing.Point(213, 218);
            this.btnRysuj.Name = "btnRysuj";
            this.btnRysuj.Size = new System.Drawing.Size(83, 31);
            this.btnRysuj.TabIndex = 3;
            this.btnRysuj.Text = "Rysuj";
            this.btnRysuj.UseVisualStyleBackColor = true;
            this.btnRysuj.Click += new System.EventHandler(this.btnRysuj_Click_1);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 255);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Legend = "Legend1";
            series3.Name = "d";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series4.Legend = "Legend1";
            series4.Name = "y";
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(284, 105);
            this.chart1.TabIndex = 100;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 402);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnRysuj);
            this.Controls.Add(this.btnDalej);
            this.Controls.Add(this.btnUcz);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUcz;
        private System.Windows.Forms.Button btnDalej;
        private System.Windows.Forms.Button btnRysuj;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

