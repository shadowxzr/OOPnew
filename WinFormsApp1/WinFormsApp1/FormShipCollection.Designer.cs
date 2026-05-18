namespace WinFormsApp1;

partial class FormShipCollection
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
        groupBoxTools = new GroupBox();
        buttonRefresh = new Button();
        buttonAddLiner = new Button();
        buttonTransferToForm = new Button();
        maskedTextBoxPosition = new MaskedTextBox();
        buttonAddShip = new Button();
        buttonRemoveShip = new Button();
        pictureBox = new PictureBox();
        groupBoxTools.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
        SuspendLayout();

        // groupBoxTools
        groupBoxTools.Controls.Add(buttonRefresh);
        groupBoxTools.Controls.Add(buttonAddLiner);
        groupBoxTools.Controls.Add(buttonTransferToForm);
        groupBoxTools.Controls.Add(maskedTextBoxPosition);
        groupBoxTools.Controls.Add(buttonAddShip);
        groupBoxTools.Controls.Add(buttonRemoveShip);
        groupBoxTools.Dock = DockStyle.Right;
        groupBoxTools.Location = new Point(845, 0);
        groupBoxTools.Name = "groupBoxTools";
        groupBoxTools.Size = new Size(200, 616);
        groupBoxTools.TabIndex = 0;
        groupBoxTools.TabStop = false;
        groupBoxTools.Text = "Управление коллекцией";

        // buttonRefresh
        buttonRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        buttonRefresh.Location = new Point(6, 570);
        buttonRefresh.Name = "buttonRefresh";
        buttonRefresh.Size = new Size(188, 40);
        buttonRefresh.TabIndex = 6;
        buttonRefresh.Text = "Обновить";
        buttonRefresh.UseVisualStyleBackColor = true;
        buttonRefresh.Click += ButtonRefresh_Click;

        // buttonAddLiner
        buttonAddLiner.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        buttonAddLiner.Location = new Point(6, 68);
        buttonAddLiner.Name = "buttonAddLiner";
        buttonAddLiner.Size = new Size(188, 40);
        buttonAddLiner.TabIndex = 2;
        buttonAddLiner.Text = "Добавить ЛАЙНЕР";
        buttonAddLiner.UseVisualStyleBackColor = true;
        buttonAddLiner.Click += ButtonAddLiner_Click;

        // buttonTransferToForm
        buttonTransferToForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        buttonTransferToForm.Location = new Point(6, 524);
        buttonTransferToForm.Name = "buttonTransferToForm";
        buttonTransferToForm.Size = new Size(188, 40);
        buttonTransferToForm.TabIndex = 5;
        buttonTransferToForm.Text = "Передать на первую форму";
        buttonTransferToForm.UseVisualStyleBackColor = true;
        buttonTransferToForm.Click += ButtonTransferToForm_Click;

        // maskedTextBoxPosition
        maskedTextBoxPosition.Location = new Point(6, 150);
        maskedTextBoxPosition.Mask = "00";
        maskedTextBoxPosition.Name = "maskedTextBoxPosition";
        maskedTextBoxPosition.Size = new Size(188, 23);
        maskedTextBoxPosition.TabIndex = 3;
        maskedTextBoxPosition.ValidatingType = typeof(int);

        // buttonAddShip
        buttonAddShip.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        buttonAddShip.Location = new Point(6, 22);
        buttonAddShip.Name = "buttonAddShip";
        buttonAddShip.Size = new Size(188, 40);
        buttonAddShip.TabIndex = 1;
        buttonAddShip.Text = "Добавить КОРАБЛЬ";
        buttonAddShip.UseVisualStyleBackColor = true;
        buttonAddShip.Click += ButtonAddShip_Click;

        // buttonRemoveShip
        buttonRemoveShip.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        buttonRemoveShip.Location = new Point(6, 179);
        buttonRemoveShip.Name = "buttonRemoveShip";
        buttonRemoveShip.Size = new Size(188, 40);
        buttonRemoveShip.TabIndex = 4;
        buttonRemoveShip.Text = "Удалить корабль";
        buttonRemoveShip.UseVisualStyleBackColor = true;
        buttonRemoveShip.Click += ButtonRemoveShip_Click;

        // pictureBox
        pictureBox.Dock = DockStyle.Fill;
        pictureBox.Location = new Point(0, 0);
        pictureBox.Name = "pictureBox";
        pictureBox.Size = new Size(845, 616);
        pictureBox.TabIndex = 1;
        pictureBox.TabStop = false;

        // FormShipCollection
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1045, 616);
        Controls.Add(pictureBox);
        Controls.Add(groupBoxTools);
        Name = "FormShipCollection";
        Text = "Пристань - Коллекция кораблей (Вариант 25)";
        groupBoxTools.ResumeLayout(false);
        groupBoxTools.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
        ResumeLayout(false);
    }

    private GroupBox groupBoxTools;
    private Button buttonRefresh;
    private Button buttonAddLiner;
    private Button buttonTransferToForm;
    private MaskedTextBox maskedTextBoxPosition;
    private Button buttonAddShip;
    private Button buttonRemoveShip;
    private PictureBox pictureBox;
}