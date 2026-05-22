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
        buttonShowDeleted = new Button();
        buttonRefresh = new Button();
        buttonAddLiner = new Button();
        buttonTransferToForm = new Button();
        maskedTextBoxPosition = new MaskedTextBox();
        buttonAddShip = new Button();
        buttonRemoveShip = new Button();
        groupBoxCompanyControls = new GroupBox();
        labelCollectionType = new Label();
        labelCompanyName = new Label();
        radioButtonLinkedList = new RadioButton();
        radioButtonList = new RadioButton();
        radioButtonMassive = new RadioButton();
        listBoxCompanies = new ListBox();
        buttonCompanyDel = new Button();
        buttonCompanyAdd = new Button();
        textBoxCompanyName = new TextBox();
        pictureBox = new PictureBox();
        groupBoxShipControls = new GroupBox();
        groupBoxTools.SuspendLayout();
        groupBoxCompanyControls.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
        groupBoxShipControls.SuspendLayout();
        SuspendLayout();

        // groupBoxTools
        groupBoxTools.Controls.Add(buttonShowDeleted);
        groupBoxTools.Controls.Add(buttonRefresh);
        groupBoxTools.Controls.Add(buttonAddLiner);
        groupBoxTools.Controls.Add(buttonTransferToForm);
        groupBoxTools.Controls.Add(maskedTextBoxPosition);
        groupBoxTools.Controls.Add(buttonAddShip);
        groupBoxTools.Controls.Add(buttonRemoveShip);
        groupBoxTools.Dock = DockStyle.Right;
        groupBoxTools.Location = new Point(700, 0);
        groupBoxTools.Name = "groupBoxTools";
        groupBoxTools.Size = new Size(200, 600);
        groupBoxTools.TabIndex = 0;
        groupBoxTools.TabStop = false;
        groupBoxTools.Text = "Управление коллекцией";

        // buttonShowDeleted
        buttonShowDeleted.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        buttonShowDeleted.Location = new Point(6, 540);
        buttonShowDeleted.Name = "buttonShowDeleted";
        buttonShowDeleted.Size = new Size(188, 35);
        buttonShowDeleted.TabIndex = 7;
        buttonShowDeleted.Text = "Показать удалённые";
        buttonShowDeleted.UseVisualStyleBackColor = true;
        buttonShowDeleted.Click += ButtonShowDeleted_Click;

        // buttonRefresh
        buttonRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        buttonRefresh.Location = new Point(6, 500);
        buttonRefresh.Name = "buttonRefresh";
        buttonRefresh.Size = new Size(188, 35);
        buttonRefresh.TabIndex = 6;
        buttonRefresh.Text = "Обновить";
        buttonRefresh.UseVisualStyleBackColor = true;
        buttonRefresh.Click += ButtonRefresh_Click;

        // buttonAddLiner
        buttonAddLiner.Location = new Point(6, 60);
        buttonAddLiner.Name = "buttonAddLiner";
        buttonAddLiner.Size = new Size(188, 40);
        buttonAddLiner.TabIndex = 2;
        buttonAddLiner.Text = "Добавить ЛАЙНЕР";
        buttonAddLiner.UseVisualStyleBackColor = true;
        buttonAddLiner.Click += ButtonAddLiner_Click;

        // buttonTransferToForm
        buttonTransferToForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        buttonTransferToForm.Location = new Point(6, 460);
        buttonTransferToForm.Name = "buttonTransferToForm";
        buttonTransferToForm.Size = new Size(188, 35);
        buttonTransferToForm.TabIndex = 5;
        buttonTransferToForm.Text = "Передать на форму";
        buttonTransferToForm.UseVisualStyleBackColor = true;
        buttonTransferToForm.Click += ButtonTransferToForm_Click;

        // maskedTextBoxPosition
        maskedTextBoxPosition.Location = new Point(6, 140);
        maskedTextBoxPosition.Mask = "00";
        maskedTextBoxPosition.Name = "maskedTextBoxPosition";
        maskedTextBoxPosition.Size = new Size(188, 23);
        maskedTextBoxPosition.TabIndex = 3;
        maskedTextBoxPosition.ValidatingType = typeof(int);

        // buttonAddShip
        buttonAddShip.Location = new Point(6, 20);
        buttonAddShip.Name = "buttonAddShip";
        buttonAddShip.Size = new Size(188, 40);
        buttonAddShip.TabIndex = 1;
        buttonAddShip.Text = "Добавить КОРАБЛЬ";
        buttonAddShip.UseVisualStyleBackColor = true;
        buttonAddShip.Click += ButtonAddShip_Click;

        // buttonRemoveShip
        buttonRemoveShip.Location = new Point(6, 170);
        buttonRemoveShip.Name = "buttonRemoveShip";
        buttonRemoveShip.Size = new Size(188, 40);
        buttonRemoveShip.TabIndex = 4;
        buttonRemoveShip.Text = "Удалить корабль";
        buttonRemoveShip.UseVisualStyleBackColor = true;
        buttonRemoveShip.Click += ButtonRemoveShip_Click;

        // groupBoxCompanyControls
        groupBoxCompanyControls.Controls.Add(labelCollectionType);
        groupBoxCompanyControls.Controls.Add(labelCompanyName);
        groupBoxCompanyControls.Controls.Add(radioButtonLinkedList);
        groupBoxCompanyControls.Controls.Add(radioButtonList);
        groupBoxCompanyControls.Controls.Add(radioButtonMassive);
        groupBoxCompanyControls.Controls.Add(listBoxCompanies);
        groupBoxCompanyControls.Controls.Add(buttonCompanyDel);
        groupBoxCompanyControls.Controls.Add(buttonCompanyAdd);
        groupBoxCompanyControls.Controls.Add(textBoxCompanyName);
        groupBoxCompanyControls.Dock = DockStyle.Left;
        groupBoxCompanyControls.Location = new Point(0, 0);
        groupBoxCompanyControls.Name = "groupBoxCompanyControls";
        groupBoxCompanyControls.Size = new Size(250, 600);
        groupBoxCompanyControls.TabIndex = 1;
        groupBoxCompanyControls.TabStop = false;
        groupBoxCompanyControls.Text = "Управление компаниями";

        // labelCollectionType
        labelCollectionType.AutoSize = true;
        labelCollectionType.Location = new Point(6, 100);
        labelCollectionType.Name = "labelCollectionType";
        labelCollectionType.Size = new Size(99, 15);
        labelCollectionType.TabIndex = 8;
        labelCollectionType.Text = "Тип коллекции:";

        // labelCompanyName
        labelCompanyName.AutoSize = true;
        labelCompanyName.Location = new Point(6, 27);
        labelCompanyName.Name = "labelCompanyName";
        labelCompanyName.Size = new Size(114, 15);
        labelCompanyName.TabIndex = 7;
        labelCompanyName.Text = "Название компании:";

        // radioButtonLinkedList
        radioButtonLinkedList.AutoSize = true;
        radioButtonLinkedList.Location = new Point(143, 75);
        radioButtonLinkedList.Name = "radioButtonLinkedList";
        radioButtonLinkedList.Size = new Size(101, 19);
        radioButtonLinkedList.TabIndex = 6;
        radioButtonLinkedList.Text = "Связный список";
        radioButtonLinkedList.UseVisualStyleBackColor = true;

        // radioButtonList
        radioButtonList.AutoSize = true;
        radioButtonList.Location = new Point(82, 75);
        radioButtonList.Name = "radioButtonList";
        radioButtonList.Size = new Size(55, 19);
        radioButtonList.TabIndex = 5;
        radioButtonList.Text = "Список";
        radioButtonList.UseVisualStyleBackColor = true;

        // radioButtonMassive
        radioButtonMassive.AutoSize = true;
        radioButtonMassive.Location = new Point(6, 75);
        radioButtonMassive.Name = "radioButtonMassive";
        radioButtonMassive.Size = new Size(70, 19);
        radioButtonMassive.TabIndex = 4;
        radioButtonMassive.Text = "Массив";
        radioButtonMassive.UseVisualStyleBackColor = true;

        // listBoxCompanies
        listBoxCompanies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        listBoxCompanies.Location = new Point(6, 210);
        listBoxCompanies.Name = "listBoxCompanies";
        listBoxCompanies.Size = new Size(238, 380);
        listBoxCompanies.TabIndex = 3;
        listBoxCompanies.SelectedIndexChanged += ListBoxCompanies_SelectedIndexChanged;

        // buttonCompanyDel
        buttonCompanyDel.Location = new Point(6, 166);
        buttonCompanyDel.Name = "buttonCompanyDel";
        buttonCompanyDel.Size = new Size(238, 30);
        buttonCompanyDel.TabIndex = 2;
        buttonCompanyDel.Text = "Удалить компанию";
        buttonCompanyDel.UseVisualStyleBackColor = true;
        buttonCompanyDel.Click += ButtonCompanyDel_Click;

        // buttonCompanyAdd
        buttonCompanyAdd.Location = new Point(6, 130);
        buttonCompanyAdd.Name = "buttonCompanyAdd";
        buttonCompanyAdd.Size = new Size(238, 30);
        buttonCompanyAdd.TabIndex = 1;
        buttonCompanyAdd.Text = "Добавить компанию";
        buttonCompanyAdd.UseVisualStyleBackColor = true;
        buttonCompanyAdd.Click += ButtonCompanyAdd_Click;

        // textBoxCompanyName
        textBoxCompanyName.Location = new Point(6, 45);
        textBoxCompanyName.Name = "textBoxCompanyName";
        textBoxCompanyName.Size = new Size(238, 23);
        textBoxCompanyName.TabIndex = 0;

        // pictureBox
        pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pictureBox.BackColor = Color.White;
        pictureBox.BorderStyle = BorderStyle.FixedSingle;
        pictureBox.Location = new Point(250, 0);
        pictureBox.Name = "pictureBox";
        pictureBox.Size = new Size(450, 600);
        pictureBox.TabIndex = 2;
        pictureBox.TabStop = false;

        // groupBoxShipControls
        groupBoxShipControls.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxShipControls.Location = new Point(250, 0);
        groupBoxShipControls.Name = "groupBoxShipControls";
        groupBoxShipControls.Size = new Size(450, 600);
        groupBoxShipControls.TabIndex = 3;
        groupBoxShipControls.TabStop = false;
        groupBoxShipControls.Text = "Отображение коллекции";

        // FormShipCollection
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(900, 600);
        Controls.Add(pictureBox);
        Controls.Add(groupBoxCompanyControls);
        Controls.Add(groupBoxTools);
        MinimumSize = new Size(916, 639);
        Name = "FormShipCollection";
        Text = "Пристань - Коллекция кораблей (Вариант 25)";
        groupBoxTools.ResumeLayout(false);
        groupBoxTools.PerformLayout();
        groupBoxCompanyControls.ResumeLayout(false);
        groupBoxCompanyControls.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
        groupBoxShipControls.ResumeLayout(false);
        ResumeLayout(false);
    }

    private GroupBox groupBoxTools;
    private Button buttonShowDeleted;
    private Button buttonRefresh;
    private Button buttonAddLiner;
    private Button buttonTransferToForm;
    private MaskedTextBox maskedTextBoxPosition;
    private Button buttonAddShip;
    private Button buttonRemoveShip;
    private GroupBox groupBoxCompanyControls;
    private Label labelCollectionType;
    private Label labelCompanyName;
    private RadioButton radioButtonLinkedList;
    private RadioButton radioButtonList;
    private RadioButton radioButtonMassive;
    private ListBox listBoxCompanies;
    private Button buttonCompanyDel;
    private Button buttonCompanyAdd;
    private TextBox textBoxCompanyName;
    private PictureBox pictureBox;
    private GroupBox groupBoxShipControls;
}