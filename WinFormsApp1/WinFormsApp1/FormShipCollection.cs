using WinFormsApp1.CollectionGenericObjects;
using WinFormsApp1.Drawings;

namespace WinFormsApp1;

/// <summary>
/// Форма для работы с коллекцией кораблей
/// </summary>
public partial class FormShipCollection : Form
{
    /// <summary>
    /// Компания (Пристань)
    /// </summary>
    private readonly AbstractCompany _company;

    /// <summary>
    /// Конструктор
    /// </summary>
    public FormShipCollection()
    {
        InitializeComponent();
        _company = new Pier(pictureBox.Width, pictureBox.Height, new MassiveGenericObjects<DrawingShip>());
    }

    /// <summary>
    /// Добавление обычного корабля
    /// </summary>
    private void ButtonAddShip_Click(object sender, EventArgs e) => CreateAndAddObjectToCollection(nameof(DrawingShip));

    /// <summary>
    /// Добавление лайнера
    /// </summary>
    private void ButtonAddLiner_Click(object sender, EventArgs e) => CreateAndAddObjectToCollection(nameof(DrawingLiner));

    /// <summary>
    /// Создание объекта и добавление его в коллекцию
    /// </summary>
    private void CreateAndAddObjectToCollection(string type)
    {
        Random random = new();
        DrawingShip ship;

        switch (type)
        {
            case nameof(DrawingShip):
                int speed = random.Next(100, 300);
                double weight = random.Next(1000, 5000);
                Color bodyColor = GetColor(random);
                int deckCount = random.Next(1, 4);
                ship = new DrawingShip(speed, weight, bodyColor, deckCount);
                break;

            case nameof(DrawingLiner):
                speed = random.Next(150, 250);      // скорость 150-250
                weight = random.Next(3000, 6000);   // вес 3000-6000 (шаг 2.5-8.3)
                bodyColor = GetColor(random);
                Color additionalColor = GetColor(random);
                deckCount = random.Next(2, 5);
                ship = new DrawingLiner(speed, weight, bodyColor, deckCount, additionalColor);
                break;

            default:
                return;
        }

        if (_company + ship)
        {
            MessageBox.Show("Объект добавлен в коллекцию", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pictureBox.Image = _company.Show();
        }
        else
        {
            MessageBox.Show("Не удалось добавить объект. Возможно, коллекция заполнена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Получение цвета через диалоговое окно
    /// </summary>
    private static Color GetColor(Random random)
    {
        ColorDialog dialog = new();
        return dialog.ShowDialog() == DialogResult.OK
            ? dialog.Color
            : Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
    }

    /// <summary>
    /// Удаление объекта из коллекции
    /// </summary>
    private void ButtonRemoveShip_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(maskedTextBoxPosition.Text))
        {
            MessageBox.Show("Введите позицию для удаления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (MessageBox.Show("Удалить объект?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            return;

        int pos = Convert.ToInt32(maskedTextBoxPosition.Text);
        if (_company - pos)
        {
            MessageBox.Show("Объект удален", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pictureBox.Image = _company.Show();
        }
        else
        {
            MessageBox.Show("Не удалось удалить объект. Проверьте позицию.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Передача случайного объекта в первую форму
    /// </summary>
    private void ButtonTransferToForm_Click(object sender, EventArgs e)
    {
        if (_company.GetRandomObject() is not DrawingShip ship)
        {
            MessageBox.Show("Не удалось получить объект из коллекции. Возможно, коллекция пуста.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        FormShip formShip = new();
        formShip.SetDrawingShip(ship);
        formShip.ShowDialog();
    }

    /// <summary>
    /// Обновление отображения коллекции
    /// </summary>
    private void ButtonRefresh_Click(object sender, EventArgs e) => pictureBox.Image = _company.Show();
}