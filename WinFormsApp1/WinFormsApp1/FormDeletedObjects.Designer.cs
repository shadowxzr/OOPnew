namespace WinFormsApp1;

partial class FormDeletedObjects
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
        pictureBoxDeleted = new PictureBox();
        labelInfo = new Label();
        buttonPrev = new Button();
        buttonNext = new Button();
        buttonTransferToForm = new Button();
        buttonClose = new Button();
        ((System.ComponentModel.ISupportInitialize)pictureBoxDeleted).BeginInit();
        SuspendLayout();

        // pictureBoxDeleted
        pictureBoxDeleted.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pictureBoxDeleted.BackColor = Color.White;
        pictureBoxDeleted.BorderStyle = BorderStyle.FixedSingle;
        pictureBoxDeleted.Location = new Point(12, 60);
        pictureBoxDeleted.Name = "pictureBoxDeleted";
        pictureBoxDeleted.Size = new Size(460, 350);
        pictureBoxDeleted.TabIndex = 0;
        pictureBoxDeleted.TabStop = false;

        // labelInfo
        labelInfo.AutoSize = true;
        labelInfo.Location = new Point(12, 20);
        labelInfo.Name = "labelInfo";
        labelInfo.Size = new Size(100, 15);
        labelInfo.TabIndex = 1;
        labelInfo.Text = "Информация об объекте";

        // buttonPrev
        buttonPrev.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonPrev.Location = new Point(12, 430);
        buttonPrev.Name = "buttonPrev";
        buttonPrev.Size = new Size(80, 30);
        buttonPrev.TabIndex = 2;
        buttonPrev.Text = "<< Назад";
        buttonPrev.UseVisualStyleBackColor = true;
        buttonPrev.Click += ButtonPrev_Click;

        // buttonNext
        buttonNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonNext.Location = new Point(98, 430);
        buttonNext.Name = "buttonNext";
        buttonNext.Size = new Size(80, 30);
        buttonNext.TabIndex = 3;
        buttonNext.Text = "Вперёд >>";
        buttonNext.UseVisualStyleBackColor = true;
        buttonNext.Click += ButtonNext_Click;

        // buttonTransferToForm
        buttonTransferToForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonTransferToForm.Location = new Point(184, 430);
        buttonTransferToForm.Name = "buttonTransferToForm";
        buttonTransferToForm.Size = new Size(150, 30);
        buttonTransferToForm.TabIndex = 4;
        buttonTransferToForm.Text = "Передать на форму";
        buttonTransferToForm.UseVisualStyleBackColor = true;
        buttonTransferToForm.Click += ButtonTransferToForm_Click;

        // buttonClose
        buttonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonClose.Location = new Point(397, 430);
        buttonClose.Name = "buttonClose";
        buttonClose.Size = new Size(75, 30);
        buttonClose.TabIndex = 5;
        buttonClose.Text = "Закрыть";
        buttonClose.UseVisualStyleBackColor = true;
        buttonClose.Click += ButtonClose_Click;

        // FormDeletedObjects
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(484, 481);
        Controls.Add(buttonClose);
        Controls.Add(buttonTransferToForm);
        Controls.Add(buttonNext);
        Controls.Add(buttonPrev);
        Controls.Add(labelInfo);
        Controls.Add(pictureBoxDeleted);
        MinimumSize = new Size(500, 520);
        Name = "FormDeletedObjects";
        Text = "Удалённые объекты (Лайнеры/Корабли) - Вариант 25";
        ((System.ComponentModel.ISupportInitialize)pictureBoxDeleted).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private PictureBox pictureBoxDeleted;
    private Label labelInfo;
    private Button buttonPrev;
    private Button buttonNext;
    private Button buttonTransferToForm;
    private Button buttonClose;
}