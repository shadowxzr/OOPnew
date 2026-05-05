namespace WinFormsApp1
{
    partial class FormShip
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pictureBoxShip = new PictureBox();
            buttonCreateShip = new Button();
            buttonLeft = new Button();
            buttonUp = new Button();
            buttonDown = new Button();
            buttonRight = new Button();
            buttonCheckBorders = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShip).BeginInit();
            SuspendLayout();

            // pictureBoxShip
            pictureBoxShip.Dock = DockStyle.Fill;
            pictureBoxShip.Location = new Point(0, 0);
            pictureBoxShip.Name = "pictureBoxShip";
            pictureBoxShip.Size = new Size(923, 597);
            pictureBoxShip.TabIndex = 0;
            pictureBoxShip.TabStop = false;

            // buttonCreateShip
            buttonCreateShip.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonCreateShip.Location = new Point(12, 562);
            buttonCreateShip.Name = "buttonCreateShip";
            buttonCreateShip.Size = new Size(75, 23);
            buttonCreateShip.TabIndex = 1;
            buttonCreateShip.Text = "Создать";
            buttonCreateShip.UseVisualStyleBackColor = true;
            buttonCreateShip.Click += ButtonCreateShip_Click;

            // buttonLeft
            buttonLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonLeft.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonLeft.Text = "←";
            buttonLeft.Location = new Point(787, 550);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(35, 35);
            buttonLeft.TabIndex = 2;
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += ButtonMove_Click;

            // buttonUp
            buttonUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonUp.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonUp.Text = "↑";
            buttonUp.Location = new Point(828, 509);
            buttonUp.Name = "buttonUp";
            buttonUp.Size = new Size(35, 35);
            buttonUp.TabIndex = 3;
            buttonUp.UseVisualStyleBackColor = true;
            buttonUp.Click += ButtonMove_Click;

            // buttonDown
            buttonDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDown.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonDown.Text = "↓";
            buttonDown.Location = new Point(828, 550);
            buttonDown.Name = "buttonDown";
            buttonDown.Size = new Size(35, 35);
            buttonDown.TabIndex = 4;
            buttonDown.UseVisualStyleBackColor = true;
            buttonDown.Click += ButtonMove_Click;

            // buttonRight
            buttonRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRight.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonRight.Text = "→";
            buttonRight.Location = new Point(869, 550);
            buttonRight.Name = "buttonRight";
            buttonRight.Size = new Size(35, 35);
            buttonRight.TabIndex = 5;
            buttonRight.UseVisualStyleBackColor = true;
            buttonRight.Click += ButtonMove_Click;

            // buttonCheckBorders
            buttonCheckBorders.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonCheckBorders.Location = new Point(12, 12);
            buttonCheckBorders.Name = "buttonCheckBorders";
            buttonCheckBorders.Size = new Size(129, 23);
            buttonCheckBorders.TabIndex = 6;
            buttonCheckBorders.Text = "Проверка границ";
            buttonCheckBorders.UseVisualStyleBackColor = true;
            buttonCheckBorders.Click += ButtonCheckBorders_Click;

            // FormShip
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 597);
            Controls.Add(buttonCheckBorders);
            Controls.Add(buttonRight);
            Controls.Add(buttonDown);
            Controls.Add(buttonUp);
            Controls.Add(buttonLeft);
            Controls.Add(buttonCreateShip);
            Controls.Add(pictureBoxShip);
            Name = "FormShip";
            Text = "Корабль - Лабораторная работа №5";
            ((System.ComponentModel.ISupportInitialize)pictureBoxShip).EndInit();
            ResumeLayout(false);
        }

        private PictureBox pictureBoxShip;
        private Button buttonCreateShip;
        private Button buttonLeft;
        private Button buttonUp;
        private Button buttonDown;
        private Button buttonRight;
        private Button buttonCheckBorders;

    }
}
