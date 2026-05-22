using WinFormsApp1.CollectionGenericObjects;
using WinFormsApp1.Drawings;

namespace WinFormsApp1;

/// <summary>
/// Форма для работы с коллекцией кораблей (лабораторная работа №4)
/// Вариант 25: Лайнер/Корабль, Пристань, LinkedList для удалённых объектов
/// </summary>
public partial class FormShipCollection : Form
{
    /// <summary>
    /// Текущая выбранная компания
    /// </summary>
    private AbstractCompany? _currentCompany;

    /// <summary>
    /// Хранилище компаний
    /// </summary>
    private readonly StorageCompanies _storageCompanies;

    public FormShipCollection()
    {
        InitializeComponent();
        _storageCompanies = new StorageCompanies();
        RefreshListBoxItems();
        groupBoxShipControls.Enabled = false;
    }

    /// <summary>
    /// Обновление списка компаний в ListBox (ЗАМЕНА for НА foreach)
    /// </summary>
    private void RefreshListBoxItems()
    {
        listBoxCompanies.Items.Clear();

        // по требованию задания: замена for на foreach
        foreach (string companyName in _storageCompanies.StorageKeys)
        {
            listBoxCompanies.Items.Add(companyName);
        }
    }

    /// <summary>
    /// Добавление компании в хранилище
    /// </summary>
    private void ButtonCompanyAdd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(textBoxCompanyName.Text))
        {
            MessageBox.Show("Введите название компании", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!radioButtonMassive.Checked && !radioButtonList.Checked && !radioButtonLinkedList.Checked)
        {
            MessageBox.Show("Выберите тип коллекции", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        CollectionType collectionType = CollectionType.None;
        if (radioButtonMassive.Checked)
            collectionType = CollectionType.Massive;
        else if (radioButtonList.Checked)
            collectionType = CollectionType.List;
        else if (radioButtonLinkedList.Checked)
            collectionType = CollectionType.LinkedList;

        _storageCompanies.AddCompany(textBoxCompanyName.Text, collectionType,
            pictureBox.Width, pictureBox.Height);

        RefreshListBoxItems();
        textBoxCompanyName.Clear();

        // сброс выбора radioButton
        radioButtonMassive.Checked = false;
        radioButtonList.Checked = false;
        radioButtonLinkedList.Checked = false;
    }

    /// <summary>
    /// Удаление компании из хранилища
    /// </summary>
    private void ButtonCompanyDel_Click(object sender, EventArgs e)
    {
        if (listBoxCompanies.SelectedIndex < 0)
        {
            MessageBox.Show("Выберите компанию для удаления", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        string companyName = listBoxCompanies.SelectedItem.ToString() ?? string.Empty;

        if (MessageBox.Show($"Удалить компанию \"{companyName}\"?", "Подтверждение",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            _storageCompanies.DelCompany(companyName);
            RefreshListBoxItems();

            if (_currentCompany != null && _storageCompanies[companyName] == null)
            {
                _currentCompany = null;
                pictureBox.Image = null;
                groupBoxShipControls.Enabled = false;
            }
        }
    }

    /// <summary>
    /// Выбор компании из списка
    /// </summary>
    private void ListBoxCompanies_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBoxCompanies.SelectedIndex < 0)
            return;

        string companyName = listBoxCompanies.SelectedItem.ToString() ?? string.Empty;
        _currentCompany = _storageCompanies[companyName];

        if (_currentCompany != null)
        {
            pictureBox.Image = _currentCompany.Show();
            groupBoxShipControls.Enabled = true;
            Text = $"Пристань - Текущая компания: {companyName}";
        }
        else
        {
            groupBoxShipControls.Enabled = false;
            Text = "Пристань - Коллекция кораблей (Вариант 25)";
        }
    }

    /// <summary>
    /// Добавление обычного корабля
    /// </summary>
    private void ButtonAddShip_Click(object sender, EventArgs e)
    {
        if (_currentCompany is null)
        {
            MessageBox.Show("Сначала выберите компанию", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        CreateAndAddObjectToCollection(nameof(DrawingShip));
    }

    /// <summary>
    /// Добавление лайнера
    /// </summary>
    private void ButtonAddLiner_Click(object sender, EventArgs e)
    {
        if (_currentCompany is null)
        {
            MessageBox.Show("Сначала выберите компанию", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        CreateAndAddObjectToCollection(nameof(DrawingLiner));
    }

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
                speed = random.Next(150, 250);
                weight = random.Next(3000, 6000);
                bodyColor = GetColor(random);
                Color additionalColor = GetColor(random);
                deckCount = random.Next(2, 5);
                ship = new DrawingLiner(speed, weight, bodyColor, deckCount, additionalColor);
                break;

            default:
                return;
        }

        // используем перегруженный оператор +
        if (_currentCompany + ship)
        {
            MessageBox.Show("Объект добавлен в коллекцию", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            pictureBox.Image = _currentCompany.Show();
        }
        else
        {
            MessageBox.Show("Не удалось добавить объект. Возможно, коллекция заполнена.", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    /// Удаление объекта из коллекции (с добавлением в LinkedList удалённых)
    /// </summary>
    private void ButtonRemoveShip_Click(object sender, EventArgs e)
    {
        if (_currentCompany is null)
        {
            MessageBox.Show("Сначала выберите компанию", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrEmpty(maskedTextBoxPosition.Text))
        {
            MessageBox.Show("Введите позицию для удаления", "Предупреждение",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int pos = Convert.ToInt32(maskedTextBoxPosition.Text);

        // получаем удаляемый объект перед удалением (через индексатор с 2 параметрами)
        string? companyName = listBoxCompanies.SelectedItem?.ToString();
        object? deletedObj = null;

        if (companyName != null)
        {
            deletedObj = _storageCompanies[companyName, pos];
        }

        if (deletedObj is not DrawingShip deletedShip)
        {
            MessageBox.Show("Объект не найден по указанной позиции", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (MessageBox.Show($"Удалить объект (корабль/лайнер) с позиции {pos}?", "Подтверждение удаления",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            return;

        // используем перегруженный оператор -
        if (_currentCompany - pos)
        {
            // добавляем удалённый объект в коллекцию LinkedList
            _storageCompanies.AddDeletedObject(deletedShip);

            MessageBox.Show("Объект удален и добавлен в коллекцию удалённых объектов", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            pictureBox.Image = _currentCompany.Show();
            maskedTextBoxPosition.Clear();
        }
        else
        {
            MessageBox.Show("Не удалось удалить объект. Проверьте позицию.", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Передача случайного объекта в первую форму
    /// </summary>
    private void ButtonTransferToForm_Click(object sender, EventArgs e)
    {
        if (_currentCompany is null)
        {
            MessageBox.Show("Сначала выберите компанию", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (_currentCompany.GetRandomObject() is not DrawingShip ship)
        {
            MessageBox.Show("Не удалось получить объект из коллекции. Возможно, коллекция пуста.", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        FormShip formShip = new();
        formShip.SetDrawingShip(ship);
        formShip.ShowDialog();
    }

    /// <summary>
    /// Обновление отображения коллекции
    /// </summary>
    private void ButtonRefresh_Click(object sender, EventArgs e)
    {
        if (_currentCompany != null)
            pictureBox.Image = _currentCompany.Show();
    }

    /// <summary>
    /// Показать форму с удалёнными объектами (усложнённая часть)
    /// </summary>
    private void ButtonShowDeleted_Click(object sender, EventArgs e)
    {
        if (_storageCompanies.DeletedObjectsCount == 0)
        {
            MessageBox.Show("Нет удалённых объектов", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        FormDeletedObjects formDeleted = new FormDeletedObjects(_storageCompanies);
        formDeleted.ShowDialog();
    }
}