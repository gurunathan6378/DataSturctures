﻿namespace WindowsFormsApplication3
{
    partial class ObjectOrientatedQuestions
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
            this.btn_Record_Max_population_for_an_year = new System.Windows.Forms.Button();
            this.btn_Calculate_Tax_Bracket = new System.Windows.Forms.Button();
            this.btn_Garden_with_flower_type = new System.Windows.Forms.Button();
            this.btn_Find_Min_Conference_room_for_the_given_meeting_times = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Record_Max_population_for_an_year
            // 
            this.btn_Record_Max_population_for_an_year.Location = new System.Drawing.Point(12, 12);
            this.btn_Record_Max_population_for_an_year.Name = "btn_Record_Max_population_for_an_year";
            this.btn_Record_Max_population_for_an_year.Size = new System.Drawing.Size(556, 41);
            this.btn_Record_Max_population_for_an_year.TabIndex = 0;
            this.btn_Record_Max_population_for_an_year.Text = "Record Max population for  an year ";
            this.btn_Record_Max_population_for_an_year.UseVisualStyleBackColor = true;
            this.btn_Record_Max_population_for_an_year.Click += new System.EventHandler(this.btn_Record_Max_population_for_an_year_Click);
            // 
            // btn_Calculate_Tax_Bracket
            // 
            this.btn_Calculate_Tax_Bracket.Location = new System.Drawing.Point(12, 59);
            this.btn_Calculate_Tax_Bracket.Name = "btn_Calculate_Tax_Bracket";
            this.btn_Calculate_Tax_Bracket.Size = new System.Drawing.Size(556, 40);
            this.btn_Calculate_Tax_Bracket.TabIndex = 1;
            this.btn_Calculate_Tax_Bracket.Text = "Calculate Tax Bracket";
            this.btn_Calculate_Tax_Bracket.UseVisualStyleBackColor = true;
            this.btn_Calculate_Tax_Bracket.Click += new System.EventHandler(this.btn_Calculate_Tax_Bracket_Click);
            // 
            // btn_Garden_with_flower_type
            // 
            this.btn_Garden_with_flower_type.Location = new System.Drawing.Point(12, 105);
            this.btn_Garden_with_flower_type.Name = "btn_Garden_with_flower_type";
            this.btn_Garden_with_flower_type.Size = new System.Drawing.Size(556, 39);
            this.btn_Garden_with_flower_type.TabIndex = 36;
            this.btn_Garden_with_flower_type.Text = "Garden with Flower Type";
            this.btn_Garden_with_flower_type.UseVisualStyleBackColor = true;
            this.btn_Garden_with_flower_type.Click += new System.EventHandler(this.btn_Garden_with_flower_type_Click);
            // 
            // btn_Find_Min_Conference_room_for_the_given_meeting_times
            // 
            this.btn_Find_Min_Conference_room_for_the_given_meeting_times.Location = new System.Drawing.Point(12, 150);
            this.btn_Find_Min_Conference_room_for_the_given_meeting_times.Name = "btn_Find_Min_Conference_room_for_the_given_meeting_times";
            this.btn_Find_Min_Conference_room_for_the_given_meeting_times.Size = new System.Drawing.Size(556, 38);
            this.btn_Find_Min_Conference_room_for_the_given_meeting_times.TabIndex = 37;
            this.btn_Find_Min_Conference_room_for_the_given_meeting_times.Text = "Find Min Conference room for the given meeting times";
            this.btn_Find_Min_Conference_room_for_the_given_meeting_times.UseVisualStyleBackColor = true;
            this.btn_Find_Min_Conference_room_for_the_given_meeting_times.Click += new System.EventHandler(this.btn_Find_Min_Conference_room_for_the_given_meeting_times_Click);
            // 
            // ObjectOrientatedQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Find_Min_Conference_room_for_the_given_meeting_times);
            this.Controls.Add(this.btn_Garden_with_flower_type);
            this.Controls.Add(this.btn_Calculate_Tax_Bracket);
            this.Controls.Add(this.btn_Record_Max_population_for_an_year);
            this.Name = "ObjectOrientatedQuestions";
            this.Text = "ObjectOrientatedQuestions";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Record_Max_population_for_an_year;
        private System.Windows.Forms.Button btn_Calculate_Tax_Bracket;
        private System.Windows.Forms.Button btn_Garden_with_flower_type;
        private System.Windows.Forms.Button btn_Find_Min_Conference_room_for_the_given_meeting_times;
    }
}