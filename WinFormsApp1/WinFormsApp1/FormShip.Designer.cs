namespace WinFormsApp1;

partial class FormShip
{
	private System.ComponentModel.IContainer components = null;

	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
			components.Dispose();
		base.Dispose(disposing);
	}

    private void InitializeComponent()
    {
        pictureBoxShip = new PictureBox();
        buttonCreateShip = new Button();
        buttonCreateBattleship = new Button();
        buttonLeft = new Button();
        buttonUp = new Button();
        buttonDown = new Button();
        buttonRight = new Button();
        buttonCheckBorders = new Button();
        buttonMovementStep = new Button();
        comboBoxDestination = new ComboBox();
        ((System.ComponentModel.ISupportInitialize)pictureBoxShip).BeginInit();
        SuspendLayout();
        // 
        // pictureBoxShip
        // 
        pictureBoxShip.Dock = DockStyle.Fill;
        pictureBoxShip.Location = new Point(0, 0);
        pictureBoxShip.Name = "pictureBoxShip";
        pictureBoxShip.Size = new Size(923, 597);
        pictureBoxShip.TabIndex = 0;
        pictureBoxShip.TabStop = false;
        // 
        // buttonCreateShip
        // 
        buttonCreateShip.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonCreateShip.Location = new Point(12, 562);
        buttonCreateShip.Name = "buttonCreateShip";
        buttonCreateShip.Size = new Size(100, 30);
        buttonCreateShip.TabIndex = 1;
        buttonCreateShip.Text = "Создать корабль";
        buttonCreateShip.UseVisualStyleBackColor = true;
        buttonCreateShip.Click += ButtonCreateShip_Click;
        // 
        // buttonCreateBattleship
        // 
        buttonCreateBattleship.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonCreateBattleship.Location = new Point(118, 562);
        buttonCreateBattleship.Name = "buttonCreateBattleship";
        buttonCreateBattleship.Size = new Size(120, 30);
        buttonCreateBattleship.TabIndex = 2;
        buttonCreateBattleship.Text = "Создать Лайнер";
        buttonCreateBattleship.UseVisualStyleBackColor = true;
        buttonCreateBattleship.Click += ButtonCreateBattleship_Click;
        // 
        // buttonLeft
        // 
        buttonLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonLeft.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        buttonLeft.Location = new Point(787, 550);
        buttonLeft.Name = "buttonLeft";
        buttonLeft.Size = new Size(35, 35);
        buttonLeft.TabIndex = 3;
        buttonLeft.Text = "←";
        buttonLeft.UseVisualStyleBackColor = true;
        buttonLeft.Click += ButtonMove_Click;
        // 
        // buttonUp
        // 
        buttonUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonUp.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        buttonUp.Location = new Point(828, 509);
        buttonUp.Name = "buttonUp";
        buttonUp.Size = new Size(35, 35);
        buttonUp.TabIndex = 4;
        buttonUp.Text = "↑";
        buttonUp.UseVisualStyleBackColor = true;
        buttonUp.Click += ButtonMove_Click;
        // 
        // buttonDown
        // 
        buttonDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonDown.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        buttonDown.Location = new Point(828, 550);
        buttonDown.Name = "buttonDown";
        buttonDown.Size = new Size(35, 35);
        buttonDown.TabIndex = 5;
        buttonDown.Text = "↓";
        buttonDown.UseVisualStyleBackColor = true;
        buttonDown.Click += ButtonMove_Click;
        // 
        // buttonRight
        // 
        buttonRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonRight.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        buttonRight.Location = new Point(869, 550);
        buttonRight.Name = "buttonRight";
        buttonRight.Size = new Size(35, 35);
        buttonRight.TabIndex = 6;
        buttonRight.Text = "→";
        buttonRight.UseVisualStyleBackColor = true;
        buttonRight.Click += ButtonMove_Click;
        // 
        // buttonCheckBorders
        // 
        buttonCheckBorders.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonCheckBorders.Location = new Point(242, 562);
        buttonCheckBorders.Name = "buttonCheckBorders";
        buttonCheckBorders.Size = new Size(120, 30);
        buttonCheckBorders.TabIndex = 7;
        buttonCheckBorders.Text = "Проверка границ";
        buttonCheckBorders.UseVisualStyleBackColor = true;
        buttonCheckBorders.Click += ButtonCheckBorders_Click;
        // 
        // buttonMovementStep
        // 
        buttonMovementStep.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonMovementStep.Location = new Point(366, 562);
        buttonMovementStep.Name = "buttonMovementStep";
        buttonMovementStep.Size = new Size(100, 30);
        buttonMovementStep.TabIndex = 8;
        buttonMovementStep.Text = "Шаг";
        buttonMovementStep.UseVisualStyleBackColor = true;
        buttonMovementStep.Click += ButtonMovementStep_Click;
        // 
        // comboBoxDestination
        // 
        comboBoxDestination.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        comboBoxDestination.Location = new Point(473, 565);
        comboBoxDestination.Name = "comboBoxDestination";
        comboBoxDestination.Size = new Size(180, 23);
        comboBoxDestination.TabIndex = 9;
        comboBoxDestination.SelectedIndexChanged += ComboBoxDestination_SelectedIndexChanged;
        // 
        // FormShip
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(923, 597);
        Controls.Add(comboBoxDestination);
        Controls.Add(buttonMovementStep);
        Controls.Add(buttonCheckBorders);
        Controls.Add(buttonRight);
        Controls.Add(buttonDown);
        Controls.Add(buttonUp);
        Controls.Add(buttonLeft);
        Controls.Add(buttonCreateBattleship);
        Controls.Add(buttonCreateShip);
        Controls.Add(pictureBoxShip);
        Name = "FormShip";
        Text = "Лабораторная работа №2";
        ((System.ComponentModel.ISupportInitialize)pictureBoxShip).EndInit();
        ResumeLayout(false);
    }

    private PictureBox pictureBoxShip;
	private Button buttonCreateShip;
	private Button buttonCreateBattleship;
	private Button buttonLeft;
	private Button buttonUp;
	private Button buttonDown;
	private Button buttonRight;
	private Button buttonCheckBorders;
	private Button buttonMovementStep;
	private ComboBox comboBoxDestination;
}