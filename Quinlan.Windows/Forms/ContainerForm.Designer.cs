namespace Quinlan.Windows.Forms
{
    partial class ContainerForm
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
            this.listBoxAvailableCards = new System.Windows.Forms.ListBox();
            this.buttonAddCard = new System.Windows.Forms.Button();
            this.listBoxContainerCards = new System.Windows.Forms.ListBox();
            this.labelAvailableCards = new System.Windows.Forms.Label();
            this.labelContainerCards = new System.Windows.Forms.Label();
            this.labelSport = new System.Windows.Forms.Label();
            this.radioButtonBaseball = new System.Windows.Forms.RadioButton();
            this.radioButtonFootball = new System.Windows.Forms.RadioButton();
            this.radioButtonBasketball = new System.Windows.Forms.RadioButton();
            this.radioButtonHockey = new System.Windows.Forms.RadioButton();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.groupBoxFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxAvailableCards
            // 
            this.listBoxAvailableCards.FormattingEnabled = true;
            this.listBoxAvailableCards.ItemHeight = 15;
            this.listBoxAvailableCards.Location = new System.Drawing.Point(422, 96);
            this.listBoxAvailableCards.Name = "listBoxAvailableCards";
            this.listBoxAvailableCards.Size = new System.Drawing.Size(570, 604);
            this.listBoxAvailableCards.TabIndex = 0;
            // 
            // buttonAddCard
            // 
            this.buttonAddCard.Location = new System.Drawing.Point(1041, 174);
            this.buttonAddCard.Name = "buttonAddCard";
            this.buttonAddCard.Size = new System.Drawing.Size(75, 63);
            this.buttonAddCard.TabIndex = 2;
            this.buttonAddCard.Text = "Add to Container";
            this.buttonAddCard.UseVisualStyleBackColor = true;
            this.buttonAddCard.Click += new System.EventHandler(this.buttonAddCard_Click);
            // 
            // listBoxContainerCards
            // 
            this.listBoxContainerCards.FormattingEnabled = true;
            this.listBoxContainerCards.ItemHeight = 15;
            this.listBoxContainerCards.Location = new System.Drawing.Point(1164, 96);
            this.listBoxContainerCards.Name = "listBoxContainerCards";
            this.listBoxContainerCards.Size = new System.Drawing.Size(570, 604);
            this.listBoxContainerCards.TabIndex = 3;
            // 
            // labelAvailableCards
            // 
            this.labelAvailableCards.AutoSize = true;
            this.labelAvailableCards.Location = new System.Drawing.Point(422, 60);
            this.labelAvailableCards.Name = "labelAvailableCards";
            this.labelAvailableCards.Size = new System.Drawing.Size(121, 15);
            this.labelAvailableCards.TabIndex = 4;
            this.labelAvailableCards.Text = "Cards not Inventoried";
            // 
            // labelContainerCards
            // 
            this.labelContainerCards.AutoSize = true;
            this.labelContainerCards.Location = new System.Drawing.Point(1164, 68);
            this.labelContainerCards.Name = "labelContainerCards";
            this.labelContainerCards.Size = new System.Drawing.Size(105, 15);
            this.labelContainerCards.TabIndex = 5;
            this.labelContainerCards.Text = "Cards in Container";
            // 
            // labelSport
            // 
            this.labelSport.AutoSize = true;
            this.labelSport.Location = new System.Drawing.Point(21, 51);
            this.labelSport.Name = "labelSport";
            this.labelSport.Size = new System.Drawing.Size(35, 15);
            this.labelSport.TabIndex = 6;
            this.labelSport.Text = "Sport";
            // 
            // radioButtonBaseball
            // 
            this.radioButtonBaseball.AutoSize = true;
            this.radioButtonBaseball.Location = new System.Drawing.Point(84, 51);
            this.radioButtonBaseball.Name = "radioButtonBaseball";
            this.radioButtonBaseball.Size = new System.Drawing.Size(68, 19);
            this.radioButtonBaseball.TabIndex = 7;
            this.radioButtonBaseball.TabStop = true;
            this.radioButtonBaseball.Text = "Baseball";
            this.radioButtonBaseball.UseVisualStyleBackColor = true;
            // 
            // radioButtonFootball
            // 
            this.radioButtonFootball.AutoSize = true;
            this.radioButtonFootball.Location = new System.Drawing.Point(84, 77);
            this.radioButtonFootball.Name = "radioButtonFootball";
            this.radioButtonFootball.Size = new System.Drawing.Size(68, 19);
            this.radioButtonFootball.TabIndex = 8;
            this.radioButtonFootball.TabStop = true;
            this.radioButtonFootball.Text = "Football";
            this.radioButtonFootball.UseVisualStyleBackColor = true;
            // 
            // radioButtonBasketball
            // 
            this.radioButtonBasketball.AutoSize = true;
            this.radioButtonBasketball.Location = new System.Drawing.Point(84, 103);
            this.radioButtonBasketball.Name = "radioButtonBasketball";
            this.radioButtonBasketball.Size = new System.Drawing.Size(78, 19);
            this.radioButtonBasketball.TabIndex = 9;
            this.radioButtonBasketball.TabStop = true;
            this.radioButtonBasketball.Text = "Basketball";
            this.radioButtonBasketball.UseVisualStyleBackColor = true;
            // 
            // radioButtonHockey
            // 
            this.radioButtonHockey.AutoSize = true;
            this.radioButtonHockey.Location = new System.Drawing.Point(84, 129);
            this.radioButtonHockey.Name = "radioButtonHockey";
            this.radioButtonHockey.Size = new System.Drawing.Size(65, 19);
            this.radioButtonHockey.TabIndex = 10;
            this.radioButtonHockey.TabStop = true;
            this.radioButtonHockey.Text = "Hockey";
            this.radioButtonHockey.UseVisualStyleBackColor = true;
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(86, 515);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(141, 50);
            this.buttonFilter.TabIndex = 14;
            this.buttonFilter.Text = "Filter Available List";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Controls.Add(this.buttonFilter);
            this.groupBoxFilters.Controls.Add(this.labelSport);
            this.groupBoxFilters.Controls.Add(this.radioButtonBaseball);
            this.groupBoxFilters.Controls.Add(this.radioButtonHockey);
            this.groupBoxFilters.Controls.Add(this.radioButtonFootball);
            this.groupBoxFilters.Controls.Add(this.radioButtonBasketball);
            this.groupBoxFilters.Location = new System.Drawing.Point(12, 96);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new System.Drawing.Size(307, 604);
            this.groupBoxFilters.TabIndex = 15;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Filtering Options";
            // 
            // ContainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1784, 817);
            this.Controls.Add(this.groupBoxFilters);
            this.Controls.Add(this.labelContainerCards);
            this.Controls.Add(this.labelAvailableCards);
            this.Controls.Add(this.listBoxContainerCards);
            this.Controls.Add(this.buttonAddCard);
            this.Controls.Add(this.listBoxAvailableCards);
            this.Name = "ContainerForm";
            this.Text = "ContainerForm";
            this.groupBoxFilters.ResumeLayout(false);
            this.groupBoxFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAvailableCards;
        private System.Windows.Forms.Button buttonAddCard;
        private System.Windows.Forms.ListBox listBoxContainerCards;
        private System.Windows.Forms.Label labelAvailableCards;
        private System.Windows.Forms.Label labelContainerCards;
        private System.Windows.Forms.Label labelSport;
        private System.Windows.Forms.RadioButton radioButtonBaseball;
        private System.Windows.Forms.RadioButton radioButtonFootball;
        private System.Windows.Forms.RadioButton radioButtonBasketball;
        private System.Windows.Forms.RadioButton radioButtonHockey;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.GroupBox groupBoxFilters;
    }
}