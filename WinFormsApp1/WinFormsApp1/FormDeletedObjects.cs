using WinFormsApp1.CollectionGenericObjects;
using WinFormsApp1.Drawings;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace WinFormsApp1;

/// <summary>
/// Форма для просмотра удалённых объектов (усложнённая часть, вариант 25)
/// </summary>
public partial class FormDeletedObjects : Form
{
    private readonly StorageCompanies _storageCompanies;
    private int _currentIndex = 0;

    public FormDeletedObjects(StorageCompanies storageCompanies)
    {
        InitializeComponent();
        _storageCompanies = storageCompanies;
        UpdateDisplay();
        UpdateButtonsState();
    }

    private void UpdateDisplay()
    {
        if (_storageCompanies.DeletedObjectsCount == 0)
        {
            labelInfo.Text = "Нет удалённых объектов";
            pictureBoxDeleted.Image = null;
            return;
        }

        object? deletedObj = _storageCompanies.GetDeletedObject(_currentIndex);
        if (deletedObj is DrawingShip ship)
        {
            labelInfo.Text = $"Объект {_currentIndex + 1} из {_storageCompanies.DeletedObjectsCount}\n" +
                           $"Тип: {ship.GetType().Name}\n" +
                           $"Ширина: {ship.DrawingShipWidth}, Высота: {ship.DrawingShipHeight}";

            // создаём временный Bitmap для отрисовки корабля
            Bitmap bmp = new Bitmap(400, 300);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                ship.SetPosition(50, 50);
                ship.DrawTransport(g);
            }
            pictureBoxDeleted.Image = bmp;
        }
    }

    private void UpdateButtonsState()
    {
        buttonPrev.Enabled = _currentIndex > 0;
        buttonNext.Enabled = _currentIndex < _storageCompanies.DeletedObjectsCount - 1;
    }

    private void ButtonPrev_Click(object sender, EventArgs e)
    {
        if (_currentIndex > 0)
        {
            _currentIndex--;
            UpdateDisplay();
            UpdateButtonsState();
        }
    }

    private void ButtonNext_Click(object sender, EventArgs e)
    {
        if (_currentIndex < _storageCompanies.DeletedObjectsCount - 1)
        {
            _currentIndex++;
            UpdateDisplay();
            UpdateButtonsState();
        }
    }

    private void ButtonTransferToForm_Click(object sender, EventArgs e)
    {
        object? deletedObj = _storageCompanies.GetDeletedObject(_currentIndex);
        if (deletedObj is DrawingShip ship)
        {
            FormShip formShip = new();
            formShip.SetDrawingShip(ship);
            formShip.ShowDialog();
        }
        else
        {
            MessageBox.Show("Не удалось передать объект", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}