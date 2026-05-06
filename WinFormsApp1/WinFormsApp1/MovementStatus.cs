namespace WinFormsApp1.MovementStrategy;

/// <summary>
/// Статус достижения цели
/// </summary>
public enum MovementStatus
{
	NotInit = 0,      // Не инициализировано
	InProgress = 1,   // В процессе
	Finish = 2        // Завершено
}